using System.ComponentModel;
using System.Windows.Forms;

namespace GmatClubTest.Practice
{
	/// <summary>
	/// Summary description for ReadingComprehensionPanel.
	/// </summary>
	public class ReadingComprehensionPanel : UserControl
	{
		internal PictureBox passagePictureBox;
		internal PictureBox questionPictureBox;
		private System.Windows.Forms.Panel passagePanel;
		internal System.Windows.Forms.Panel questionPanel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ReadingComprehensionPanel()
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
			this.passagePanel = new System.Windows.Forms.Panel();
			this.passagePictureBox = new System.Windows.Forms.PictureBox();
			this.questionPanel = new System.Windows.Forms.Panel();
			this.questionPictureBox = new System.Windows.Forms.PictureBox();
			this.passagePanel.SuspendLayout();
			this.questionPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// passagePanel
			// 
			this.passagePanel.AutoScroll = true;
			this.passagePanel.BackColor = System.Drawing.Color.White;
			this.passagePanel.Controls.Add(this.passagePictureBox);
			this.passagePanel.Location = new System.Drawing.Point(0, 0);
			this.passagePanel.Name = "passagePanel";
			this.passagePanel.Size = new System.Drawing.Size(335, 376);
			this.passagePanel.TabIndex = 30;
			// 
			// passagePictureBox
			// 
			this.passagePictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.passagePictureBox.Location = new System.Drawing.Point(0, 0);
			this.passagePictureBox.Name = "passagePictureBox";
			this.passagePictureBox.Size = new System.Drawing.Size(15, 15);
			this.passagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.passagePictureBox.TabIndex = 25;
			this.passagePictureBox.TabStop = false;
			// 
			// questionPanel
			// 
			this.questionPanel.AutoScroll = true;
			this.questionPanel.BackColor = System.Drawing.Color.White;
			this.questionPanel.Controls.Add(this.questionPictureBox);
			this.questionPanel.Location = new System.Drawing.Point(336, 0);
			this.questionPanel.Name = "questionPanel";
			this.questionPanel.Size = new System.Drawing.Size(336, 376);
			this.questionPanel.TabIndex = 31;
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
			// ReadingComprehensionPanel
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.passagePanel);
			this.Controls.Add(this.questionPanel);
			this.Name = "ReadingComprehensionPanel";
			this.Size = new System.Drawing.Size(672, 376);
			this.passagePanel.ResumeLayout(false);
			this.questionPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void answerPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}
