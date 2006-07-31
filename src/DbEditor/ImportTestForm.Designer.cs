namespace GmatClubTest.DbEditor
{
    partial class ImportTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportTestForm));
            this.label1 = new System.Windows.Forms.Label();
            this.connectionComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baseDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPracticeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataset1 = new GmatClubTest.DbEditor.Data.Dataset();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.import = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.impotrFromTextFile = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fileDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPracticeDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileDataset = new global::ImportExport.Data.Dataset();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Connection";
            // 
            // connectionComboBox
            // 
            this.connectionComboBox.FormattingEnabled = true;
            this.connectionComboBox.Location = new System.Drawing.Point(101, 20);
            this.connectionComboBox.Name = "connectionComboBox";
            this.connectionComboBox.Size = new System.Drawing.Size(349, 21);
            this.connectionComboBox.TabIndex = 0;
            this.connectionComboBox.SelectedValueChanged += new System.EventHandler(this.connectionComboBox_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.connectionComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 60);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select connection";
            // 
            // baseDataGridView
            // 
            this.baseDataGridView.AllowUserToAddRows = false;
            this.baseDataGridView.AllowUserToDeleteRows = false;
            this.baseDataGridView.AllowUserToResizeRows = false;
            this.baseDataGridView.AutoGenerateColumns = false;
            this.baseDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.baseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.isPracticeDataGridViewCheckBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn});
            this.baseDataGridView.DataMember = "Tests";
            this.baseDataGridView.DataSource = this.dataset1;
            this.baseDataGridView.Location = new System.Drawing.Point(6, 19);
            this.baseDataGridView.MultiSelect = false;
            this.baseDataGridView.Name = "baseDataGridView";
            this.baseDataGridView.ReadOnly = true;
            this.baseDataGridView.Size = new System.Drawing.Size(450, 203);
            this.baseDataGridView.TabIndex = 0;
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
            // isPracticeDataGridViewCheckBoxColumn
            // 
            this.isPracticeDataGridViewCheckBoxColumn.DataPropertyName = "IsPractice";
            this.isPracticeDataGridViewCheckBoxColumn.HeaderText = "Is practice";
            this.isPracticeDataGridViewCheckBoxColumn.Name = "isPracticeDataGridViewCheckBoxColumn";
            this.isPracticeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataset1
            // 
            this.dataset1.DataSetName = "Dataset";
            this.dataset1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataset1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baseDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 228);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tests in DB";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "File";
            // 
            // import
            // 
            this.import.Enabled = false;
            this.import.Location = new System.Drawing.Point(200, 50);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(80, 23);
            this.import.TabIndex = 4;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.importButton_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(64, 19);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(216, 20);
            this.textBoxFileName.TabIndex = 8;
            // 
            // browse
            // 
            this.browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browse.Location = new System.Drawing.Point(288, 18);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(80, 23);
            this.browse.TabIndex = 9;
            this.browse.Text = "Browse...";
            this.browse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(288, 50);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(80, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox3.Controls.Add(this.impotrFromTextFile);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.import);
            this.groupBox3.Controls.Add(this.textBoxFileName);
            this.groupBox3.Controls.Add(this.browse);
            this.groupBox3.Controls.Add(this.cancel);
            this.groupBox3.Location = new System.Drawing.Point(94, 391);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 79);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // impotrFromTextFile
            // 
            this.impotrFromTextFile.Location = new System.Drawing.Point(11, 50);
            this.impotrFromTextFile.Name = "impotrFromTextFile";
            this.impotrFromTextFile.Size = new System.Drawing.Size(154, 23);
            this.impotrFromTextFile.TabIndex = 11;
            this.impotrFromTextFile.Text = "Impotr from text file";
            this.impotrFromTextFile.UseVisualStyleBackColor = true;
            this.impotrFromTextFile.Click += new System.EventHandler(this.impotrFromTypedTextFile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fileDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(12, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(463, 73);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test in file";
            // 
            // fileDataGridView
            // 
            this.fileDataGridView.AllowUserToAddRows = false;
            this.fileDataGridView.AllowUserToDeleteRows = false;
            this.fileDataGridView.AllowUserToResizeRows = false;
            this.fileDataGridView.AutoGenerateColumns = false;
            this.fileDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.isPracticeDataGridViewCheckBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.versionDataGridViewTextBoxColumn1});
            this.fileDataGridView.DataMember = "Tests";
            this.fileDataGridView.DataSource = this.fileDataset;
            this.fileDataGridView.Location = new System.Drawing.Point(0, 19);
            this.fileDataGridView.MultiSelect = false;
            this.fileDataGridView.Name = "fileDataGridView";
            this.fileDataGridView.ReadOnly = true;
            this.fileDataGridView.Size = new System.Drawing.Size(450, 48);
            this.fileDataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // isPracticeDataGridViewCheckBoxColumn1
            // 
            this.isPracticeDataGridViewCheckBoxColumn1.DataPropertyName = "IsPractice";
            this.isPracticeDataGridViewCheckBoxColumn1.HeaderText = "Is practice";
            this.isPracticeDataGridViewCheckBoxColumn1.Name = "isPracticeDataGridViewCheckBoxColumn1";
            this.isPracticeDataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn1
            // 
            this.versionDataGridViewTextBoxColumn1.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn1.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn1.Name = "versionDataGridViewTextBoxColumn1";
            this.versionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fileDataset
            // 
            this.fileDataset.DataSetName = "Dataset";
            this.fileDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ImportTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(487, 482);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import test";
            this.Load += new System.EventHandler(this.ImportTestForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.baseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileDataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox connectionComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView baseDataGridView;
        private System.Windows.Forms.BindingSource DatasetBindingSource;
        private GmatClubTest.DbEditor.Data.Dataset Dataset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private GmatClubTest.DbEditor.Data.Dataset dataset1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPracticeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView fileDataGridView;
        private global::ImportExport.Data.Dataset fileDataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPracticeDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button impotrFromTextFile;
    }
}