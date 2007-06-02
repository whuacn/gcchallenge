using System;
using System.Data;
using System.Windows.Forms;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public partial class SelectPassageQuestionForm : Form
    {
        private int setId;
        private CreateNewQuestionForm createForm;
        private Dataset t;
        public int selectedPassageId = -1;

        public SelectPassageQuestionForm(Dataset data, int setId, CreateNewQuestionForm createForm)
        {
            t = (Dataset) data.Copy();
            this.createForm = createForm;
            this.setId = setId;
            InitializeComponent();
        }


        public SelectPassageQuestionForm(Dataset data, int setId)
        {
            t = (Dataset) data.Copy();
            //this.createForm = createForm;
            this.setId = setId;
            InitializeComponent();
        }

        private void selectPassageQuestionForm_Load(object sender, EventArgs e)
        {
            dataset = t;
            for (int i = 0; i < dataset.QuestionsEx.Count; i++)
            {
                if (dataset.QuestionsEx[i].RowState == DataRowState.Deleted)
                {
                    continue;
                }
                //if (dataset.QuestionSetsEx.FindById(dataset.QuestionsEx[i].SetId).TestId != dataset.QuestionSetsEx.FindById(setId).TestId)
                //{
                //    dataset.QuestionsEx[i].Delete();
                //    continue;
                //}
                if (dataset.QuestionsEx[i].SubtypeId != 3)
                {
                    dataset.QuestionsEx[i].Delete();
                    continue;
                }
                if (!dataset.QuestionSetsEx.FindById(setId).IsQuestionTypeIdNull())
                {
                    if (dataset.QuestionsEx[i].TypeId != dataset.QuestionSetsEx.FindById(setId).QuestionTypeId)
                    {
                        dataset.QuestionsEx[i].Delete();
                        continue;
                    }
                }
            }
            type.DataSource = dataset;
            difficultyLevelId.DataSource = dataset;
            passagesDataGrid.DataSource = dataset;
            passagesDataGrid.Update();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (passagesDataGrid.SelectedRows.Count != 0)
            {
                //createForm.selectedPassageId = (int)passagesDataGrid.SelectedRows[0].Cells[0].Value;
                selectedPassageId = (int) passagesDataGrid.SelectedRows[0].Cells[0].Value;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Passage question not selected.", "Select set", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
        }

        private void passagesDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
    }
}