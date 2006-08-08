using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public class VerbalAdaptiveTests : FolderWithTests
    {
        public VerbalAdaptiveTests(AdaptiveTests parent)
            : base("IsPractice=0 AND QuestionTypeId=" + (int) QuestionType.Type.Verbal, "Verbal", parent)
        {
        }

        internal override bool DoCanAddNewChild(Entity entity)
        {
            Test t = entity as Test;
            return
                t != null && !t.Value.IsPractice && !t.Value.IsQuestionTypeIdNull() &&
                t.Value.QuestionTypeId == (int) QuestionType.Type.Verbal;
        }
    }
}