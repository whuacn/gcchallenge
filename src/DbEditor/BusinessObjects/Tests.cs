using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class Tests: StaticFolder
	{
		public Tests(Connection parent): base("Tests", parent)
		{
			new AdaptiveTests(this);
			new Practices(this);
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			return entity is AdaptiveTests || entity is Practices;
		}

		internal override bool DoCanAddMovingChild(Entity entity)
		{
			return false;
		}

		public override object EntityId
		{
			get { return Root.Name + this.GetType().Name; }
		}
	}
}
