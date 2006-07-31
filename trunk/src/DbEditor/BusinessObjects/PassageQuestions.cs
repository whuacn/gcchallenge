using System;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    class PassageQuestions : StaticFolder
    {
        public PassageQuestions(Entity parent): base("Question Sets", parent)
        {

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
            get { return Root.Name + this.GetType().Name; }
        }
    }
}
