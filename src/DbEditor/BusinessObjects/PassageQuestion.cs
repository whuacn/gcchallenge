using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    class PassageQuestion : DbObject
    {
        protected Dataset.QuestionsExRow value;
        //public Connection connection;
        public PassageQuestion(Dataset.QuestionsExRow value, Connection connection, Entity parent)
            :
            base(value.Text, new QuestionType(
					new OptionalInteger(value.IsTypeIdNull() ? null : (Object)value.TypeId),
					new OptionalInteger(value.IsSubtypeIdNull() ? null : (Object)value.SubtypeId)))
        {
            this.value = value;
            parent.AddNewChild(this);
            this.connection = connection;
        }
        
        protected override void DoLoadFullDataset()
        {
            connection.DataProvider.LoadQuestions(FullDataset, value.SetId);
        }

        public Dataset.QuestionsExRow Value
        {
            get { return value; }
        }
        
        public override void Save()
        {
           // connection.DataProvider.UpdateQuestions(FullDataset, value.SetId);
            connection.DataProvider.UpdatePassageQuestion(FullDataset, value);
            OnStructureChangedInternally();
        }

        public override bool HasChanges
        {
            get
            {
                if ((FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).RowState != DataRowState.Unchanged) || (value.RowState != DataRowState.Unchanged))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
