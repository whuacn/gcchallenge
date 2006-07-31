using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GmatClubTest.Practice
{
	/// <summary>
	/// Summary description for ResultsForm.
	/// </summary>
	public class ResultsForm : Form
	{
		private Button okButton;
		private ImageList imageList24x24;
		private IContainer components;
		private DateTimePicker beginDateTimePicker;
		private DateTimePicker endDateTimePicker;
		private DataGrid resultsGrid;
		private DataGridTableStyle dataGridTableStyle1;
		private DataGridTextBoxColumn dataGridTextBoxColumn1;
		private Label label1;
		private Label label2;
		private Manager manager;
		private Button viewDetailsButton;
		private ResultSet results;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3Text;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn4;
		private Label label3;

		public ResultsForm(Manager manager)
		{
			InitializeComponent();
			this.manager = manager;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ResultsForm));
			this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.okButton = new System.Windows.Forms.Button();
			this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
			this.viewDetailsButton = new System.Windows.Forms.Button();
			this.resultsGrid = new System.Windows.Forms.DataGrid();
			this.results = new GmatClubTest.Data.ResultSet();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3Text = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn4 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.results)).BeginInit();
			this.SuspendLayout();
			// 
			// beginDateTimePicker
			// 
			this.beginDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.beginDateTimePicker.CustomFormat = "ddMMMMyyyy  HH:mm:ss";
			this.beginDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.beginDateTimePicker.Location = new System.Drawing.Point(48, 351);
			this.beginDateTimePicker.Name = "beginDateTimePicker";
			this.beginDateTimePicker.Size = new System.Drawing.Size(104, 20);
			this.beginDateTimePicker.TabIndex = 2;
			this.beginDateTimePicker.Value = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.beginDateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
			// 
			// endDateTimePicker
			// 
			this.endDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.endDateTimePicker.CustomFormat = "ddMMMMyyyy  HH:mm:ss";
			this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.endDateTimePicker.Location = new System.Drawing.Point(48, 383);
			this.endDateTimePicker.Name = "endDateTimePicker";
			this.endDateTimePicker.Size = new System.Drawing.Size(104, 20);
			this.endDateTimePicker.TabIndex = 3;
			this.endDateTimePicker.Value = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
			this.endDateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.okButton.ImageIndex = 0;
			this.okButton.ImageList = this.imageList24x24;
			this.okButton.Location = new System.Drawing.Point(504, 369);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(96, 32);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "Done";
			this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// imageList24x24
			// 
			this.imageList24x24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList24x24.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList24x24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24x24.ImageStream")));
			this.imageList24x24.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// viewDetailsButton
			// 
			this.viewDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.viewDetailsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.viewDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.viewDetailsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.viewDetailsButton.ImageIndex = 2;
			this.viewDetailsButton.ImageList = this.imageList24x24;
			this.viewDetailsButton.Location = new System.Drawing.Point(504, 327);
			this.viewDetailsButton.Name = "viewDetailsButton";
			this.viewDetailsButton.Size = new System.Drawing.Size(96, 32);
			this.viewDetailsButton.TabIndex = 4;
			this.viewDetailsButton.Text = "&View details";
			this.viewDetailsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.viewDetailsButton.Click += new System.EventHandler(this.viewDetailsButton_Click);
			// 
			// resultsGrid
			// 
			this.resultsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.resultsGrid.CaptionVisible = false;
			this.resultsGrid.DataMember = "Results";
			this.resultsGrid.DataSource = this.results;
			this.resultsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.resultsGrid.Location = new System.Drawing.Point(8, 8);
			this.resultsGrid.Name = "resultsGrid";
			this.resultsGrid.PreferredColumnWidth = 100;
			this.resultsGrid.ReadOnly = true;
			this.resultsGrid.RowHeadersVisible = false;
			this.resultsGrid.Size = new System.Drawing.Size(590, 302);
			this.resultsGrid.TabIndex = 1;
			this.resultsGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.resultsGrid.Resize += new System.EventHandler(this.resultsGrid_Resize);
			this.resultsGrid.DoubleClick += new System.EventHandler(this.resultsGrid_DoubleClick);
			// 
			// results
			// 
			this.results.DataSetName = "ResultSet";
			this.results.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.resultsGrid;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3Text,
																												  this.dataGridBoolColumn4,
																												  this.dataGridTextBoxColumn5});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Results";
			this.dataGridTableStyle1.PreferredColumnWidth = 100;
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Start time";
			this.dataGridTextBoxColumn1.MappingName = "StartTime";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 120;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "End time";
			this.dataGridTextBoxColumn2.MappingName = "EndTime";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 120;
			// 
			// dataGridTextBoxColumn3Text
			// 
			this.dataGridTextBoxColumn3Text.Format = "";
			this.dataGridTextBoxColumn3Text.FormatInfo = null;
			this.dataGridTextBoxColumn3Text.HeaderText = "Test";
			this.dataGridTextBoxColumn3Text.MappingName = "TestName";
			this.dataGridTextBoxColumn3Text.ReadOnly = true;
			this.dataGridTextBoxColumn3Text.Width = 210;
			// 
			// dataGridBoolColumn4
			// 
			this.dataGridBoolColumn4.FalseValue = true;
			this.dataGridBoolColumn4.HeaderText = "Is test";
			this.dataGridBoolColumn4.MappingName = "TestIsPractice";
			this.dataGridBoolColumn4.NullValue = ((object)(resources.GetObject("dataGridBoolColumn4.NullValue")));
			this.dataGridBoolColumn4.ReadOnly = true;
			this.dataGridBoolColumn4.TrueValue = false;
			this.dataGridBoolColumn4.Width = 40;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Score";
			this.dataGridTextBoxColumn5.MappingName = "Score";
			this.dataGridTextBoxColumn5.ReadOnly = true;
			this.dataGridTextBoxColumn5.Width = 50;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.label1.Location = new System.Drawing.Point(8, 352);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "From";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.label2.Location = new System.Drawing.Point(8, 384);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "To";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Location = new System.Drawing.Point(8, 320);
			this.label3.Name = "label3";
			this.label3.TabIndex = 9;
			this.label3.Text = "Show period:";
			// 
			// ResultsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.viewDetailsButton;
			this.ClientSize = new System.Drawing.Size(606, 414);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.resultsGrid);
			this.Controls.Add(this.viewDetailsButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.endDateTimePicker);
			this.Controls.Add(this.beginDateTimePicker);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(614, 448);
			this.Name = "ResultsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "History of Results";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ResultsForm_Closing);
			this.Load += new System.EventHandler(this.ResultsForm_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ResultsForm_HelpRequested);
			((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.results)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ResultsForm_Load(object sender, EventArgs e)
		{
			manager.GetResults(manager.UserId, beginDateTimePicker.Value, endDateTimePicker.Value, results);
			resultsGrid_Resize(null, null);
		}

		private void DateTimePickerValueChanged(object sender, EventArgs e)
		{
			results.Clear();
			manager.GetResults(manager.UserId, beginDateTimePicker.Value, endDateTimePicker.Value, results);
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Dispose();
		}

		private void viewDetailsButton_Click(object sender, EventArgs e)
		{
			if (resultsGrid.CurrentRowIndex != -1)
			{
				ResultDetailsForm resultDetailsForm = new ResultDetailsForm(results.Results[resultsGrid.CurrentRowIndex], manager);
				resultDetailsForm.ShowDialog();
			}
			this.DialogResult = DialogResult.Abort;
		}

		private void resultsGrid_DoubleClick(object sender, EventArgs e)
		{
			viewDetailsButton_Click(null, null);
		}

		private void ResultsForm_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
		{
			MainForm.ShowHelpForm(HelpForm.HelpSubtype.Main);
		}

		private void ResultsForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.DialogResult == DialogResult.Abort)
			{
				e.Cancel = true;
			}
		}

		private void resultsGrid_Resize(object sender, System.EventArgs e)
		{
			int s = dataGridTextBoxColumn1.Width;
			s += dataGridTextBoxColumn2.Width;
			s += dataGridBoolColumn4.Width;
			s += dataGridTextBoxColumn5.Width;

			dataGridTextBoxColumn3Text.Width = resultsGrid.Width - s - 40;
		}
	}
}
