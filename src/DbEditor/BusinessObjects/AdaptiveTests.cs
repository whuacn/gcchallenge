using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public class AdaptiveTests : StaticFolder
    {
        public AdaptiveTests(Tests parent) : base("Computer-Adaptive Tests", parent)
        {
            new QuantitativeAdaptiveTests(this);
            new VerbalAdaptiveTests(this);
            new MixedAdaptiveTests(this);
        }

        internal override bool DoCanAddNewChild(Entity entity)
        {
            return entity is QuantitativeAdaptiveTests || entity is VerbalAdaptiveTests || entity is MixedAdaptiveTests;
        }

        internal override bool DoCanAddMovingChild(Entity entity)
        {
            return false;
        }

        public override object EntityId
        {
            get { return Root.Name + GetType().Name; }
        }
    }
}