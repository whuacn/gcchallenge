using System;
using System.Threading;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.ImportExport;

namespace GmatClubTest.DbEditor
{
    public partial class ExportTestForm : Form
    {
        private Provider provider;
        private SaveFileDialog saveFileDialog;
        private string fileName;
        private MainForm mainForm;


        public ExportTestForm(MainForm mainForm)
        {
            // this.Dataset = new Dataset();
            //provider =  p;
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void ExportTestForm_Load(object sender, EventArgs e)
        {
            int conCount = 0;
            for (int i = 0; i < mainForm.Tree.Connections.Count; i++)
            {
                if (((Connection) mainForm.Tree.Connections[i]).Opened)
                {
                    connectionComboBox.Items.Add((Connection) mainForm.Tree.Connections[i]);
                    conCount++;
                }
            }

            if (conCount > 0)
            {
                connectionComboBox.SelectedIndex = 0;
                provider = ((Connection) (connectionComboBox.SelectedItem)).DataProvider;
                provider.AllTestsAdapter.Fill(dataset.Tests);
                dataGridView1.Update();
            }
            else
            {
                MessageBox.Show("No opened connection.", "Export test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Test not selected.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((fileName == "") || (fileName == null))
            {
                MessageBox.Show("File name not set.", "Export test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (showSaveDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            int testId = (int) dataGridView1.SelectedRows[0].Cells[0].Value;

            ImEx imEx = new ImEx();
            if (((Connection) connectionComboBox.SelectedItem).DbType == Connection.Type.Sql)
            {
                imEx.InitSQLConnection(((Connection) connectionComboBox.SelectedItem).ServerName,
                                       ((Connection) connectionComboBox.SelectedItem).DbName,
                                       ((Connection) connectionComboBox.SelectedItem).UserName,
                                       ((Connection) connectionComboBox.SelectedItem).Password);
            }
            else
            {
                imEx.InitAccessConnection(((Connection) connectionComboBox.SelectedItem).FileName);
            }
            ProcessingForm pc = new ProcessingForm();
            pc.Show();
            pc.Caption = "Export test";
            pc.Operation = "Exporting...";
            pc.StartSomeProcess();
            imEx.theadFilePath = fileName;
            imEx.theadTestId = testId;
            Thread t = new Thread(new ThreadStart(imEx.ExportTestOnNewTheader));
            t.Start();
            while (t.ThreadState != ThreadState.Stopped)
            {
                pc.ReDrowProgress();
            }
            pc.Close();
            pc.Dispose();
            MessageBox.Show("Test is exported.", "Export test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }


        private DialogResult showSaveDialog()
        {
            saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Gmat test files(*.gtf)|*.gtf|All files (*.*)|*.*";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                saveFileDialog.FileName = (string) dataGridView1.SelectedRows[0].Cells[1].Value;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Text = saveFileDialog.FileName;
                fileName = saveFileDialog.FileName;
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.Cancel;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            showSaveDialog();
        }

        private void connectionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            provider = ((Connection) (connectionComboBox.SelectedItem)).DataProvider;
            dataset.Clear();
            provider.AllTestsAdapter.Fill(dataset.Tests);
            dataGridView1.Update();
        }
    }
}