using System;
using GmatClubTest.Data;

namespace GmatClubTest.BusinessLogic
{
	/// <summary>
	/// Controls execution of practice/test. 
	/// </summary>
	public interface INavigator
	{
		int TotalNumberOfQuestions { get; }
		TimeSpan TotalTime { get; }

		QuestionSetSet Sets { get; }
		bool HasRandomSetAccess { get; }
		void SetActiveSet(int setId);
		bool IsActiveSetValid { get; }
		bool HasNextSet { get; }
		bool HasPreviousSet { get; }
		QuestionSetSet.QuestionSetsRow GetPreviousSet();
		QuestionSetSet.QuestionSetsRow GetNextSet();

		bool IsActiveQuestionValid {get;}
		bool HasRandomQuestionAccess {get;}
		void SetActiveQuestion(int questionId);
		void GetActiveQuestion(QuestionAnswerSet questionAnswerSet);
		bool HasNextQuestion { get; }
		bool HasPreviousQuestion { get; }
		void GetPreviousQuestion(QuestionAnswerSet questionAnswerSet);
		void GetNextQuestion(QuestionAnswerSet questionAnswerSet);
		void SetUserAnswer(int answerId);

		void CommitResult();

		/// <summary>
		/// Gets remeined time for current section. 
		/// Returns TimeSpan.MaxValue if time is unlimited.
		/// </summary>
		TimeSpan RemainedTime { get; }

		Question.Status GetQuestionStatus(int questionId);
		QuestionAnswerSet[] QuestionsAnswers {get;}

		QuestionSet.QuestionsRow GetPasssageToQuestion(int questionId);

		ResultResultDetailSet ResultResultDetailSet {get;}
	}
}
