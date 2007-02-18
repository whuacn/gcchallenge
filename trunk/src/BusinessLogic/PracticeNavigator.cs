using System;
using System.Collections.Generic;
using System.Data;
using GmatClubTest.Data;

namespace GmatClubTest.BusinessLogic
{
    /// <summary>
    /// Controls execution of a practice.
    /// </summary>
    internal class PracticeNavigator : NavigatorSkeleton
    {
        private QuestionAnswerSet[] questionsAnswers;
        private int[] activeQuestionIndexes;

        public PracticeNavigator(TestSet.TestsRow test, Manager manager) : base(test, manager)
        {
            questionsAnswers = new QuestionAnswerSet[sets.QuestionSets.Count];
            activeQuestionIndexes = new int[sets.QuestionSets.Count];

            int i = 0;
            int timeMin = 0;
            totalQuestions = 0;
            Random r = new Random();
            foreach (QuestionSetSet.QuestionSetsRow set in sets.QuestionSets)
            {
                totalQuestions += set.NumberOfQuestionsToPick;
                if (timeMin >= 0)
                {
                    if (set.IsTimeLimitNull())
                        timeMin = -1;
                    else
                        timeMin += set.TimeLimit;
                }

                activeQuestionIndexes[i] = -1;
                questionsAnswers[i] = new QuestionAnswerSet();
                manager.DataProvider.GetQuestionsAnswersByQuestionSetId(set.Id, questionsAnswers[i]);

                if (questionsAnswers[i].Questions.Count < set.NumberOfQuestionsToPick)
                    throw new Exception(
                        "Test is not valid: NumberOfQuestionsToPick is greater then total number of questions assigned to the test");

                //Take random questions from the set so we have only NumberOfQuestionsToPick questions.
                int count = questionsAnswers[i].Questions.Count;
                if (set.NumberOfQuestionsToPick - questionsAnswers[i].Questions.Count < set.NumberOfQuestionsToPick/2)
                {
                    while (count != set.NumberOfQuestionsToPick)
                    {
                        int j;
                        do
                        {
                            j = r.Next(questionsAnswers[i].Questions.Count);
                        } while (questionsAnswers[i].Questions[j].RowState == DataRowState.Deleted);
                        questionsAnswers[i].Questions[j].Delete();
                        --count;
                    }
                }
                else
                {
                    foreach (QuestionAnswerSet.QuestionsRow row in questionsAnswers[i].Questions)
                        row.Delete();

                    count = 0;
                    while (count != set.NumberOfQuestionsToPick)
                    {
                        int j;
                        do
                        {
                            j = r.Next(questionsAnswers[i].Questions.Count);
                        } while (questionsAnswers[i].Questions[j].RowState != DataRowState.Deleted);
                        questionsAnswers[i].Questions[j].RejectChanges();
                        ++count;
                    }
                }

                questionsAnswers[i].Questions.AcceptChanges();

                ++i;
            }

            if (timeMin >= 0)
                totalTime = new TimeSpan(0, timeMin, 0);
            else
                totalTime = TimeSpan.MaxValue;
        }

        public override bool HasNextQuestion
        {
            get
            {
                if (!IsActiveSetValid) throw new InvalidOperationException("Active question set is invalid");
                if (_reviwState == ReviewState.none)
                {
                    return activeQuestionIndexes[activeSetIndex] + 1 < questionsAnswers[activeSetIndex].Questions.Count;
                }
                //New functionality
                if(_reviwState == ReviewState.ReviewFlagged)
                {
                    Dictionary<QuestionIdentity, bool> questionInfo = GetQuestionInfoForReview();
                    bool findCurren = false;
                    foreach (KeyValuePair<QuestionIdentity, bool> keyValuePair in questionInfo)
                    {
                        if (!findCurren)
                        {
                            if (keyValuePair.Key.SetId == activeSetIndex &&
                                keyValuePair.Key.QuestionId == ActiveQuestion.Id)
                            {
                                findCurren = true;
                            }
                        }
                        else
                        {
                            if (keyValuePair.Key.SetId == activeSetIndex && keyValuePair.Value)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                return false;
            }
        }

        public override bool HasPreviousQuestion
        {
            get
            {
                if (!IsActiveSetValid) throw new InvalidOperationException("Active question set is invalid");
                if (_reviwState == ReviewState.none)
                {
                    return activeQuestionIndexes[activeSetIndex] > 0;
                }
                if (_reviwState == ReviewState.ReviewFlagged)
                {
                    Dictionary<QuestionIdentity, bool> questionInfo = GetQuestionInfoForReview();
                    QuestionIdentity prevQi = new QuestionIdentity(-1, -1);
                    foreach (KeyValuePair<QuestionIdentity, bool> keyValuePair in questionInfo)
                    {
                        if (keyValuePair.Key.SetId == activeSetIndex &&
                            keyValuePair.Key.QuestionId == ActiveQuestion.Id)
                        {
                            if (prevQi.QuestionId != -1)
                            {
                                return true;
                            }
                        }
                        prevQi = keyValuePair.Key;
                    }
                }
                return false;
            }
        }

        protected override void DoGetPreviousQuestion(QuestionAnswerSet questionAnswerSet)
        {
            if (_reviwState == ReviewState.none)
            {
                activeQuestionIndexes[activeSetIndex] = activeQuestionIndexes[activeSetIndex] - 1;
                GetActiveQuestion(questionAnswerSet);
            }
            if (_reviwState == ReviewState.ReviewFlagged)
            {
                Dictionary<QuestionIdentity, bool> questionInfo = GetQuestionInfoForReview();
                QuestionIdentity prevQi = new QuestionIdentity(-1, -1);
                foreach (KeyValuePair<QuestionIdentity, bool> keyValuePair in questionInfo)
                {
                    if (keyValuePair.Key.SetId == activeSetIndex &&
                        keyValuePair.Key.QuestionId == ActiveQuestion.Id)
                    {
                        SetActiveQuestion(prevQi.QuestionId);
                    }
                    prevQi = keyValuePair.Key;
                }
            }
        }

        protected override void DoGetNextQuestion(QuestionAnswerSet questionAnswerSet)
        {
            if (_reviwState == ReviewState.none)
            {
                activeQuestionIndexes[activeSetIndex] = activeQuestionIndexes[activeSetIndex] + 1;
                GetActiveQuestion(questionAnswerSet);
            }
            if(_reviwState == ReviewState.ReviewFlagged)
            {
                Dictionary<QuestionIdentity, bool> questionInfo = GetQuestionInfoForReview();
                bool findCurren = false;
                foreach (KeyValuePair<QuestionIdentity, bool> keyValuePair in questionInfo)
                {
                    if (!findCurren)
                    {
                        if (keyValuePair.Key.SetId == activeSetIndex &&
                            keyValuePair.Key.QuestionId == ActiveQuestion.Id)
                        {
                            findCurren = true;
                        }
                    }
                    else
                    {
                        if (keyValuePair.Key.SetId == activeSetIndex && keyValuePair.Value)
                        {
                            SetActiveQuestion(keyValuePair.Key.QuestionId);
                            break;
                        }
                    }
                }
            }
        }

        protected override double CalculateScoreOfActiveQuestion(bool isCorrect)
        {
            return isCorrect ? 1 : 0;
        }

        public override QuestionAnswerSet[] QuestionsAnswers
        {
            get { return questionsAnswers; }
        }

        protected override QuestionAnswerSet.QuestionsRow ActiveQuestion
        {
            get { return questionsAnswers[activeSetIndex].Questions[activeQuestionIndexes[activeSetIndex]]; }
        }

        protected override int ActiveQuestionIndex
        {
            get { return activeQuestionIndexes[activeSetIndex]; }
        }

        public override void DoGetActiveQuestion(QuestionAnswerSet questionAnswerSet)
        {
            questionAnswerSet.Clear();
            QuestionAnswerSet.QuestionsRow qr =
                questionsAnswers[activeSetIndex].Questions[activeQuestionIndexes[activeSetIndex]];
            questionAnswerSet.Merge(new DataRow[] {qr});
            questionAnswerSet.Merge(qr.GetAnswersRows());
        }

        public override bool HasRandomSetAccess
        {
            get { return true; }
        }

        public override bool HasPreviousSet
        {
            get { return activeSetIndex > 0; }
        }

        public override bool IsActiveQuestionValid
        {
            get
            {
                return IsActiveSetValid &&
                       activeQuestionIndexes[activeSetIndex] >= 0 &&
                       activeQuestionIndexes[activeSetIndex] < questionsAnswers[activeSetIndex].Questions.Count;
            }
        }

        public override bool HasRandomQuestionAccess
        {
            get { return true; }
        }

        public override void DoSetActiveQuestion(int questionId)
        {
            int i = 0, index = -1;
            foreach (QuestionAnswerSet.QuestionsRow q in questionsAnswers[activeSetIndex].Questions)
            {
                if (q.Id == questionId)
                {
                    index = i;
                    break;
                }
                ++i;
            }

            if (index == -1) throw new Exception(String.Format("No question {0}", questionId));

            activeQuestionIndexes[activeSetIndex] = index;
        }
    }
}