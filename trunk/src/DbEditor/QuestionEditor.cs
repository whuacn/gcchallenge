using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor
{
    class QuestionEditor : Editor
    {
        private System.Windows.Forms.Button addFormulaButton;
        private System.Windows.Forms.Button addPicturebutton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox difficutlyLevelcomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox subTypecomboBox;
        private System.Windows.Forms.Label typelabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView answersDataGridView;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ImageList imageList;
        private System.ComponentModel.IContainer components;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCorrectDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private Button addAnswerFormula;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Button deletePicturebutton;
        private System.Windows.Forms.TextBox textTextBox;

        public QuestionEditor(Question question): base(question)
		{
           InitializeComponent();
        }

        public override int Id
        {
            get { return ((Question)dbObject).Value.Id; }
        }

        public override void SaveCurrentEdit()
        {
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).DifficultyLevelId = difficutlyLevelcomboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).TypeId = typeComboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).SubtypeId = subTypecomboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Text = textTextBox.Text;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Picture = picture;
            byte order = 0;

            for (int i = 0; i < dataSet.Answers.Count; ++i)
            {
                if (dataSet.Answers[i].RowState == DataRowState.Deleted)
                {
                    continue;
                }

                if (dataSet.Answers[i].QuestionId != value.Id)
                {
                    continue;
                }

                if (dataSet.Answers[i].RowState == DataRowState.Added)
                {
                    dbObject.FullDataset.Answers.AddAnswersRow(value.Id, dataSet.Answers[i].Text, dataSet.Answers[i].IsCorrect, order);
                    order++;
                }

                if (dataSet.Answers[i].RowState == DataRowState.Modified)
                {
                    dbObject.FullDataset.Answers.FindById(dataSet.Answers[i].Id).Text = dataSet.Answers[i].Text;
                    dbObject.FullDataset.Answers.FindById(dataSet.Answers[i].Id).IsCorrect = dataSet.Answers[i].IsCorrect;
                    order++;
                    continue;
                }
            }
        }
        
        public override void SetBindingPosition()
        {
            int pos = 0;
            Question d = ((Question)dbObject);
            foreach (Dataset.QuestionsExRow row in dbObject.FullDataset.QuestionsEx.Rows)
            {
                if(row.RowState == DataRowState.Deleted){continue;}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionEditor));
            this.addFormulaButton = new System.Windows.Forms.Button();
            this.addPicturebutton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.difficutlyLevelcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subTypecomboBox = new System.Windows.Forms.ComboBox();
            this.typelabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addAnswerFormula = new System.Windows.Forms.Button();
            this.answersDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCorrectDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.orderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addNewButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.deletePicturebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // addFormulaButton
            // 
            this.addFormulaButton.Location = new System.Drawing.Point(41, 11);
            this.addFormulaButton.Name = "addFormulaButton";
            this.addFormulaButton.Size = new System.Drawing.Size(85, 23);
            this.addFormulaButton.TabIndex = 43;
            this.addFormulaButton.Text = "add formula";
            this.addFormulaButton.UseVisualStyleBackColor = true;
            this.addFormulaButton.Click += new System.EventHandler(this.addFormulaButton_Click);
            // 
            // addPicturebutton
            // 
            this.addPicturebutton.Location = new System.Drawing.Point(210, 92);
            this.addPicturebutton.Name = "addPicturebutton";
            this.addPicturebutton.Size = new System.Drawing.Size(45, 20);
            this.addPicturebutton.TabIndex = 42;
            this.addPicturebutton.Text = "add";
            this.addPicturebutton.UseVisualStyleBackColor = true;
            this.addPicturebutton.Click += new System.EventHandler(this.addPicturebutton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(9, 118);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(297, 154);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 41;
            this.pictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Picture:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 39;
            this.label4.Text = "Difficutly level";
            // 
            // difficutlyLevelcomboBox
            // 
            this.difficutlyLevelcomboBox.FormattingEnabled = true;
            this.difficutlyLevelcomboBox.Location = new System.Drawing.Point(89, 11);
            this.difficutlyLevelcomboBox.Name = "difficutlyLevelcomboBox";
            this.difficutlyLevelcomboBox.Size = new System.Drawing.Size(217, 21);
            this.difficutlyLevelcomboBox.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Sub type:";
            // 
            // subTypecomboBox
            // 
            this.subTypecomboBox.FormattingEnabled = true;
            this.subTypecomboBox.Location = new System.Drawing.Point(89, 65);
            this.subTypecomboBox.Name = "subTypecomboBox";
            this.subTypecomboBox.Size = new System.Drawing.Size(217, 21);
            this.subTypecomboBox.TabIndex = 36;
            this.subTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.subTypecomboBox_SelectedIndexChanged);
            // 
            // typelabel
            // 
            this.typelabel.Location = new System.Drawing.Point(6, 41);
            this.typelabel.Name = "typelabel";
            this.typelabel.Size = new System.Drawing.Size(51, 23);
            this.typelabel.TabIndex = 35;
            this.typelabel.Text = "Type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(89, 38);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(217, 21);
            this.typeComboBox.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Text:";
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(6, 41);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(441, 232);
            this.textTextBox.TabIndex = 32;
            this.textTextBox.TextChanged += new System.EventHandler(this.textTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addAnswerFormula);
            this.groupBox2.Controls.Add(this.answersDataGridView);
            this.groupBox2.Controls.Add(this.addNewButton);
            this.groupBox2.Controls.Add(this.removeButton);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(6, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 341);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Answers";
            // 
            // addAnswerFormula
            // 
            this.addAnswerFormula.Enabled = false;
            this.addAnswerFormula.Location = new System.Drawing.Point(8, 16);
            this.addAnswerFormula.Name = "addAnswerFormula";
            this.addAnswerFormula.Size = new System.Drawing.Size(85, 23);
            this.addAnswerFormula.TabIndex = 44;
            this.addAnswerFormula.Text = "add formula";
            this.addAnswerFormula.UseVisualStyleBackColor = true;
            this.addAnswerFormula.Click += new System.EventHandler(this.addAnswerFormula_Click);
            // 
            // answersDataGridView
            // 
            this.answersDataGridView.AllowUserToAddRows = false;
            this.answersDataGridView.AllowUserToDeleteRows = false;
            this.answersDataGridView.AllowUserToOrderColumns = true;
            this.answersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.answersDataGridView.AutoGenerateColumns = false;
            this.answersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.answersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.questionIdDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.isCorrectDataGridViewCheckBoxColumn,
            this.orderDataGridViewTextBoxColumn});
            this.answersDataGridView.DataMember = "Answers";
            this.answersDataGridView.DataSource = this.data;
            this.answersDataGridView.Location = new System.Drawing.Point(6, 64);
            this.answersDataGridView.MultiSelect = false;
            this.answersDataGridView.Name = "answersDataGridView";
            this.answersDataGridView.Size = new System.Drawing.Size(759, 271);
            this.answersDataGridView.TabIndex = 11;
            this.answersDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.answersDataGridView_CellEndEdit);
            this.answersDataGridView.Click += new System.EventHandler(this.answersDataGridView_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionIdDataGridViewTextBoxColumn
            // 
            this.questionIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionId";
            this.questionIdDataGridViewTextBoxColumn.HeaderText = "QuestionId";
            this.questionIdDataGridViewTextBoxColumn.Name = "questionIdDataGridViewTextBoxColumn";
            this.questionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.textDataGridViewTextBoxColumn.Width = 300;
            // 
            // isCorrectDataGridViewCheckBoxColumn
            // 
            this.isCorrectDataGridViewCheckBoxColumn.DataPropertyName = "IsCorrect";
            this.isCorrectDataGridViewCheckBoxColumn.HeaderText = "IsCorrect";
            this.isCorrectDataGridViewCheckBoxColumn.Name = "isCorrectDataGridViewCheckBoxColumn";
            // 
            // orderDataGridViewTextBoxColumn
            // 
            this.orderDataGridViewTextBoxColumn.DataPropertyName = "Order";
            this.orderDataGridViewTextBoxColumn.HeaderText = "Order";
            this.orderDataGridViewTextBoxColumn.Name = "orderDataGridViewTextBoxColumn";
            this.orderDataGridViewTextBoxColumn.Visible = false;
            // 
            // addNewButton
            // 
            this.addNewButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addNewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewButton.ImageIndex = 0;
            this.addNewButton.Location = new System.Drawing.Point(583, 34);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(88, 24);
            this.addNewButton.TabIndex = 8;
            this.addNewButton.Text = "Add &New...";
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeButton.ImageIndex = 2;
            this.removeButton.Location = new System.Drawing.Point(677, 34);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(88, 24);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "&Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deletePicturebutton);
            this.groupBox1.Controls.Add(this.subTypecomboBox);
            this.groupBox1.Controls.Add(this.typeComboBox);
            this.groupBox1.Controls.Add(this.typelabel);
            this.groupBox1.Controls.Add(this.addPicturebutton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.difficutlyLevelcomboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(465, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 279);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addFormulaButton);
            this.groupBox3.Controls.Add(this.textTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 279);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            // 
            // deletePicturebutton
            // 
            this.deletePicturebutton.Location = new System.Drawing.Point(261, 92);
            this.deletePicturebutton.Name = "deletePicturebutton";
            this.deletePicturebutton.Size = new System.Drawing.Size(45, 20);
            this.deletePicturebutton.TabIndex = 43;
            this.deletePicturebutton.Text = "delete";
            this.deletePicturebutton.UseVisualStyleBackColor = true;
            this.deletePicturebutton.Click += new System.EventHandler(this.deletePicturebutton_Click);
            // 
            // QuestionEditor
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "QuestionEditor";
            this.Size = new System.Drawing.Size(782, 632);
            this.Load += new System.EventHandler(this.QuestionEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }
        
        private byte[] picture;
        private Dataset.QuestionsExRow value;
        private Dataset dataSet;
        public int selectedPassageId = -1;
        byte lastOrder=0;
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
        private void QuestionEditor_Load(object sender, System.EventArgs e)
        {
            
            //dataSet = (Dataset)data.Copy();
            isInit = true;
            dataSet = (Dataset)dbObject.FullDataset.Copy();
            value = ((Question)dbObject).Value;
            textTextBox.Text = value.Text;
            int setId = value.SetId;
            difficutlyLevelcomboBox.DataSource = dataSet.DifficultyLevel;
            difficutlyLevelcomboBox.DisplayMember = "Name";
            difficutlyLevelcomboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(value.Id, value.SetId).DifficultyLevelId - 1;
            difficutlyLevelcomboBox.Update();

            if (value.SubtypeId == 4)
            {
                subTypecomboBox.Enabled = false;
            }
           
            typeComboBox.DataSource = dataSet.QuestionTypes;
            typeComboBox.DisplayMember = "Name";
            typeComboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(value.Id, value.SetId).TypeId - 1;
            typeComboBox.Update();

            subTypecomboBox.DataSource = dataSet.QuestionSubtypes;
            subTypecomboBox.DisplayMember = "Name";
            subTypecomboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(value.Id, value.SetId).SubtypeId - 1;
            subTypecomboBox.Update();

            if(!value.IsPictureNull())
            {
                File.WriteAllBytes(Application.StartupPath + @"\templates\Picture.bmp", value.Picture);
                //pictureBox.Image = Image.FromFile(Application.StartupPath + @"\templates\Picture.bmp");
                pictureBox.ImageLocation = Application.StartupPath + @"\templates\Picture.bmp";
                addPicturebutton.Text = "edit";
                picture = value.Picture;
            }
            
            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionTypeIdNull())
            {
                typeComboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(value.Id, value.SetId).TypeId - 1;
                typeComboBox.Update();
                typeComboBox.Enabled = false;
            }

            if(dbObject.Parent is PassageQuestion)
            {
                subTypecomboBox.Enabled = false; 
            }
            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionSubtypeIdNull())
            {
                subTypecomboBox.SelectedIndex = dataSet.QuestionsEx.FindByIdSetId(value.Id, value.SetId).SubtypeId - 1;
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
            
            if(textTextBox.Text.LastIndexOf("<math display = \"block\">") != -1)
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
            get { return "question '" + QuestionType.TypeNames[((Question)dbObject).Value.TypeId] + "'"; }
        }
        
        private void subTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isInit){return;}
            if ((subTypecomboBox.SelectedIndex == 3) && (subTypecomboBox.Enabled))//Question to passage
            {
                if (MessageBox.Show("Convert question to 'Reading Comprehension - Question to Passage'?", APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SelectPassageQuestionForm selectPassage = new SelectPassageQuestionForm(dbObject.FullDataset, value.SetId);
                    if(selectPassage.ShowDialog() == DialogResult.OK)
                    {
                        this.Close(true);
                        selectedPassageId = selectPassage.selectedPassageId;
                        dbObject.FullDataset.PassagesToQuestionsEx.AddPassagesToQuestionsExRow(dbObject.FullDataset.QuestionsEx.FindByIdSetId(selectedPassageId, value.SetId).Text, selectedPassageId, Id);
                        dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).SubtypeId = 4;
                        PassageQuestion qse = new PassageQuestion(dbObject.FullDataset.QuestionsEx.FindByIdSetId(selectedPassageId, value.SetId), dbObject.GetConnection(), dbObject.Parent);
                        ApplicationController.Instance.Edit(qse);
                        
                        
                    }else
                    {   
                        //MessageBox.Show("Convert question to 'Reading Comprehension - Question to Passage'?", APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        subTypecomboBox.SelectedIndex = dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).SubtypeId - 1;
                    }
                }
                else
                {
                    subTypecomboBox.SelectedIndex = dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).SubtypeId-1;
                }
                return;
            }else
            {
                value.Text = textTextBox.Text + "";
            }
            if ((subTypecomboBox.SelectedIndex == 2) && (subTypecomboBox.Enabled))//Question to passage
            {
                if (MessageBox.Show("Convert question to 'Reading Comprehension - Passage'?", APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close(true);
                    dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).SubtypeId = 3;
                    PassageQuestion qse = new PassageQuestion(dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId), dbObject.GetConnection(), dbObject.Parent);
                    ApplicationController.Instance.Edit(qse);
                    //
                }
                else
                {
                    subTypecomboBox.SelectedIndex = dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).SubtypeId - 1;
                }
                return;
            }
            else
            {
                value.Text = textTextBox.Text + "";
            }
            
        }

        
        private void addPicturebutton_Click(object sender, System.EventArgs e)
        {
            if (addPicturebutton.Text != "edit")
            {
                File.Copy(Application.StartupPath + @"\templates\newPicture.bmp", Application.StartupPath + @"\templates\Picture.bmp", true);
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
            value.Text = textTextBox.Text + "";
        }

        private void answersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isInit) { return; }
            if (e.ColumnIndex == textDataGridViewTextBoxColumn.Index)
            {
                dataSet.Answers.FindById(Convert.ToInt32(answersDataGridView.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Text = answersDataGridView.Rows[e.RowIndex].Cells[textDataGridViewTextBoxColumn.Index].Value.ToString();
                value.SetModified();
               //dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Text = answersDataGridView.Rows[e.RowIndex].Cells[textDataGridViewTextBoxColumn.Index].Value.ToString();
                return;
            }

            if (e.ColumnIndex == isCorrectDataGridViewCheckBoxColumn.Index)
            {
                if (value.RowState == DataRowState.Unchanged)
                {
                    value.SetModified();
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
            dataSet.Answers.AddAnswersRow(value.Id, "New answer", false, lastOrder);
            //dbObject.FullDataset.Answers.AddAnswersRow(value.Id, "New answer", false, lastOrder);
            lastOrder++;
            value.Text = textTextBox.Text + "";
            answersDataGridView.Update();
        }

        private void addFormulaButton_Click(object sender, EventArgs e)
        {
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
            if (addFormulaButton.Text != "edit question with formulas")
            {
                if (MessageBox.Show("Convert simple question to question with formulas?", "Formulator", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            value.Text = textTextBox.Text;
           // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
        }
        private int[] deletedId;
        private int deletedCount = 0;
        public static string APP_CAPTION = "GMAT Club Test - Database Editor";
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
           // “Do you really want to remove the answer?”
            if (MessageBox.Show("Do you really want to remove the answer?", "Remove the answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int answerId = Convert.ToInt32(gw.Rows[gw.SelectedRows[0].Index].Cells[idDataGridViewTextBoxColumn.Index].Value);
                deletedId[deletedCount] = answerId;
                deletedCount++;
                if (selectedRowIndex != gw.Rows.Count - 1)
                {
                    for (int i = selectedRowIndex + 1; i < gw.Rows.Count; ++i)
                    {
                        gw.Rows[i].Cells[orderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(gw.Rows[i].Cells[orderDataGridViewTextBoxColumn.Index].Value) - 1;
                    }
                }
                dataSet.Answers.FindById(Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Delete();
                //dbObject.FullDataset.Answers.FindById(Convert.ToInt32(gw.Rows[selectedRowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value)).Delete();
                gw.Update();
                value.Text = textTextBox.Text;
                lastOrder--;
            }
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isInit) { return; }
           // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
            value.Text = textTextBox.Text + "";
        }

        private void addAnswerFormula_Click(object sender, EventArgs e)
        {
            DataGridView gw = answersDataGridView;
            if (gw.SelectedRows.Count != 0)
            {
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
               Dataset.AnswersRow answerRow = dataSet.Answers.FindById((int)gw.SelectedRows[0].Cells[idDataGridViewTextBoxColumn.Index].Value);
               if (MessageBox.Show("Convert simple answer to answe with formulas?", "Formulator", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                   if (answerRow.Text.LastIndexOf("<math display = \"block\">") == -1)
                   {
                       answerRow.Text = answerRow.Text.Insert(0, "<math display = 'block'><mrow><mi mathvariant = 'italic'>");
                       answerRow.Text = answerRow.Text.Insert(answerRow.Text.Length, "</mi></mrow></math>");
                   }
                   File.WriteAllText(Application.StartupPath + @"\question.xml", answerRow.Text);
                   ProcessStartInfo pInfo = new ProcessStartInfo();
                   pInfo.Arguments = "\"" + Application.StartupPath + @"\question.xml" + "\"";
                   pInfo.FileName = formulatorPath + "Formulator.exe";
                   Process p = Process.Start(pInfo);
                   while (!p.HasExited)
                   {

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
            if (isInit) { return; }
            DataGridView gw = answersDataGridView;
            if (gw.SelectedRows.Count != 0)
            {
                addAnswerFormula.Enabled = true;
            }else
            {
                addAnswerFormula.Enabled = false;
            }
        }

        private void deletePicturebutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delelete the picture?", "Delete picture?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                picture = null;
                pictureBox.Image = null;
            }
        }
    }
}
