using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public class MixedPractices : FolderWithTests
    {
        public MixedPractices(Practices parent)
            : base("IsPractice=1 AND Isnull(QuestionTypeId, -1)=-1", "Mixed", parent)
        {
        }

        internal override bool DoCanAddNewChild(Entity entity)
        {
            Test t = entity as Test;
            return t != null && t.Value.IsPractice && t.Value.IsQuestionTypeIdNull();
        }
    }
}