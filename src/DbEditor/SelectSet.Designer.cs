namespace GmatClubTest.DbEditor
{
    partial class SelectSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSet));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setsDataGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionSubtypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setsDataset = new GmatClubTest.DbEditor.Data.Dataset();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setsDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.cancelButton);
            this.groupBox2.Location = new System.Drawing.Point(287, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 50);
            this.groupBox2.TabIndex = 10;
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setsDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 228);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select set (Section)";
            // 
            // setsDataGrid
            // 
            this.setsDataGrid.AllowUserToAddRows = false;
            this.setsDataGrid.AllowUserToDeleteRows = false;
            this.setsDataGrid.AutoGenerateColumns = false;
            this.setsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.setsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn,
            this.timeLimitDataGridViewTextBoxColumn,
            this.questionTypeIdDataGridViewTextBoxColumn,
            this.questionSubtypeIdDataGridViewTextBoxColumn,
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn,
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn,
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn});
            this.setsDataGrid.DataMember = "QuestionSets";
            this.setsDataGrid.DataSource = this.setsDataset;
            this.setsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setsDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.setsDataGrid.Location = new System.Drawing.Point(3, 16);
            this.setsDataGrid.MultiSelect = false;
            this.setsDataGrid.Name = "setsDataGrid";
            this.setsDataGrid.ReadOnly = true;
            this.setsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.setsDataGrid.Size = new System.Drawing.Size(455, 209);
            this.setsDataGrid.TabIndex = 0;
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
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberOfQuestionsToPickDataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsToPick";
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.HeaderText = "Number of questions to pick";
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.Name = "numberOfQuestionsToPickDataGridViewTextBoxColumn";
            this.numberOfQuestionsToPickDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeLimitDataGridViewTextBoxColumn
            // 
            this.timeLimitDataGridViewTextBoxColumn.DataPropertyName = "TimeLimit";
            this.timeLimitDataGridViewTextBoxColumn.HeaderText = "Time limit";
            this.timeLimitDataGridViewTextBoxColumn.Name = "timeLimitDataGridViewTextBoxColumn";
            this.timeLimitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // questionTypeIdDataGridViewTextBoxColumn
            // 
            this.questionTypeIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionTypeId";
            this.questionTypeIdDataGridViewTextBoxColumn.HeaderText = "QuestionTypeId";
            this.questionTypeIdDataGridViewTextBoxColumn.Name = "questionTypeIdDataGridViewTextBoxColumn";
            this.questionTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // questionSubtypeIdDataGridViewTextBoxColumn
            // 
            this.questionSubtypeIdDataGridViewTextBoxColumn.DataPropertyName = "QuestionSubtypeId";
            this.questionSubtypeIdDataGridViewTextBoxColumn.HeaderText = "QuestionSubtypeId";
            this.questionSubtypeIdDataGridViewTextBoxColumn.Name = "questionSubtypeIdDataGridViewTextBoxColumn";
            this.questionSubtypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionSubtypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // numberOfQuestionsInZone1DataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsInZone1";
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.HeaderText = "NumberOfQuestionsInZone1";
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.Name = "numberOfQuestionsInZone1DataGridViewTextBoxColumn";
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfQuestionsInZone1DataGridViewTextBoxColumn.Visible = false;
            // 
            // numberOfQuestionsInZone2DataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsInZone2";
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.HeaderText = "NumberOfQuestionsInZone2";
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.Name = "numberOfQuestionsInZone2DataGridViewTextBoxColumn";
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfQuestionsInZone2DataGridViewTextBoxColumn.Visible = false;
            // 
            // numberOfQuestionsInZone3DataGridViewTextBoxColumn
            // 
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.DataPropertyName = "NumberOfQuestionsInZone3";
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.HeaderText = "NumberOfQuestionsInZone3";
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.Name = "numberOfQuestionsInZone3DataGridViewTextBoxColumn";
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfQuestionsInZone3DataGridViewTextBoxColumn.Visible = false;
            // 
            // setsDataset
            // 
            this.setsDataset.DataSetName = "Dataset";
            this.setsDataset.Locale = new System.Globalization.CultureInfo("en-US");
            this.setsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SelectSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 303);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select set(section)";
            this.Load += new System.EventHandler(this.SelectSet_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.setsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setsDataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private GmatClubTest.DbEditor.Data.Dataset setsDataset;
        private System.Windows.Forms.DataGridView setsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfQuestionsToPickDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeLimitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionSubtypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfQuestionsInZone1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfQuestionsInZone2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfQuestionsInZone3DataGridViewTextBoxColumn;
    }
}