using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class Practices: StaticFolder
	{
		public Practices(Tests parent): base("Practices", parent)
		{
			new QuantitativePractices(this);
			new VerbalPractices(this);
			new MixedPractices(this);
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			return entity is QuantitativePractices || entity is VerbalPractices || entity is MixedPractices;
		}

		internal override bool DoCanAddMovingChild(Entity entity)
		{
			return false;
		}

		public override object EntityId
		{
			get { return Root.Name + this.GetType().Name;}
		}
	}
}
