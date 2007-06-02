using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public partial class SelectAnswerForm : Form
    {
        public int answerId;
        private int questionId;
        private Dataset copyDataset;

        public SelectAnswerForm(Dataset data, int questionId)
        {
            InitializeComponent();
            this.questionId = questionId;
            copyDataset = (Dataset) data.Copy();
            dataset = copyDataset;
        }

        private void SelectAnswerForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataset.Answers.Count; ++i)
            {
                if (dataset.Answers[i].QuestionId == questionId)
                {
                    dataset.Answers[i].Delete();
                }
            }

            answersDataGrid.DataSource = dataset;
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            answersDataGrid.Sort(answersDataGrid.Columns[orderDataGridViewTextBoxColumn.Index], direction);
            answersDataGrid.Update();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (answersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected answer.", "Select exist answer", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            else
            {
                answerId =
                    Convert.ToInt32(answersDataGrid.SelectedRows[0].Cells[idDataGridViewTextBoxColumn.Index].Value);
                DialogResult = DialogResult.OK;
            }
        }
    }
}