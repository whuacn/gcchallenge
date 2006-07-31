using System;
using System.Data;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public partial class SelectQuestionForm : Form
    {
        int setId;
        Dataset ds = new Dataset();
        public Dataset.QuestionsExRow qr;
        DbObject dbObject;
        public SelectQuestionForm(Dataset data, int setId, DbObject dbObject)
        {
            ds = (Dataset)data.Copy();
            this.setId = setId;
            this.dbObject = dbObject;
            InitializeComponent();
        }

        private void SelectQuestionForm_Load(object sender, EventArgs e)
        {
            dataset = ds;
            dataset.QuestionsEx.Clear();
            dbObject.GetAllQuestionsEx(dataset);
            int count = 0;
            for(int i= 0; i<dataset.QuestionsEx.Count; ++i)
            {
                if(dataset.QuestionsEx[i].SetId == setId)
                {
                    dataset.QuestionsEx[i].Delete();
                    count++;
                    continue;
                    
                }
                 if (!dataset.QuestionSetsEx.FindById(setId).IsQuestionTypeIdNull())
                 {
                     if (dataset.QuestionsEx[i].TypeId != dataset.QuestionSetsEx.FindById(setId).QuestionTypeId)
                     {
                         dataset.QuestionsEx[i].Delete();
                         count++;
                         continue;
                     }
                 }
                     
            }
           if(count == dataset.QuestionsEx.Count)
           {
               MessageBox.Show("Not valid to add question in database.", "Select question", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               {
                   this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               }
           }
           questionDataGrid.DataSource = dataset;
           type.DataSource = dataset;
           subType.DataSource = dataset;
           difficultyLevelId.DataSource = dataset;
           questionDataGrid.Update();
        }

        private void questionDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(questionDataGrid.SelectedRows.Count !=0)
            {
                for (int i = 0; i < dataset.QuestionsEx.Count; ++i )
                {if(dataset.QuestionsEx[i].RowState == DataRowState.Deleted){continue;}
                    if (dataset.QuestionsEx[i].Id == (int)questionDataGrid.SelectedRows[0].Cells[0].Value)
                    {
                        qr = dataset.QuestionsEx[i]; //FindByIdSetId((int)questionDataGrid.SelectedRows[0].Cells[0].Value);
                        break;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SelectQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}