using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using GmatClubTest.Common;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Forms;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor
{
    internal class QuestionEditor : Editor
    {
        private Button addFormulaButton;
        private Button addPicturebutton;
        private PictureBox pictureBox;
        private Label label6;
        private Label label4;
        private ComboBox difficutlyLevelcomboBox;
        private Label label1;
        private ComboBox subTypecomboBox;
        private Label typelabel;
        private ComboBox typeComboBox;
        private Label label2;
        private GroupBox groupBox2;
        private DataGridView answersDataGridView;
        private Button addNewButton;
        private Button removeButton;
        private ImageList imageList;
        private IContainer components;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCorrectDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private Button addAnswerFormula;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button deletePicturebutton;
        private TextBox textTextBox;
        private Button explanationButton;

        public QuestionEditor(Question question) : base(question)
        {
            InitializeComponent();
        }

        public override int Id
        {
            get { return ((Question) dbObject).Value.Id; }
        }

        public override void SaveCurrentEdit()
        {
            Dataset.QuestionsExRow questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId(_questionRow.Id, _questionRow.SetId);
            if (questionRow == null)
            {
                return;
            }
            questionRow.DifficultyLevelId =
                difficutlyLevelcomboBox.SelectedIndex + 1;
            questionRow.TypeId = (int)typeComboBox.SelectedValue;
            questionRow.SubtypeId = (int)subTypecomboBox.SelectedValue;
            questionRow.Text = textTextBox.Text;
            questionRow.Picture = picture;
            byte order = 0;

            for (int i = 0; i < dataSet.Answers.Count; ++i)
            {
                if (dataSet.Answers[i].RowState == DataRowState.Deleted)
                {
                    continue;
                }

                if (dataSet.Answers[i].QuestionId != _questionRow.Id)
                {
                    continue;
                }

                if (dataSet.Answers[i].RowState == DataRowState.Added)
                {
                    dbObject.FullDataset.Answers.AddAnswersRow(_questionRow.Id, dataSet.Answers[i].Text,
                                                               dataSet.Answers[i].IsCorrect, order);
                    order++;
                }

                if (dataSet.Answers[i].RowState == DataRowState.Modified)
                {
                    dbObject.FullDataset.Answers.FindById(dataSet.Answers[i].Id).Text = dataSet.Answers[i].Text;
                    dbObject.FullDataset.Answers.FindById(dataSet.Answers[i].Id).IsCorrect =
                        dataSet.Answers[i].IsCorrect;
                    order++;
                    continue;
                }
            }
        }

        public override void SetBindingPosition()
        {
            int pos = 0;
            Question d = ((Question) dbObject);
            foreach (Dataset.QuestionsExRow row in dbObject.FullDataset.QuestionsEx.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (row.Id == d.Value.Id) break;
                ++pos;
            }
            BindingContext[data, "Questions"].Position = pos;
        }

        public override void EndCurrentEdit()
        {
            BindingContext[data, "Questions"].EndCurrentEdit();
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof (QuestionEditor));
            addFormulaButton = new Button();
            addPicturebutton = new Button();
            pictureBox = new PictureBox();
            label6 = new Label();
            label4 = new Label();
            difficutlyLevelcomboBox = new ComboBox();
            label1 = new Label();
            subTypecomboBox = new ComboBox();
            typelabel = new Label();
            typeComboBox = new ComboBox();
            label2 = new Label();
            textTextBox = new TextBox();
            groupBox2 = new GroupBox();
            addAnswerFormula = new Button();
            answersDataGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            questionIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            textDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isCorrectDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            orderDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addNewButton = new Button();
            removeButton = new Button();
            imageList = new ImageList(components);
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            deletePicturebutton = new Button();
            ((ISupportInitialize) (data)).BeginInit();
            ((ISupportInitialize) (pictureBox)).BeginInit();
            groupBox2.SuspendLayout();
            ((ISupportInitialize) (answersDataGridView)).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();

            // 
            // explanationButton
            // 
            explanationButton = new Button();
            explanationButton.Location = new Point(132, 11);
            explanationButton.Name = "explanationButton";
            explanationButton.Size = new Size(85, 23);
            explanationButton.Text = "explanation";
            explanationButton.Click += new EventHandler(explanationButton_Click);
            explanationButton.UseVisualStyleBackColor = true;
            // 
            // explanationButton
            // 

            // 
            // addFormulaButton
            // 
            addFormulaButton.Location = new Point(41, 11);
            addFormulaButton.Name = "addFormulaButton";
            addFormulaButton.Size = new Size(85, 23);
            addFormulaButton.TabIndex = 43;
            addFormulaButton.Text = "add formula";
            addFormulaButton.UseVisualStyleBackColor = true;
            addFormulaButton.Click += new EventHandler(addFormulaButton_Click);
            // 
            // addPicturebutton
            // 
            addPicturebutton.Location = new Point(210, 92);
            addPicturebutton.Name = "addPicturebutton";
            addPicturebutton.Size = new Size(45, 20);
            addPicturebutton.TabIndex = 42;
            addPicturebutton.Text = "add";
            addPicturebutton.UseVisualStyleBackColor = true;
            addPicturebutton.Click += new EventHandler(addPicturebutton_Click);
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Location = new Point(9, 118);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(297, 154);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 41;
            pictureBox.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 92);
            label6.Name = "label6";
            label6.Size = new Size(43, 13);
            label6.TabIndex = 40;
            label6.Text = "Picture:";
            // 
            // label4
            // 
            label4.Location = new Point(6, 14);
            label4.Name = "label4";
            label4.Size = new Size(77, 23);
            label4.TabIndex = 39;
            label4.Text = "Difficutly level";
            // 
            // difficutlyLevelcomboBox
            // 
            difficutlyLevelcomboBox.FormattingEnabled = true;
            difficutlyLevelcomboBox.Location = new Point(89, 11);
            difficutlyLevelcomboBox.Name = "difficutlyLevelcomboBox";
            difficutlyLevelcomboBox.Size = new Size(217, 21);
            difficutlyLevelcomboBox.TabIndex = 38;
            // 
            // label1
            // 
            label1.Location = new Point(6, 68);
            label1.Name = "label1";
            label1.Size = new Size(77, 23);
            label1.TabIndex = 37;
            label1.Text = "Sub type:";
            // 
            // subTypecomboBox
            // 
            subTypecomboBox.FormattingEnabled = true;
            subTypecomboBox.Location = new Point(89, 65);
            subTypecomboBox.Name = "subTypecomboBox";
            subTypecomboBox.Size = new Size(217, 21);
            subTypecomboBox.TabIndex = 36;
            subTypecomboBox.SelectedIndexChanged += new EventHandler(subTypecomboBox_SelectedIndexChanged);
            // 
            // typelabel
            // 
            typelabel.Location = new Point(6, 41);
            typelabel.Name = "typelabel";
            typelabel.Size = new Size(51, 23);
            typelabel.TabIndex = 35;
            typelabel.Text = "Type:";
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(89, 38);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(217, 21);
            typeComboBox.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 16);
            label2.Name = "label2";
            label2.Size = new Size(31, 13);
            label2.TabIndex = 33;
            label2.Text = "Text:";
            // 
            // textTextBox
            // 
            textTextBox.Location = new Point(6, 41);
            textTextBox.Multiline = true;
            textTextBox.Name = "textTextBox";
            textTextBox.Size = new Size(441, 232);
            textTextBox.TabIndex = 32;
            textTextBox.TextChanged += new EventHandler(textTextBox_TextChanged);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(addAnswerFormula);
            groupBox2.Controls.Add(answersDataGridView);
            groupBox2.Controls.Add(addNewButton);
            groupBox2.Controls.Add(removeButton);
            groupBox2.FlatStyle = FlatStyle.System;
            groupBox2.Location = new Point(6, 288);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(771, 341);
            groupBox2.TabIndex = 47;
            groupBox2.TabStop = false;
            groupBox2.Text = "Answers";
            // 
            // addAnswerFormula
            // 
            addAnswerFormula.Enabled = false;
            addAnswerFormula.Location = new Point(8, 16);
            addAnswerFormula.Name = "addAnswerFormula";
            addAnswerFormula.Size = new Size(85, 23);
            addAnswerFormula.TabIndex = 44;
            addAnswerFormula.Text = "add formula";
            addAnswerFormula.UseVisualStyleBackColor = true;
            addAnswerFormula.Click += new EventHandler(addAnswerFormula_Click);
            // 
            // answersDataGridView
            // 
            answersDataGridView.AllowUserToAddRows = false;
            answersDataGridView.AllowUserToDeleteRows = false;
            answersDataGridView.AllowUserToOrderColumns = true;
            answersDataGridView.Anchor = ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
            answersDataGridView.AutoGenerateColumns = false;
            answersDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            answersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            answersDataGridView.Columns.AddRange(new DataGridViewColumn[]
                                                     {
                                                         idDataGridViewTextBoxColumn,
                                                         questionIdDataGridViewTextBoxColumn,
                                                         textDataGridViewTextBoxColumn,
                                                         isCorrectDataGridViewCheckBoxColumn,
                                                         orderDataGridViewTextBoxColumn
                                                     });
            answersDataGridView.DataMember = "Answers";
            answersDataGridView.DataSource = data;
            answersDataGridView.Location = new Point(6, 64);
            answersDataGridView.MultiSelect = false;
            answersDataGridView.Name = "answersDataGridView";
            answersDataGridView.Size = new Size(759, 271);
            answersDataGridView.TabIndex = 11;
            answersDataGridView.CellEndEdit += new DataGridViewCellEventHandler(answersDataGridView_CellEndEdit);
            answersDataGridView.Click += new EventHandler(answersDataGridView_Click);
            answersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionIdDataGridViewTextBoxColumn
            // 
            questionIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionId";
            questionIdDataGridViewTextBoxColumn.HeaderText = "QuestionId";
            questionIdDataGridViewTextBoxColumn.Name = "questionIdDataGridViewTextBoxColumn";
            questionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // textDataGridViewTextBoxColumn
            // 
            textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            textDataGridViewTextBoxColumn.HeaderText = "Text";
            textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            textDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            textDataGridViewTextBoxColumn.Width = 300;
            // 
            // isCorrectDataGridViewCheckBoxColumn
            // 
            isCorrectDataGridViewCheckBoxColumn.DataPropertyName = "IsCorrect";
            isCorrectDataGridViewCheckBoxColumn.HeaderText = "IsCorrect";
            isCorrectDataGridViewCheckBoxColumn.Name = "isCorrectDataGridViewCheckBoxColumn";
            // 
            // orderDataGridViewTextBoxColumn
            // 
            orderDataGridViewTextBoxColumn.DataPropertyName = "Order";
            orderDataGridViewTextBoxColumn.HeaderText = "Order";
            orderDataGridViewTextBoxColumn.Name = "orderDataGridViewTextBoxColumn";
            orderDataGridViewTextBoxColumn.Visible = false;
            // 
            // addNewButton
            // 
            addNewButton.Anchor = AnchorStyles.Right;
            addNewButton.FlatStyle = FlatStyle.System;
            addNewButton.ImageIndex = 0;
            addNewButton.Location = new Point(583, 34);
            addNewButton.Name = "addNewButton";
            addNewButton.Size = new Size(88, 24);
            addNewButton.TabIndex = 8;
            addNewButton.Text = "Add &New...";
            addNewButton.Click += new EventHandler(addNewButton_Click);
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Right;
            removeButton.FlatStyle = FlatStyle.System;
            removeButton.ImageIndex = 2;
            removeButton.Location = new Point(677, 34);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(88, 24);
            removeButton.TabIndex = 9;
            removeButton.Text = "&Remove";
            removeButton.Click += new EventHandler(removeButton_Click);
            // 
            // imageList
            // 
            imageList.ImageStream = ((ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            imageList.TransparentColor = Color.Fuchsia;
            imageList.Images.SetKeyName(0, "");
            imageList.Images.SetKeyName(1, "");
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(deletePicturebutton);
            groupBox1.Controls.Add(subTypecomboBox);
            groupBox1.Controls.Add(typeComboBox);
            groupBox1.Controls.Add(typelabel);
            groupBox1.Controls.Add(addPicturebutton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pictureBox);
            groupBox1.Controls.Add(difficutlyLevelcomboBox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(465, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(312, 279);
            groupBox1.TabIndex = 48;
            groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(addFormulaButton);
            groupBox3.Controls.Add(explanationButton);
            groupBox3.Controls.Add(textTextBox);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(6, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(453, 279);
            groupBox3.TabIndex = 49;
            groupBox3.TabStop = false;
            // 
            // deletePicturebutton
            // 
            deletePicturebutton.Location = new Point(261, 92);
            deletePicturebutton.Name = "deletePicturebutton";
            deletePicturebutton.Size = new Size(45, 20);
            deletePicturebutton.TabIndex = 43;
            deletePicturebutton.Text = "delete";
            deletePicturebutton.UseVisualStyleBackColor = true;
            deletePicturebutton.Click += new EventHandler(deletePicturebutton_Click);
            // 
            // QuestionEditor
            // 
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "QuestionEditor";
            Size = new Size(782, 632);
            Load += new EventHandler(QuestionEditor_Load);
            ((ISupportInitialize) (data)).EndInit();
            ((ISupportInitialize) (pictureBox)).EndInit();
            groupBox2.ResumeLayout(false);
            ((ISupportInitialize) (answersDataGridView)).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        private byte[] picture;
        private Dataset.QuestionsExRow _questionRow;
        private Dataset dataSet;
        public int selectedPassageId = -1;
        private byte lastOrder = 0;
        //private void addPassgeToQuestionButton_Click(object sender, System.EventArgs e)
        //{
        //    SelectPassageQuestionForm selectPassage = new SelectPassageQuestionForm(dataSet, ((Question)dbObject).Value.SetId);
        //    selectPassage.ShowDialog();
        //    if (selectPassage.DialogResult == System.Windows.Forms.DialogResult.OK && selectedPassageId != -1)
        //    {
        //        passageTextBox.Text = dataSet.QuestionsEx.FindByIdSetId(selectedPassageId, ((Question)dbObject).Value.SetId).Text;
        //    }
        //}

        private bool isInit = true;

        private void QuestionEditor_Load(object sender, EventArgs e)
        {
            //dataSet = (Dataset)data.Copy();
            isInit = true;
            dataSet = (Dataset) dbObject.FullDataset.Copy();
            _questionRow = ((Question) dbObject).Value;
            textTextBox.Text = _questionRow.Text;
            int setId = _questionRow.SetId;
            difficutlyLevelcomboBox.DataSource = dataSet.DifficultyLevel;
            difficutlyLevelcomboBox.DisplayMember = "Name";
            difficutlyLevelcomboBox.SelectedIndex =
                dataSet.QuestionsEx.FindByIdSetId(_questionRow.Id, _questionRow.SetId).DifficultyLevelId - 1;
            difficutlyLevelcomboBox.Update();

            if (_questionRow.SubtypeId == 4)
            {
                subTypecomboBox.Enabled = false;
            }

            typeComboBox.DataSource = dataSet.QuestionTypes;
            typeComboBox.DisplayMember = "Name";
            typeComboBox.ValueMember = "id";
            typeComboBox.SelectedValue = dataSet.QuestionsEx.FindByIdSetId(_questionRow.Id, _questionRow.SetId).TypeId;
            typeComboBox.Update();

            subTypecomboBox.DataSource = dataSet.QuestionSubtypes;
            subTypecomboBox.DisplayMember = "Name";
            subTypecomboBox.ValueMember = "id";
            subTypecomboBox.SelectedValue = dataSet.QuestionsEx.FindByIdSetId(_questionRow.Id, _questionRow.SetId).SubtypeId;
            subTypecomboBox.Update();

            if (!_questionRow.IsPictureNull())
            {
                File.WriteAllBytes(Application.StartupPath + @"\templates\Picture.bmp", _questionRow.Picture);
                //pictureBox.Image = Image.FromFile(Application.StartupPath + @"\templates\Picture.bmp");
                pictureBox.ImageLocation = Application.StartupPath + @"\templates\Picture.bmp";
                addPicturebutton.Text = "edit";
                picture = _questionRow.Picture;
            }

            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionTypeIdNull())
            {
                typeComboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(_questionRow.Id, _questionRow.SetId).TypeId - 1;
                typeComboBox.Update();
                typeComboBox.Enabled = false;
            }

            if (dbObject.Parent is PassageQuestion)
            {
                subTypecomboBox.Enabled = false;
            }
            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionSubtypeIdNull())
            {
                subTypecomboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(_questionRow.Id, _questionRow.SetId).SubtypeId - 1;
                subTypecomboBox.Update();
                subTypecomboBox.Enabled = false;
            }


            for (int i = 0; i < dataSet.Answers.Count; ++i)
            {
                if (dataSet.Answers[i].QuestionId != Id)
                {
                    dataSet.Answers[i].Delete();
                }
                else
                {
                    lastOrder++;
                }
            }

            if (textTextBox.Text.LastIndexOf("<math display = \"block\">") != -1)
            {
                textTextBox.Enabled = false;
                addFormulaButton.Text = "edit question with formulas";
            }
            answersDataGridView.DataSource = dataSet;
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            answersDataGridView.Sort(answersDataGridView.Columns[orderDataGridViewTextBoxColumn.Index], direction);
            isInit = false;
        }

        public override String ObjectName
        {
            get { return "question '" + BuisinessObjects.TypeNames[((Question)dbObject).Value.TypeId] + "'"; }
        }

        private void subTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                return;
            }
            if ((subTypecomboBox.SelectedIndex == 3) && (subTypecomboBox.Enabled)) //Question to passage
            {
                if (
                    MessageBox.Show("Convert question to 'Reading Comprehension - Question to Passage'?", APP_CAPTION,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SelectPassageQuestionForm selectPassage =
                        new SelectPassageQuestionForm(dbObject.FullDataset, _questionRow.SetId);
                    if (selectPassage.ShowDialog() == DialogResult.OK)
                    {
                        Close(true);
                        selectedPassageId = selectPassage.selectedPassageId;
                        dbObject.FullDataset.PassagesToQuestionsEx.AddPassagesToQuestionsExRow(
                            dbObject.FullDataset.QuestionsEx.FindByIdSetId(selectedPassageId, _questionRow.SetId).Text,
                            selectedPassageId, Id);
                        dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, _questionRow.SetId).SubtypeId = 4;
                        PassageQuestion qse =
                            new PassageQuestion(
                                dbObject.FullDataset.QuestionsEx.FindByIdSetId(selectedPassageId, _questionRow.SetId),
                                dbObject.GetConnection(), dbObject.Parent);
                        ApplicationController.Instance.Edit(qse);
                    }
                    else
                    {
                        //MessageBox.Show("Convert question to 'Reading Comprehension - Question to Passage'?", APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        subTypecomboBox.SelectedIndex =
                            dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, _questionRow.SetId).SubtypeId - 1;
                    }
                }
                else
                {
                    subTypecomboBox.SelectedIndex =
                        dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, _questionRow.SetId).SubtypeId - 1;
                }
                return;
            }
            else
            {
                _questionRow.Text = textTextBox.Text + "";
            }
            if ((subTypecomboBox.SelectedIndex == 2) && (subTypecomboBox.Enabled)) //Question to passage
            {
                if (
                    MessageBox.Show("Convert question to 'Reading Comprehension - Passage'?", APP_CAPTION,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Close(true);
                    dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, _questionRow.SetId).SubtypeId = 3;
                    PassageQuestion qse =
                        new PassageQuestion(dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, _questionRow.SetId),
                                            dbObject.GetConnection(), dbObject.Parent);
                    ApplicationController.Instance.Edit(qse);
                    //
                }
                else
                {
                    subTypecomboBox.SelectedIndex =
                        dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, _questionRow.SetId).SubtypeId - 1;
                }
                return;
            }
            else
            {
                _questionRow.Text = textTextBox.Text + "";
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
                //Image image = Image.FromFile(Application.StartupPath + @"\templates\Picture.bmp");
                if (temlatePicture != picture)
                {
                    picture = File.ReadAllBytes(Application.StartupPath + @"\templates\Picture.bmp");
                    pictureBox.ImageLocation = Application.StartupPath + @"\templates\Picture.bmp";
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
                picture = File.ReadAllBytes(Application.StartupPath + @"\templates\Picture.bmp");
                //Image image = Image.FromFile(Application.StartupPath + @"\templates\Picture.bmp");
            }
            // dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Picture = picture;
            pictureBox.ImageLocation = Application.StartupPath + @"\templates\Picture.bmp";
            _questionRow.Text = textTextBox.Text + "";
        }

        private void answersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isInit)
            {
                return;
            }
            if (e.ColumnIndex == textDataGridViewTextBoxColumn.Index)
            {
                dataSet.Answers.FindById(
                    Convert.ToInt32(answersDataGridView.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value))
                    .Text =
                    answersDataGridView.Rows[e.RowIndex].Cells[textDataGridViewTextBoxColumn.Index].Value.ToString();
                if (_questionRow.RowState == DataRowState.Unchanged)
                {
                    _questionRow.SetModified();
                }
                //dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Text = answersDataGridView.Rows[e.RowIndex].Cells[textDataGridViewTextBoxColumn.Index].Value.ToString();
                return;
            }

            if (e.ColumnIndex == isCorrectDataGridViewCheckBoxColumn.Index)
            {
                if (_questionRow.RowState == DataRowState.Unchanged)
                {
                    _questionRow.SetModified();
                }
                //bool isCorrect = Convert.ToBoolean(answersDataGridView.Rows[e.RowIndex].Cells[isCorrectDataGridViewCheckBoxColumn.Index].Value);
                //for (int i = 0; i < dataSet.Answers.Count; ++i)
                //{
                //    if (dataSet.Answers[i].RowState != DataRowState.Deleted)
                //    {
                //        if (dataSet.Answers[i].IsCorrect)
                //        {
                //            dataSet.Answers[i].IsCorrect = false;
                //        }
                //    }
                //}
                //dataSet.Answers.FindById(Convert.ToInt32(answersDataGridView.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).IsCorrect = isCorrect;
                //dbObject.FullDataset.Answers.FindById(Convert.ToInt32(answersDataGridView.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).IsCorrect = isCorrect;
            }
            answersDataGridView.Update();
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            dataSet.Answers.AddAnswersRow(_questionRow.Id, "New answer", false, lastOrder);
            //dbObject.FullDataset.Answers.AddAnswersRow(value.Id, "New answer", false, lastOrder);
            lastOrder++;
            _questionRow.Text = textTextBox.Text + "";
            answersDataGridView.Update();
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
                    textTextBox.Text = formula;
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
            _questionRow.Text = textTextBox.Text;
            // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
        }

        private int[] deletedId;
        private int deletedCount = 0;
        public static string APP_CAPTION = "GMAT Club Test - Database Editor";

        private void removeButton_Click(object sender, EventArgs e)
        {
            deletedId = new int[data.Answers.Count];
            DataGridView gw = answersDataGridView;
            if (gw.SelectedRows.Count == 0)
            {
                MessageBox.Show("No selected answer.", APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedRowIndex = gw.SelectedRows[0].Index;
            // �Do you really want to remove the answer?�
            if (
                MessageBox.Show("Do you really want to remove the answer?", "Remove the answer", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int answerId =
                    Convert.ToInt32(gw.Rows[gw.SelectedRows[0].Index].Cells[idDataGridViewTextBoxColumn.Index].Value);
                deletedId[deletedCount] = answerId;
                deletedCount++;
                if (selectedRowIndex != gw.Rows.Count - 1)
                {
                    for (int i = selectedRowIndex + 1; i < gw.Rows.Count; ++i)
                    {
                        gw.Rows[i].Cells[orderDataGridViewTextBoxColumn.Index].Value =
                            Convert.ToInt32(gw.Rows[i].Cells[orderDataGridViewTextBoxColumn.Index].Value) - 1;
                    }
                }
                dataSet.Answers.FindById(
                    Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Delete();
                //dbObject.FullDataset.Answers.FindById(Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Delete();
                gw.Update();
                _questionRow.Text = textTextBox.Text;
                lastOrder--;
            }
        }
               

        void explanationButton_Click(object sender, EventArgs e)
        {
            EplanationForm eplanationForm = new EplanationForm(Convert.ToString(_questionRow.explanation));
            if(eplanationForm.ShowDialog() == DialogResult.OK)
            {
                _questionRow.explanation = eplanationForm.EplanationText;
            }
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                return;
            }
            // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
            _questionRow.Text = textTextBox.Text + "";
        }

        private void addAnswerFormula_Click(object sender, EventArgs e)
        {
            DataGridView gw = answersDataGridView;
            if (gw.SelectedRows.Count != 0)
            {
                string formulatorPath = "";
                try
                {
                    formulatorPath =
                        (String)
                        Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Hermitech Laboratory\Formulator\Settings\").GetValue
                            (@"path");
                }
                catch
                {
                    MessageBox.Show("Formulator not installeted! Plese reinstall this application.", "Formulator",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Dataset.AnswersRow answerRow =
                    dataSet.Answers.FindById((int) gw.SelectedRows[0].Cells[idDataGridViewTextBoxColumn.Index].Value);
                if (
                    MessageBox.Show("Convert simple answer to answe with formulas?", "Formulator",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (answerRow.Text.LastIndexOf("<math display = \"block\">") == -1)
                    {
                        answerRow.Text =
                            answerRow.Text.Insert(0, "<math display = 'block'><mrow><mi mathvariant = 'italic'>");
                        answerRow.Text = answerRow.Text.Insert(answerRow.Text.Length, "</mi></mrow></math>");
                    }
                    File.WriteAllText(Application.StartupPath + @"\question.xml", answerRow.Text);
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.Arguments = "\"" + Application.StartupPath + @"\question.xml" + "\"";
                    pInfo.FileName = formulatorPath + "Formulator.exe";
                    Process p = Process.Start(pInfo);
                    while (!p.HasExited)
                    {
                        Thread.Sleep(10);
                    }
                    string formula = File.ReadAllText(Application.StartupPath + @"\question.xml");
                    textTextBox.Text = formula;
                    //  addFormulaButton.Text = "edit question with formulas";
                    textTextBox.Enabled = false;
                }

                //value.Text = textTextBox.Text;
            }
        }

        private void answersDataGridView_Click(object sender, EventArgs e)
        {
            if (isInit)
            {
                return;
            }
            DataGridView gw = answersDataGridView;
            if (gw.SelectedRows.Count != 0)
            {
                addAnswerFormula.Enabled = true;
            }
            else
            {
                addAnswerFormula.Enabled = false;
            }
        }

        private void deletePicturebutton_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Do you really want to delelete the picture?", "Delete picture?",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                picture = null;
                pictureBox.Image = null;
            }
        }
    }
}