using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public abstract class FolderWithSets : StaticFolder
    {
        public FolderWithSets(string rowFilter, string name, StaticFolder parent) : base(name, parent)
        {
            Connection con = ((Connection) Root);

            foreach (TestQuestionSetSet.QuestionSetsRow row in con.QuestionSets.Select(rowFilter))
                new QuestionSet(row, this);
        }

        internal override bool DoCanAddMovingChild(Entity entity)
        {
            return DoCanAddNewChild(entity);
        }

        public override object EntityId
        {
            get { return Root.Name + GetType().Name; }
        }
    }
}