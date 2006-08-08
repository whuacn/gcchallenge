using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;

namespace GmatClubTest.Practice
{
    /// <summary>
    /// Summary description for TestDescription.
    /// </summary>
    public class DescriptionForm : Form, ITestForm
    {
        private IContainer components;
        private Button runButton;
        private Button cancelButton;
        private ImageList imageList24x24;
        internal RichTextBox descriptionRichTextBox;

        public DescriptionForm()
        {
            InitializeComponent();
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (DescriptionForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
            this.runButton = new System.Windows.Forms.Button();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.ImageIndex = 1;
            this.cancelButton.ImageList = this.imageList24x24;
            this.cancelButton.Location = new System.Drawing.Point(223, 408);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "E&xit Test";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // imageList24x24
            // 
            this.imageList24x24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList24x24.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList24x24.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList24x24.ImageStream")));
            this.imageList24x24.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // runButton
            // 
            this.runButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.runButton.ImageIndex = 0;
            this.runButton.ImageList = this.imageList24x24;
            this.runButton.Location = new System.Drawing.Point(351, 408);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(96, 32);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "&Continue";
            this.runButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.ReadOnly = true;
            this.descriptionRichTextBox.Size = new System.Drawing.Size(672, 392);
            this.descriptionRichTextBox.TabIndex = 4;
            this.descriptionRichTextBox.Text = "";
            // 
            // DescriptionForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(670, 456);
            this.Controls.Add(this.descriptionRichTextBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.DescriptionForm_HelpRequested);
            this.ResumeLayout(false);
        }

        #endregion

        private void runButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void ReEnableButtons(INavigator navigator)
        {
            throw new NotImplementedException();
        }

        public void ChangeCaption(string caption)
        {
            Text = caption;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        private void DescriptionForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MainForm.ShowHelpForm(HelpForm.HelpSubtype.Main);
        }
    }
}