using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GmatClubTest.DbEditor
{
	public class ProcessingForm : Form
	{
		private GroupBox groupBox;
		public ProgressBar progressBar;
		private Label label;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ProcessingForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.label);
            this.groupBox.Controls.Add(this.progressBar);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(488, 120);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // label
            // 
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label.Location = new System.Drawing.Point(16, 40);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(456, 16);
            this.label.TabIndex = 1;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 64);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(456, 23);
            this.progressBar.TabIndex = 0;
            // 
            // ProcessingForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(488, 120);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingForm";
            this.TopMost = true;
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
        public string Caption
		{
			get {return groupBox.Text;}
			set {groupBox.Text = value;}
		}

		public string Operation
		{
			get {return label.Text;}
			set {label.Text = value;}
		}

		public int Progress
		{
			get {return progressBar.Value;}
			set {progressBar.Value = value;}
		}
        DateTime startDT;
        bool first;
        int i = 0;
	    public void ReDrowProgress()
	    {
            TimeSpan m = (DateTime.Now - startDT);
            if ((m.TotalMilliseconds > i) || (first))
            {
                if (first) { Update(); i = 0; }
                first = false;

                if (progressBar.Value == progressBar.Maximum -1)
                {
                    progressBar.Value = 0;
                }
                progressBar.Value += 1;
                i += 25;
            }
                
	    }
	    
        public void StartSomeProcess()
        {
            startDT = DateTime.Now;
            progressBar.Style = ProgressBarStyle.Marquee;
            first = true;
        }

	}
}
