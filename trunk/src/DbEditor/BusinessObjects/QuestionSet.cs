using System;
using System.Data;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class QuestionSet: DbObject
	{
		protected TestQuestionSetSet.QuestionSetsRow value;

		public QuestionSet(TestQuestionSetSet.QuestionSetsRow value, Entity parent): 
			base(value.Name, 
				new QuestionType(
					new OptionalInteger(value.IsQuestionTypeIdNull() ? null : (Object)value.QuestionTypeId),
					new OptionalInteger(value.IsQuestionSubtypeIdNull() ? null : (Object)value.QuestionSubtypeId)))
		{
			this.value = value;
			parent.AddNewChild(this);
			connection = ((Connection)Root);
		}

		private QuestionSet(TestQuestionSetSet.QuestionSetsRow value): 
			base(value.Name, 
				new QuestionType(
					new OptionalInteger(value.IsQuestionTypeIdNull() ? null : (Object)value.QuestionTypeId),
					new OptionalInteger(value.IsQuestionSubtypeIdNull() ? null : (Object)value.QuestionSubtypeId)))
		{
			this.value = value;
		}

		public TestQuestionSetSet.QuestionSetsRow Value
		{
			get { return value; }
		}

		protected override void DoLoadFullDataset()
		{
			connection.DataProvider.FillQuestionSet(FullDataset, value.Id);
		}
	
		public override void Save()
		{
		    Dataset.QuestionSetsExRow r = FullDatasetRow;
			connection.DataProvider.UpdateQuestionSet(r);
            connection.DataProvider.UpdateSetsToQuestions(FullDataset, value.Id);
			value.Table.DataSet.Merge(new DataRow[] {r});
			Name = value.Name;
			Entity.OnStructureChangedInternally();
		}

	  
	   public override bool HasChanges
		{
			get 
            {
                bool t = (FullDatasetRow.RowState != DataRowState.Unchanged);
                //for (int i = 0; i < FullDataset.QuestionsEx.Count; ++i)
                //{
                //    if (FullDataset.QuestionsEx[i].RowState != DataRowState.Unchanged)
                //    {
                //        t = true;
                //        break;
                //    }
                //}
                return t;
            }
		}

		public override object EntityId
		{
			get
			{
			    return (Parent is DbObject?((String)((DbObject)Parent).EntityId):"") + connection.Name + "QuetionSet#" + value.Id;
			}
		}

		protected virtual Dataset.QuestionSetsExRow FullDatasetRow
		{
          //  get { return FullDatasetRow; }
            get
            {
                int i;
                for (i = 0; i < FullDataset.QuestionSetsEx.Count; ++i)
                {
                    if (FullDataset.QuestionSetsEx[i].Id == value.Id)
                    {
                        break;    
                    }
                }
                return FullDataset.QuestionSetsEx[i];
            }
		}
	
		/*private static TestQuestionSetSet.QuestionSetsRow Convert(Dataset.QuestionSetsExRow value)
		{
			TestQuestionSetSet t = new TestQuestionSetSet();
			TestQuestionSetSet.QuestionSetsRow row = t.QuestionSets.AddQuestionSetsRow(value.Name, value.Description, value.NumberOfQuestionsToPick, 0, 0, 0, value.NumberOfQuestionsInZone1, value.NumberOfQuestionsInZone2, value.NumberOfQuestionsInZone3);
			
			if (value.IsTimeLimitNull())
				row.SetTimeLimitNull();
			else
				row.TimeLimit = value.TimeLimit;
			
			if (value.IsQuestionTypeIdNull()) 
				row.SetQuestionTypeIdNull();
			else
				row.QuestionTypeId = value.QuestionTypeId;

			if (value.IsQuestionSubtypeIdNull()) 
				row.SetQuestionSubtypeIdNull();
			else
				row.QuestionSubtypeId = value.QuestionSubtypeId;

			return row;
		}*/

		public static QuestionSet Create(QuestionType questionType, Connection connection)
		{
		    int setId = 0;
		    for(int i=0; i<connection.TestQuestionSetSet.QuestionSets.Count;++i)
		    {
		         if(setId<connection.TestQuestionSetSet.QuestionSets[i].Id)
		         {
		            setId = connection.TestQuestionSetSet.QuestionSets[i].Id;
		         }
		    }
            setId += 1;
            TestQuestionSetSet.QuestionSetsRow row = connection.TestQuestionSetSet.QuestionSets.AddQuestionSetsRow(setId, "New Question Set", "", 0, 0, 0, 0, 0, 0, 0);
            //setId,
			row.SetTimeLimitNull();
			
			if (!questionType.QuestionTypeId.HasValue) 
				row.SetQuestionTypeIdNull();
			else
				row.QuestionTypeId = questionType.QuestionTypeId.Value;

			if (!questionType.QuestionSubtypeId.HasValue) 
				row.SetQuestionSubtypeIdNull();
			else
				row.QuestionSubtypeId = questionType.QuestionSubtypeId.Value;

			QuestionSet qs = new QuestionSet(row);

			bool added = false;

			//locate where to add the question set
			foreach (Entity entity in connection.Children)
			{
				if (entity is QuestionSets)
				{
					foreach (Entity child in entity.Children)
					{
						if (child.CanAddNewChild(qs))
						{
							child.AddNewChild(qs);
							qs.connection = ((Connection)qs.Root);
							added = true;
							break;	
						}
					}
					break;
				}
			}

			if (!added) throw new Exception("Cannot find folder for new question set");

			Entity.OnStructureChangedInternally();

			return qs;
		}

	    

	    public void ShangeQuestoinOrder(Dataset data, int questioId, bool IsUp, int setId)
	    {
	        int cou;
            int chQuestionId = -1;
	        if(IsUp)
	        {
                cou = -1; 
	        }else
	        {
                cou = 1;
	        }

            if ((data.QuestionsEx.FindByIdSetId(questioId, setId).QuestionOrder != 0) || (!IsUp))
	         {
                 for (int i = 0; i < data.QuestionsEx.Count; i++)
                 {
                     if (data.QuestionsEx.FindByIdSetId(questioId, setId).SetId == data.QuestionsEx[i].SetId)
                     {
                         if (data.QuestionsEx.FindByIdSetId(questioId, setId).QuestionOrder + cou == data.QuestionsEx[i].QuestionOrder)
                         {
                             if (IsUp)
                             {
                                 data.QuestionsEx[i].QuestionOrder += 1;

                             }
                             else
                             {
                                 data.QuestionsEx[i].QuestionOrder -= 1;
                             }
                             chQuestionId = data.QuestionsEx[i].Id;
                             break;
                         }
                     }
                 }

                if(IsUp)
                {
                    data.QuestionsEx.FindByIdSetId(questioId, setId).QuestionOrder -= 1;
                }
                else
                {
                    data.QuestionsEx.FindByIdSetId(questioId, setId).QuestionOrder += 1;
                }

                FullDataset.QuestionSetsEx.FindById(FullDataset.QuestionsEx.FindByIdSetId(questioId, setId).SetId).Name += "";
               // connection.QuestionSets.FindById(setId).Name += "";
             }
	        
	    }

	    public void GetAllQuestionEx(Dataset.QuestionsExDataTable questionExTable)
	    {
            connection.DataProvider.GetAllQuestionsEx(questionExTable);
	    }
	}
}
