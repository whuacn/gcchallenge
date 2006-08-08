using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using Timer=System.Timers.Timer;

namespace GmatClubTest.Practice
{
    public class TestForm : Form, ITestForm
    {
        private Button answerConfirmButton;
        private Button nextButton;
        private Button helpButton;
        private Button timeButton;
        private Button sectionExitButton;
        private Button testQuitButton;
        private TestController testController;
        internal StatusBar statusBar;
        internal Panel panel;
        internal Timer clockTimer;
        private Container components = null;

        public TestForm(TestController testController)
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (TestForm));
            this.answerConfirmButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.timeButton = new System.Windows.Forms.Button();
            this.sectionExitButton = new System.Windows.Forms.Button();
            this.testQuitButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.panel = new System.Windows.Forms.Panel();
            this.clockTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize) (this.clockTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // answerConfirmButton
            // 
            this.answerConfirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.answerConfirmButton.Enabled = false;
            this.answerConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.answerConfirmButton.Image = ((System.Drawing.Image) (resources.GetObject("answerConfirmButton.Image")));
            this.answerConfirmButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.answerConfirmButton.Location = new System.Drawing.Point(536, 392);
            this.answerConfirmButton.Name = "answerConfirmButton";
            this.answerConfirmButton.Size = new System.Drawing.Size(55, 50);
            this.answerConfirmButton.TabIndex = 19;
            this.answerConfirmButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.answerConfirmButton.Click += new System.EventHandler(this.answerConfirmButton_Click);
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
            // timeButton
            // 
            this.timeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.timeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.timeButton.Image = ((System.Drawing.Image) (resources.GetObject("timeButton.Image")));
            this.timeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeButton.Location = new System.Drawing.Point(144, 392);
            this.timeButton.Name = "timeButton";
            this.timeButton.Size = new System.Drawing.Size(55, 50);
            this.timeButton.TabIndex = 16;
            this.timeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.timeButton.Click += new System.EventHandler(this.timeButton_Click);
            // 
            // sectionExitButton
            // 
            this.sectionExitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sectionExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sectionExitButton.Image = ((System.Drawing.Image) (resources.GetObject("sectionExitButton.Image")));
            this.sectionExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sectionExitButton.Location = new System.Drawing.Point(80, 392);
            this.sectionExitButton.Name = "sectionExitButton";
            this.sectionExitButton.Size = new System.Drawing.Size(55, 50);
            this.sectionExitButton.TabIndex = 15;
            this.sectionExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sectionExitButton.Click += new System.EventHandler(this.sectionExitButton_Click);
            // 
            // testQuitButton
            // 
            this.testQuitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.testQuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.testQuitButton.Image = ((System.Drawing.Image) (resources.GetObject("testQuitButton.Image")));
            this.testQuitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testQuitButton.Location = new System.Drawing.Point(16, 392);
            this.testQuitButton.Name = "testQuitButton";
            this.testQuitButton.Size = new System.Drawing.Size(55, 50);
            this.testQuitButton.TabIndex = 14;
            this.testQuitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.testQuitButton.Click += new System.EventHandler(this.testQuitButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 451);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(670, 22);
            this.statusBar.TabIndex = 25;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(672, 376);
            this.panel.TabIndex = 26;
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 250;
            this.clockTimer.SynchronizingObject = this;
            this.clockTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.clockTimer_Elapsed);
            // 
            // TestForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(670, 473);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.answerConfirmButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.timeButton);
            this.Controls.Add(this.sectionExitButton);
            this.Controls.Add(this.testQuitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.VerbalForm_Closing);
            this.Load += new System.EventHandler(this.VerbalForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TestForm_HelpRequested);
            ((System.ComponentModel.ISupportInitialize) (this.clockTimer)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public void ReEnableButtons(INavigator navigator)
        {
            if (testController.IsQuestionAnswered())
            {
                nextButton.Enabled = true;
                answerConfirmButton.Enabled = false;
            }
            else
            {
                nextButton.Enabled = false;
            }
        }

        public void ChangeCaption(string caption)
        {
            Text = caption;
        }

        public void Exit()
        {
            testController.ConfirmExit();
        }

        private void testQuitButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void VerbalForm_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Exit();
        }

        private void timeButton_Click(object sender, EventArgs e)
        {
            testController.TimeButton_Click();
        }

        private void clockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            testController.OnTimerElapsed();
        }

        private void VerbalForm_Load(object sender, EventArgs e)
        {
            testController.FormLoading();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            answerConfirmButton.Enabled = true;
            nextButton.Enabled = false;
        }

        private void answerConfirmButton_Click(object sender, EventArgs e)
        {
            answerConfirmButton.Enabled = false;
            nextButton.Enabled = true;
            testController.NextQuestion();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            testController.ShowHelp();
        }

        private void TestForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            testController.ShowHelp();
        }

        private void sectionExitButton_Click(object sender, EventArgs e)
        {
            testController.SectionExit();
        }
    }
}