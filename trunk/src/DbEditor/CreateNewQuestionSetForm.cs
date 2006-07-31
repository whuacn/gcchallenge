using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public partial class CreateNewQuestionSetForm : Form
    {
        private Provider provider;
        private MainForm mainForm;
        private Dataset dataset = new Dataset();
        public CreateNewQuestionSetForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void CreateNewQuestionSetForm_Load(object sender, EventArgs e)
        {
            int conCount = 0;
            for (int i = 0; i < mainForm.Tree.Connections.Count; i++)
            {
                if (((Connection)mainForm.Tree.Connections[i]).Opened)
                {
                    connectionComboBox.Items.Add((Connection)mainForm.Tree.Connections[i]);
                    conCount++;
                }

            }

            if (conCount > 0)
            {
                connectionComboBox.SelectedIndex = 0;
                provider = ((Connection)(connectionComboBox.SelectedItem)).DataProvider;
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
            }
            else
            {
                MessageBox.Show("No opened connection.", "New test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            dataset.QuestionSets.AddQuestionSetsRow(nameTextBox.Text, descriptionTextBox.Text, 0, 0, 0, 0, 0, 0, 0);
            if(timeTextBox.Text != "")
            {
                dataset.QuestionSets[0].TimeLimit = Convert.ToInt32(timeTextBox.Text);
            }else
            {
                dataset.QuestionSets[0].SetTimeLimitNull();
            }
                 
            if (typeComboBox.SelectedIndex != 0)
            {
                dataset.QuestionSets[0].QuestionTypeId = dataset.QuestionTypes[typeComboBox.SelectedIndex - 1].Id;
            }
            else
            {
                dataset.QuestionSets[0].SetQuestionTypeIdNull();
            }

            if (subTypecomboBox.SelectedIndex != 0)
            {
                dataset.QuestionSets[0].QuestionSubtypeId = dataset.QuestionSubtypes[subTypecomboBox.SelectedIndex - 1].Id;
            }
            else
            {
                dataset.QuestionSets[0].SetQuestionSubtypeIdNull();
            }
            provider.AddNewQuestionSet(dataset.QuestionSets[0]);
            
            ((Connection)connectionComboBox.SelectedItem).Refresh();

            this.DialogResult = DialogResult.OK;
        }
    }
}