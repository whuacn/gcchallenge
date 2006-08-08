using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public class TestEditor : Editor
    {
        private GroupBox groupBox1;
        private Label isPracticeLabel;
        private Label typeLable;
        private Label numberOfSectionsLable;
        private Label totalTimeLable;
        private Label totalNumberOfQuestionsLable;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private GroupBox groupBox2;
        private Button addExistingButton;
        private Button addNewButton;
        private Button removeButton;
        private Button buttonUp;
        private ImageList imageList;
        private Button buttonDown;
        private DataGridView questionSetdataGridView;
        private IContainer components;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn questionType;
        private DataGridViewComboBoxColumn questionSubType;
        private DataGridViewTextBoxColumn numberOfQuestionsToPickDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timeLimitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionTypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionSubtypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberOfQuestionsInZone1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberOfQuestionsInZone2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberOfQuestionsInZone3DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn testIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionSetOrderDataGridViewTextBoxColumn;
        private GroupBox groupBox3;
        private TextBox descriptionTextBox;
        private TextBox nameTextBox;
        private Label label1;
        private Label label2;


        private Dataset ds;

        public TestEditor(Test test) : base(test)
        {
            InitializeComponent();
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof (TestEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isPracticeLabel = new System.Windows.Forms.Label();
            this.typeLable = new System.Windows.Forms.Label();
            this.numberOfSectionsLable = new System.Windows.Forms.Label();
            this.totalTimeLable = new System.Windows.Forms.Label();
            this.totalNumberOfQuestionsLable = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.questionSetdataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.questionSubType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionSubtypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn =
                new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionSetOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonUp = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.addExistingButton = new System.Windows.Forms.Button();
            this.addNewButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.data)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.questionSetdataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.isPracticeLabel);
            this.groupBox1.Controls.Add(this.typeLable);
            this.groupBox1.Controls.Add(this.numberOfSectionsLable);
            this.groupBox1.Controls.Add(this.totalTimeLable);
            this.groupBox1.Controls.Add(this.totalNumberOfQuestionsLable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(543, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 144);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // isPracticeLabel
            // 
            this.isPracticeLabel.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isPracticeLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.isPracticeLabel.Location = new System.Drawing.Point(154, 16);
            this.isPracticeLabel.Name = "isPracticeLabel";
            this.isPracticeLabel.Size = new System.Drawing.Size(72, 16);
            this.isPracticeLabel.TabIndex = 13;
            this.isPracticeLabel.Text = "Adaptive Test";
            this.isPracticeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // typeLable
            // 
            this.typeLable.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.typeLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.typeLable.Location = new System.Drawing.Point(106, 40);
            this.typeLable.Name = "typeLable";
            this.typeLable.Size = new System.Drawing.Size(120, 16);
            this.typeLable.TabIndex = 12;
            this.typeLable.Text = "Reading Comprehension";
            this.typeLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numberOfSectionsLable
            // 
            this.numberOfSectionsLable.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberOfSectionsLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.numberOfSectionsLable.Location = new System.Drawing.Point(154, 64);
            this.numberOfSectionsLable.Name = "numberOfSectionsLable";
            this.numberOfSectionsLable.Size = new System.Drawing.Size(72, 16);
            this.numberOfSectionsLable.TabIndex = 14;
            this.numberOfSectionsLable.Text = "99";
            this.numberOfSectionsLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalTimeLable
            // 
            this.totalTimeLable.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTimeLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.totalTimeLable.Location = new System.Drawing.Point(146, 88);
            this.totalTimeLable.Name = "totalTimeLable";
            this.totalTimeLable.Size = new System.Drawing.Size(80, 16);
            this.totalTimeLable.TabIndex = 16;
            this.totalTimeLable.Text = "Unlimited";
            this.totalTimeLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalNumberOfQuestionsLable
            // 
            this.totalNumberOfQuestionsLable.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalNumberOfQuestionsLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.totalNumberOfQuestionsLable.Location = new System.Drawing.Point(146, 112);
            this.totalNumberOfQuestionsLable.Name = "totalNumberOfQuestionsLable";
            this.totalNumberOfQuestionsLable.Size = new System.Drawing.Size(80, 16);
            this.totalNumberOfQuestionsLable.TabIndex = 15;
            this.totalNumberOfQuestionsLable.Text = "999";
            this.totalNumberOfQuestionsLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type:";
            // 
            // label4
            // 
            this.label4.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(10, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number of Sections:";
            // 
            // label5
            // 
            this.label5.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(10, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total Time Limit:";
            // 
            // label6
            // 
            this.label6.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Class:";
            // 
            // label7
            // 
            this.label7.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(10, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Total # of Questions:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.questionSetdataGridView);
            this.groupBox2.Controls.Add(this.buttonUp);
            this.groupBox2.Controls.Add(this.addExistingButton);
            this.groupBox2.Controls.Add(this.addNewButton);
            this.groupBox2.Controls.Add(this.removeButton);
            this.groupBox2.Controls.Add(this.buttonDown);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(3, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 369);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Question Sets (Sections)";
            // 
            // questionSetdataGridView
            // 
            this.questionSetdataGridView.AllowUserToAddRows = false;
            this.questionSetdataGridView.AllowUserToDeleteRows = false;
            this.questionSetdataGridView.AllowUserToOrderColumns = true;
            this.questionSetdataGridView.AutoGenerateColumns = false;
            this.questionSetdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.questionSetdataGridView.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionSetdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                                                              {
                                                                  this.idDataGridViewTextBoxColumn,
                                                                  this.nameDataGridViewTextBoxColumn,
                                                                  this.descriptionDataGridViewTextBoxColumn,
                                                                  this.questionType,
                                                                  this.questionSubType,
                                                                  this.numberOfQuestionsToPickDataGridViewTextBoxColumn,
                                                                  this.timeLimitDataGridViewTextBoxColumn,
                                                                  this.questionTypeIdDataGridViewTextBoxColumn,
                                                                  this.questionSubtypeIdDataGridViewTextBoxColumn,
                                                                  this.numberOfQuestionsInZone1DataGridViewTextBoxColumn
                                                                  ,
                                                                  this.numberOfQuestionsInZone2DataGridViewTextBoxColumn
                                                                  ,
                                                                  this.numberOfQuestionsInZone3DataGridViewTextBoxColumn
                                                                  ,
                                                                  this.testIdDataGridViewTextBoxColumn,
                                                                  this.questionSetOrderDataGridViewTextBoxColumn
                                                              });
            this.questionSetdataGridView.DataMember = "QuestionSetsEx";
            this.questionSetdataGridView.DataSource = this.data;
            this.questionSetdataGridView.Location = new System.Drawing.Point(6, 46);
            this.questionSetdataGridView.MultiSelect = false;
            this.questionSetdataGridView.Name = "questionSetdataGridView";
            this.questionSetdataGridView.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.questionSetdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questionSetdataGridView.ShowRowErrors = false;
            this.questionSetdataGridView.Size = new System.Drawing.Size(760, 317);
            this.questionSetdataGridView.TabIndex = 11;
            this.questionSetdataGridView.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.questionSetdataGridView_CellDoubleClick);
            this.questionSetdataGridView.CellEndEdit +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.questionSetdataGridView_CellEndEdit);
            this.questionSetdataGridView.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.questionSetdataGridView_DataError);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // questionType
            // 
            this.questionType.DataPropertyName = "QuestionTypeId";
            this.questionType.DataSource = this.data;
            this.questionType.DisplayMember = "QuestionTypes.Name";
            this.questionType.HeaderText = "Questions type";
            this.questionType.Name = "questionType";
            this.questionType.ValueMember = "QuestionTypes.Id";
            this.questionType.Visible = false;
            // 
            // questionSubType
            // 
            this.questionSubType.DataPropertyName = "QuestionTypeId";
            this.questionSubType.DataSource = this.data;
            this.questionSubType.DisplayMember = "QuestionSubtypes.Name";
            this.questionSubType.HeaderText = "Questions sub type";
            this.questionSubType.Name = "questionSubType";
            this.questionSubType.ValueMember = "QuestionSubtypes.Id";
            this.questionSubType.Visible = false;
            // 
            // numberOfQuestionsToPickDataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsToPick";
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.HeaderText = "Number of questions to pick";
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.Name =
                "numberOfQuestionsToPickDataGridViewTextBoxColumn";
            // 
            // timeLimitDataGridViewTextBoxColumn
            // 
            this.timeLimitDataGridViewTextBoxColumn.DataPropertyName = "TimeLimit";
            this.timeLimitDataGridViewTextBoxColumn.HeaderText = "Time limit";
            this.timeLimitDataGridViewTextBoxColumn.Name = "timeLimitDataGridViewTextBoxColumn";
            // 
            // questionTypeIdDataGridViewTextBoxColumn
            // 
            this.questionTypeIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionTypeId";
            this.questionTypeIdDataGridViewTextBoxColumn.HeaderText = "QuestionTypeId";
            this.questionTypeIdDataGridViewTextBoxColumn.Name = "questionTypeIdDataGridViewTextBoxColumn";
            this.questionTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionSubtypeIdDataGridViewTextBoxColumn
            // 
            this.questionSubtypeIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionSubtypeId";
            this.questionSubtypeIdDataGridViewTextBoxColumn.HeaderText = "QuestionSubtypeId";
            this.questionSubtypeIdDataGridViewTextBoxColumn.Name = "questionSubtypeIdDataGridViewTextBoxColumn";
            this.questionSubtypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // numberOfQuestionsInZone1DataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsInZone1";
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.HeaderText = "Questions in zone 1";
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.Name =
                "numberOfQuestionsInZone1DataGridViewTextBoxColumn";
            // 
            // numberOfQuestionsInZone2DataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsInZone2";
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.HeaderText = "Questions in zone 2";
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.Name =
                "numberOfQuestionsInZone2DataGridViewTextBoxColumn";
            // 
            // numberOfQuestionsInZone3DataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsInZone3";
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.HeaderText = "Questions in zone 3";
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.Name =
                "numberOfQuestionsInZone3DataGridViewTextBoxColumn";
            // 
            // testIdDataGridViewTextBoxColumn
            // 
            this.testIdDataGridViewTextBoxColumn.DataPropertyName = "TestId";
            this.testIdDataGridViewTextBoxColumn.HeaderText = "TestId";
            this.testIdDataGridViewTextBoxColumn.Name = "testIdDataGridViewTextBoxColumn";
            this.testIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionSetOrderDataGridViewTextBoxColumn
            // 
            this.questionSetOrderDataGridViewTextBoxColumn.DataPropertyName = "QuestionSetOrder";
            this.questionSetOrderDataGridViewTextBoxColumn.HeaderText = "QuestionSetOrder";
            this.questionSetOrderDataGridViewTextBoxColumn.Name = "questionSetOrderDataGridViewTextBoxColumn";
            this.questionSetOrderDataGridViewTextBoxColumn.Visible = false;
            // 
            // buttonUp
            // 
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUp.ImageIndex = 0;
            this.buttonUp.ImageList = this.imageList;
            this.buttonUp.Location = new System.Drawing.Point(8, 16);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(17, 24);
            this.buttonUp.TabIndex = 10;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            // 
            // addExistingButton
            // 
            this.addExistingButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addExistingButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addExistingButton.ImageIndex = 1;
            this.addExistingButton.Location = new System.Drawing.Point(486, 16);
            this.addExistingButton.Name = "addExistingButton";
            this.addExistingButton.Size = new System.Drawing.Size(88, 24);
            this.addExistingButton.TabIndex = 7;
            this.addExistingButton.Text = "Add &Existing...";
            this.addExistingButton.Click += new System.EventHandler(this.addExistingButton_Click);
            // 
            // addNewButton
            // 
            this.addNewButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewButton.ImageIndex = 0;
            this.addNewButton.Location = new System.Drawing.Point(582, 16);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(88, 24);
            this.addNewButton.TabIndex = 8;
            this.addNewButton.Text = "Add &New...";
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeButton.ImageIndex = 2;
            this.removeButton.Location = new System.Drawing.Point(678, 16);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(88, 24);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "&Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDown.ImageIndex = 1;
            this.buttonDown.ImageList = this.imageList;
            this.buttonDown.Location = new System.Drawing.Point(27, 16);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(17, 24);
            this.buttonDown.TabIndex = 10;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.descriptionTextBox);
            this.groupBox3.Controls.Add(this.nameTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 239);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(
                new System.Windows.Forms.Binding("Text", this.data, "Tests.Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(5, 56);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(523, 177);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.data, "Tests.Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(42, 14);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(486, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // TestEditor
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(200, 150);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestEditor";
            this.Size = new System.Drawing.Size(780, 620);
            this.Load += new System.EventHandler(this.TestEditor_Load);
            ((System.ComponentModel.ISupportInitialize) (this.data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.questionSetdataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public override String ObjectName
        {
            get { return "test '" + ((Test) dbObject).Value.Name + "'"; }
        }

        public override int Id
        {
            get { return ((Test) dbObject).Value.Id; }
        }

        public override void EndCurrentEdit()
        {
            BindingContext[data, "Tests"].EndCurrentEdit();
        }

        public override void SaveCurrentEdit()
        {
        }

        private void TestEditor_Load(object sender, EventArgs e)
        {
            //data.Tests.TestsRowChanged +=new GmatClubTest.DbEditor.Data.Dataset.TestsRowChangeEventHandler(Tests_TestsRowChanged);
            data.QuestionSetsEx.QuestionSetsExRowChanged +=
                new Dataset.QuestionSetsExRowChangeEventHandler(QuestionSetsEx_QuestionSetsExRowChanged);

            ds = new Dataset();
            ds = (Dataset) ((Test) dbObject).FullDataset.Copy();
            RefreshTestInfo();
        }

        private void QuestionSetsEx_QuestionSetsExRowChanged(object sender, Dataset.QuestionSetsExRowChangeEvent e)
        {
            RefreshTestInfo();
        }

        private void RefreshTestInfo()
        {
            isPracticeLabel.Text = data.Tests[0].IsPractice ? "Practice" : "Adaptive Test";

            if (data.Tests[0].IsQuestionSubtypeIdNull())
            {
                if (data.Tests[0].IsQuestionTypeIdNull())
                    typeLable.Text = "Mixed";
                else
                    typeLable.Text = QuestionType.TypeNames[data.Tests[0].QuestionTypeId];
            }
            else
            {
                typeLable.Text = QuestionType.SubtypeNames[data.Tests[0].QuestionSubtypeId];
            }

            DataRowCollection qs = data.QuestionSetsEx.Rows;
            numberOfSectionsLable.Text = qs.Count.ToString();

            int t = 0;
            int q = 0;

            foreach (Dataset.QuestionSetsExRow row in qs)
            {
                if (t != -1)
                {
                    t = row.IsTimeLimitNull() ? -1 : t + row.TimeLimit;
                }

                if (data.Tests[0].IsPractice)
                {
                    q += row.NumberOfQuestionsToPick;
                }
                else
                {
                    q += row.NumberOfQuestionsInZone1 + row.NumberOfQuestionsInZone2 + row.NumberOfQuestionsInZone3;
                }
            }

            totalTimeLable.Text = t == -1 ? "Unlimited" : t.ToString() + " min";
            totalNumberOfQuestionsLable.Text = q.ToString();
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            TypeSelectionForm tsf = new TypeSelectionForm();
            tsf.BaseQuestionType = QuestionType.CreateMixed(); // dbObject.QuestionType;

            if (tsf.ShowDialog() != DialogResult.OK) return;

            QuestionSet questionSet = ((Test) dbObject).AddNewQuestionSet(tsf.QuestionType);

            ApplicationController.Instance.Edit(questionSet);

            ds = (Dataset) ((Test) dbObject).FullDataset;
            questionSetdataGridView.Update();
            //questionSetdataGridView.Update();
            //dbObject.RefreshConnection();
        }

        private void addExistingButton_Click(object sender, EventArgs e)
        {
            int testId = Id; // (int)questionSetdataGridView.Rows[0].Cells[10].Value;

            ((Test) dbObject).AddExistingSetToTest(data, testId);

            ds = (Dataset) ((Test) dbObject).FullDataset;
            questionSetdataGridView.Update();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (questionSetdataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Set not selected", "Remove set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (
                MessageBox.Show("Remove " + questionSetdataGridView.SelectedRows[0].Cells[1].Value + " set?",
                                "Remove set", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ((Test) dbObject).DeleteSetFromTest(
                    (int) questionSetdataGridView.SelectedRows[0].Cells[idDataGridViewTextBoxColumn.Index].Value,
                    (int) questionSetdataGridView.SelectedRows[0].Cells[testIdDataGridViewTextBoxColumn.Index].Value,
                    data);
                questionSetdataGridView.Update();
            }
        }

        private void questionSetsDataGrid_DoubleClick(object sender, EventArgs e)
        {
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (questionSetdataGridView.SelectedRows.Count != 0)
            {
                ((Test) dbObject).ShangeSetOrder(data, (int) questionSetdataGridView.SelectedRows[0].Cells[0].Value,
                                                 true);
                data.QuestionSetsEx.FindById((int) questionSetdataGridView.SelectedRows[0].Cells[0].Value).Name += "";
                ListSortDirection direction;
                direction = ListSortDirection.Ascending;
                questionSetdataGridView.Sort(
                    questionSetdataGridView.Columns[questionSetOrderDataGridViewTextBoxColumn.Index], direction);
                questionSetdataGridView.Update();
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (questionSetdataGridView.SelectedRows.Count != 0)
            {
                if (
                    Convert.ToInt32(
                        questionSetdataGridView.SelectedRows[0].Cells[questionSetOrderDataGridViewTextBoxColumn.Index].
                            Value) < questionSetdataGridView.Rows.Count - 1)
                {
                    ((Test) dbObject).ShangeSetOrder(data, (int) questionSetdataGridView.SelectedRows[0].Cells[0].Value,
                                                     false);
                    data.QuestionSetsEx.FindById((int) questionSetdataGridView.SelectedRows[0].Cells[0].Value).Name +=
                        "";
                    ListSortDirection direction;
                    direction = ListSortDirection.Ascending;
                    questionSetdataGridView.Sort(
                        questionSetdataGridView.Columns[questionSetOrderDataGridViewTextBoxColumn.Index], direction);
                    questionSetdataGridView.Update();
                }
            }
        }

        private void questionSetdataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gw = (DataGridView) sender;
            dbObject.FullDataset.Tests.FindById(Id).Name += "";
            int setId = (int) gw.Rows[e.RowIndex].Cells[idDataGridViewTextBoxColumn.Index].Value;
            if (e.ColumnIndex == nameDataGridViewTextBoxColumn.Index)
            {
                dbObject.FullDataset.QuestionSetsEx.FindById(setId).Name =
                    (string) gw.Rows[e.RowIndex].Cells[nameDataGridViewTextBoxColumn.Index].Value;
                return;
            }
            if (e.ColumnIndex == descriptionDataGridViewTextBoxColumn.Index)
            {
                dbObject.FullDataset.QuestionSetsEx.FindById(setId).Description =
                    (string) gw.Rows[e.RowIndex].Cells[descriptionDataGridViewTextBoxColumn.Index].Value;
                return;
            }
            if (e.ColumnIndex == questionType.Index)
            {
                dbObject.FullDataset.QuestionSetsEx.FindById(setId).QuestionTypeId =
                    (int) gw.Rows[e.RowIndex].Cells[questionType.Index].Value;
                return;
            }
            if (e.ColumnIndex == questionSubType.Index)
            {
                dbObject.FullDataset.QuestionSetsEx.FindById(setId).QuestionSubtypeId =
                    (int) gw.Rows[e.RowIndex].Cells[questionSubType.Index].Value;
                return;
            }

            if (e.ColumnIndex == numberOfQuestionsToPickDataGridViewTextBoxColumn.Index)
            {
                int count = new int();
                for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; i++)
                {
                    if (dbObject.FullDataset.QuestionsEx[i].SetId == setId)
                    {
                        count++;
                    }
                }
                if ((int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsToPickDataGridViewTextBoxColumn.Index].Value <=
                    count)
                {
                    dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsToPick =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsToPickDataGridViewTextBoxColumn.Index].Value;
                    ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsToPick =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsToPickDataGridViewTextBoxColumn.Index].Value;
                    data.QuestionSetsEx.FindById(setId).NumberOfQuestionsToPick =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsToPickDataGridViewTextBoxColumn.Index].Value;
                }
                else
                {
                    MessageBox.Show(
                        "Number of questions to pick can't be larger of total question on this set.(Total question on this set is - " +
                        count + " )", "Change number of questions to pick", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gw.Rows[e.RowIndex].Cells[numberOfQuestionsToPickDataGridViewTextBoxColumn.Index].Value =
                        ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsToPick;
                    data.QuestionSetsEx.FindById(setId).NumberOfQuestionsToPick =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsToPickDataGridViewTextBoxColumn.Index].Value;
                    gw.Update();
                }
                return;
            }


            if (e.ColumnIndex == numberOfQuestionsInZone1DataGridViewTextBoxColumn.Index)
            {
                int count = new int();
                for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; i++)
                {
                    if (dbObject.FullDataset.QuestionsEx[i].SetId == setId)
                    {
                        if (
                            dbObject.FullDataset.DifficultyLevel.FindById(
                                dbObject.FullDataset.QuestionsEx[i].DifficultyLevelId).Name == "Easy")
                        {
                            count++;
                        }
                    }
                }
                if ((int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone1DataGridViewTextBoxColumn.Index].Value <=
                    count)
                {
                    dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1 =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone1DataGridViewTextBoxColumn.Index].Value;
                    ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1 =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone1DataGridViewTextBoxColumn.Index].Value;
                }
                else
                {
                    MessageBox.Show(
                        "Number of questions in zone 1 can't be larger of total question level 1 on this set.(Total question level 1 on this set is - " +
                        count + " )", "Change number of questions in zone 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //data.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1 = dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1;
                    gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone1DataGridViewTextBoxColumn.Index].Value =
                        ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1;
                    //data.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1 = dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone1;
                    gw.Update();
                }
                return;
            }

            if (e.ColumnIndex == numberOfQuestionsInZone2DataGridViewTextBoxColumn.Index)
            {
                int count = new int();
                for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; i++)
                {
                    if (dbObject.FullDataset.QuestionsEx[i].SetId == setId)
                    {
                        if (
                            dbObject.FullDataset.DifficultyLevel.FindById(
                                dbObject.FullDataset.QuestionsEx[i].DifficultyLevelId).Name == "Medium")
                        {
                            count++;
                        }
                    }
                }
                if ((int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone2DataGridViewTextBoxColumn.Index].Value <=
                    count)
                {
                    dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone2 =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone2DataGridViewTextBoxColumn.Index].Value;
                    ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone2 =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone2DataGridViewTextBoxColumn.Index].Value;
                }
                else
                {
                    MessageBox.Show(
                        "Number of questions in zone 2 can't be larger of total question leve 2 on this set.(Total question level 2 on this set is - " +
                        count + " )", "Change number of questions in zone 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone2DataGridViewTextBoxColumn.Index].Value =
                        ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone2;
                    //data.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone2 = dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone2;
                    gw.Update();
                }
                return;
            }

            if (e.ColumnIndex == numberOfQuestionsInZone3DataGridViewTextBoxColumn.Index)
            {
                int count = new int();
                for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; i++)
                {
                    if (dbObject.FullDataset.QuestionsEx[i].SetId == setId)
                    {
                        if (
                            dbObject.FullDataset.DifficultyLevel.FindById(
                                dbObject.FullDataset.QuestionsEx[i].DifficultyLevelId).Name == "Hard")
                        {
                            count++;
                        }
                    }
                }
                if ((int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone3DataGridViewTextBoxColumn.Index].Value <=
                    count)
                {
                    dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone3 =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone3DataGridViewTextBoxColumn.Index].Value;
                    ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone3 =
                        (int) gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone3DataGridViewTextBoxColumn.Index].Value;
                }
                else
                {
                    MessageBox.Show(
                        "Number of questions in zone 3 can't be larger of total question leve 3 on this set.(Total question level 3 on this set is - " +
                        count + " )", "Change number of questions in zone 3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gw.Rows[e.RowIndex].Cells[numberOfQuestionsInZone3DataGridViewTextBoxColumn.Index].Value =
                        ds.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone3;
                    //data.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone3 = dbObject.FullDataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsInZone3;
                    gw.Update();
                }
            }
        }

        private void questionSetdataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView gw = (DataGridView) sender;
            if (e.ColumnIndex == questionSubType.Index)
            {
                gw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Mixet";
            }
        }

        private void questionSetdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                TestQuestionSetSet.QuestionSetsRow questionSetRow =
                    ((Test) dbObject).GetTestTestQuestionSetSetQuestiomSetRow(
                        (int) questionSetdataGridView.SelectedRows[0].Cells[0].Value);
                QuestionSet qset = new QuestionSet(questionSetRow, (Test) (dbObject));
                ApplicationController.Instance.Edit(qset);
            }
        }
    }
}