using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    internal class Questions : StaticFolder
    {
        public Questions(Connection parent) : base("Question Sets", parent)
        {
            //new QuantitativeSets(this);
            //new VerbalSets(this);
            //new MixedSets(this);
        }

        internal override bool DoCanAddNewChild(Entity entity)
        {
            return entity is QuantitativeSets || entity is VerbalSets || entity is MixedSets;
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

//using GmatClubTest.DbEditor.Tree;

//namespace GmatClubTest.DbEditor.BusinessObjects
//{
//    public class QuestionSets: StaticFolder
//    {
//        public QuestionSets(Connection parent): base("Question Sets", parent)
//        {
//            new QuantitativeSets(this);
//            new VerbalSets(this);
//            new MixedSets(this);
//        }

//        internal override bool DoCanAddNewChild(Entity entity)
//        {
//            return entity is QuantitativeSets || entity is VerbalSets || entity is MixedSets;
//        }

//        internal override bool DoCanAddMovingChild(Entity entity)
//        {
//            return false;
//        }

//        public override object EntityId
//        {
//            get { return Root.Name + this.GetType().Name; }
//        }
//    }
//}