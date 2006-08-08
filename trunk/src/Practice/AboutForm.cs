using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace GmatClubTest.Practice
{
    /// <summary>
    /// Summary description for AboutForm.
    /// </summary>
    public class AboutForm : Form
    {
        private Button okButton;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox licensedBox;
        private Label label4;
        private LinkLabel link;
        private Label label5;
        private LinkLabel linkLabel1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public AboutForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            licensedBox.Text = "User: " + MainForm.license.User + "\r\n" +
                               "License Type: " + MainForm.license.LicenseType + "\r\n" +
                               "Expired: " + MainForm.license.Expired + "\r\n" +
                               "S/N: " + MainForm.license.SerialNumber + "\r\n" +
                               "Issued: " + MainForm.license.Issued;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (AboutForm));
            this.okButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.licensedBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.okButton.Image = ((System.Drawing.Image) (resources.GetObject("okButton.Image")));
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(279, 418);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(96, 32);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&Ok";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.licensedBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.link);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 412);
            this.panel1.TabIndex = 9;
            // 
            // licensedBox
            // 
            this.licensedBox.BackColor = System.Drawing.Color.White;
            this.licensedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licensedBox.Location = new System.Drawing.Point(11, 269);
            this.licensedBox.Multiline = true;
            this.licensedBox.Name = "licensedBox";
            this.licensedBox.ReadOnly = true;
            this.licensedBox.Size = new System.Drawing.Size(360, 72);
            this.licensedBox.TabIndex = 3;
            this.licensedBox.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "This product is licensed to:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Copyright (c) 2005 GMAT Club. All rights reserved";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "GMAT Club Test - Practice version 1.0";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(140, 357);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(102, 23);
            this.link.TabIndex = 4;
            this.link.TabStop = true;
            this.link.Text = "www.gmatclub.com";
            this.link.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 81);
            this.label4.TabIndex = 0;
            this.label4.Text =
                @"Warning: This computer program is protected by copyright law and international treaties. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties, and will be prosecuted to the maximum extent possible under the law.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Magic Library v.1.7.4 is used in this software";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(238, 389);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 15);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.dotnetmagic.com";
            this.linkLabel1.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(380, 496);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About GMAT Club Test - Practice";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://" + link.Text);
        }
    }
}