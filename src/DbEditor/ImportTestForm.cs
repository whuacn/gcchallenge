using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.ImportExport;
using Dataset=ImportExport.Data.Dataset;

namespace GmatClubTest.DbEditor
{
    public partial class ImportTestForm : Form
    {
        private Provider provider;
        private OpenFileDialog OpenFileDialog;
        private string fileName;
        private MainForm mainForm;


        public ImportTestForm(MainForm mainForm)
        {
            // this.dataset1 = new dataset1();
            //provider =  p;
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void ImportTestForm_Load(object sender, EventArgs e)
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
                provider.AllTestsAdapter.Fill(dataset1.Tests);
                baseDataGridView.Update();
            }
            else
            {
                MessageBox.Show("No opened connection.", "Import test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if ((fileName == "") || (fileName == null))
            {
                MessageBox.Show("File name not specified.", "Import test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (showOpenDialog("Gmat test files(*.gtf)|*.gtf|All files (*.*)|*.*") != DialogResult.OK)
                {
                    return;
                }
            }

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
            bool isUpdate = false;
            for (int i = 0; i < dataset1.Tests.Count; ++i)
            {
                if (dataset1.Tests[i].GUID == fileDataset.Tests[0].GUID)
                {
                    if (
                        MessageBox.Show(
                            "Test ' " + dataset1.Tests[i].Name + "' version " + dataset1.Tests[i].Version +
                            " is alredy exist in databese. Updete test to version " + fileDataset.Tests[0].Version,
                            "Import test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        imEx.DeleteOldTest(dataset1.Tests[i].Id);
                        ProcessingForm pc = new ProcessingForm();
                        pc.Show();
                        pc.Caption = "Import test";
                        pc.Operation = "Importing...";
                        pc.StartSomeProcess();
                        imEx.theadFilePath = fileName;
                        Thread t = new Thread(new ThreadStart(imEx.ImportTestOnNewTheader));
                        t.Start();
                        while (t.ThreadState != ThreadState.Stopped)
                        {
                            pc.ReDrowProgress();
                        }
                        pc.Close();
                        pc.Dispose();
                    }
                    isUpdate = true;
                    break;
                }
            }
            if (!isUpdate)
            {
                ProcessingForm pc = new ProcessingForm();
                pc.Show();
                pc.Caption = "Import test";
                pc.Operation = "Importing...";
                pc.StartSomeProcess();
                imEx.theadFilePath = fileName;
                Thread t = new Thread(new ThreadStart(imEx.ImportTestOnNewTheader));
                t.Start();
                while (t.ThreadState != ThreadState.Stopped)
                {
                    pc.ReDrowProgress();
                }
                pc.Close();
                pc.Dispose();
            }
            MessageBox.Show("Test is imported.", "Import test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ((Connection) connectionComboBox.SelectedItem).Refresh();
            DialogResult = DialogResult.OK;
        }

        private DialogResult showOpenDialog(string filter)
        {
            OpenFileDialog = new OpenFileDialog();

            OpenFileDialog.Filter = filter;
            //"Gmat test files(*.gtf)|*.gtf|All files (*.*)|*.*";
            if (baseDataGridView.SelectedRows.Count > 0)
            {
                OpenFileDialog.FileName = (string) baseDataGridView.SelectedRows[0].Cells[1].Value;
            }
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Text = OpenFileDialog.FileName;
                fileName = OpenFileDialog.FileName;
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.Cancel;
            }
        }


        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (showOpenDialog("Gmat test text files(*.gtf)|*.gtf|All files (*.*)|*.*") == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(textBoxFileName.Text, FileMode.Open, FileAccess.Read, FileShare.Read);

                try
                {
                    fileDataset = (Dataset) formatter.Deserialize(stream);
                    fileDataGridView.DataSource = fileDataset;
                    fileDataGridView.Update();
                    import.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("File isn't GmatClubTest file.", "Import test", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    textBoxFileName.Text = "";
                }
                stream.Close();
            }
        }

        private void connectionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            provider = ((Connection) (connectionComboBox.SelectedItem)).DataProvider;
            dataset1.Clear();
            provider.AllTestsAdapter.Fill(dataset1.Tests);
            baseDataGridView.Update();
        }

        private void impotrFromTypedTextFile_Click(object sender, EventArgs e)
        {
            if (showOpenDialog("Gmat test files(*.txt)|*.txt|All files (*.*)|*.*") == DialogResult.OK)
            {
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
                    imEx.InitAccessConnection(((Connection) connectionComboBox.SelectedItem).DbName);
                }
                try
                {
                    ProcessingForm pc = new ProcessingForm();
                    pc.Show();
                    pc.Caption = "Import test";
                    pc.Operation = "Importing...";
                    pc.StartSomeProcess();
                    imEx.theadFilePath = textBoxFileName.Text;
                    Thread t = new Thread(new ThreadStart(imEx.ImportTestOnNewTheader));
                    t.Start();
                    while (t.ThreadState != ThreadState.Stopped)
                    {
                        pc.ReDrowProgress();
                    }
                    pc.Close();
                    pc.Dispose();
                    MessageBox.Show("Test is imported.", "Import test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("File isn't GmatClubTest file.", "Import test", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    textBoxFileName.Text = "";
                }
            }
        }
    }
}