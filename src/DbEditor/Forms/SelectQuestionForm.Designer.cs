namespace GmatClubTest.DbEditor
{
    partial class SelectQuestionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectQuestionForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.questionDataGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataset = new GmatClubTest.DbEditor.Data.Dataset();
            this.subType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.difficultyLevelId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficultyLevelIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.cancelButton);
            this.groupBox2.Location = new System.Drawing.Point(280, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 54);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(92, 19);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.questionDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 232);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valid to add questions";
            // 
            // questionDataGrid
            // 
            this.questionDataGrid.AllowUserToAddRows = false;
            this.questionDataGrid.AllowUserToDeleteRows = false;
            this.questionDataGrid.AutoGenerateColumns = false;
            this.questionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.pictureDataGridViewImageColumn,
            this.type,
            this.subType,
            this.difficultyLevelId,
            this.typeIdDataGridViewTextBoxColumn,
            this.subtypeIdDataGridViewTextBoxColumn,
            this.difficultyLevelIdDataGridViewTextBoxColumn});
            this.questionDataGrid.DataMember = "QuestionsEx";
            this.questionDataGrid.DataSource = this.dataset;
            this.questionDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.questionDataGrid.Location = new System.Drawing.Point(3, 16);
            this.questionDataGrid.MultiSelect = false;
            this.questionDataGrid.Name = "questionDataGrid";
            this.questionDataGrid.ReadOnly = true;
            this.questionDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questionDataGrid.Size = new System.Drawing.Size(455, 213);
            this.questionDataGrid.TabIndex = 0;
            this.questionDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.questionDataGrid_DataError);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "Picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            this.pictureDataGridViewImageColumn.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "TypeId";
            this.type.DataSource = this.dataset;
            this.type.DisplayMember = "QuestionTypes.Name";
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.ValueMember = "QuestionTypes.Id";
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // subType
            // 
            this.subType.DataPropertyName = "SubtypeId";
            this.subType.DataSource = this.dataset;
            this.subType.DisplayMember = "QuestionSubtypes.Name";
            this.subType.HeaderText = "Sub type";
            this.subType.Name = "subType";
            this.subType.ReadOnly = true;
            this.subType.ValueMember = "QuestionSubtypes.Id";
            // 
            // difficultyLevelId
            // 
            this.difficultyLevelId.DataPropertyName = "DifficultyLevelId";
            this.difficultyLevelId.DataSource = this.dataset;
            this.difficultyLevelId.DisplayMember = "DifficultyLevel.Name";
            this.difficultyLevelId.HeaderText = "Difficulty level";
            this.difficultyLevelId.Name = "difficultyLevelId";
            this.difficultyLevelId.ReadOnly = true;
            this.difficultyLevelId.ValueMember = "DifficultyLevel.Id";
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
            // SelectQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 302);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectQuestionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select question";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectQuestionForm_FormClosing);
            this.Load += new System.EventHandler(this.SelectQuestionForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView questionDataGrid;
        private GmatClubTest.DbEditor.Data.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn type;
        private System.Windows.Forms.DataGridViewComboBoxColumn subType;
        private System.Windows.Forms.DataGridViewComboBoxColumn difficultyLevelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficultyLevelIdDataGridViewTextBoxColumn;
    }
}