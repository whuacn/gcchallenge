namespace GmatClubTest.DbEditor
{
    partial class SelectPassageQuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPassageQuestionForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.passagesDataGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficultyLevelIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataset = new GmatClubTest.DbEditor.Data.Dataset();
            this.difficultyLevelId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.setIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionZoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passagesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.selectButton);
            this.groupBox2.Controls.Add(this.cancelButton);
            this.groupBox2.Location = new System.Drawing.Point(312, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 54);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(6, 19);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(80, 23);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passagesDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 232);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valid passages";
            // 
            // passagesDataGrid
            // 
            this.passagesDataGrid.AllowUserToAddRows = false;
            this.passagesDataGrid.AllowUserToDeleteRows = false;
            this.passagesDataGrid.AutoGenerateColumns = false;
            this.passagesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.passagesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.typeIdDataGridViewTextBoxColumn,
            this.subtypeIdDataGridViewTextBoxColumn,
            this.difficultyLevelIdDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.type,
            this.difficultyLevelId,
            this.pictureDataGridViewImageColumn,
            this.setIdDataGridViewTextBoxColumn,
            this.questionOrderDataGridViewTextBoxColumn,
            this.questionZoneDataGridViewTextBoxColumn,
            this.questionIdDataGridViewTextBoxColumn});
            this.passagesDataGrid.DataMember = "QuestionsEx";
            this.passagesDataGrid.DataSource = this.dataset;
            this.passagesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passagesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.passagesDataGrid.Location = new System.Drawing.Point(3, 16);
            this.passagesDataGrid.MultiSelect = false;
            this.passagesDataGrid.Name = "passagesDataGrid";
            this.passagesDataGrid.ReadOnly = true;
            this.passagesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.passagesDataGrid.Size = new System.Drawing.Size(479, 213);
            this.passagesDataGrid.TabIndex = 0;
            this.passagesDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.passagesDataGrid_DataError);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
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
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
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
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "Picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            this.pictureDataGridViewImageColumn.ReadOnly = true;
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
            // SelectPassageQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(509, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectPassageQuestionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select passage";
            this.Load += new System.EventHandler(this.selectPassageQuestionForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.passagesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView passagesDataGrid;
        private GmatClubTest.DbEditor.Data.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficultyLevelIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn type;
        private System.Windows.Forms.DataGridViewComboBoxColumn difficultyLevelId;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionZoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionIdDataGridViewTextBoxColumn;
    }
}