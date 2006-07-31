using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor
{
    class PassageQuestionEditor : Editor
    {
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.ImageList imageList;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView questionToPassageSetsDataGrid;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private DataGridViewImageColumn pictureDataGridViewImageColumn;
        private DataGridViewComboBoxColumn difficultyLevel;
        private DataGridViewComboBoxColumn TypeId;
        private DataGridViewComboBoxColumn SubtypeId;
        private DataGridViewComboBoxColumn Idpas;
        private DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subtypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn difficultyLevelIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn setIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionOrderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionZoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionIdDataGridViewTextBoxColumn;
        private GroupBox groupBox1;
        private ComboBox subTypecomboBox;
        private ComboBox typeComboBox;
        private Label label3;
        private Label label5;
        private ComboBox difficutlyLevelcomboBox;
        private GroupBox groupBox3;
        private Button addFormulaButton;
        private TextBox textTextBox;
        private Label label2;
        private Label label7;
    
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassageQuestionEditor));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.questionToPassageSetsDataGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.difficultyLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubtypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Idpas = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficultyLevelIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionZoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addNewButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subTypecomboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.difficutlyLevelcomboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addFormulaButton = new System.Windows.Forms.Button();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionToPassageSetsDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.questionToPassageSetsDataGrid);
            this.groupBox2.Controls.Add(this.addNewButton);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(6, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 300);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Questions to passage";
            // 
            // questionToPassageSetsDataGrid
            // 
            this.questionToPassageSetsDataGrid.AllowUserToAddRows = false;
            this.questionToPassageSetsDataGrid.AllowUserToDeleteRows = false;
            this.questionToPassageSetsDataGrid.AllowUserToOrderColumns = true;
            this.questionToPassageSetsDataGrid.AutoGenerateColumns = false;
            this.questionToPassageSetsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.questionToPassageSetsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionToPassageSetsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.pictureDataGridViewImageColumn,
            this.difficultyLevel,
            this.TypeId,
            this.SubtypeId,
            this.Idpas,
            this.typeIdDataGridViewTextBoxColumn,
            this.subtypeIdDataGridViewTextBoxColumn,
            this.difficultyLevelIdDataGridViewTextBoxColumn,
            this.setIdDataGridViewTextBoxColumn,
            this.questionOrderDataGridViewTextBoxColumn,
            this.questionZoneDataGridViewTextBoxColumn,
            this.questionIdDataGridViewTextBoxColumn});
            this.questionToPassageSetsDataGrid.DataMember = "QuestionsEx";
            this.questionToPassageSetsDataGrid.DataSource = this.data;
            this.questionToPassageSetsDataGrid.Location = new System.Drawing.Point(6, 46);
            this.questionToPassageSetsDataGrid.MultiSelect = false;
            this.questionToPassageSetsDataGrid.Name = "questionToPassageSetsDataGrid";
            this.questionToPassageSetsDataGrid.ReadOnly = true;
            this.questionToPassageSetsDataGrid.Size = new System.Drawing.Size(759, 248);
            this.questionToPassageSetsDataGrid.TabIndex = 13;
            this.questionToPassageSetsDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.questionToPassageSetsDataGrid_CellDoubleClick);
            this.questionToPassageSetsDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.questionToPassageSetsDataGrid_DataError);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
            this.textDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "Picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            this.pictureDataGridViewImageColumn.ReadOnly = true;
            // 
            // difficultyLevel
            // 
            this.difficultyLevel.DataPropertyName = "DifficultyLevelId";
            this.difficultyLevel.DataSource = this.data;
            this.difficultyLevel.DisplayMember = "DifficultyLevel.Name";
            this.difficultyLevel.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.difficultyLevel.HeaderText = "Difficulty level";
            this.difficultyLevel.Name = "difficultyLevel";
            this.difficultyLevel.ReadOnly = true;
            this.difficultyLevel.ValueMember = "DifficultyLevel.Id";
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.DataSource = this.data;
            this.TypeId.DisplayMember = "QuestionTypes.Name";
            this.TypeId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TypeId.HeaderText = "Type";
            this.TypeId.Name = "TypeId";
            this.TypeId.ReadOnly = true;
            this.TypeId.ValueMember = "QuestionTypes.Id";
            // 
            // SubtypeId
            // 
            this.SubtypeId.DataPropertyName = "SubtypeId";
            this.SubtypeId.DataSource = this.data;
            this.SubtypeId.DisplayMember = "QuestionSubtypes.Name";
            this.SubtypeId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SubtypeId.HeaderText = "Subtype";
            this.SubtypeId.Name = "SubtypeId";
            this.SubtypeId.ReadOnly = true;
            this.SubtypeId.ValueMember = "QuestionSubtypes.Id";
            this.SubtypeId.Width = 250;
            // 
            // Idpas
            // 
            this.Idpas.AutoComplete = false;
            this.Idpas.DataPropertyName = "QuestionId";
            this.Idpas.DataSource = this.data;
            this.Idpas.DisplayMember = "PassagesToQuestionsEx.Text";
            this.Idpas.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Idpas.HeaderText = "Passage";
            this.Idpas.Name = "Idpas";
            this.Idpas.ReadOnly = true;
            this.Idpas.ValueMember = "PassagesToQuestionsEx.Id";
            this.Idpas.Visible = false;
            this.Idpas.Width = 200;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            this.typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // subtypeIdDataGridViewTextBoxColumn
            // 
            this.subtypeIdDataGridViewTextBoxColumn.DataPropertyName = "SubtypeId";
            this.subtypeIdDataGridViewTextBoxColumn.HeaderText = "SubtypeId";
            this.subtypeIdDataGridViewTextBoxColumn.Name = "subtypeIdDataGridViewTextBoxColumn";
            this.subtypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.subtypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // difficultyLevelIdDataGridViewTextBoxColumn
            // 
            this.difficultyLevelIdDataGridViewTextBoxColumn.DataPropertyName = "DifficultyLevelId";
            this.difficultyLevelIdDataGridViewTextBoxColumn.HeaderText = "DifficultyLevelId";
            this.difficultyLevelIdDataGridViewTextBoxColumn.Name = "difficultyLevelIdDataGridViewTextBoxColumn";
            this.difficultyLevelIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.difficultyLevelIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // setIdDataGridViewTextBoxColumn
            // 
            this.setIdDataGridViewTextBoxColumn.DataPropertyName = "SetId";
            this.setIdDataGridViewTextBoxColumn.HeaderText = "SetId";
            this.setIdDataGridViewTextBoxColumn.Name = "setIdDataGridViewTextBoxColumn";
            this.setIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.setIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionOrderDataGridViewTextBoxColumn
            // 
            this.questionOrderDataGridViewTextBoxColumn.DataPropertyName = "QuestionOrder";
            this.questionOrderDataGridViewTextBoxColumn.HeaderText = "QuestionOrder";
            this.questionOrderDataGridViewTextBoxColumn.Name = "questionOrderDataGridViewTextBoxColumn";
            this.questionOrderDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionOrderDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionZoneDataGridViewTextBoxColumn
            // 
            this.questionZoneDataGridViewTextBoxColumn.DataPropertyName = "QuestionZone";
            this.questionZoneDataGridViewTextBoxColumn.HeaderText = "QuestionZone";
            this.questionZoneDataGridViewTextBoxColumn.Name = "questionZoneDataGridViewTextBoxColumn";
            this.questionZoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionZoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionIdDataGridViewTextBoxColumn
            // 
            this.questionIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionId";
            this.questionIdDataGridViewTextBoxColumn.HeaderText = "QuestionId";
            this.questionIdDataGridViewTextBoxColumn.Name = "questionIdDataGridViewTextBoxColumn";
            this.questionIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // addNewButton
            // 
            this.addNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewButton.ImageIndex = 0;
            this.addNewButton.Location = new System.Drawing.Point(677, 16);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(88, 24);
            this.addNewButton.TabIndex = 8;
            this.addNewButton.Text = "Add &New...";
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
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
            this.groupBox1.Controls.Add(this.subTypecomboBox);
            this.groupBox1.Controls.Add(this.typeComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.difficutlyLevelcomboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(465, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 96);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            // 
            // subTypecomboBox
            // 
            this.subTypecomboBox.FormattingEnabled = true;
            this.subTypecomboBox.Location = new System.Drawing.Point(89, 65);
            this.subTypecomboBox.Name = "subTypecomboBox";
            this.subTypecomboBox.Size = new System.Drawing.Size(217, 21);
            this.subTypecomboBox.TabIndex = 36;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(89, 38);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(217, 21);
            this.typeComboBox.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Type:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 37;
            this.label5.Text = "Sub type:";
            // 
            // difficutlyLevelcomboBox
            // 
            this.difficutlyLevelcomboBox.FormattingEnabled = true;
            this.difficutlyLevelcomboBox.Location = new System.Drawing.Point(89, 11);
            this.difficutlyLevelcomboBox.Name = "difficutlyLevelcomboBox";
            this.difficutlyLevelcomboBox.Size = new System.Drawing.Size(217, 21);
            this.difficutlyLevelcomboBox.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 23);
            this.label7.TabIndex = 39;
            this.label7.Text = "Difficutly level";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addFormulaButton);
            this.groupBox3.Controls.Add(this.textTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(453, 279);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            // 
            // addFormulaButton
            // 
            this.addFormulaButton.Location = new System.Drawing.Point(41, 11);
            this.addFormulaButton.Name = "addFormulaButton";
            this.addFormulaButton.Size = new System.Drawing.Size(85, 23);
            this.addFormulaButton.TabIndex = 43;
            this.addFormulaButton.Text = "add formula";
            this.addFormulaButton.UseVisualStyleBackColor = true;
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(6, 41);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(441, 232);
            this.textTextBox.TabIndex = 32;
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
            // PassageQuestionEditor
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "PassageQuestionEditor";
            this.Size = new System.Drawing.Size(780, 594);
            this.Load += new System.EventHandler(this.PassageQuestionEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionToPassageSetsDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        public override int Id
        {
            get { return ((PassageQuestion)dbObject).Value.Id; }
        }

        public override String ObjectName
        {
            get { return "passage question '" + QuestionType.TypeNames[((PassageQuestion)dbObject).Value.TypeId] + "'"; }
        }
        public PassageQuestionEditor(PassageQuestion question): base(question)
		{
			InitializeComponent();
            value = question.Value;
		}

        public override void SetBindingPosition()
        {
            int pos = 0;
            PassageQuestion d = ((PassageQuestion)dbObject);
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
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).DifficultyLevelId = difficutlyLevelcomboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).TypeId = typeComboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).SubtypeId = subTypecomboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Text = textTextBox.Text;
            for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; ++i)
            {
                if (dbObject.FullDataset.QuestionsEx[i].SubtypeId != 4) { continue; }
                if (dbObject.FullDataset.QuestionsEx[i].SetId != Id) { continue; }
                try
                {
                    if (dataSet.QuestionsEx.FindByIdSetId(dbObject.FullDataset.QuestionsEx[i].Id, Id).RowState == DataRowState.Deleted)
                    {
                        dbObject.FullDataset.QuestionsEx[i].Delete();
                    }
                }
                catch { dbObject.FullDataset.QuestionsEx[i].Delete(); }
            }
        }


        private Dataset.QuestionsExRow value;
        private Dataset dataSet;
        public int selectedPassageId = -1;
        byte lastOrder = 0;
        bool isInit = true;
        private void PassageQuestionEditor_Load(object sender, EventArgs e)
        {
            isInit = true;
            dataSet = (Dataset)dbObject.FullDataset.Copy();
            //value = ((PassageQuestion)dbObject).Value;
            textTextBox.Text = value.Text;
            int setId = value.SetId;

            difficutlyLevelcomboBox.DataSource = dataSet.DifficultyLevel;
            difficutlyLevelcomboBox.DisplayMember = "Name";
            difficutlyLevelcomboBox.SelectedIndex = value.DifficultyLevelId - 1;
            difficutlyLevelcomboBox.Update();

            typeComboBox.DataSource = dataSet.QuestionTypes;
            typeComboBox.DisplayMember = "Name";
            typeComboBox.SelectedIndex = value.TypeId - 1;
            typeComboBox.Update();

            subTypecomboBox.DataSource = dataSet.QuestionSubtypes;
            subTypecomboBox.DisplayMember = "Name";
            subTypecomboBox.SelectedIndex = value.SubtypeId - 1;
            subTypecomboBox.Enabled = false;
            subTypecomboBox.Update();
            
            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionTypeIdNull())
            {
                typeComboBox.SelectedIndex = value.TypeId - 1;
                typeComboBox.Update();
                typeComboBox.Enabled = false;
            }

            if (!dataSet.QuestionSetsEx.FindById(setId).IsQuestionSubtypeIdNull())
            {
                subTypecomboBox.SelectedIndex = value.SubtypeId - 1;
                subTypecomboBox.Update();
                subTypecomboBox.Enabled = false;
            }
            dataSet.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Delete();

            for (int i = 0; i < dataSet.QuestionsEx.Count; i++)
            {
                if(dataSet.QuestionsEx[i].RowState == DataRowState.Deleted){continue;}
                if (dataSet.QuestionsEx[i].SubtypeId != 4)
                {
                    dataSet.QuestionsEx[i].Delete();
                    continue;
                }
             }


             for (int i = 0; i < dataSet.PassagesToQuestionsEx.Count; ++i)
             {
                 if(dataSet.PassagesToQuestionsEx[i].Id != value.Id)
                 {
                     for (int j = 0; j < dataSet.QuestionsEx.Count; ++j)
                     {
                         if (dataSet.QuestionsEx[j].RowState == DataRowState.Deleted) { continue; }
                         if( dataSet.QuestionsEx[j].Id == dataSet.PassagesToQuestionsEx[i].PassageQuestionId)
                         {
                             dataSet.QuestionsEx[j].Delete();
                         }
                         //dataSet.QuestionsEx.FindByIdSetId(dataSet.PassagesToQuestionsEx[i].Id, value.SetId).Delete();
                     }
                     continue;
                 }
             }
            
            //for (int i = 0; i < dataSet.QuestionsEx.Count; i++)
            //{
            //    if (dataSet.QuestionsEx[i].SetId != setId)
            //    {
            //        dataSet.QuestionsEx[i].Delete();
            //        continue;
            //    }
            //    if (dataSet.QuestionsEx[i].SubtypeId != 4)
            //    {
            //        dataSet.QuestionsEx[i].Delete();
            //        continue;
            //    }
            //    if (dataSet.PassagesToQuestionsEx.FindById(dataSet.QuestionsEx[i].Id) == null)
            //    {
            //        dataSet.QuestionsEx[i].Delete();
            //        continue;
            //    }
            //    if (dataSet.PassagesToQuestionsEx.FindById(dataSet.QuestionsEx[i].Id).PassageQuestionId == Id)
            //    {
            //        dataSet.QuestionsEx[i].Delete();
            //        continue;
            //    }
            //}

            for (int i = 0; i < dataSet.PassagesToQuestionsEx.Count; ++i)
            {
                if (dataSet.PassagesToQuestionsEx[i].PassageQuestionId != Id)
                {
                    if (dataSet.QuestionsEx.FindByIdSetId(dataSet.PassagesToQuestionsEx[i].Id, setId) == null) { continue; }
                    if (dataSet.QuestionsEx.FindByIdSetId(dataSet.PassagesToQuestionsEx[i].Id, setId).RowState == DataRowState.Deleted) { continue; }

                    dataSet.QuestionsEx.FindByIdSetId(dataSet.PassagesToQuestionsEx[i].Id, setId).Delete();
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
            questionToPassageSetsDataGrid.DataSource = dataSet;
            questionToPassageSetsDataGrid.Update();
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            questionToPassageSetsDataGrid.Sort(questionToPassageSetsDataGrid.Columns[questionOrderDataGridViewTextBoxColumn.Index], direction);
            isInit = false;
        }

        private void questionToPassageSetsDataGrid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {

        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            if(isInit){return;}
            //dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
            value.Text = textTextBox.Text;
        }

        private void difficutlyLevelcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) { return; }
            //dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).DifficultyLevelId = ((ComboBox)sender).SelectedIndex + 1;
            value.DifficultyLevelId = ((ComboBox)sender).SelectedIndex + 1;
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) { return; }
           // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).TypeId = ((ComboBox)sender).SelectedIndex + 1;
            value.TypeId = ((ComboBox)sender).SelectedIndex + 1;
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
           // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
            value.Text = textTextBox.Text;
        }

        private void questionToPassageSetsDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gw = (DataGridView)sender;
            if (e.ColumnIndex == -1)
            {
                Dataset.QuestionsExRow questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId((int)gw.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value, value.SetId);
                //questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId(dbObject.FullDataset.PassagesToQuestionsEx.FindById(questionRow.Id).PassageQuestionId, Id);
                Question qse = new Question(questionRow, dbObject.GetConnection(), (PassageQuestion)(dbObject));
                ApplicationController.Instance.Edit(qse);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridView gw = questionToPassageSetsDataGrid;
           // dbObject.FullDataset.QuestionsEx.FindByIdSetId((int)gw.Rows[gw.SelectedRows[0].Index].Cells[0].Value, value.SetId).Delete();
            dataSet.QuestionsEx.FindByIdSetId((int)gw.Rows[gw.SelectedRows[0].Index].Cells[0].Value, value.SetId).Delete();
            //dbObject.FullDataset.QuestionSetsEx.FindById(Id).Name += "";
            gw.Update();
        }

      
        private void addNewButton_Click(object sender, EventArgs e)
        {
            byte order;
            try
            {
                order = (byte)questionToPassageSetsDataGrid.Rows[questionToPassageSetsDataGrid.Rows.Count - 1].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value;
            }
            catch { order = 0; }
            Guid guid = Guid.NewGuid();
            Dataset.QuestionsExRow questionRow = dbObject.FullDataset.QuestionsEx.AddQuestionsExRow(1, 1, 1, "New question to passage(" + guid + ")", null, value.SetId, order, 0, 0);
            dbObject.FullDataset.PassagesToQuestionsEx.AddPassagesToQuestionsExRow(value.Text, value.Id, questionRow.Id);
            questionRow.SubtypeId = 4;
            value.Text += "";
            Question qse = new Question(questionRow, dbObject.GetConnection(), (PassageQuestion)(dbObject));
            ApplicationController.Instance.Edit(qse);
           // dbObject.FullDatasetQuestionsEx.FindByIdSetId(Id, value.SetId).Text 
            PassageQuestionEditor_Load(null, null);
        }

      
               
    }
}
