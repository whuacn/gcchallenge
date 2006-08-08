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
    internal class PassageQuestionEditor : Editor
    {
        private GroupBox groupBox2;
        private Button addNewButton;
        private ImageList imageList;
        private IContainer components;
        private DataGridView questionToPassageSetsDataGrid;
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof (PassageQuestionEditor));
            groupBox2 = new GroupBox();
            questionToPassageSetsDataGrid = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            textDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pictureDataGridViewImageColumn = new DataGridViewImageColumn();
            difficultyLevel = new DataGridViewComboBoxColumn();
            TypeId = new DataGridViewComboBoxColumn();
            SubtypeId = new DataGridViewComboBoxColumn();
            Idpas = new DataGridViewComboBoxColumn();
            typeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subtypeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            difficultyLevelIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            setIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            questionOrderDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            questionZoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            questionIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addNewButton = new Button();
            imageList = new ImageList(components);
            groupBox1 = new GroupBox();
            subTypecomboBox = new ComboBox();
            typeComboBox = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            difficutlyLevelcomboBox = new ComboBox();
            label7 = new Label();
            groupBox3 = new GroupBox();
            addFormulaButton = new Button();
            textTextBox = new TextBox();
            label2 = new Label();
            ((ISupportInitialize) (data)).BeginInit();
            groupBox2.SuspendLayout();
            ((ISupportInitialize) (questionToPassageSetsDataGrid)).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                  | AnchorStyles.Left)
                                                 | AnchorStyles.Right)));
            groupBox2.Controls.Add(questionToPassageSetsDataGrid);
            groupBox2.Controls.Add(addNewButton);
            groupBox2.FlatStyle = FlatStyle.System;
            groupBox2.Location = new Point(6, 290);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(771, 300);
            groupBox2.TabIndex = 57;
            groupBox2.TabStop = false;
            groupBox2.Text = "Questions to passage";
            // 
            // questionToPassageSetsDataGrid
            // 
            questionToPassageSetsDataGrid.AllowUserToAddRows = false;
            questionToPassageSetsDataGrid.AllowUserToDeleteRows = false;
            questionToPassageSetsDataGrid.AllowUserToOrderColumns = true;
            questionToPassageSetsDataGrid.AutoGenerateColumns = false;
            questionToPassageSetsDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            questionToPassageSetsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            questionToPassageSetsDataGrid.Columns.AddRange(new DataGridViewColumn[]
                                                               {
                                                                   idDataGridViewTextBoxColumn,
                                                                   textDataGridViewTextBoxColumn,
                                                                   pictureDataGridViewImageColumn,
                                                                   difficultyLevel,
                                                                   TypeId,
                                                                   SubtypeId,
                                                                   Idpas,
                                                                   typeIdDataGridViewTextBoxColumn,
                                                                   subtypeIdDataGridViewTextBoxColumn,
                                                                   difficultyLevelIdDataGridViewTextBoxColumn,
                                                                   setIdDataGridViewTextBoxColumn,
                                                                   questionOrderDataGridViewTextBoxColumn,
                                                                   questionZoneDataGridViewTextBoxColumn,
                                                                   questionIdDataGridViewTextBoxColumn
                                                               });
            questionToPassageSetsDataGrid.DataMember = "QuestionsEx";
            questionToPassageSetsDataGrid.DataSource = data;
            questionToPassageSetsDataGrid.Location = new Point(6, 46);
            questionToPassageSetsDataGrid.MultiSelect = false;
            questionToPassageSetsDataGrid.Name = "questionToPassageSetsDataGrid";
            questionToPassageSetsDataGrid.ReadOnly = true;
            questionToPassageSetsDataGrid.Size = new Size(759, 248);
            questionToPassageSetsDataGrid.TabIndex = 13;
            questionToPassageSetsDataGrid.CellDoubleClick +=
                new DataGridViewCellEventHandler(questionToPassageSetsDataGrid_CellDoubleClick);
            questionToPassageSetsDataGrid.DataError +=
                new DataGridViewDataErrorEventHandler(questionToPassageSetsDataGrid_DataError);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // textDataGridViewTextBoxColumn
            // 
            textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            textDataGridViewTextBoxColumn.HeaderText = "Text";
            textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            textDataGridViewTextBoxColumn.ReadOnly = true;
            textDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pictureDataGridViewImageColumn
            // 
            pictureDataGridViewImageColumn.DataPropertyName = "Picture";
            pictureDataGridViewImageColumn.HeaderText = "Picture";
            pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            pictureDataGridViewImageColumn.ReadOnly = true;
            // 
            // difficultyLevel
            // 
            difficultyLevel.DataPropertyName = "DifficultyLevelId";
            difficultyLevel.DataSource = data;
            difficultyLevel.DisplayMember = "DifficultyLevel.Name";
            difficultyLevel.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            difficultyLevel.HeaderText = "Difficulty level";
            difficultyLevel.Name = "difficultyLevel";
            difficultyLevel.ReadOnly = true;
            difficultyLevel.ValueMember = "DifficultyLevel.Id";
            // 
            // TypeId
            // 
            TypeId.DataPropertyName = "TypeId";
            TypeId.DataSource = data;
            TypeId.DisplayMember = "QuestionTypes.Name";
            TypeId.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            TypeId.HeaderText = "Type";
            TypeId.Name = "TypeId";
            TypeId.ReadOnly = true;
            TypeId.ValueMember = "QuestionTypes.Id";
            // 
            // SubtypeId
            // 
            SubtypeId.DataPropertyName = "SubtypeId";
            SubtypeId.DataSource = data;
            SubtypeId.DisplayMember = "QuestionSubtypes.Name";
            SubtypeId.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            SubtypeId.HeaderText = "Subtype";
            SubtypeId.Name = "SubtypeId";
            SubtypeId.ReadOnly = true;
            SubtypeId.ValueMember = "QuestionSubtypes.Id";
            SubtypeId.Width = 250;
            // 
            // Idpas
            // 
            Idpas.AutoComplete = false;
            Idpas.DataPropertyName = "QuestionId";
            Idpas.DataSource = data;
            Idpas.DisplayMember = "PassagesToQuestionsEx.Text";
            Idpas.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            Idpas.HeaderText = "Passage";
            Idpas.Name = "Idpas";
            Idpas.ReadOnly = true;
            Idpas.ValueMember = "PassagesToQuestionsEx.Id";
            Idpas.Visible = false;
            Idpas.Width = 200;
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            typeIdDataGridViewTextBoxColumn.HeaderText = "TypeId";
            typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            typeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // subtypeIdDataGridViewTextBoxColumn
            // 
            subtypeIdDataGridViewTextBoxColumn.DataPropertyName = "SubtypeId";
            subtypeIdDataGridViewTextBoxColumn.HeaderText = "SubtypeId";
            subtypeIdDataGridViewTextBoxColumn.Name = "subtypeIdDataGridViewTextBoxColumn";
            subtypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            subtypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // difficultyLevelIdDataGridViewTextBoxColumn
            // 
            difficultyLevelIdDataGridViewTextBoxColumn.DataPropertyName = "DifficultyLevelId";
            difficultyLevelIdDataGridViewTextBoxColumn.HeaderText = "DifficultyLevelId";
            difficultyLevelIdDataGridViewTextBoxColumn.Name = "difficultyLevelIdDataGridViewTextBoxColumn";
            difficultyLevelIdDataGridViewTextBoxColumn.ReadOnly = true;
            difficultyLevelIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // setIdDataGridViewTextBoxColumn
            // 
            setIdDataGridViewTextBoxColumn.DataPropertyName = "SetId";
            setIdDataGridViewTextBoxColumn.HeaderText = "SetId";
            setIdDataGridViewTextBoxColumn.Name = "setIdDataGridViewTextBoxColumn";
            setIdDataGridViewTextBoxColumn.ReadOnly = true;
            setIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionOrderDataGridViewTextBoxColumn
            // 
            questionOrderDataGridViewTextBoxColumn.DataPropertyName = "QuestionOrder";
            questionOrderDataGridViewTextBoxColumn.HeaderText = "QuestionOrder";
            questionOrderDataGridViewTextBoxColumn.Name = "questionOrderDataGridViewTextBoxColumn";
            questionOrderDataGridViewTextBoxColumn.ReadOnly = true;
            questionOrderDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionZoneDataGridViewTextBoxColumn
            // 
            questionZoneDataGridViewTextBoxColumn.DataPropertyName = "QuestionZone";
            questionZoneDataGridViewTextBoxColumn.HeaderText = "QuestionZone";
            questionZoneDataGridViewTextBoxColumn.Name = "questionZoneDataGridViewTextBoxColumn";
            questionZoneDataGridViewTextBoxColumn.ReadOnly = true;
            questionZoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionIdDataGridViewTextBoxColumn
            // 
            questionIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionId";
            questionIdDataGridViewTextBoxColumn.HeaderText = "QuestionId";
            questionIdDataGridViewTextBoxColumn.Name = "questionIdDataGridViewTextBoxColumn";
            questionIdDataGridViewTextBoxColumn.ReadOnly = true;
            questionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // addNewButton
            // 
            addNewButton.Anchor = ((AnchorStyles) ((AnchorStyles.Top | AnchorStyles.Right)));
            addNewButton.FlatStyle = FlatStyle.System;
            addNewButton.ImageIndex = 0;
            addNewButton.Location = new Point(677, 16);
            addNewButton.Name = "addNewButton";
            addNewButton.Size = new Size(88, 24);
            addNewButton.TabIndex = 8;
            addNewButton.Text = "Add &New...";
            addNewButton.Click += new EventHandler(addNewButton_Click);
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
            groupBox1.Controls.Add(subTypecomboBox);
            groupBox1.Controls.Add(typeComboBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(difficutlyLevelcomboBox);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(465, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(312, 96);
            groupBox1.TabIndex = 58;
            groupBox1.TabStop = false;
            // 
            // subTypecomboBox
            // 
            subTypecomboBox.FormattingEnabled = true;
            subTypecomboBox.Location = new Point(89, 65);
            subTypecomboBox.Name = "subTypecomboBox";
            subTypecomboBox.Size = new Size(217, 21);
            subTypecomboBox.TabIndex = 36;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(89, 38);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(217, 21);
            typeComboBox.TabIndex = 34;
            // 
            // label3
            // 
            label3.Location = new Point(6, 41);
            label3.Name = "label3";
            label3.Size = new Size(51, 23);
            label3.TabIndex = 35;
            label3.Text = "Type:";
            // 
            // label5
            // 
            label5.Location = new Point(6, 68);
            label5.Name = "label5";
            label5.Size = new Size(77, 23);
            label5.TabIndex = 37;
            label5.Text = "Sub type:";
            // 
            // difficutlyLevelcomboBox
            // 
            difficutlyLevelcomboBox.FormattingEnabled = true;
            difficutlyLevelcomboBox.Location = new Point(89, 11);
            difficutlyLevelcomboBox.Name = "difficutlyLevelcomboBox";
            difficutlyLevelcomboBox.Size = new Size(217, 21);
            difficutlyLevelcomboBox.TabIndex = 38;
            // 
            // label7
            // 
            label7.Location = new Point(6, 14);
            label7.Name = "label7";
            label7.Size = new Size(77, 23);
            label7.TabIndex = 39;
            label7.Text = "Difficutly level";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(addFormulaButton);
            groupBox3.Controls.Add(textTextBox);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(6, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(453, 279);
            groupBox3.TabIndex = 59;
            groupBox3.TabStop = false;
            // 
            // addFormulaButton
            // 
            addFormulaButton.Location = new Point(41, 11);
            addFormulaButton.Name = "addFormulaButton";
            addFormulaButton.Size = new Size(85, 23);
            addFormulaButton.TabIndex = 43;
            addFormulaButton.Text = "add formula";
            addFormulaButton.UseVisualStyleBackColor = true;
            // 
            // textTextBox
            // 
            textTextBox.Location = new Point(6, 41);
            textTextBox.Multiline = true;
            textTextBox.Name = "textTextBox";
            textTextBox.Size = new Size(441, 232);
            textTextBox.TabIndex = 32;
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
            // PassageQuestionEditor
            // 
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "PassageQuestionEditor";
            Size = new Size(780, 594);
            Load += new EventHandler(PassageQuestionEditor_Load);
            ((ISupportInitialize) (data)).EndInit();
            groupBox2.ResumeLayout(false);
            ((ISupportInitialize) (questionToPassageSetsDataGrid)).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        public override int Id
        {
            get { return ((PassageQuestion) dbObject).Value.Id; }
        }

        public override String ObjectName
        {
            get { return "passage question '" + QuestionType.TypeNames[((PassageQuestion) dbObject).Value.TypeId] + "'"; }
        }

        public PassageQuestionEditor(PassageQuestion question) : base(question)
        {
            InitializeComponent();
            value = question.Value;
        }

        public override void SetBindingPosition()
        {
            int pos = 0;
            PassageQuestion d = ((PassageQuestion) dbObject);
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
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).DifficultyLevelId =
                difficutlyLevelcomboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).TypeId = typeComboBox.SelectedIndex +
                                                                                           1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).SubtypeId =
                subTypecomboBox.SelectedIndex + 1;
            dbObject.FullDataset.QuestionsEx.FindByIdSetId(value.Id, value.SetId).Text = textTextBox.Text;
            for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; ++i)
            {
                if (dbObject.FullDataset.QuestionsEx[i].SubtypeId != 4)
                {
                    continue;
                }
                if (dbObject.FullDataset.QuestionsEx[i].SetId != Id)
                {
                    continue;
                }
                try
                {
                    if (dataSet.QuestionsEx.FindByIdSetId(dbObject.FullDataset.QuestionsEx[i].Id, Id).RowState ==
                        DataRowState.Deleted)
                    {
                        dbObject.FullDataset.QuestionsEx[i].Delete();
                    }
                }
                catch
                {
                    dbObject.FullDataset.QuestionsEx[i].Delete();
                }
            }
        }


        private Dataset.QuestionsExRow value;
        private Dataset dataSet;
        public int selectedPassageId = -1;
        private byte lastOrder = 0;
        private bool isInit = true;

        private void PassageQuestionEditor_Load(object sender, EventArgs e)
        {
            isInit = true;
            dataSet = (Dataset) dbObject.FullDataset.Copy();
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
                if (dataSet.QuestionsEx[i].RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (dataSet.QuestionsEx[i].SubtypeId != 4)
                {
                    dataSet.QuestionsEx[i].Delete();
                    continue;
                }
            }


            for (int i = 0; i < dataSet.PassagesToQuestionsEx.Count; ++i)
            {
                if (dataSet.PassagesToQuestionsEx[i].Id != value.Id)
                {
                    for (int j = 0; j < dataSet.QuestionsEx.Count; ++j)
                    {
                        if (dataSet.QuestionsEx[j].RowState == DataRowState.Deleted)
                        {
                            continue;
                        }
                        if (dataSet.QuestionsEx[j].Id == dataSet.PassagesToQuestionsEx[i].PassageQuestionId)
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
                    if (dataSet.QuestionsEx.FindByIdSetId(dataSet.PassagesToQuestionsEx[i].Id, setId) == null)
                    {
                        continue;
                    }
                    if (dataSet.QuestionsEx.FindByIdSetId(dataSet.PassagesToQuestionsEx[i].Id, setId).RowState ==
                        DataRowState.Deleted)
                    {
                        continue;
                    }

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
            questionToPassageSetsDataGrid.Sort(
                questionToPassageSetsDataGrid.Columns[questionOrderDataGridViewTextBoxColumn.Index], direction);
            isInit = false;
        }

        private void questionToPassageSetsDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                return;
            }
            //dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
            value.Text = textTextBox.Text;
        }

        private void difficutlyLevelcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                return;
            }
            //dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).DifficultyLevelId = ((ComboBox)sender).SelectedIndex + 1;
            value.DifficultyLevelId = ((ComboBox) sender).SelectedIndex + 1;
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit)
            {
                return;
            }
            // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).TypeId = ((ComboBox)sender).SelectedIndex + 1;
            value.TypeId = ((ComboBox) sender).SelectedIndex + 1;
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
            // dbObject.FullDataset.QuestionsEx.FindByIdSetId(Id, value.SetId).Text = textTextBox.Text;
            value.Text = textTextBox.Text;
        }

        private void questionToPassageSetsDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gw = (DataGridView) sender;
            if (e.ColumnIndex == -1)
            {
                Dataset.QuestionsExRow questionRow =
                    dbObject.FullDataset.QuestionsEx.FindByIdSetId(
                        (int) gw.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value, value.SetId);
                //questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId(dbObject.FullDataset.PassagesToQuestionsEx.FindById(questionRow.Id).PassageQuestionId, Id);
                Question qse = new Question(questionRow, dbObject.GetConnection(), (PassageQuestion) (dbObject));
                ApplicationController.Instance.Edit(qse);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridView gw = questionToPassageSetsDataGrid;
            // dbObject.FullDataset.QuestionsEx.FindByIdSetId((int)gw.Rows[gw.SelectedRows[0].Index].Cells[0].Value, value.SetId).Delete();
            dataSet.QuestionsEx.FindByIdSetId((int) gw.Rows[gw.SelectedRows[0].Index].Cells[0].Value, value.SetId).
                Delete();
            //dbObject.FullDataset.QuestionSetsEx.FindById(Id).Name += "";
            gw.Update();
        }


        private void addNewButton_Click(object sender, EventArgs e)
        {
            byte order;
            try
            {
                order =
                    (byte)
                    questionToPassageSetsDataGrid.Rows[questionToPassageSetsDataGrid.Rows.Count - 1].Cells[
                        questionOrderDataGridViewTextBoxColumn.Index].Value;
            }
            catch
            {
                order = 0;
            }
            Guid guid = Guid.NewGuid();
            Dataset.QuestionsExRow questionRow =
                dbObject.FullDataset.QuestionsEx.AddQuestionsExRow(1, 1, 1, "New question to passage(" + guid + ")",
                                                                   null, value.SetId, order, 0, 0);
            dbObject.FullDataset.PassagesToQuestionsEx.AddPassagesToQuestionsExRow(value.Text, value.Id, questionRow.Id);
            questionRow.SubtypeId = 4;
            value.Text += "";
            Question qse = new Question(questionRow, dbObject.GetConnection(), (PassageQuestion) (dbObject));
            ApplicationController.Instance.Edit(qse);
            // dbObject.FullDatasetQuestionsEx.FindByIdSetId(Id, value.SetId).Text 
            PassageQuestionEditor_Load(null, null);
        }
    }
}