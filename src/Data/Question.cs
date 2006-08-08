namespace GmatClubTest.Data
{
    public abstract class Question
    {
        public enum Type
        {
            Quantitative = 1,
            Verbal = 2
        } ;

        public enum Subtype
        {
            DataSufficiency = 1,
            ProblemSolving = 2,
            ReadingComprehensionPassage = 3,
            ReadingComprehensionQuestionToPassage = 4,
            CriticalReasoning = 5,
            SentenceCorrection = 6
        } ;

        public enum DifficultyLevel
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        } ;

        public class Status
        {
            public enum StatusType
            {
                NOT_SEEN = 0,
                SEEN = 1,
                ANSWER_IS_CORRECT = 2,
                ANSWER_IS_INCORRECT = 3
            } ;

            public Status()
            {
                status = StatusType.SEEN;
            }

            public Status(StatusType status)
            {
                this.status = status;
            }

            public StatusType status;
            public int answeredId = -1;
            public double score = 0;
        }
    }
}