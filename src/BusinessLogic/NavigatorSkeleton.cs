using System;
using System.Collections;
using GmatClubTest.Data;

namespace GmatClubTest.BusinessLogic
{
	internal abstract class NavigatorSkeleton: INavigator
	{
		protected delegate void SimpleMethod();
        protected event SimpleMethod NextSet;
		protected Manager manager;
		protected TestSet.TestsRow test;
		protected QuestionSetSet sets = new QuestionSetSet();
		protected int activeSetIndex = -1;
		protected ResultResultDetailSet result = new ResultResultDetailSet();
		protected ResultResultDetailSet.ResultsRow resultRow;
		protected int totalQuestions = 0;
		protected TimeSpan totalTime;
		protected DateTime activeSetStartTime = DateTime.MinValue;
		protected TimeSpan[] setRemainedTime;

		//questionId -> Question.Status
		protected Hashtable questionStatus = new Hashtable();

		//questionId
		protected Hashtable questionToPassageCash = new Hashtable();
		protected QuestionSet passageCache = new QuestionSet();

		public NavigatorSkeleton(TestSet.TestsRow test, Manager manager)
		{
			this.manager = manager;
            this.test = test;
			manager.DataProvider.GetQuestionSetsByTestId(test.Id, sets);
			setRemainedTime = new TimeSpan[sets.QuestionSets.Count];

			resultRow = result.Results.AddResultsRow(manager.UserId, test.Id, DateTime.Now, DateTime.MaxValue, 0);

			int i = 0;
			foreach (QuestionSetSet.QuestionSetsRow row in sets.QuestionSets)
			{
				setRemainedTime[i] = row.IsTimeLimitNull() ? TimeSpan.MaxValue : new TimeSpan(0, row.TimeLimit, 0);
				++i;
				result.ResultsDetailsOfSets.AddResultsDetailsOfSetsRow(resultRow, row.Id, 0, (byte)i);
			}
			
		}

		public QuestionSetSet Sets
		{
			get {return sets;}
		}

		public abstract bool HasRandomSetAccess { get; }

		public void SetActiveSet(int setId)
		{
			if (!HasRandomSetAccess) throw new InvalidOperationException("SetActiveSet is not supported");
			
			int i = 0, index = -1;
			foreach (QuestionSetSet.QuestionSetsRow set in sets.QuestionSets)
			{
				if (set.Id == setId) {index = i; break;}
				++i;
			}

			if (index == -1) throw new Exception(String.Format("No question set {0}", setId));

			AdjustSetRemainedTime();
			activeSetIndex = index;
			activeSetStartTime = DateTime.MinValue;
		}

		public bool IsActiveSetValid
		{
			get { return activeSetIndex >= 0 && activeSetIndex < sets.QuestionSets.Count;}
		}

		public bool HasNextSet
		{
			get { return activeSetIndex + 1 < sets.QuestionSets.Count; }
		}

		public abstract bool HasPreviousSet {get;}

		public int TotalNumberOfQuestions
		{
			get {return totalQuestions; }
		}

		public TimeSpan TotalTime
		{
			get {return totalTime;}
		}

		public QuestionSetSet.QuestionSetsRow GetNextSet()
		{
			if (!HasNextSet) throw new InvalidOperationException("No next set");
			AdjustSetRemainedTime();
			++activeSetIndex;
			activeSetStartTime = DateTime.MinValue;
			OnNextSet();
			return sets.QuestionSets[activeSetIndex];
		}

		private void OnNextSet()
		{
			if (NextSet != null) NextSet();
		}

		public abstract bool IsActiveQuestionValid { get; }
		public abstract bool HasRandomQuestionAccess { get; }

		public void SetActiveQuestion(int questionId)
		{
			if (!HasRandomQuestionAccess) throw new InvalidOperationException("SetActiveQuestion is not supported");
			CheckTime();
			DoSetActiveQuestion(questionId);
			if (!questionStatus.Contains(questionId))
				questionStatus[questionId] =  new Question.Status();
		}

		public void GetActiveQuestion(QuestionAnswerSet questionAnswerSet)
		{
			if (!IsActiveQuestionValid) throw new InvalidOperationException("Current question is invalid");
			CheckTime();
			DoGetActiveQuestion(questionAnswerSet);
		}

		public abstract void DoGetActiveQuestion(QuestionAnswerSet questionAnswerSet);

		public abstract void DoSetActiveQuestion(int questionId);

		public QuestionSetSet.QuestionSetsRow GetPreviousSet()
		{
			if (!HasPreviousSet) throw new InvalidOperationException("No previous set");
			AdjustSetRemainedTime();
			--activeSetIndex;
			activeSetStartTime = DateTime.MinValue;
			return sets.QuestionSets[activeSetIndex];
		}

		public abstract bool HasNextQuestion {get;}

		public abstract bool HasPreviousQuestion {get;}

		public void GetPreviousQuestion(QuestionAnswerSet questionAnswerSet)
		{
			if (!HasPreviousQuestion) throw new InvalidOperationException("No previous question");
			CheckTime();
			DoGetPreviousQuestion(questionAnswerSet);
			if (!questionStatus.Contains(questionAnswerSet.Questions[0].Id))
				questionStatus[questionAnswerSet.Questions[0].Id] =  new Question.Status();
		}

		public void GetNextQuestion(QuestionAnswerSet questionAnswerSet)
		{
			if (!HasNextQuestion) throw new InvalidOperationException("No next question");
			CheckTime();
			DoGetNextQuestion(questionAnswerSet);
			if (!questionStatus.Contains(questionAnswerSet.Questions[0].Id))
				questionStatus[questionAnswerSet.Questions[0].Id] =  new Question.Status();

		}

		protected abstract void DoGetPreviousQuestion(QuestionAnswerSet questionAnswerSet);
		protected abstract void DoGetNextQuestion(QuestionAnswerSet questionAnswerSet);

 		public void SetUserAnswer(int answerId)
		{
			CheckTime();
 			QuestionAnswerSet.QuestionsRow q = ActiveQuestion;
 			ResultResultDetailSet.ResultsDetailsRow row = result.ResultsDetails.FindByResultIdQuestionId(result.Results[0].Id, q.Id);

			bool isCorrect = false;
			foreach (QuestionAnswerSet.AnswersRow r in q.GetAnswersRows())
				if (r.Id == answerId)
				{
					isCorrect = r.IsCorrect;
					break;
				}

			double scoreForCorrect = CalculateScoreOfActiveQuestion(true);
			double score = CalculateScoreOfActiveQuestion(isCorrect);

			Data.ResultResultDetailSet.ResultsDetailsOfSetsRow setRow = result.ResultsDetailsOfSets.FindByResultIdQuestionSetId(resultRow.Id, sets.QuestionSets[activeSetIndex].Id);

			if (row != null)
			{
				row.AnswerId = answerId;
				if (isCorrect)
				{
					if (((Question.Status)questionStatus[q.Id]).status != Question.Status.StatusType.ANSWER_IS_CORRECT)
						setRow.Score += score;
				}
				else
				{
					if (((Question.Status)questionStatus[q.Id]).status == Question.Status.StatusType.ANSWER_IS_CORRECT)
					setRow.Score -= scoreForCorrect;
				}
			}
			else
			{
				row = result.ResultsDetails.AddResultsDetailsRow(resultRow, q.Id, answerId, (byte)(ActiveQuestionIndex + 1));
				setRow.Score += score;
			}

			((Question.Status)questionStatus[q.Id]).status = isCorrect ? Question.Status.StatusType.ANSWER_IS_CORRECT : Question.Status.StatusType.ANSWER_IS_INCORRECT;
			((Question.Status)questionStatus[q.Id]).answeredId = answerId;
			((Question.Status)questionStatus[q.Id]).score = score;
		}

		protected abstract double CalculateScoreOfActiveQuestion(bool isCorrect);

		public void CommitResult()
		{
			if (result.ResultsDetails.Count > 0)
			{
				double score = 0;
				foreach (Question.Status status in questionStatus.Values)
					score += status.score;

				result.Results[0].Score = score;
				result.Results[0].EndTime = DateTime.Now;

				manager.DataProvider.Update(result);
			}
		}

		private void AdjustSetRemainedTime()
		{
			if (activeSetIndex == -1) return;
			setRemainedTime[activeSetIndex] = setRemainedTime[activeSetIndex] - (DateTime.Now - activeSetStartTime);
			if (setRemainedTime[activeSetIndex].TotalMilliseconds < 0)
				setRemainedTime[activeSetIndex] = new TimeSpan(0);
		}

		public TimeSpan RemainedTime
		{
			get
			{
				if (activeSetStartTime == DateTime.MinValue)
					if (!sets.QuestionSets[activeSetIndex].IsTimeLimitNull())
						return new TimeSpan(0, sets.QuestionSets[activeSetIndex].TimeLimit, 0);
					else
						return TimeSpan.MaxValue;

				if (setRemainedTime[activeSetIndex].Ticks == 0 || setRemainedTime[activeSetIndex] == TimeSpan.MaxValue) return setRemainedTime[activeSetIndex];
				TimeSpan r = setRemainedTime[activeSetIndex] - (DateTime.Now - activeSetStartTime);
				if (r.Ticks <= 0)
				{
					setRemainedTime[activeSetIndex] = new TimeSpan(0);
					r = setRemainedTime[activeSetIndex];
				}

				return r;
			}
		}

		public Question.Status GetQuestionStatus(int questionId)
		{
			if (questionStatus.Contains(questionId))
				return (Question.Status)questionStatus[questionId];
			
			return new Question.Status(Question.Status.StatusType.NOT_SEEN);
		}

		public abstract QuestionAnswerSet[] QuestionsAnswers {get;}

		public QuestionSet.QuestionsRow GetPasssageToQuestion(int questionId)
		{
			if (questionToPassageCash.Contains(questionId))
				return passageCache.Questions[0];

			PassageToQuestionSet pq = new PassageToQuestionSet();

			manager.DataProvider.GetPassageToQuestions(questionId, pq);

			if (pq.PassageToQuestions.Count == 0)
				throw new Exception(String.Format("No passage for question {0} is defined", questionId));

			questionToPassageCash.Clear();
			foreach (PassageToQuestionSet.PassageToQuestionsRow row in pq.PassageToQuestions)
				questionToPassageCash[row.QuestionId] = null;

			passageCache.Clear();
			manager.DataProvider.GetQuestion(pq.PassageToQuestions[0].PassageQuestionId, passageCache);
			return passageCache.Questions[0];
		}

		public ResultResultDetailSet ResultResultDetailSet 
		{
			get {return result;}
		}

		private void CheckTime()
		{
			if (activeSetStartTime == DateTime.MinValue)
				activeSetStartTime = DateTime.Now;

			if (RemainedTime.Ticks == 0)
				throw new TimeIsUpException();
		}

		protected abstract QuestionAnswerSet.QuestionsRow ActiveQuestion {get;}
		protected abstract int ActiveQuestionIndex {get;}

        #region INavigator Members


     
        #endregion
    }
}