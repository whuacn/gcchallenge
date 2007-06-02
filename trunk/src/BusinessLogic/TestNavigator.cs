using System;
using System.Data;
using GmatClubTest.Data;

namespace GmatClubTest.BusinessLogic
{
    /// <summary>
    /// Controls execution of an adaptive test.
    /// </summary>
    internal class TestNavigator : NavigatorSkeleton
    {
        private static double[,] QUESTION_COST = {{1, 1.5, 2}, {0.5, 1, 1.5}, {0.25, 0.5, 1}};
        private static int[] CONSECUTIVE_LEN_TO_ADAPT = {1, 2, 3};

        //[set, zone]
        private QuestionAnswerSet[,] questionsAnswers;
        private int[] questionsInZones = new int[3];
        private int activeQuestionIndex = -1;
        private int activeZoneIndex = 0;
        private int activeDifficultyLevel = 1;
        private int activeQuestionInZone = -1;
        private bool lastIsCorrect;
        private int consecutiveTrue = 0;
        private int consecutiveFalse = 0;
        private QuestionAnswerSet activeQuestion = new QuestionAnswerSet();
        private Random random = new Random();

        public TestNavigator(TestSet.TestsRow test, Manager manager) : base(test, manager)
        {
            questionsAnswers = new QuestionAnswerSet[sets.QuestionSets.Count,3];

            int i = 0, timeMin = 0;
            foreach (QuestionSetSet.QuestionSetsRow set in sets.QuestionSets)
            {
                for (byte zoneIndex = 0; zoneIndex <= 2; ++zoneIndex)
                {
                    QuestionAnswerSet qa = new QuestionAnswerSet();
                    manager.DataProvider.GetQuestionsAnswersByQuestionSetIdAndZone(set.Id, (byte) (zoneIndex + 1), qa);
                    questionsAnswers[i, zoneIndex] = qa;
                }
                ++i;
                totalQuestions += set.NumberOfQuestionsInZone1 + set.NumberOfQuestionsInZone2 +
                                  set.NumberOfQuestionsInZone3;
                questionsInZones[0] = set.NumberOfQuestionsInZone1;
                questionsInZones[1] = set.NumberOfQuestionsInZone2;
                questionsInZones[2] = set.NumberOfQuestionsInZone3;
                if (timeMin >= 0)
                {
                    if (set.IsTimeLimitNull())
                        timeMin = -1;
                    else
                        timeMin += set.TimeLimit;
                }
            }

            base.NextSet += new SimpleMethod(TestNavigator_NextSet);

            if (timeMin >= 0)
                totalTime = new TimeSpan(0, timeMin, 0);
            else
                totalTime = TimeSpan.MaxValue;
        }

        protected override void DoGetNextQuestion(QuestionAnswerSet questionAnswers)
        {
            ++activeQuestionInZone;
            if (activeQuestionInZone >= questionsInZones[activeZoneIndex])
            {
                if (activeZoneIndex >= 2)
                    throw new Exception("No next question");

                ++activeZoneIndex;
                activeQuestionInZone = 0;
                activeDifficultyLevel = 1;
                consecutiveTrue = 0;
                consecutiveFalse = 0;
            }

            if (activeQuestionInZone != 0)
            {
                if (lastIsCorrect)
                {
                    consecutiveFalse = 0;
                    ++consecutiveTrue;
                    if (consecutiveTrue >= CONSECUTIVE_LEN_TO_ADAPT[activeZoneIndex] && activeDifficultyLevel < 3)
                    {
                        ++activeDifficultyLevel;
                        consecutiveTrue = 0;
                    }
                }
                else
                {
                    consecutiveTrue = 0;
                    ++consecutiveFalse;
                    if (consecutiveFalse >= CONSECUTIVE_LEN_TO_ADAPT[activeZoneIndex] && activeDifficultyLevel > 1)
                    {
                        --activeDifficultyLevel;
                        consecutiveFalse = 0;
                    }
                }
            }

            GetRandomQuestion(questionAnswers);
            ++activeQuestionIndex;
        }

        private void GetRandomQuestion(QuestionAnswerSet questionAnswers)
        {
            QuestionAnswerSet.QuestionsDataTable qt = questionsAnswers[activeSetIndex, activeZoneIndex].Questions;
            QuestionAnswerSet.QuestionsRow[] rows =
                (QuestionAnswerSet.QuestionsRow[]) qt.Select("DifficultyLevelId = " + activeDifficultyLevel.ToString());
            if (rows.Length == 0)
                throw new Exception(
                    String.Format(
                        "The content of the test is incorrent. There is not enough questions of difficulty {0} in zone {1} of question set {2}",
                        activeDifficultyLevel, activeZoneIndex + 1, activeSetIndex + 1));

            questionAnswers.Clear();
            activeQuestion.Clear();

            QuestionAnswerSet.QuestionsRow q = rows[random.Next(rows.Length)];
            DataRow[] dr = new DataRow[] {q};
            QuestionAnswerSet.AnswersRow[] ar = q.GetAnswersRows();
            activeQuestion.Merge(dr);
            activeQuestion.Merge(ar);
            questionAnswers.Merge(dr);
            questionAnswers.Merge(ar);

            qt.RemoveQuestionsRow(q);
        }

        public override bool HasNextQuestion
        {
            get { return activeQuestionIndex < totalQuestions - 1; }
        }

        public override Explanations.ExplanationsDataTable GetExplanations()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override double CalculateScoreOfActiveQuestion(bool isCorrect)
        {
            lastIsCorrect = isCorrect;

            if (!isCorrect) return 0;

            return QUESTION_COST[activeZoneIndex, activeQuestion.Questions[0].DifficultyLevelId - 1];
        }

        public override void DoGetActiveQuestion(QuestionAnswerSet questionAnswerSet)
        {
            questionAnswerSet.Clear();
            questionAnswerSet.Merge(new DataRow[] {activeQuestion.Questions[0]});
            questionAnswerSet.Merge(activeQuestion.Questions[0].GetAnswersRows());
        }

        protected override QuestionAnswerSet.QuestionsRow ActiveQuestion
        {
            get { return activeQuestion.Questions[0]; }
        }

        protected override int ActiveQuestionIndex
        {
            get { return activeQuestionIndex; }
        }

        public override bool IsActiveQuestionValid
        {
            get { return activeQuestionIndex != -1; }
        }

        private void TestNavigator_NextSet()
        {
            activeQuestionIndex = -1;
            activeZoneIndex = 0;
            activeDifficultyLevel = 1;
            activeQuestionInZone = -1;
            consecutiveTrue = 0;
            consecutiveFalse = 0;
        }

        #region Not supported operations

        public override bool HasPreviousQuestion
        {
            get { return false; }
        }

        public override bool HasRandomSetAccess
        {
            get { return false; }
        }

        public override bool HasPreviousSet
        {
            get { return false; }
        }

        public override bool HasRandomQuestionAccess
        {
            get { return false; }
        }

        public override void DoSetActiveQuestion(int questionId)
        {
            throw new InvalidOperationException("SetActiveQuestion is not supported");
        }

        protected override void DoGetPreviousQuestion(QuestionAnswerSet questionAnswerSet)
        {
            throw new InvalidOperationException("DoGetPreviousQuestion is not supported");
        }

        public override QuestionAnswerSet[] QuestionsAnswers
        {
            get { throw new InvalidOperationException("Get QuestionsAnswers is not supported"); }
        }

        #endregion

        public override string GetExplanation()
        {
            throw new ApplicationException("Explanation are not bound resources in test.");
        }
    }
}