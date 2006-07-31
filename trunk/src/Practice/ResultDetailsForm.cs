using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;

namespace GmatClubTest.Practice
{
	public class ResultDetailsForm : Form
	{
		private Button button;
		private Manager manager;
		private ImageList imageList;
		private ImageList imageList24x24;
		private DataGridTableStyle dataGridTableStyle1;
		private DataGridTextBoxColumn dataGridTextBoxColumn1;
		private DataGrid questionStatusDataGrid;
		private DataGridTextBoxColumn dataGridTextBoxColumn3;
		private DataGridBoolColumn dataGridBoolColumn1;
		private GmatClubTest.Data.QuestionSetsResultDetailsSet questionSetsResultDetailsSet;
		private IContainer components;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGrid setStutusDataGrid;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2Text;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridSectionName;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridSectionScore;
		private int  resultId;

		public ResultDetailsForm(ResultSet.ResultsRow result, Manager manager)
		{
			InitializeComponent();
			this.manager = manager;
			resultId = result.Id;
		}

		public ResultDetailsForm(int resultId, Manager manager)
		{
			InitializeComponent();
			this.manager = manager;
			this.resultId = resultId;
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ResultDetailsForm));
			this.questionSetsResultDetailsSet = new GmatClubTest.Data.QuestionSetsResultDetailsSet();
			this.button = new System.Windows.Forms.Button();
			this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.questionStatusDataGrid = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2Text = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.setStutusDataGrid = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridSectionName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridSectionScore = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.questionSetsResultDetailsSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.questionStatusDataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.setStutusDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// questionSetsResultDetailsSet
			// 
			this.questionSetsResultDetailsSet.DataSetName = "QuestionSetsResultDetailsSet";
			this.questionSetsResultDetailsSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// button
			// 
			this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button.ImageIndex = 0;
			this.button.ImageList = this.imageList24x24;
			this.button.Location = new System.Drawing.Point(296, 392);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(96, 32);
			this.button.TabIndex = 3;
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
			this.questionStatusDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.questionStatusDataGrid.CaptionVisible = false;
			this.questionStatusDataGrid.DataMember = "QuestionSets.QuestionSetsAnswers";
			this.questionStatusDataGrid.DataSource = this.questionSetsResultDetailsSet;
			this.questionStatusDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.questionStatusDataGrid.Location = new System.Drawing.Point(8, 112);
			this.questionStatusDataGrid.Name = "questionStatusDataGrid";
			this.questionStatusDataGrid.ReadOnly = true;
			this.questionStatusDataGrid.RowHeadersVisible = false;
			this.questionStatusDataGrid.Size = new System.Drawing.Size(384, 272);
			this.questionStatusDataGrid.TabIndex = 2;
			this.questionStatusDataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											   this.dataGridTableStyle1});
			this.questionStatusDataGrid.Resize += new System.EventHandler(this.questionStatusDataGrid_Resize);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.questionStatusDataGrid;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2Text,
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
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 20;
			// 
			// dataGridTextBoxColumn2Text
			// 
			this.dataGridTextBoxColumn2Text.Format = "";
			this.dataGridTextBoxColumn2Text.FormatInfo = null;
			this.dataGridTextBoxColumn2Text.HeaderText = "Question text";
			this.dataGridTextBoxColumn2Text.MappingName = "QuestionText";
			this.dataGridTextBoxColumn2Text.ReadOnly = true;
			this.dataGridTextBoxColumn2Text.Width = 200;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Difficulty Level";
			this.dataGridTextBoxColumn3.MappingName = "QuestionDifficultyLevel";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 77;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = false;
			this.dataGridBoolColumn1.HeaderText = "Is correct";
			this.dataGridBoolColumn1.MappingName = "IsCorrect";
			this.dataGridBoolColumn1.NullValue = ((object)(resources.GetObject("dataGridBoolColumn1.NullValue")));
			this.dataGridBoolColumn1.ReadOnly = true;
			this.dataGridBoolColumn1.TrueValue = true;
			this.dataGridBoolColumn1.Width = 74;
			// 
			// setStutusDataGrid
			// 
			this.setStutusDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.setStutusDataGrid.CaptionVisible = false;
			this.setStutusDataGrid.DataMember = "QuestionSets";
			this.setStutusDataGrid.DataSource = this.questionSetsResultDetailsSet;
			this.setStutusDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.setStutusDataGrid.Location = new System.Drawing.Point(8, 16);
			this.setStutusDataGrid.Name = "setStutusDataGrid";
			this.setStutusDataGrid.ReadOnly = true;
			this.setStutusDataGrid.RowHeadersVisible = false;
			this.setStutusDataGrid.Size = new System.Drawing.Size(384, 96);
			this.setStutusDataGrid.TabIndex = 1;
			this.setStutusDataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										  this.dataGridTableStyle2});
			this.setStutusDataGrid.Resize += new System.EventHandler(this.setStutusDataGrid_Resize);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.setStutusDataGrid;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridSectionName,
																												  this.dataGridSectionScore});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "QuestionSets";
			this.dataGridTableStyle2.ReadOnly = true;
			this.dataGridTableStyle2.RowHeadersVisible = false;
			// 
			// dataGridSectionName
			// 
			this.dataGridSectionName.Format = "";
			this.dataGridSectionName.FormatInfo = null;
			this.dataGridSectionName.HeaderText = "Section name";
			this.dataGridSectionName.MappingName = "Name";
			this.dataGridSectionName.NullText = "";
			this.dataGridSectionName.Width = 275;
			// 
			// dataGridSectionScore
			// 
			this.dataGridSectionScore.Format = "";
			this.dataGridSectionScore.FormatInfo = null;
			this.dataGridSectionScore.HeaderText = "Score";
			this.dataGridSectionScore.MappingName = "Score";
			this.dataGridSectionScore.NullText = "";
			this.dataGridSectionScore.Width = 90;
			// 
			// ResultDetailsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 440);
			this.Controls.Add(this.setStutusDataGrid);
			this.Controls.Add(this.questionStatusDataGrid);
			this.Controls.Add(this.button);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "ResultDetailsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Details";
			this.Load += new System.EventHandler(this.ResultDetailsForm_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ResultDetailsForm_HelpRequested);
			((System.ComponentModel.ISupportInitialize)(this.questionSetsResultDetailsSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.questionStatusDataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.setStutusDataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ResultDetailsForm_Load(object sender, EventArgs e)
		{
			manager.GetQuestionSetsResultDetailsSet(resultId, questionSetsResultDetailsSet);
			Renderer renderer = new Renderer();
			renderer.RenderToString(questionSetsResultDetailsSet);

			questionStatusDataGrid_Resize(null, null);
			setStutusDataGrid_Resize(null, null);
		}

		private void ResultDetailsForm_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
		{
			MainForm.ShowHelpForm(HelpForm.HelpSubtype.Main);
		}

		private void questionStatusDataGrid_Resize(object sender, System.EventArgs e)
		{
			int s = dataGridTextBoxColumn1.Width;
			s += dataGridTextBoxColumn3.Width;
			s += dataGridBoolColumn1.Width;
	
			dataGridTextBoxColumn2Text.Width = questionStatusDataGrid.Width - s - 5;
		}

		private void setStutusDataGrid_Resize(object sender, System.EventArgs e)
		{
			dataGridSectionName.Width = setStutusDataGrid.Width - dataGridSectionScore.Width - 5;
		}

	}
}
