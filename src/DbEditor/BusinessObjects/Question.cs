using System;
using System.Data;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    class Question : DbObject
    {
        protected Dataset.QuestionsExRow value;
        //public Connection connection;
        public Question(Dataset.QuestionsExRow value, Connection connection, Entity parent)
            :
            base(value.Text, new QuestionType(
					new OptionalInteger(value.IsTypeIdNull() ? null : (Object)value.TypeId),
					new OptionalInteger(value.IsSubtypeIdNull() ? null : (Object)value.SubtypeId)))
        {
            this.value = value;
            parent.AddNewChild(this);
            this.connection = connection;
        }


        public override object EntityId
        {
            get
            {
                return (Parent is DbObject ? ((String)((DbObject)Parent).EntityId) : "") + connection.Name + "Quetion#" + value.Id;
            }
        }
        
       
        public Dataset.QuestionsExRow Value
        {
            get { return value; }
        }
        
        protected override void DoLoadFullDataset()
        {
            //connection.DataProvider. (FullDataset, value.Id);
            connection.DataProvider.LoadQuestions(FullDataset, value.SetId);
        }

        public override void Save()
        {
         // connection.DataProvider.UpdateQuestions(FullDataset,value.SetId);
            connection.DataProvider.UpdateQuestion(FullDataset, value);
            OnStructureChangedInternally();
        }

        public override bool HasChanges
        {
            get
            {
                if ((value.RowState == DataRowState.Modified) || (value.RowState == DataRowState.Added))
                {
                    return true;
                }else
                {
                    for (int i = 0; i < FullDataset.Answers.Count; ++i )
                    {
                        if ((FullDataset.Answers[i].RowState == DataRowState.Modified))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
