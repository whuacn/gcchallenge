using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.License;

namespace GmatClubTest.Practice
{
    /// <summary>
    /// Summary description for LicenseForm.
    /// </summary>
    public class LicenseForm : Form
    {
        private ImageList imageList24x24;
        private OpenFileDialog openFileDialog;
        private IContainer components;
        private Panel panel1;
        private TextBox licensedBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private LinkLabel link;
        private PictureBox pictureBox1;
        private Label label4;
        private LinkLabel linkLabel1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button browseButton;
        private Button cancelOkButton;
        private string publickKeyFileName;

        public LicenseForm(string publickKeyFileName)
        {
            this.publickKeyFileName = publickKeyFileName;
            InitializeComponent();
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (LicenseForm));
            this.browseButton = new System.Windows.Forms.Button();
            this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
            this.cancelOkButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.licensedBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.browseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseButton.ImageIndex = 0;
            this.browseButton.ImageList = this.imageList24x24;
            this.browseButton.Location = new System.Drawing.Point(280, 456);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(96, 32);
            this.browseButton.TabIndex = 11;
            this.browseButton.Text = "&Browse...";
            this.browseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // imageList24x24
            // 
            this.imageList24x24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList24x24.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList24x24.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList24x24.ImageStream")));
            this.imageList24x24.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // cancelOkButton
            // 
            this.cancelOkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelOkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelOkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelOkButton.ImageIndex = 1;
            this.cancelOkButton.ImageList = this.imageList24x24;
            this.cancelOkButton.Location = new System.Drawing.Point(280, 504);
            this.cancelOkButton.Name = "cancelOkButton";
            this.cancelOkButton.Size = new System.Drawing.Size(96, 32);
            this.cancelOkButton.TabIndex = 13;
            this.cancelOkButton.Text = "&Close";
            this.cancelOkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelOkButton.Click += new System.EventHandler(this.cancelOkButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "License files|*.gcl";
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 390);
            this.panel1.TabIndex = 14;
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
            this.licensedBox.TabIndex = 5;
            this.licensedBox.Text = "No valid license";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "This product is licensed to:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Copyright (c) 2005 GMAT Club. All rights reserved";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "GMAT Club Test - Practice version 1.0";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(140, 357);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(103, 23);
            this.link.TabIndex = 1;
            this.link.TabStop = true;
            this.link.Text = "www.gmatclub.com";
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
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
            this.label4.Location = new System.Drawing.Point(48, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 27);
            this.label4.TabIndex = 15;
            this.label4.Text = "You can buy GMAT Club Test - Practice on-line:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(208, 408);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(168, 16);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.gmatclub.com/practice/buy";
            this.linkLabel1.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
            this.label5.Location = new System.Drawing.Point(0, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 34);
            this.label5.TabIndex = 17;
            this.label5.Text = "1.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
            this.label6.Location = new System.Drawing.Point(0, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 34);
            this.label6.TabIndex = 18;
            this.label6.Text = "2.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(48, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 27);
            this.label7.TabIndex = 19;
            this.label7.Text = "Browse for your license that you received after step 1 :";
            // 
            // LicenseForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelOkButton;
            this.ClientSize = new System.Drawing.Size(380, 544);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.cancelOkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void CopyAndRegisterLicenseFile()
        {
            string dist = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                          "\\GMATClubTest - Practice\\" +
                          openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf("\\"));
            File.Copy(openFileDialog.FileName, dist, true);
            MainForm.registryKey.SetValue("LicenseFileName", dist);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MainForm.license = Manager.CheckLicense(openFileDialog.FileName, publickKeyFileName);

                    MessageBox.Show("The license is valid.", MainForm.APP_CAPTION, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    CopyAndRegisterLicenseFile();

                    cancelOkButton.Text = "Ok";
                    cancelOkButton.ImageIndex = 0;
                }
                catch (Exception ex)
                {
                    MainForm.license = null;
                    MessageBox.Show("Bad license: " + ex.Message, MainForm.APP_CAPTION, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    cancelOkButton.Text = "&Close";
                    cancelOkButton.ImageIndex = 1;
                    DialogResult = DialogResult.None;
                }

                ShowLicenceInfo();
            }
        }

        private void cancelOkButton_Click(object sender, EventArgs e)
        {
            if (cancelOkButton.Text == "&Close")
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            ShowLicenceInfo();
        }

        private void ShowLicenceInfo()
        {
            if (MainForm.license != null)
            {
                licensedBox.Text = "User: " + MainForm.license.User + "\r\n" +
                                   "License Type: " + MainForm.license.LicenseType + "\r\n" +
                                   "Expired: " + MainForm.license.Expired + "\r\n" +
                                   "S/N: " + MainForm.license.SerialNumber + "\r\n" +
                                   "Issued: " + MainForm.license.Issued;
            }
            else
            {
                licensedBox.Text = "No license";
            }
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://" + ((LinkLabel) (sender)).Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://" + ((LinkLabel) (sender)).Text);
        }
    }
}