using System.ComponentModel;
using System.Windows.Forms;

namespace GmatClubTest.Practice
{
	/// <summary>
	/// Summary description for GeneralQuestionPanel.
	/// </summary>
	public class GeneralQuestionPanel : UserControl
	{
		internal Panel questionPanel;
		internal PictureBox questionPictureBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public GeneralQuestionPanel()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.questionPanel = new System.Windows.Forms.Panel();
			this.questionPictureBox = new System.Windows.Forms.PictureBox();
			this.questionPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// questionPanel
			// 
			this.questionPanel.AutoScroll = true;
			this.questionPanel.BackColor = System.Drawing.Color.White;
			this.questionPanel.Controls.Add(this.questionPictureBox);
			this.questionPanel.Location = new System.Drawing.Point(0, 0);
			this.questionPanel.Name = "questionPanel";
			this.questionPanel.Size = new System.Drawing.Size(672, 376);
			this.questionPanel.TabIndex = 29;
			// 
			// questionPictureBox
			// 
			this.questionPictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.questionPictureBox.Location = new System.Drawing.Point(0, 0);
			this.questionPictureBox.Name = "questionPictureBox";
			this.questionPictureBox.Size = new System.Drawing.Size(15, 15);
			this.questionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.questionPictureBox.TabIndex = 25;
			this.questionPictureBox.TabStop = false;
			// 
			// GeneralQuestionPanel
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.questionPanel);
			this.Name = "GeneralQuestionPanel";
			this.Size = new System.Drawing.Size(672, 376);
			this.questionPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
