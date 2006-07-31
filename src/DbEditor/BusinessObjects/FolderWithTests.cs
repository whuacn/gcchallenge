using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public abstract class FolderWithTests: StaticFolder
	{
		public FolderWithTests(string rowFilter, string name, StaticFolder parent): base(name, parent)
		{
			Connection con = ((Connection)Root);

			foreach (TestQuestionSetSet.TestsRow row in con.Tests.Select(rowFilter))
				new Test(row, this);
		}

		internal override bool DoCanAddMovingChild(Entity entity)
		{
			return DoCanAddNewChild(entity);
		}

		public override object EntityId
		{
			get { return Root.Name + this.GetType().Name; }
		}
	}
}
