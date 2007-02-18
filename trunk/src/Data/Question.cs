
using GmatClubTest.Common;

namespace GmatClubTest.Data
{
    public abstract class Question
    {
        //private static BuisinessObjects.Subtype _subtype;

        public static BuisinessObjects.Subtype Subtype;
        public static BuisinessObjects.Type Type;
        public static BuisinessObjects.DifficultyLevel DifficultyLevel;
       
        public  class Status
        {
            public static BuisinessObjects.StatusType StatusType;

            public Status()
            {
                status = BuisinessObjects.StatusType.SEEN;
            }

            public  Status(BuisinessObjects.StatusType status)
            {
                this.status = status;
            }

            public BuisinessObjects.StatusType status;
            public int answeredId = -1;
            public double score = 0;
        }
    }
}