using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using Timer=System.Timers.Timer;

namespace GmatClubTest.Practice
{
    /// <summary>
    /// Summary description for PracticeForm.
    /// </summary>
    public class PracticeForm : Form, ITestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private Button nextButton;
        private Button helpButton;
        private Button prevButton;
        private Button answerCheckButton;
        private Button reviewButton;
        private Button exitButton;
        internal Panel panel;
        internal StatusBar statusBar;
        internal Timer clockTimer;
        private TestController testController;

        public PracticeForm(TestController testController)
        {
            InitializeComponent();
            this.testController = testController;
        }

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (PracticeForm));
            this.nextButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.answerCheckButton = new System.Windows.Forms.Button();
            this.reviewButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.clockTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize) (this.clockTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextButton.Image = ((System.Drawing.Image) (resources.GetObject("nextButton.Image")));
            this.nextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nextButton.Location = new System.Drawing.Point(600, 392);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(55, 50);
            this.nextButton.TabIndex = 18;
            this.nextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpButton.Image = ((System.Drawing.Image) (resources.GetObject("helpButton.Image")));
            this.helpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.Location = new System.Drawing.Point(472, 392);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(55, 50);
            this.helpButton.TabIndex = 17;
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Image = ((System.Drawing.Image) (resources.GetObject("exitButton.Image")));
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.Location = new System.Drawing.Point(16, 392);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(55, 50);
            this.exitButton.TabIndex = 14;
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.prevButton.Enabled = false;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prevButton.Image = ((System.Drawing.Image) (resources.GetObject("prevButton.Image")));
            this.prevButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prevButton.Location = new System.Drawing.Point(536, 392);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(55, 50);
            this.prevButton.TabIndex = 20;
            this.prevButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // answerCheckButton
            // 
            this.answerCheckButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.answerCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.answerCheckButton.Image = ((System.Drawing.Image) (resources.GetObject("answerCheckButton.Image")));
            this.answerCheckButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.answerCheckButton.Location = new System.Drawing.Point(408, 392);
            this.answerCheckButton.Name = "answerCheckButton";
            this.answerCheckButton.Size = new System.Drawing.Size(55, 50);
            this.answerCheckButton.TabIndex = 21;
            this.answerCheckButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.answerCheckButton.Click += new System.EventHandler(this.answerCheckButton_Click);
            // 
            // reviewButton
            // 
            this.reviewButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.reviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reviewButton.Image = ((System.Drawing.Image) (resources.GetObject("reviewButton.Image")));
            this.reviewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reviewButton.Location = new System.Drawing.Point(80, 392);
            this.reviewButton.Name = "reviewButton";
            this.reviewButton.Size = new System.Drawing.Size(55, 50);
            this.reviewButton.TabIndex = 22;
            this.reviewButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reviewButton.Click += new System.EventHandler(this.reviewButton_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(672, 376);
            this.panel.TabIndex = 23;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 451);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(670, 22);
            this.statusBar.TabIndex = 24;
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 250;
            this.clockTimer.SynchronizingObject = this;
            this.clockTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.clockTimer_Elapsed);
            // 
            // PracticeForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(670, 473);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.reviewButton);
            this.Controls.Add(this.answerCheckButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PracticeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Practice";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PracticeForm_Closing);
            this.Load += new System.EventHandler(this.PracticeForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.PracticeForm_HelpRequested);
            ((System.ComponentModel.ISupportInitialize) (this.clockTimer)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void nextButton_Click(object sender, EventArgs e)
        {
            testController.NextQuestion();
        }


        private void PracticeForm_Load(object sender, EventArgs e)
        {
            testController.FormLoading();
        }

        public void ReEnableButtons(INavigator navigator)
        {
            if (navigator.HasPreviousQuestion)
            {
                prevButton.Enabled = true;
            }
            else
            {
                if (navigator.HasPreviousSet)
                {
                    prevButton.Enabled = true;
                }
                else
                {
                    prevButton.Enabled = false;
                }
            }
        }

        public void ChangeCaption(string caption)
        {
            Text = caption;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            testController.PrevQuestion();
        }

        private void answerCheckButton_Click(object sender, EventArgs e)
        {
            testController.AnswerCheck_Click();
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            testController.ReviewButton_Click();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            testController.ConfirmExit();
        }

        private void PracticeForm_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            testController.ConfirmExit();
        }

        private void clockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            testController.OnTimerElapsed();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            testController.ShowHelp();
        }


        private void PracticeForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            testController.ShowHelp();
        }
    }
}