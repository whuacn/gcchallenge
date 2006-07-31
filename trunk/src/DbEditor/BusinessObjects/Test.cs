using System;
using System.Data;
using System.Windows.Forms;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class Test: DbObject
	{
		private TestQuestionSetSet.TestsRow value;
		private bool contentIsChanged = false;

		public Test(TestQuestionSetSet.TestsRow value, StaticFolder parent):
			base(value.Name,
			new QuestionType(
				new OptionalInteger(value.IsQuestionTypeIdNull() ? null : (Object)value.QuestionTypeId),
				new OptionalInteger(value.IsQuestionSubtypeIdNull() ? null : (Object)value.QuestionSubtypeId)))
		{
			this.value = value;
			parent.AddNewChild(this);
			connection = (Connection)Root;

			DataRelation relation = connection.TestQuestionSetSet.Relations["QuestionSetsTestContents"];
			foreach (TestQuestionSetSet.TestContentsRow row in value.GetTestContentsRows())
				new QuestionSet((TestQuestionSetSet.QuestionSetsRow)row.GetParentRow(relation), this);
		}

		public TestQuestionSetSet.TestsRow Value
		{
			get { return value; }
		}

		internal override bool DoCanAddMovingChild(Entity entity)
		{
			return DoCanAddNewChild(entity);
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			bool res = entity is QuestionSet && ((QuestionSet)entity).QuestionType.IsSubsetOf(this.QuestionType);
			if (!res) return res;
			QuestionSet qs = (QuestionSet)entity;

			foreach (QuestionSet set in Children)
				if (set.Value.Id == qs.Value.Id) return false;

			return true;
		}

		protected override void DoLoadFullDataset()
		{
			connection.DataProvider.FillTest(FullDataset, value.Id);
		}

		public override void Save()
		{
            connection.DataProvider.UpdateTest(FullDataset);
            contentIsChanged = false;
            Dataset.TestsRow r = FullDataset.Tests[0];
			value.Table.DataSet.Merge(new DataRow[] {r});
			Name = value.Name;
			Entity.OnStructureChangedInternally();
		}

		public override bool HasChanges
		{
			get { return FullDataset.Tests.FindById(value.Id).RowState != DataRowState.Unchanged || contentIsChanged; }
		}

		public override object EntityId
		{
            get { return connection.Name + "Test#" + value.Id; }
		}

		public QuestionSet AddNewQuestionSet(QuestionType questionType)
		{
			QuestionSet s = QuestionSet.Create(questionType, connection);

			QuestionSet ns = AddQuestionSet(s);
            			
			return ns;
		}

		private QuestionSet AddQuestionSet(QuestionSet set)
		{
			if (set.Root != this.Root)
				throw new NotImplementedException();

			QuestionSet qs = new QuestionSet(set.Value, this);
                     
			connection.TestQuestionSetSet.TestContents.AddTestContentsRow(Value, qs.Value, 0);

            Dataset.QuestionSetsExRow row = FullDataset.QuestionSetsEx.AddQuestionSetsExRow(qs.Value.Id, qs.Value.Name, qs.Value.Description, qs.Value.NumberOfQuestionsToPick, 1, 1, 1, qs.Value.NumberOfQuestionsInZone1, qs.Value.NumberOfQuestionsInZone2, qs.Value.NumberOfQuestionsInZone3, this.FullDataset.Tests[0].Id, 0);
            //Check!qs.Value.Id,
         
            if (qs.Value.IsTimeLimitNull())
                row.SetTimeLimitNull();
            else
                row.TimeLimit = qs.Value.TimeLimit;

            if (qs.Value.IsQuestionTypeIdNull())
                row.SetQuestionTypeIdNull();
            else
                row.QuestionTypeId = qs.Value.QuestionTypeId;

            if (qs.Value.IsQuestionSubtypeIdNull())
                row.SetQuestionSubtypeIdNull();
            else
                row.QuestionSubtypeId = qs.Value.QuestionSubtypeId;

			contentIsChanged = true;

			Entity.OnStructureChangedInternally();

			return qs;
		}

	    public void DeleteSetFromTest(int setId, int testId, Dataset data)
	    {
            connection.TestQuestionSetSet.TestContents.FindByTestIdQuestionSetId(testId, setId).Delete();
            FullDataset.Tests.FindById(testId).Name += "";
	        FullDataset.QuestionSetsEx.FindById(setId).Delete();
            //.FindByTestIdQuestionSetId(testId, setId)
	        connection.Refresh();
            Entity.OnStructureChangedInternally();
	        //data.QuestionSetsEx.FindById(setId).Delete();
           
	    }
        int testId;
	    public int setId;
        public void AddExistingSetToTest(Dataset data, int testId)
	    {
	        this.testId = testId;
            int setOrder = data.QuestionSetsEx.Count;
            SelectSet sS = new SelectSet(connection, testId ,setId, setOrder, this);
	        sS.ShowDialog();
            
            if (sS.DialogResult == DialogResult.Yes)
            {

                connection.TestQuestionSetSet.TestContents.AddTestContentsRow(connection.TestQuestionSetSet.Tests.FindById(testId), connection.TestQuestionSetSet.QuestionSets.FindById(setId), Convert.ToByte(setOrder));
                Dataset.QuestionSetsExRow row = FullDataset.QuestionSetsEx.AddQuestionSetsExRow(setId, sS.qsRow.Name, sS.qsRow.Description, sS.qsRow.NumberOfQuestionsToPick, sS.qsRow.IsTimeLimitNull() ? (0) : (sS.qsRow.TimeLimit), sS.qsRow.IsQuestionSubtypeIdNull() ? (0) : (sS.qsRow.QuestionSubtypeId), sS.qsRow.IsQuestionTypeIdNull() ? (0) : (sS.qsRow.QuestionTypeId), sS.qsRow.NumberOfQuestionsInZone1, sS.qsRow.NumberOfQuestionsInZone2, sS.qsRow.NumberOfQuestionsInZone3, testId, Convert.ToByte(setOrder));

                if (row.TimeLimit == 0)
                {
                    row.SetTimeLimitNull();
                }

                if (row.QuestionTypeId == 0)
                {
                    row.SetQuestionTypeIdNull();
                }

                if (row.QuestionSubtypeId == 0)
                {
                    row.SetQuestionSubtypeIdNull();
                }
                
                connection.DataProvider.AddQuestionsExToDataSet(FullDataset, row.Id);
                FullDataset.Tests.FindById(testId).Name += "";
                ApplicationController.Instance.Refresh(connection);
                Entity.OnStructureChangedInternally();
              
                //data.Clear();
                //connection.DataProvider.FillTest(data, testId);
                
                //TestQuestionSetSet tempValue = new TestQuestionSetSet();

                //tempValue.QuestionSets.AddQuestionSetsRow(setId, sS.qsEx.Name, sS.qsEx.Description, sS.qsEx.NumberOfQuestionsToPick, sS.qsEx.IsTimeLimitNull() ? (0) : (sS.qsEx.TimeLimit), sS.qsEx.IsQuestionSubtypeIdNull() ? (0) : (sS.qsEx.QuestionSubtypeId), sS.qsEx.IsQuestionTypeIdNull() ? (0) : (sS.qsEx.QuestionTypeId), sS.qsEx.NumberOfQuestionsInZone1, sS.qsEx.NumberOfQuestionsInZone2, sS.qsEx.NumberOfQuestionsInZone3);
                ////
                //if(sS.qsEx.IsTimeLimitNull())
                //{
                //    tempValue.QuestionSets[0].SetTimeLimitNull();
                //}

                //if (sS.qsEx.IsQuestionTypeIdNull())
                //{
                //    tempValue.QuestionSets[0].SetQuestionTypeIdNull();
                //}

                //if (sS.qsEx.IsQuestionSubtypeIdNull())
                //{
                //    tempValue.QuestionSets[0].SetQuestionSubtypeIdNull();
                //}
                
                //QuestionSet qs = new QuestionSet(tempValue.QuestionSets[0], this);
                //AddQuestionSet(qs);
                
                //Provider provider = connection.DataProvider;
                //provider.AddExistingSetToTest(sS.setId, testId, setOrder);
                //provider.Dispose();

            }
            else
            {
                return;
            }
            
	    }
	    
	    public TestQuestionSetSet.QuestionSetsRow GetTestTestQuestionSetSetQuestiomSetRow(int setId)
	    {
            return connection.TestQuestionSetSet.QuestionSets.FindById(setId);
	    }

	    public void ShangeSetOrder(Dataset data, int setId, bool IsUp)
	    {
            int cou;
            int chSetId = -1;
	        if(IsUp)
	        {
                cou = -1; 
	        }else
	        {
                cou = 1;
	        }
	            
	         if ((data.QuestionSetsEx.FindById(setId).QuestionSetOrder !=0)||(!IsUp))
	         {
                 for (int i = 0; i < data.QuestionSetsEx.Count; i++ )
                 {
                    if (data.QuestionSetsEx.FindById(setId).QuestionSetOrder + cou == data.QuestionSetsEx[i].QuestionSetOrder)
                    {
                        if (IsUp)
                        { data.QuestionSetsEx[i].QuestionSetOrder += 1;
                            
                        }
                        else {
                            data.QuestionSetsEx[i].QuestionSetOrder -= 1; 
                        }
                        chSetId = data.QuestionSetsEx[i].Id;
                        break;
                     }
                 }
	             
                if(IsUp)
                {data.QuestionSetsEx.FindById(setId).QuestionSetOrder -=1;}
                else { data.QuestionSetsEx.FindById(setId).QuestionSetOrder += 1; }

	            
                FullDataset.Tests.FindById(FullDataset.QuestionSetsEx.FindById(setId).TestId).Name +="";
               // connection.QuestionSets.FindById(setId).Name += "";
             }
	        
       
	    }
	}
}

