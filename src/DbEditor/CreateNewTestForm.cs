using System;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public partial class CreateNewTestForm : Form
    {
        private Provider provider;
        private MainForm mainForm;
        private Dataset dataset = new Dataset();

        public CreateNewTestForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void CreateNewTestForm_Load(object sender, EventArgs e)
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
                provider.FillTypes_Subtypes(dataset);
                typeComboBox.Items.Add("Mixed");
                subTypecomboBox.Items.Add("Untyped");
                for (int i = 0; i < dataset.QuestionTypes.Count; i++)
                {
                    typeComboBox.Items.Add(dataset.QuestionTypes[i].Name);
                }
                for (int i = 0; i < dataset.QuestionSubtypes.Count; i++)
                {
                    subTypecomboBox.Items.Add(dataset.QuestionSubtypes[i].Name);
                }
                typeComboBox.SelectedIndex = 0;
                subTypecomboBox.SelectedIndex = 0;
                //provider.AllTestsAdapter.Fill(this.dataset1.Tests);
                //baseDataGridView.Update();
            }
            else
            {
                MessageBox.Show("No opened connection.", "New test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Guid testGUID;
            testGUID = Guid.NewGuid();
            dataset.Tests.AddTestsRow(nameTextBox.Text, isPracticeCheckBox.Checked ? (true) : (false),
                                      descriptionTextBox.Text, 0, 0, testGUID.ToString(), 1);
            if (typeComboBox.SelectedIndex != 0)
            {
                dataset.Tests[0].QuestionTypeId = dataset.QuestionTypes[typeComboBox.SelectedIndex - 1].Id;
            }
            else
            {
                dataset.Tests[0].SetQuestionTypeIdNull();
            }

            if (subTypecomboBox.SelectedIndex != 0)
            {
                dataset.Tests[0].QuestionSubtypeId = dataset.QuestionSubtypes[subTypecomboBox.SelectedIndex - 1].Id;
            }
            else
            {
                dataset.Tests[0].SetQuestionSubtypeIdNull();
            }
            provider.AddNewTest(dataset.Tests[0]);

            ((Connection) connectionComboBox.SelectedItem).Refresh();

            DialogResult = DialogResult.OK;
        }
    }
}