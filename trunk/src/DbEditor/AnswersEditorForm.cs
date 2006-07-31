using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.DbEditor.Data;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor
{
    public partial class AnswersEditorForm : Form
    {
        int questionId;
        Dataset copyDataset;
        Dataset data;
        byte lastOrder;
        public static string APP_CAPTION = "GMAT Club Test - Database Editor";
        public AnswersEditorForm(Dataset ds, int qId)
        {
            InitializeComponent();
            copyDataset = (Dataset)ds.Copy();
            dataset = (Dataset)ds.Copy();
            questionId = qId;
            data = ds;
        }

        private void AnswersEditorForm_Load(object sender, System.EventArgs e)
        {
            for (int i = 0; i < dataset.Answers.Count; ++i)
            {
                if (dataset.Answers[i].QuestionId != questionId)
                {
                    dataset.Answers[i].Delete();
                    
                }else
                {
                    lastOrder++;
                }
            }
            answersDataGridView.DataSource = dataset;
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            answersDataGridView.Sort(answersDataGridView.Columns[orderDataGridViewTextBoxColumn.Index], direction);
        }

        private void addNewButton_Click(object sender, System.EventArgs e)
        {
            dataset.Answers.AddAnswersRow(questionId, "New answer", false, lastOrder);
            lastOrder++;
            answersDataGridView.Update();
        }

        private void answersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == textDataGridViewTextBoxColumn.Index)
            {
                dataset.Answers.FindById(Convert.ToInt32(answersDataGridView.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Text = answersDataGridView.Rows[e.RowIndex].Cells[textDataGridViewTextBoxColumn.Index].Value.ToString();
                return;
            }

            if (e.ColumnIndex == isCorrectDataGridViewCheckBoxColumn.Index)
            {
                bool isCorrect = Convert.ToBoolean(answersDataGridView.Rows[e.RowIndex].Cells[isCorrectDataGridViewCheckBoxColumn.Index].Value);
                for (int i = 0; i < dataset.Answers.Count; ++i)
                {
                    if (dataset.Answers[i].RowState != DataRowState.Deleted)
                    {
                        if (dataset.Answers[i].IsCorrect)
                        {
                            dataset.Answers[i].IsCorrect = false;
                        }
                    }
                }
                dataset.Answers.FindById(Convert.ToInt32(answersDataGridView.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).IsCorrect = isCorrect;

                return;
            }
            answersDataGridView.Update();
        }

        private void editFormulaButton_Click(object sender, EventArgs e)
        {
            DataGridView gw = answersDataGridView;
            if (gw.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected answer.", APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string formulatorPath = "";
            try
            {
                formulatorPath = (String)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Hermitech Laboratory\Formulator\Settings\").GetValue(@"path");
            }
            catch
            {
                MessageBox.Show("Formulator not installeted! Plese reinstall this application.", "Formulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string answer = (string)gw.SelectedRows[0].Cells[textDataGridViewTextBoxColumn.Index].Value;
            if (answer.LastIndexOf('<') != -1)
            {
                File.WriteAllText(Application.StartupPath + @"\answer.xml", answer);
                //File.WriteAllText(@"C:\Program Files\Microsoft Office\OFFICE11\question.xml", question.Substring(last, end - last + 7));
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.Arguments = "\"" + Application.StartupPath + @"\answer.xml" + "\"";
                pInfo.FileName = formulatorPath + "Formulator.exe";
                Process p = Process.Start(pInfo);
                while (!p.HasExited)
                {

                }
                string formula = File.ReadAllText(Application.StartupPath + @"\answer.xml");
                answer = formula;
                gw.SelectedRows[0].Cells[textDataGridViewTextBoxColumn.Index].Value = answer;
                dataset.Answers.FindById(Convert.ToInt32(gw.SelectedRows[0].Cells[idDataGridViewTextBoxColumn.Index].Value)).Text = answer;
                return;
            }
            else
            {
                if (MessageBox.Show("Convert simple answer to answer with farmulas?", "Formulator", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    answer = answer.Insert(0, "<math display = 'block'><mrow><mi mathvariant = 'italic'>");
                    answer = answer.Insert(answer.Length, "</mi></mrow></math>");
                    File.WriteAllText(Application.StartupPath + @"\answer.xml", answer);
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.Arguments = "\"" + Application.StartupPath + @"\answer.xml" + "\"";
                    pInfo.FileName = formulatorPath + "Formulator.exe";
                    Process p = Process.Start(pInfo);
                    while (!p.HasExited)
                    {

                    }
                    string formula = File.ReadAllText(Application.StartupPath + @"\answer.xml");
                    answer = formula;
                    gw.SelectedRows[0].Cells[textDataGridViewTextBoxColumn.Index].Value = answer;
                    dataset.Answers.FindById(Convert.ToInt32(gw.SelectedRows[0].Cells[idDataGridViewTextBoxColumn.Index].Value)).Text = answer;
                }
            }
        }

        private int[] deletedId;
        private int deletedCount=0;
        private void removeButton_Click(object sender, EventArgs e)
        {
            deletedId = new int[data.Answers.Count];
            DataGridView gw = answersDataGridView;
            int selectedRowIndex = gw.SelectedRows[0].Index;
            if (gw.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected answer.", APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Remove " + " answer?", "Remove answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int answerId = Convert.ToInt32(gw.Rows[gw.SelectedRows[0].Index].Cells[idDataGridViewTextBoxColumn.Index].Value);
                deletedId[deletedCount] = answerId;
                deletedCount++;
                if (selectedRowIndex != gw.Rows.Count-1)
                {
                    for (int i = selectedRowIndex + 1; i < gw.Rows.Count; ++i)
                    {
                        gw.Rows[i].Cells[orderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(gw.Rows[i].Cells[orderDataGridViewTextBoxColumn.Index].Value) - 1;
                    }
                }
                dataset.Answers.FindById(Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Delete();
                gw.Update();
                lastOrder--;
            }
            
        }
        private int selectedAnswerId = -1;
        private void addExistButton_Click(object sender, EventArgs e)
        {
            SelectAnswerForm sAf = new SelectAnswerForm(copyDataset, questionId);
            if(sAf.ShowDialog() == DialogResult.OK)
            {
                selectedAnswerId = sAf.answerId;
                dataset.Answers.AddAnswersRow(questionId, copyDataset.Answers.FindById(selectedAnswerId).Text, false, lastOrder);
                lastOrder++;
            }
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < deletedCount; ++i)
            {
                data.Answers.FindById(deletedId[i]).Delete();
            }
            
            for(int i=0; i<dataset.Answers.Count; ++i)
            {
                if(dataset.Answers[i].RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (data.Answers.FindById(dataset.Answers[i].Id) == null)
                {
                    data.Answers.AddAnswersRow(questionId, dataset.Answers[i].Text, dataset.Answers[i].IsCorrect, dataset.Answers[i].Order);
                }else
                {
                    data.Answers.FindById(dataset.Answers[i].Id).Text = dataset.Answers[i].Text;
                    data.Answers.FindById(dataset.Answers[i].Id).Order = dataset.Answers[i].Order;
                    data.Answers.FindById(dataset.Answers[i].Id).IsCorrect = dataset.Answers[i].IsCorrect;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            DataGridView gw = answersDataGridView;

            if (gw.SelectedRows.Count == 0){return;}
            int selectedRowIndex = gw.SelectedRows[0].Index;
            if(selectedRowIndex == 0)
            {
                return;
            }

            gw.Rows[selectedRowIndex].Cells[orderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[orderDataGridViewTextBoxColumn.Index].Value) - 1;
            gw.Rows[selectedRowIndex -1].Cells[orderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[orderDataGridViewTextBoxColumn.Index].Value) + 1;
            answersDataGridView.DataSource = dataset;
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            answersDataGridView.Sort(answersDataGridView.Columns[orderDataGridViewTextBoxColumn.Index], direction);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            DataGridView gw = answersDataGridView;

            if (gw.SelectedRows.Count == 0) { return; }
            int selectedRowIndex = gw.SelectedRows[0].Index;
            if (selectedRowIndex == gw.Rows.Count -1)
            {
                return;
            }

            gw.Rows[selectedRowIndex].Cells[orderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[orderDataGridViewTextBoxColumn.Index].Value) + 1;
            gw.Rows[selectedRowIndex+1].Cells[orderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[orderDataGridViewTextBoxColumn.Index].Value) - 1;
            answersDataGridView.DataSource = dataset;
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            answersDataGridView.Sort(answersDataGridView.Columns[orderDataGridViewTextBoxColumn.Index], direction);
        }

     
    }
}