using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GmatClubTest.Practice
{
	/// <summary>
	/// Summary description for ResultDitailsForm.
	/// </summary>
	public class ResultDitailsForm : Form
	{
		private Button button;
		private ComboBox setsComboBox;
		private Manager manager;
		private ResultSet.ResultsRow result;
		private ImageList imageList;
		private ImageList imageList24x24;
		private DataGridTableStyle dataGridTableStyle1;
		private DataGridTextBoxColumn dataGridTextBoxColumn1;
		private DataGridTextBoxColumn dataGridTextBoxColumn2;
		private DataGrid questionStatusDataGrid;
		private DataGridTextBoxColumn dataGridTextBoxColumn3;
		private DataGridBoolColumn dataGridBoolColumn1;
		private QuestionSetResultsDitailsExSet questionSetResultsDitailsExSet;
		private IContainer components;

		public ResultDitailsForm(ResultSet.ResultsRow result ,Manager manager)
		{
		
			InitializeComponent();
			this.manager = manager;
			this.result = result;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ResultDitailsForm));
			this.setsComboBox = new System.Windows.Forms.ComboBox();
			this.button = new System.Windows.Forms.Button();
			this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.questionStatusDataGrid = new System.Windows.Forms.DataGrid();
			this.questionSetResultsDitailsExSet = new GmatClubTest.Data.QuestionSetResultsDitailsExSet();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			((System.ComponentModel.ISupportInitialize)(this.questionStatusDataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.questionSetResultsDitailsExSet)).BeginInit();
			this.SuspendLayout();
			// 
			// setsComboBox
			// 
			this.setsComboBox.DataSource = this.questionSetResultsDitailsExSet;
			this.setsComboBox.DisplayMember = "QuestionSetsEx.Name";
			this.setsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.setsComboBox.Location = new System.Drawing.Point(16, 16);
			this.setsComboBox.Name = "setsComboBox";
			this.setsComboBox.Size = new System.Drawing.Size(376, 21);
			this.setsComboBox.TabIndex = 5;
			this.setsComboBox.ValueMember = "QuestionSetsEx.Id";
			// 
			// button
			// 
			this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button.ImageIndex = 0;
			this.button.ImageList = this.imageList24x24;
			this.button.Location = new System.Drawing.Point(152, 352);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(96, 32);
			this.button.TabIndex = 7;
			this.button.Text = "Ok";
			this.button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList24x24
			// 
			this.imageList24x24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList24x24.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList24x24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24x24.ImageStream")));
			this.imageList24x24.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// questionStatusDataGrid
			// 
			this.questionStatusDataGrid.AllowDrop = true;
			this.questionStatusDataGrid.CaptionVisible = false;
			this.questionStatusDataGrid.DataMember = "QuestionSetsEx.QuestionSetsExAnswers";
			this.questionStatusDataGrid.DataSource = this.questionSetResultsDitailsExSet;
			this.questionStatusDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.questionStatusDataGrid.Location = new System.Drawing.Point(16, 40);
			this.questionStatusDataGrid.Name = "questionStatusDataGrid";
			this.questionStatusDataGrid.ReadOnly = true;
			this.questionStatusDataGrid.RowHeadersVisible = false;
			this.questionStatusDataGrid.Size = new System.Drawing.Size(376, 296);
			this.questionStatusDataGrid.TabIndex = 8;
			this.questionStatusDataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											   this.dataGridTableStyle1});
			// 
			// questionSetResultsDitailsExSet
			// 
			this.questionSetResultsDitailsExSet.DataSetName = "QuestionSetResultsDitailsExSet";
			this.questionSetResultsDitailsExSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.questionStatusDataGrid;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridBoolColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Answers";
			this.dataGridTableStyle1.ReadOnly = true;
			this.dataGridTableStyle1.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "¹";
			this.dataGridTextBoxColumn1.MappingName = "QuestionOrder";
			this.dataGridTextBoxColumn1.Width = 20;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Question text";
			this.dataGridTextBoxColumn2.MappingName = "QuestionText";
			this.dataGridTextBoxColumn2.Width = 200;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Difficulty Level";
			this.dataGridTextBoxColumn3.MappingName = "QuestionDifficultyLevel";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.FalseValue = false;
			this.dataGridBoolColumn1.HeaderText = "Is correct";
			this.dataGridBoolColumn1.MappingName = "IsCorrect";
			this.dataGridBoolColumn1.NullValue = ((object)(resources.GetObject("dataGridBoolColumn1.NullValue")));
			this.dataGridBoolColumn1.TrueValue = true;
			this.dataGridBoolColumn1.Width = 75;
			// 
			// ResultDitailsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 400);
			this.Controls.Add(this.questionStatusDataGrid);
			this.Controls.Add(this.setsComboBox);
			this.Controls.Add(this.button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "ResultDitailsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ditails result";
			this.Load += new System.EventHandler(this.ResultDitailsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.questionStatusDataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.questionSetResultsDitailsExSet)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ResultDitailsForm_Load(object sender, EventArgs e)
		{
			manager.GetQuestionSetResultsDitailsExSet(result ,questionSetResultsDitailsExSet);
		}
	}
}
