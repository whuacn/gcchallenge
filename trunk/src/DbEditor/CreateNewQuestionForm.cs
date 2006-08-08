using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.DbEditor.Data;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor
{
    public partial class CreateNewQuestionForm : Form
    {
        private Dataset.QuestionsExDataTable questionTable;
        private Dataset dataSet;
        private Dataset data;
        private int setId;
        private byte[] picture;
        public Dataset.QuestionsExRow newQuestion;

        public CreateNewQuestionForm(Dataset.QuestionsExDataTable ds, Dataset data, int setId)
        {
            questionTable = ds;
            this.data = data;
            this.setId = setId;
            dataSet = (Dataset) data.Copy();
            InitializeComponent();
        }

        private void CreateNewQuestionForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataset1.DifficultyLevel' table. You can move, or remove it, as needed.
            difficutlyLevelcomboBox.DataSource = dataSet.DifficultyLevel;
            difficutlyLevelcomboBox.DisplayMember = "Name";
            difficutlyLevelcomboBox.Update();

            typeComboBox.DataSource = dataSet.QuestionTypes;
            typeComboBox.DisplayMember = "Name";
            typeComboBox.Update();

            subTypecomboBox.DataSource = dataSet.QuestionSubtypes;
            subTypecomboBox.DisplayMember = "Name";
            subTypecomboBox.Update();

            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionTypeIdNull())
            {
                typeComboBox.SelectedIndex = dataSet.QuestionSetsEx.FindById(setId).QuestionTypeId - 1;
                typeComboBox.Update();
                typeComboBox.Enabled = false;
            }

            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionSubtypeIdNull())
            {
                subTypecomboBox.SelectedIndex = dataSet.QuestionSetsEx.FindById(setId).QuestionSubtypeId - 1;
                subTypecomboBox.Update();
                subTypecomboBox.Enabled = false;
            }
        }

        private void subTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subTypecomboBox.SelectedIndex == 3)
            {
                addPassgeToQuestionButton.Enabled = true;
                passageTextBox.Enabled = true;
            }
            else
            {
                addPassgeToQuestionButton.Enabled = false;
                passageTextBox.Enabled = false;
                passageTextBox.Text = "";
                selectedPassageId = -1;
            }
        }


        private void addPicturebutton_Click(object sender, EventArgs e)
        {
            if (addPicturebutton.Text != "edit")
            {
                File.Copy(Application.StartupPath + @"\templates\newPicture.bmp",
                          Application.StartupPath + @"\templates\Picture.bmp", true);
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.Arguments = "\"" + Application.StartupPath + @"\templates\Picture.bmp" + "\"";
                pInfo.FileName = @"C:\WINDOWS\system32\mspaint.exe";
                Process p = Process.Start(pInfo);
                while (!p.HasExited)
                {
                }
                byte[] temlatePicture = File.ReadAllBytes(Application.StartupPath + @"\templates\newPicture.bmp");
                Image image = Image.FromFile(Application.StartupPath + @"\templates\Picture.bmp");
                if (temlatePicture != picture)
                {
                    picture = File.ReadAllBytes(Application.StartupPath + @"\templates\Picture.bmp");
                    pictureBox.Image = image;
                    addPicturebutton.Text = "edit";
                }
            }
            else
            {
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.Arguments = "\"" + Application.StartupPath + @"\templates\Picture.bmp" + "\"";
                pInfo.FileName = @"C:\WINDOWS\system32\mspaint.exe";
                Process p = Process.Start(pInfo);
                while (!p.HasExited)
                {
                }
                byte[] temlatePicture = File.ReadAllBytes(Application.StartupPath + @"\templates\newPicture.bmp");
                picture = File.ReadAllBytes(Application.StartupPath + @"\templates\Picture.bmp");
                Image image = Image.FromFile(Application.StartupPath + @"\templates\Picture.bmp");
            }
        }

        private void addFormulaButton_Click(object sender, EventArgs e)
        {
            string formulatorPath = "";
            try
            {
                formulatorPath =
                    (String)
                    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Hermitech Laboratory\Formulator\Settings\").GetValue(
                        @"path");
            }
            catch
            {
                MessageBox.Show("Formulator not installeted! Plese reinstall this application.", "Formulator",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (addFormulaButton.Text != "edit question with formulas")
            {
                if (
                    MessageBox.Show("Convert simple question to question with formulas?", "Formulator",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string question = textTextBox.Text;
                    question = question.Insert(0, "<math display = 'block'><mrow><mi mathvariant = 'italic'>");
                    question = question.Insert(question.Length, "</mi></mrow></math>");
                    File.WriteAllText(Application.StartupPath + @"\question.xml", question);
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.Arguments = "\"" + Application.StartupPath + @"\question.xml" + "\"";
                    pInfo.FileName = formulatorPath + "Formulator.exe";
                    Process p = Process.Start(pInfo);
                    while (!p.HasExited)
                    {
                    }
                    string formula = File.ReadAllText(Application.StartupPath + @"\question.xml");
                    textTextBox.Text += formula;
                    addFormulaButton.Text = "edit question with formulas";
                    textTextBox.Enabled = false;
                }
            }
            else
            {
                File.WriteAllText(Application.StartupPath + @"\templates\newQuestion.xml", textTextBox.Text);
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.Arguments = "\"" + Application.StartupPath + @"\templates\newQuestion.xml" + "\"";
                pInfo.FileName = formulatorPath + "Formulator.exe";
                Process p = Process.Start(pInfo);
                while (!p.HasExited)
                {
                }
                string formula = File.ReadAllText(Application.StartupPath + @"\templates\newQuestion.xml");
                textTextBox.Text = formula;
            }
        }

        public int selectedPassageId = -1;

        private void addPassgeToQuestionButton_Click(object sender, EventArgs e)
        {
            SelectPassageQuestionForm selectPassage = new SelectPassageQuestionForm(dataSet, setId, this);
            selectPassage.ShowDialog();
            if (selectPassage.DialogResult == DialogResult.OK && selectedPassageId != -1)
            {
                passageTextBox.Text = dataSet.QuestionsEx.FindByIdSetId(selectedPassageId, setId).Text;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            byte[] temp = new byte[0];
            newQuestion = data.QuestionsEx.AddQuestionsExRow(typeComboBox.SelectedIndex + 1,
                                                             subTypecomboBox.SelectedIndex + 1,
                                                             difficutlyLevelcomboBox.SelectedIndex + 1,
                                                             textTextBox.Text, temp, setId, 0, 0, 0
                );
            if (picture == null)
            {
                newQuestion.SetPictureNull();
            }
            else
            {
                newQuestion.Picture = picture;
            }
            DialogResult = DialogResult.OK;
        }
    }
}