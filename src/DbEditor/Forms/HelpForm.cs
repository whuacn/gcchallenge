using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GmatClubTest.DbEditor
{
    /// <summary>
    /// Summary description for HelpForm.
    /// </summary>
    public class HelpForm : Form
    {
        private IContainer components;
        private RichTextBox helpRichTextBox;
        private ImageList imageList16x16;
        private TreeView topicsTree;
        private string path;

        public enum HelpSubtype
        {
            DataSufficiency = 1,
            ProblemSolving = 2,
            ReadingComprehensionQuestionToPassage = 3,
            CriticalReasoning = 4,
            SentenceCorrection = 5,
            Main = 6
        } ;

        public int helpTypeId = 6;

        public HelpForm()
        {
            InitializeComponent();
            topicsTree.ExpandAll();
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (HelpForm));
            this.helpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.imageList16x16 = new System.Windows.Forms.ImageList(this.components);
            this.topicsTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // helpRichTextBox
            // 
            this.helpRichTextBox.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.helpRichTextBox.Location = new System.Drawing.Point(256, 0);
            this.helpRichTextBox.Name = "helpRichTextBox";
            this.helpRichTextBox.ReadOnly = true;
            this.helpRichTextBox.Size = new System.Drawing.Size(528, 560);
            this.helpRichTextBox.TabIndex = 6;
            this.helpRichTextBox.Text = "";
            // 
            // imageList16x16
            // 
            this.imageList16x16.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList16x16.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList16x16.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList16x16.ImageStream")));
            this.imageList16x16.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // topicsTree
            // 
            this.topicsTree.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)));
            this.topicsTree.FullRowSelect = true;
            this.topicsTree.ImageList = this.imageList16x16;
            this.topicsTree.Location = new System.Drawing.Point(0, 0);
            this.topicsTree.Name = "topicsTree";
            this.topicsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[]
                                               {
                                                   new System.Windows.Forms.TreeNode("Help",
                                                                                     new System.Windows.Forms.TreeNode[]
                                                                                         {
                                                                                             new
                                                                                                 System.Windows.Forms.
                                                                                                 TreeNode(
                                                                                                 "Data Sufficiency", 1,
                                                                                                 1),
                                                                                             new
                                                                                                 System.Windows.Forms.
                                                                                                 TreeNode(
                                                                                                 "Probles Solving", 1, 1)
                                                                                             ,
                                                                                             new
                                                                                                 System.Windows.Forms.
                                                                                                 TreeNode(
                                                                                                 "Reading Comprehension Question to Passage",
                                                                                                 1, 1),
                                                                                             new
                                                                                                 System.Windows.Forms.
                                                                                                 TreeNode(
                                                                                                 "Critical Reasoning Passage",
                                                                                                 1, 1),
                                                                                             new
                                                                                                 System.Windows.Forms.
                                                                                                 TreeNode(
                                                                                                 "Sentence Correction",
                                                                                                 1, 1)
                                                                                         })
                                               });
            this.topicsTree.Size = new System.Drawing.Size(256, 560);
            this.topicsTree.TabIndex = 8;
            this.topicsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.topicsTree_AfterSelect);
            // 
            // HelpForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(784, 558);
            this.Controls.Add(this.topicsTree);
            this.Controls.Add(this.helpRichTextBox);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.HelpForm_Closing);
            this.Activated += new System.EventHandler(this.HelpForm_Activated);
            this.ResumeLayout(false);
        }

        #endregion

        private void topicsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string helpName = "";
            if (e.Node.Text == "Help")
            {
                path = Application.StartupPath + "\\" + "Help_Main.rtf";
                helpRichTextBox.LoadFile(path);
                return;
            }
            helpName = HelpSubtype.GetName(typeof (HelpSubtype), e.Node.Index + 1).ToString();
            if (helpName != "")
            {
                path = Application.StartupPath + "\\Help_" + helpName + ".rtf";
                helpRichTextBox.LoadFile(path);
            }
        }

        private void HelpForm_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void HelpForm_Activated(object sender, EventArgs e)
        {
            if (helpTypeId == 6)
            {
                path = Application.StartupPath + "\\" + "Help_Main.rtf";
                helpRichTextBox.LoadFile(path);
            }
            else
            {
                string helpName = "";
                helpName = HelpSubtype.GetName(typeof (HelpSubtype), helpTypeId).ToString();
                path = Application.StartupPath + "\\Help_" + helpName + ".rtf";
                helpRichTextBox.LoadFile(path);
            }
        }
    }
}