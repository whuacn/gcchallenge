using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GmatClubTest.UnexpectedExceptionDialog
{
    /// <summary>
    /// Summary description for ExceptionBox.
    /// </summary>
    public class ExceptionBox : Form
    {
        private Button detailsButton;
        private Button closeButton;
        private TextBox detailsBox;
        private TextBox messageBox;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private PictureBox pictureBox1;

        private int height;

        public static void Show(Exception exception)
        {
            (new ExceptionBox(exception)).ShowDialog();
        }

        public ExceptionBox()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public ExceptionBox(Exception exception)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            Text = "Unexpected exception";
            messageBox.Text = exception.Message;
            detailsBox.Text = ExceptionMessageRecursiveBuild(exception) + "\r\n\r\n" + exception.StackTrace;

            height = detailsBox.Height;

#if DEBUG
#else
         HideDetails();
#endif
        }

        private void HideDetails()
        {
            detailsBox.Visible = false;
            Height -= height;
            detailsButton.Text = "Show details >>";
        }

        private void ShowDetails()
        {
            Height += height;
            detailsBox.Visible = true;
            detailsButton.Text = "<< Hide details";
        }

        private static string ExceptionMessageRecursiveBuild(Exception e)
        {
            return
                e.InnerException != null
                    ? e.Message + " " + ExceptionMessageRecursiveBuild(e.InnerException)
                    : e.Message;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (ExceptionBox));
            this.detailsBox = new System.Windows.Forms.TextBox();
            this.detailsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // detailsBox
            // 
            this.detailsBox.AcceptsReturn = true;
            this.detailsBox.AcceptsTab = true;
            this.detailsBox.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsBox.Location = new System.Drawing.Point(8, 112);
            this.detailsBox.Multiline = true;
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.ReadOnly = true;
            this.detailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsBox.Size = new System.Drawing.Size(432, 160);
            this.detailsBox.TabIndex = 3;
            this.detailsBox.Text = "";
            // 
            // detailsButton
            // 
            this.detailsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.detailsButton.Location = new System.Drawing.Point(8, 80);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(96, 23);
            this.detailsButton.TabIndex = 1;
            this.detailsButton.Text = "<< Hide details";
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.closeButton.Location = new System.Drawing.Point(344, 80);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(96, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            // 
            // messageBox
            // 
            this.messageBox.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox.Location = new System.Drawing.Point(50, 8);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(390, 64);
            this.messageBox.TabIndex = 4;
            this.messageBox.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ExceptionBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 278);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.detailsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unexpected exception";
            this.ResumeLayout(false);
        }

        #endregion

        private void detailsButton_Click(object sender, EventArgs e)
        {
            if (detailsBox.Visible)
                HideDetails();
            else
                ShowDetails();
        }
    }
}