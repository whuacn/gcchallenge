using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public class MixedSets : FolderWithSets
    {
        public MixedSets(QuestionSets parent) : base("Isnull(QuestionTypeId, -1)=-1", "Mixed", parent)
        {
        }

        internal override bool DoCanAddNewChild(Entity entity)
        {
            QuestionSet t = entity as QuestionSet;
            return t != null && t.Value.IsQuestionTypeIdNull();
        }
    }
}