using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GmatClubTest.Practice
{
    public class ReviewForm : Form
    {
        private ColumnHeader namber;
        private ColumnHeader question;
        private ColumnHeader status;
        internal Button button;
        private ImageList imageList;
        private ImageList imageList24x24;
        private IContainer components;
        internal ListView questionStatusListView;
        internal ListView setStatusListView;
        private ColumnHeader SetName;
        private ColumnHeader Score;
        private ColumnHeader number;
        private TestController testController;

        public ReviewForm(TestController testController)
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (ReviewForm));
            this.button = new System.Windows.Forms.Button();
            this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
            this.questionStatusListView = new System.Windows.Forms.ListView();
            this.namber = new System.Windows.Forms.ColumnHeader();
            this.question = new System.Windows.Forms.ColumnHeader();
            this.status = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.setStatusListView = new System.Windows.Forms.ListView();
            this.number = new System.Windows.Forms.ColumnHeader();
            this.SetName = new System.Windows.Forms.ColumnHeader();
            this.Score = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button.ImageList = this.imageList24x24;
            this.button.Location = new System.Drawing.Point(296, 392);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(96, 32);
            this.button.TabIndex = 3;
            this.button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // imageList24x24
            // 
            this.imageList24x24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList24x24.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList24x24.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList24x24.ImageStream")));
            this.imageList24x24.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // questionStatusListView
            // 
            this.questionStatusListView.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.questionStatusListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionStatusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
                                                             {
                                                                 this.namber,
                                                                 this.question,
                                                                 this.status
                                                             });
            this.questionStatusListView.FullRowSelect = true;
            this.questionStatusListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.questionStatusListView.Location = new System.Drawing.Point(8, 112);
            this.questionStatusListView.MultiSelect = false;
            this.questionStatusListView.Name = "questionStatusListView";
            this.questionStatusListView.Size = new System.Drawing.Size(384, 272);
            this.questionStatusListView.SmallImageList = this.imageList;
            this.questionStatusListView.TabIndex = 2;
            this.questionStatusListView.View = System.Windows.Forms.View.Details;
            this.questionStatusListView.Resize += new System.EventHandler(this.questionStatusListView_Resize);
            this.questionStatusListView.DoubleClick += new System.EventHandler(this.questionStatuslistView_DoubleClick);
            // 
            // namber
            // 
            this.namber.Text = "¹";
            this.namber.Width = 43;
            // 
            // question
            // 
            this.question.Text = "Question";
            this.question.Width = 221;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 110;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // setStatusListView
            // 
            this.setStatusListView.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.setStatusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
                                                        {
                                                            this.number,
                                                            this.SetName,
                                                            this.Score
                                                        });
            this.setStatusListView.FullRowSelect = true;
            this.setStatusListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.setStatusListView.Location = new System.Drawing.Point(8, 16);
            this.setStatusListView.MultiSelect = false;
            this.setStatusListView.Name = "setStatusListView";
            this.setStatusListView.Size = new System.Drawing.Size(384, 96);
            this.setStatusListView.TabIndex = 4;
            this.setStatusListView.View = System.Windows.Forms.View.Details;
            this.setStatusListView.Resize += new System.EventHandler(this.setStatusListView_Resize);
            this.setStatusListView.Click += new System.EventHandler(this.setStatusListView_Click);
            // 
            // number
            // 
            this.number.Text = "¹";
            this.number.Width = 34;
            // 
            // SetName
            // 
            this.SetName.Text = "Section name";
            this.SetName.Width = 250;
            // 
            // Score
            // 
            this.Score.Text = "Score";
            this.Score.Width = 87;
            // 
            // ReviewForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(402, 440);
            this.Controls.Add(this.setStatusListView);
            this.Controls.Add(this.questionStatusListView);
            this.Controls.Add(this.button);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 474);
            this.Name = "ReviewForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Review";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ReviewForm_Closing);
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ReviewForm_HelpRequested);
            this.ResumeLayout(false);
        }

        #endregion

        private void questionStatuslistView_DoubleClick(object sender, EventArgs e)
        {
            testController.TransitionOnSelectQuestion(setStatusListView.SelectedItems[0].Index,
                                                      ((ListView) sender).SelectedItems[0].Index);
        }

        private void ReviewForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MainForm.ShowHelpForm(HelpForm.HelpSubtype.Main);
        }

        private void setStatusListView_Click(object sender, EventArgs e)
        {
            testController.SelectedSetChanged();
        }

        private void setStatusListView_Resize(object sender, EventArgs e)
        {
            setStatusListView.Columns[1].Width = setStatusListView.Width - 5 -
                                                 (setStatusListView.Columns[0].Width +
                                                  setStatusListView.Columns[2].Width);
        }

        private void questionStatusListView_Resize(object sender, EventArgs e)
        {
            questionStatusListView.Columns[1].Width = questionStatusListView.Width - 5 -
                                                      (questionStatusListView.Columns[0].Width +
                                                       questionStatusListView.Columns[2].Width);
        }

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            setStatusListView_Resize(null, null);
            questionStatusListView_Resize(null, null);
        }

        private void button_Click(object sender, EventArgs e)
        {
            testController.OnRewievFormClosing();
        }

        private void ReviewForm_Closing(object sender, CancelEventArgs e)
        {
            testController.OnRewievFormClosing();
        }
    }
}