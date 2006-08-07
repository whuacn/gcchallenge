using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor
{
	public class QuestionSetEditor : Editor
    {
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button addExistingButton;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.ImageList imageList;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label typeLable;
        private System.Windows.Forms.Label timeLable;
        private System.Windows.Forms.Label numberOfQuestionsLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView questionSetsDataGrid;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label inZone3;
        private Label inZone2;
        private Label inZone1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subtypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn difficultyLevelIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewImageColumn pictureDataGridViewImageColumn;
        private DataGridViewComboBoxColumn difficultyLevel;
        private DataGridViewComboBoxColumn TypeId;
        private DataGridViewComboBoxColumn SubtypeId;
        private DataGridViewComboBoxColumn Idpas;
        private DataGridViewTextBoxColumn setIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionOrderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn questionZoneDataGridViewTextBoxColumn;
        private GroupBox groupBox3;
        private TextBox descriptionTextBox;
        private TextBox nameTextBox;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn questionIdDataGridViewTextBoxColumn;
	
		public QuestionSetEditor(QuestionSet questionSet): base(questionSet)
		{
			InitializeComponent();
		}

        public static string APP_CAPTION = "GMAT Club Test - Database Editor";
        public bool questionHasChanges = false;
	    
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionSetEditor));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.questionSetsDataGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficultyLevelIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.difficultyLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubtypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Idpas = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.setIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionZoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonUp = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.addExistingButton = new System.Windows.Forms.Button();
            this.addNewButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inZone3 = new System.Windows.Forms.Label();
            this.inZone2 = new System.Windows.Forms.Label();
            this.inZone1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.typeLable = new System.Windows.Forms.Label();
            this.timeLable = new System.Windows.Forms.Label();
            this.numberOfQuestionsLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionSetsDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.questionSetsDataGrid);
            this.groupBox2.Controls.Add(this.buttonUp);
            this.groupBox2.Controls.Add(this.addExistingButton);
            this.groupBox2.Controls.Add(this.addNewButton);
            this.groupBox2.Controls.Add(this.removeButton);
            this.groupBox2.Controls.Add(this.buttonDown);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(3, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 381);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Questions";
            // 
            // questionSetsDataGrid
            // 
            this.questionSetsDataGrid.AllowUserToAddRows = false;
            this.questionSetsDataGrid.AllowUserToDeleteRows = false;
            this.questionSetsDataGrid.AllowUserToOrderColumns = true;
            this.questionSetsDataGrid.AutoGenerateColumns = false;
            this.questionSetsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.questionSetsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionSetsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.typeIdDataGridViewTextBoxColumn,
            this.subtypeIdDataGridViewTextBoxColumn,
            this.difficultyLevelIdDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.pictureDataGridViewImageColumn,
            this.difficultyLevel,
            this.TypeId,
            this.SubtypeId,
            this.Idpas,
            this.setIdDataGridViewTextBoxColumn,
            this.questionOrderDataGridViewTextBoxColumn,
            this.questionZoneDataGridViewTextBoxColumn,
            this.questionIdDataGridViewTextBoxColumn});
            this.questionSetsDataGrid.DataMember = "QuestionsEx";
            this.questionSetsDataGrid.DataSource = this.data;
            this.questionSetsDataGrid.Location = new System.Drawing.Point(5, 46);
            this.questionSetsDataGrid.MultiSelect = false;
            this.questionSetsDataGrid.Name = "questionSetsDataGrid";
            this.questionSetsDataGrid.ReadOnly = true;
            this.questionSetsDataGrid.Size = new System.Drawing.Size(759, 329);
            this.questionSetsDataGrid.TabIndex = 11;
            this.questionSetsDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.questionSetsDataGrid_CellDoubleClick);
            this.questionSetsDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.questionSetsDataGrid_DataError);
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
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            this.typeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Text";
            this.dataGridViewTextBoxColumn1.HeaderText = "Text";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "Picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
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
            this.questionZoneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            // 
            // addExistingButton
            // 
            this.addExistingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addExistingButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addExistingButton.ImageIndex = 1;
            this.addExistingButton.Location = new System.Drawing.Point(488, 16);
            this.addExistingButton.Name = "addExistingButton";
            this.addExistingButton.Size = new System.Drawing.Size(88, 24);
            this.addExistingButton.TabIndex = 7;
            this.addExistingButton.Text = "Add &Existing...";
            this.addExistingButton.Click += new System.EventHandler(this.addExistingButton_Click);
            // 
            // addNewButton
            // 
            this.addNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeButton.ImageIndex = 2;
            this.removeButton.Location = new System.Drawing.Point(676, 16);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.inZone3);
            this.groupBox1.Controls.Add(this.inZone2);
            this.groupBox1.Controls.Add(this.inZone1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.typeLable);
            this.groupBox1.Controls.Add(this.timeLable);
            this.groupBox1.Controls.Add(this.numberOfQuestionsLable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(542, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 126);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // inZone3
            // 
            this.inZone3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inZone3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inZone3.Location = new System.Drawing.Point(147, 93);
            this.inZone3.Name = "inZone3";
            this.inZone3.Size = new System.Drawing.Size(80, 16);
            this.inZone3.TabIndex = 22;
            this.inZone3.Text = "999";
            this.inZone3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inZone2
            // 
            this.inZone2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inZone2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inZone2.Location = new System.Drawing.Point(147, 78);
            this.inZone2.Name = "inZone2";
            this.inZone2.Size = new System.Drawing.Size(80, 16);
            this.inZone2.TabIndex = 21;
            this.inZone2.Text = "999";
            this.inZone2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inZone1
            // 
            this.inZone1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inZone1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inZone1.Location = new System.Drawing.Point(147, 63);
            this.inZone1.Name = "inZone1";
            this.inZone1.Size = new System.Drawing.Size(80, 16);
            this.inZone1.TabIndex = 20;
            this.inZone1.Text = "999";
            this.inZone1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(11, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Questions in zone 2";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(11, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Questions in zone 3";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(11, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Questions in zone 1";
            // 
            // typeLable
            // 
            this.typeLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.typeLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.typeLable.Location = new System.Drawing.Point(107, 16);
            this.typeLable.Name = "typeLable";
            this.typeLable.Size = new System.Drawing.Size(120, 16);
            this.typeLable.TabIndex = 12;
            this.typeLable.Text = "Reading Comprehension";
            this.typeLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timeLable
            // 
            this.timeLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timeLable.Location = new System.Drawing.Point(147, 32);
            this.timeLable.Name = "timeLable";
            this.timeLable.Size = new System.Drawing.Size(80, 16);
            this.timeLable.TabIndex = 16;
            this.timeLable.Text = "Unlimited";
            this.timeLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numberOfQuestionsLable
            // 
            this.numberOfQuestionsLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberOfQuestionsLable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.numberOfQuestionsLable.Location = new System.Drawing.Point(147, 47);
            this.numberOfQuestionsLable.Name = "numberOfQuestionsLable";
            this.numberOfQuestionsLable.Size = new System.Drawing.Size(80, 16);
            this.numberOfQuestionsLable.TabIndex = 15;
            this.numberOfQuestionsLable.Text = "999";
            this.numberOfQuestionsLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Type:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(11, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Time Limit:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(11, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "# of Questions:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.descriptionTextBox);
            this.groupBox3.Controls.Add(this.nameTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(531, 239);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.data, "Tests.Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(5, 56);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(520, 177);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.data, "Tests.Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(42, 14);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(483, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description";
            // 
            // QuestionSetEditor
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "QuestionSetEditor";
            this.Size = new System.Drawing.Size(782, 632);
            this.Enter += new System.EventHandler(this.QuestionSetEditor_Enter);
            this.Load += new System.EventHandler(this.QuestionSetEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionSetsDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


        public override void SaveCurrentEdit()
        {
            for (int i = 0; i < dbObject.FullDataset.QuestionsEx.Count; ++i)
            {
                if (dbObject.FullDataset.QuestionsEx[i].RowState == DataRowState.Deleted) { continue; }
                if (dbObject.FullDataset.QuestionsEx[i].SubtypeId == 3) { continue; }
                if (dbObject.FullDataset.QuestionsEx[i].SetId != Id) { continue; }
                try
                {
                    if (ds.QuestionsEx.FindByIdSetId(dbObject.FullDataset.QuestionsEx[i].Id, Id).RowState == DataRowState.Deleted)
                    {
                        dbObject.FullDataset.QuestionsEx[i].Delete();
                    }
                }
                catch { dbObject.FullDataset.QuestionsEx[i].Delete(); }
            }
            
        }
	    
		public override String ObjectName
		{
			get { return "question set '" + ((QuestionSet)dbObject).Value.Name + "'"; }
		}

		public override int Id
		{
			get { return ((QuestionSet)dbObject).Value.Id; }
		}

	    public void GetAllQuestions(Dataset ds)
	    {
            dbObject.GetAllQuestionsEx(ds); 
	    }
	    
		public override void SetBindingPosition()
		{
			int pos = 0;
			QuestionSet d = ((QuestionSet)dbObject);
			foreach (Dataset.QuestionSetsExRow row in dbObject.FullDataset.QuestionSetsEx.Rows)
			{
				if (row.Id == d.Value.Id) break;
				++pos;
            }
			BindingContext[data,"QuestionSetsEx"].Position = pos;
		}

		public override void EndCurrentEdit()
		{
			BindingContext[data,"QuestionSetsEx"].EndCurrentEdit();
		    
		}

        Dataset ds;
        private void QuestionSetEditor_Load(object sender, EventArgs e)
        {
            ds = new Dataset();
            ds = (Dataset)dbObject.FullDataset.Copy();
            for (int i = 0; i < ds.QuestionsEx.Count; i++)
            {
                if (ds.QuestionsEx[i].RowState == DataRowState.Deleted){continue;}
                if (ds.QuestionsEx[i].SetId != Id)
                {
                    ds.QuestionsEx[i].Delete();
                    continue;
                }
                if(ds.QuestionsEx[i].SubtypeId == 3)
                {
                    ds.QuestionsEx[i].Delete();
                    continue; 
                }
            }

            pasId = new int[ds.PassagesToQuestionsEx.Count];
            
            questionSetsDataGrid.DataSource = ds;
            Idpas.DataSource = ds;
            questionSetsDataGrid.Update();
            RefreshSetInfo();
            ListSortDirection direction;
            direction = ListSortDirection.Ascending;
            questionSetsDataGrid.Sort(questionSetsDataGrid.Columns[questionOrderDataGridViewTextBoxColumn.Index], direction);
        }
        private int[] pasId;
	    

	    private void RefreshSetInfo()
	    {
            nameTextBox.Text = data.QuestionSetsEx.FindById(Id).Name;
            descriptionTextBox.Text = data.QuestionSetsEx.FindById(Id).Description;
            timeLable.Text = data.QuestionSetsEx.FindById(Id).IsTimeLimitNull() ? "Unlimited" : data.QuestionSetsEx.FindById(Id).TimeLimit.ToString() + " min";
           
            try
            {
                typeLable.Text = QuestionType.TypeNames[data.QuestionSetsEx.FindById(Id).QuestionTypeId];
            }catch
            {
                
            }
            inZone1.Text = data.QuestionSetsEx.FindById(Id).NumberOfQuestionsInZone1.ToString();
            inZone2.Text = data.QuestionSetsEx.FindById(Id).NumberOfQuestionsInZone2.ToString();
            inZone3.Text = data.QuestionSetsEx.FindById(Id).NumberOfQuestionsInZone3.ToString();
	    }

        
	    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void questionSetsDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView gw = (DataGridView)sender;
            if (e.ColumnIndex == Idpas.Index)
            {
                gw.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Question must by - 'Reading Comprehension - Question to Passage' type";
            }
        }

        private void questionSetsDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == -1)
            {
                DataGridView gw = (DataGridView)sender;
                Dataset.QuestionsExRow questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId((int)gw.Rows[e.RowIndex].Cells[0].Value, Id);
                if (questionRow.SubtypeId == 4)
                {
                    try
                    {
                        for (int i = 0; i < dbObject.FullDataset.PassagesToQuestionsEx.Count; ++i)
                        {
                            if (dbObject.FullDataset.PassagesToQuestionsEx[i].Id == questionRow.Id)
                            {
                                questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId(dbObject.FullDataset.PassagesToQuestionsEx[i].PassageQuestionId, Id);
                            }
                        }
                        //questionRow = dbObject.FullDataset.QuestionsEx.FindByIdSetId(dbObject.FullDataset.PassagesToQuestionsEx.FindById(questionRow.Id).PassageQuestionId, Id);
                        PassageQuestion qse = new PassageQuestion(questionRow, dbObject.GetConnection(), (QuestionSet)(dbObject));
                        ApplicationController.Instance.Edit(qse);
                    }catch
                    {
                        MessageBox.Show("Problem in database! Check database.", "DbError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                   
                }
                else
                {
                    Question qse = new Question(questionRow, dbObject.GetConnection(), (QuestionSet)(dbObject));
                    ApplicationController.Instance.Edit(qse);
                }
                
                return;
            }
         }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (questionSetsDataGrid.SelectedRows.Count != 0)
            {
                int seseltedRowIndex = questionSetsDataGrid.SelectedRows[0].Index;
              
                if (Convert.ToInt32(questionSetsDataGrid.SelectedRows[0].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) > 0)
                {
                    ((QuestionSet)dbObject).ShangeQuestoinOrder(dbObject.FullDataset, (int)questionSetsDataGrid.SelectedRows[0].Cells[0].Value, true, Id);
                    questionSetsDataGrid.SelectedRows[0].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(questionSetsDataGrid.SelectedRows[0].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) - 1;
                    int prevQIndex = seseltedRowIndex - 1;
                    if (prevQIndex >= 0)
                    {
                       questionSetsDataGrid.Rows[prevQIndex].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(questionSetsDataGrid.Rows[prevQIndex].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) + 1;
                    }
                }
                ListSortDirection direction;
                direction = ListSortDirection.Ascending;
                questionSetsDataGrid.Sort(questionSetsDataGrid.Columns[questionOrderDataGridViewTextBoxColumn.Index], direction);
                questionSetsDataGrid.DataSource = ds;
                Idpas.DataSource = ds;
                questionSetsDataGrid.Update();
            }

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (questionSetsDataGrid.SelectedRows.Count != 0)
            {
                int seseltedRowIndex = questionSetsDataGrid.SelectedRows[0].Index;
                if (Convert.ToInt32(questionSetsDataGrid.SelectedRows[0].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) < questionSetsDataGrid.Rows.Count - 1)
                {
                    ((QuestionSet)dbObject).ShangeQuestoinOrder(dbObject.FullDataset, (int)questionSetsDataGrid.SelectedRows[0].Cells[0].Value, false, Id);
                    questionSetsDataGrid.SelectedRows[0].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(questionSetsDataGrid.SelectedRows[0].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) +1;
                    int prevQIndex = seseltedRowIndex + 1;
                    if (prevQIndex >= 0)
                    {
                        questionSetsDataGrid.Rows[prevQIndex].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value = Convert.ToInt32(questionSetsDataGrid.Rows[prevQIndex].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) - 1;
                    }
                }
                ListSortDirection direction;
                direction = ListSortDirection.Ascending;
                questionSetsDataGrid.Sort(questionSetsDataGrid.Columns[questionOrderDataGridViewTextBoxColumn.Index], direction);
                questionSetsDataGrid.DataSource = ds;
                Idpas.DataSource = ds;
                questionSetsDataGrid.Update();
            }

        }
        public int selQuestionId = new int();
        private void addExistingButton_Click(object sender, EventArgs e)
        {

            SelectQuestionForm sq = new SelectQuestionForm((Dataset)dbObject.FullDataset.Copy(), Id, dbObject);
            sq.ShowDialog();
            if (sq.DialogResult == DialogResult.OK)
            {
                int questionOrder;
               
                if (questionSetsDataGrid.Rows.Count > 0)
                {
                    questionOrder = Convert.ToByte(Convert.ToByte(questionSetsDataGrid.Rows[questionSetsDataGrid.Rows.Count - 1].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value) + 1);
                }
                else
                {
                    questionOrder = 0;
                } 
               

                dbObject.AddExistingQuestionToSet(sq.qr, questionOrder, Id);
            }
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            byte order;
            try
            {
                order = (byte)questionSetsDataGrid.Rows[questionSetsDataGrid.Rows.Count - 1].Cells[questionOrderDataGridViewTextBoxColumn.Index].Value;
            }catch{order =0;}
            Guid guid = Guid.NewGuid();
            Dataset.QuestionsExRow questionRow = dbObject.FullDataset.QuestionsEx.AddQuestionsExRow(1, 1, 1, "New question (" + guid+")", null, Id, order, 0, 0);
            if (!dbObject.FullDataset.QuestionSetsEx.FindById(Id).IsQuestionTypeIdNull())
            {
                questionRow.TypeId = dbObject.FullDataset.QuestionSetsEx.FindById(Id).QuestionTypeId;
            }
            if (!dbObject.FullDataset.QuestionSetsEx.FindById(Id).IsQuestionSubtypeIdNull())
            {
                questionRow.SubtypeId = dbObject.FullDataset.QuestionSetsEx.FindById(Id).QuestionSubtypeId;
            }
            Question qse = new Question(questionRow, dbObject.GetConnection(), (QuestionSet)(dbObject));
            ApplicationController.Instance.Edit(qse);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
            DataGridView gw = questionSetsDataGrid;
            if (gw.SelectedRows.Count == 0){return;}
            ds.QuestionsEx.FindByIdSetId((int)gw.Rows[gw.SelectedRows[0].Index].Cells[0].Value, Id).Delete();
            dbObject.FullDataset.QuestionSetsEx.FindById(Id).Name += "";
            gw.Update();
        }

       
        private void QuestionSetEditor_Enter(object sender, EventArgs e)
        {
            QuestionSetEditor_Load(null, null);
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            ds.QuestionSetsEx.FindById(Id).Name = nameTextBox.Text;
            dbObject.FullDataset.QuestionSetsEx.FindById(Id).Name += "";
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            ds.QuestionSetsEx.FindById(Id).Description = descriptionTextBox.Text;
            dbObject.FullDataset.QuestionSetsEx.FindById(Id).Name += "";
        }
	}
}
