using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using GmatClubTest.License;
using GmatClubTest.UnexpectedExceptionDialog;
using Microsoft.Win32;
using TabControl=Crownwood.Magic.Controls.TabControl;
using TabPage=Crownwood.Magic.Controls.TabPage;

namespace GmatClubTest.ManualLicenseIssuer
{
    public class MainForm : Form
    {
        private TabControl tabControl;
        private TabPage issueTabPage;
        private ImageList imageList;
        private TabPage checkTabPage;
        private TabPage keyTabPage;
        private Button issueButton;
        private TextBox serialNumberBox;
        private Label label7;
        private DateTimePicker issuedDatePicker;
        private Label label6;
        private DateTimePicker expiredDatePicker;
        private Label label5;
        private ComboBox licenseTypeCombo;
        private Label label4;
        private TextBox userNameBox;
        private Label label3;
        private TextBox licenseInfoBox;
        private Label label9;
        private Label label8;
        private TextBox licenseFileNameBox;
        private Label label2;
        private TextBox keyInfoBox;
        private Button exportButton;
        private Button generateButton;
        private Label label1;
        private TextBox keyFileNameBox;
        private Button browselicenseButton;
        private Button browseKeyButton;
        private IContainer components;

        public static string APP_CAPTION = "GMAT Club Test - Manual License Issuer";

        private bool isPublicKeyOk = false;
        private bool isPrivateKeyOk = false;
        private SaveFileDialog saveKeyPairDialog;
        private OpenFileDialog openKeyDialog;
        private SaveFileDialog exportPublicKeyDialog;
        private OpenFileDialog openLicenseDialog;
        private SaveFileDialog saveLicenseDialog;
        private RegistryKey registryKey;
        private Button checkButton;
        private DSACryptoServiceProvider dsa;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            issueTabPage.Selected = true;
            licenseTypeCombo.SelectedIndex = 1;
            serialNumberBox.Text = Guid.NewGuid().ToString();

            registryKey = Registry.CurrentUser.CreateSubKey("Software\\GmatClubTest\\ManualLicenseIssuer\\");
            keyFileNameBox.Text =
                (String) registryKey.GetValue("KeyFileName", Application.StartupPath + "\\DefaultGmatClubKeyPair.gck");

            LoadKey();

            licenseTypeCombo_SelectedIndexChanged(null, null);
        }

        private void LoadKey()
        {
            try
            {
                StreamReader sr = new StreamReader(keyFileNameBox.Text);
                string k = sr.ReadToEnd();
                sr.Close();

                dsa = Manager.LoadKey(k);

                try
                {
                    dsa.ExportParameters(true);
                    isPrivateKeyOk = true;
                }
                catch
                {
                    tabControl.SelectedTab = keyTabPage;
                    isPrivateKeyOk = false;
                }

                keyInfoBox.Text = "Private key: " + (isPrivateKeyOk ? "Present" : "Absent") + "\r\n" +
                                  "Key size: " + dsa.KeySize + "\r\n" +
                                  "Signature algorithm: " + dsa.SignatureAlgorithm + "\r\n";

                issueTabPage.Enabled = true;
                checkTabPage.Enabled = true;
                exportButton.Enabled = true;
                isPublicKeyOk = true;
                return;
            }
            catch (Exception e)
            {
                keyInfoBox.Text = "ERROR: " + e.Message;
            }

            issueTabPage.Enabled = false;
            checkTabPage.Enabled = false;
            exportButton.Enabled = false;
            isPublicKeyOk = false;
            isPrivateKeyOk = false;

            tabControl.SelectedTab = keyTabPage;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (MainForm));
            this.tabControl = new Crownwood.Magic.Controls.TabControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.checkTabPage = new Crownwood.Magic.Controls.TabPage();
            this.checkButton = new System.Windows.Forms.Button();
            this.licenseInfoBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.browselicenseButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.licenseFileNameBox = new System.Windows.Forms.TextBox();
            this.issueTabPage = new Crownwood.Magic.Controls.TabPage();
            this.issueButton = new System.Windows.Forms.Button();
            this.serialNumberBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.issuedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.expiredDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.licenseTypeCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keyTabPage = new Crownwood.Magic.Controls.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.keyInfoBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.browseKeyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.keyFileNameBox = new System.Windows.Forms.TextBox();
            this.saveKeyPairDialog = new System.Windows.Forms.SaveFileDialog();
            this.openKeyDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportPublicKeyDialog = new System.Windows.Forms.SaveFileDialog();
            this.openLicenseDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveLicenseDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.checkTabPage.SuspendLayout();
            this.issueTabPage.SuspendLayout();
            this.keyTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.BoldSelectedPage = true;
            this.tabControl.HotTrack = true;
            this.tabControl.IDEPixelArea = false;
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.issueTabPage;
            this.tabControl.Size = new System.Drawing.Size(496, 160);
            this.tabControl.TabIndex = 3;
            this.tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[]
                                                  {
                                                      this.issueTabPage,
                                                      this.checkTabPage,
                                                      this.keyTabPage
                                                  });
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // checkTabPage
            // 
            this.checkTabPage.Controls.Add(this.checkButton);
            this.checkTabPage.Controls.Add(this.licenseInfoBox);
            this.checkTabPage.Controls.Add(this.label9);
            this.checkTabPage.Controls.Add(this.browselicenseButton);
            this.checkTabPage.Controls.Add(this.label8);
            this.checkTabPage.Controls.Add(this.licenseFileNameBox);
            this.checkTabPage.ImageIndex = 1;
            this.checkTabPage.ImageList = this.imageList;
            this.checkTabPage.Location = new System.Drawing.Point(0, 0);
            this.checkTabPage.Name = "checkTabPage";
            this.checkTabPage.Selected = false;
            this.checkTabPage.Size = new System.Drawing.Size(496, 135);
            this.checkTabPage.TabIndex = 4;
            this.checkTabPage.Title = "Check License";
            // 
            // checkButton
            // 
            this.checkButton.Enabled = false;
            this.checkButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkButton.Location = new System.Drawing.Point(384, 42);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(104, 23);
            this.checkButton.TabIndex = 10;
            this.checkButton.Text = "&Check";
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // licenseInfoBox
            // 
            this.licenseInfoBox.AcceptsReturn = true;
            this.licenseInfoBox.AcceptsTab = true;
            this.licenseInfoBox.Location = new System.Drawing.Point(72, 40);
            this.licenseInfoBox.Multiline = true;
            this.licenseInfoBox.Name = "licenseInfoBox";
            this.licenseInfoBox.ReadOnly = true;
            this.licenseInfoBox.Size = new System.Drawing.Size(304, 88);
            this.licenseInfoBox.TabIndex = 9;
            this.licenseInfoBox.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Info";
            // 
            // browselicenseButton
            // 
            this.browselicenseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browselicenseButton.Location = new System.Drawing.Point(384, 8);
            this.browselicenseButton.Name = "browselicenseButton";
            this.browselicenseButton.Size = new System.Drawing.Size(104, 23);
            this.browselicenseButton.TabIndex = 7;
            this.browselicenseButton.Text = "&Browse...";
            this.browselicenseButton.Click += new System.EventHandler(this.browselicenseButton_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "License";
            // 
            // licenseFileNameBox
            // 
            this.licenseFileNameBox.Location = new System.Drawing.Point(72, 8);
            this.licenseFileNameBox.Name = "licenseFileNameBox";
            this.licenseFileNameBox.ReadOnly = true;
            this.licenseFileNameBox.Size = new System.Drawing.Size(304, 21);
            this.licenseFileNameBox.TabIndex = 6;
            this.licenseFileNameBox.Text = "";
            // 
            // issueTabPage
            // 
            this.issueTabPage.Controls.Add(this.issueButton);
            this.issueTabPage.Controls.Add(this.serialNumberBox);
            this.issueTabPage.Controls.Add(this.label7);
            this.issueTabPage.Controls.Add(this.issuedDatePicker);
            this.issueTabPage.Controls.Add(this.label6);
            this.issueTabPage.Controls.Add(this.expiredDatePicker);
            this.issueTabPage.Controls.Add(this.label5);
            this.issueTabPage.Controls.Add(this.licenseTypeCombo);
            this.issueTabPage.Controls.Add(this.label4);
            this.issueTabPage.Controls.Add(this.userNameBox);
            this.issueTabPage.Controls.Add(this.label3);
            this.issueTabPage.ImageIndex = 0;
            this.issueTabPage.ImageList = this.imageList;
            this.issueTabPage.Location = new System.Drawing.Point(0, 0);
            this.issueTabPage.Name = "issueTabPage";
            this.issueTabPage.Size = new System.Drawing.Size(496, 135);
            this.issueTabPage.TabIndex = 3;
            this.issueTabPage.Title = "Issue License";
            // 
            // issueButton
            // 
            this.issueButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.issueButton.Location = new System.Drawing.Point(384, 104);
            this.issueButton.Name = "issueButton";
            this.issueButton.Size = new System.Drawing.Size(104, 23);
            this.issueButton.TabIndex = 21;
            this.issueButton.Text = "&Issue";
            this.issueButton.Click += new System.EventHandler(this.issueButton_Click);
            // 
            // serialNumberBox
            // 
            this.serialNumberBox.Location = new System.Drawing.Point(88, 72);
            this.serialNumberBox.Name = "serialNumberBox";
            this.serialNumberBox.Size = new System.Drawing.Size(400, 21);
            this.serialNumberBox.TabIndex = 18;
            this.serialNumberBox.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Serial number";
            // 
            // issuedDatePicker
            // 
            this.issuedDatePicker.Location = new System.Drawing.Point(88, 105);
            this.issuedDatePicker.Name = "issuedDatePicker";
            this.issuedDatePicker.Size = new System.Drawing.Size(192, 21);
            this.issuedDatePicker.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Issued";
            // 
            // expiredDatePicker
            // 
            this.expiredDatePicker.Location = new System.Drawing.Point(296, 39);
            this.expiredDatePicker.Name = "expiredDatePicker";
            this.expiredDatePicker.Size = new System.Drawing.Size(192, 21);
            this.expiredDatePicker.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(212, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Expiration date";
            // 
            // licenseTypeCombo
            // 
            this.licenseTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.licenseTypeCombo.Items.AddRange(new object[]
                                                     {
                                                         "Trial",
                                                         "Permanent",
                                                         "Custom"
                                                     });
            this.licenseTypeCombo.Location = new System.Drawing.Point(88, 39);
            this.licenseTypeCombo.Name = "licenseTypeCombo";
            this.licenseTypeCombo.TabIndex = 14;
            this.licenseTypeCombo.SelectedIndexChanged +=
                new System.EventHandler(this.licenseTypeCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "License Type";
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(88, 6);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(400, 21);
            this.userNameBox.TabIndex = 12;
            this.userNameBox.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "User Name";
            // 
            // keyTabPage
            // 
            this.keyTabPage.Controls.Add(this.label2);
            this.keyTabPage.Controls.Add(this.keyInfoBox);
            this.keyTabPage.Controls.Add(this.exportButton);
            this.keyTabPage.Controls.Add(this.generateButton);
            this.keyTabPage.Controls.Add(this.browseKeyButton);
            this.keyTabPage.Controls.Add(this.label1);
            this.keyTabPage.Controls.Add(this.keyFileNameBox);
            this.keyTabPage.ImageIndex = 2;
            this.keyTabPage.ImageList = this.imageList;
            this.keyTabPage.Location = new System.Drawing.Point(0, 0);
            this.keyTabPage.Name = "keyTabPage";
            this.keyTabPage.Selected = false;
            this.keyTabPage.Size = new System.Drawing.Size(496, 135);
            this.keyTabPage.TabIndex = 5;
            this.keyTabPage.Title = "Key";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Info";
            // 
            // keyInfoBox
            // 
            this.keyInfoBox.AcceptsReturn = true;
            this.keyInfoBox.AcceptsTab = true;
            this.keyInfoBox.Location = new System.Drawing.Point(72, 40);
            this.keyInfoBox.Multiline = true;
            this.keyInfoBox.Name = "keyInfoBox";
            this.keyInfoBox.ReadOnly = true;
            this.keyInfoBox.Size = new System.Drawing.Size(304, 88);
            this.keyInfoBox.TabIndex = 10;
            this.keyInfoBox.Text = "";
            // 
            // exportButton
            // 
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportButton.Location = new System.Drawing.Point(384, 40);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(104, 23);
            this.exportButton.TabIndex = 12;
            this.exportButton.Text = "&Export public key";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.generateButton.Location = new System.Drawing.Point(384, 72);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(104, 23);
            this.generateButton.TabIndex = 13;
            this.generateButton.Text = "&Generate new key";
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // browseKeyButton
            // 
            this.browseKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browseKeyButton.Location = new System.Drawing.Point(384, 8);
            this.browseKeyButton.Name = "browseKeyButton";
            this.browseKeyButton.Size = new System.Drawing.Size(104, 23);
            this.browseKeyButton.TabIndex = 11;
            this.browseKeyButton.Text = "&Browse...";
            this.browseKeyButton.Click += new System.EventHandler(this.browseKeyButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "DSA pair";
            // 
            // keyFileNameBox
            // 
            this.keyFileNameBox.Location = new System.Drawing.Point(72, 8);
            this.keyFileNameBox.Name = "keyFileNameBox";
            this.keyFileNameBox.ReadOnly = true;
            this.keyFileNameBox.Size = new System.Drawing.Size(304, 21);
            this.keyFileNameBox.TabIndex = 8;
            this.keyFileNameBox.Text = "";
            // 
            // saveKeyPairDialog
            // 
            this.saveKeyPairDialog.DefaultExt = "gck";
            this.saveKeyPairDialog.FileName = "NewGmatClubKeyPair";
            this.saveKeyPairDialog.Filter = "GMAT Club Key files|*.gck";
            this.saveKeyPairDialog.Title = "Save public and private keys";
            // 
            // openKeyDialog
            // 
            this.openKeyDialog.DefaultExt = "gck";
            this.openKeyDialog.Filter = "GMAT Club Key files|*.gck";
            this.openKeyDialog.ShowReadOnly = true;
            this.openKeyDialog.Title = "Open key";
            // 
            // exportPublicKeyDialog
            // 
            this.exportPublicKeyDialog.DefaultExt = "gck";
            this.exportPublicKeyDialog.FileName = "NewGmatClubPublicKey";
            this.exportPublicKeyDialog.Filter = "GMAT Club Key files|*.gck";
            this.exportPublicKeyDialog.Title = "Export public key";
            // 
            // openLicenseDialog
            // 
            this.openLicenseDialog.DefaultExt = "gcl";
            this.openLicenseDialog.Filter = "GMAT Club License files|*.gcl";
            this.openLicenseDialog.ShowReadOnly = true;
            this.openLicenseDialog.Title = "Open licence";
            // 
            // saveLicenseDialog
            // 
            this.saveLicenseDialog.DefaultExt = "gcl";
            this.saveLicenseDialog.FileName = "NewGmatClubLicense";
            this.saveLicenseDialog.Filter = "GMAT Club License files|*.gcl";
            this.saveLicenseDialog.Title = "Save license";
            // 
            // MainForm
            // 
            this.AcceptButton = this.issueButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 160);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMAT Club Test -  Manual License Issuer";
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.tabControl.ResumeLayout(false);
            this.checkTabPage.ResumeLayout(false);
            this.issueTabPage.ResumeLayout(false);
            this.keyTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private static MainForm mainForm = null;

        #region Exception management

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                ExceptionBox.Show(e.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal error. Application will be closed.", APP_CAPTION,
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

                mainForm = new MainForm();

                foreach (string s in args)
                {
                    if (s.EndsWith(".gcl"))
                    {
                        mainForm.licenseFileNameBox.Text = s;
                        mainForm.checkButton_Click(null, null);
                        mainForm.checkTabPage.Selected = true;
                        break;
                    }
                    else
                    {
                        if (s.EndsWith(".gck"))
                        {
                            mainForm.keyFileNameBox.Text = s;
                            mainForm.LoadKey();
                            mainForm.keyTabPage.Selected = true;
                            break;
                        }
                    }
                }

                Application.Run(mainForm);
            }
            catch (Exception e)
            {
                ExceptionBox.Show(e);
            }
        }

        private void tabControl_SelectionChanged(object sender, EventArgs e)
        {
            if ((issueTabPage.Selected && !isPrivateKeyOk) ||
                (checkTabPage.Selected && !isPublicKeyOk))
                keyTabPage.Selected = true;
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            if (isPublicKeyOk)
                registryKey.SetValue("KeyFileName", keyFileNameBox.Text);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (isPrivateKeyOk)
                if (DialogResult.Yes !=
                    MessageBox.Show(
                        "You have a valid pair of keys. If you generate a new pair, you have to rebuild 'GmatClubTest - Practice' with inserted hash value of the new public key. Also you need to export the key and supply it to the program. Otherwise the program will not recognize newly issued licenses.\r\n\r\nDo you want to generate the new pair?",
                        APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;

            string s = Manager.GenerateKey();

            if (saveKeyPairDialog.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveKeyPairDialog.FileName);
                sw.Write(s);
                sw.Close();
                keyFileNameBox.Text = saveKeyPairDialog.FileName;
                LoadKey();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (exportPublicKeyDialog.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(exportPublicKeyDialog.FileName);
                sw.Write(Manager.ExportPublicKey(dsa));
                sw.Close();

                sw = new StreamWriter(exportPublicKeyDialog.FileName + ".hash");
                byte[] hash = Manager.ComputeHash(exportPublicKeyDialog.FileName);
                sw.Write(Convert.ToBase64String(hash));
                sw.Close();
            }
        }

        private void browseKeyButton_Click(object sender, EventArgs e)
        {
            if (openKeyDialog.ShowDialog(this) == DialogResult.OK)
            {
                keyFileNameBox.Text = openKeyDialog.FileName;
                LoadKey();
            }
        }

        private void licenseTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (licenseTypeCombo.SelectedIndex)
            {
                case 0:
                    expiredDatePicker.Enabled = false;
                    expiredDatePicker.Value = DateTime.Now + TimeSpan.FromDays(30);
                    break;
                case 1:
                    expiredDatePicker.Enabled = false;
                    expiredDatePicker.Value = DateTime.MaxValue - TimeSpan.FromDays(1000);
                    break;
                case 2:
                    expiredDatePicker.Enabled = true;
                    expiredDatePicker.Value = DateTime.Now + TimeSpan.FromDays(60);
                    break;
            }
        }

        private void issueButton_Click(object sender, EventArgs e)
        {
            saveLicenseDialog.FileName = userNameBox.Text;
            if (saveLicenseDialog.ShowDialog(this) == DialogResult.OK)
            {
                XmlDocument doc =
                    Manager.IssueLicense(
                        new XmlLicense(userNameBox.Text, licenseTypeCombo.SelectedItem.ToString(),
                                       expiredDatePicker.Value, serialNumberBox.Text, issuedDatePicker.Value), dsa);
                doc.Save(saveLicenseDialog.FileName);
            }

            licenseFileNameBox.Text = saveLicenseDialog.FileName;
            userNameBox.Text = "";
            serialNumberBox.Text = Guid.NewGuid().ToString();
            userNameBox.Focus();
        }

        private void browselicenseButton_Click(object sender, EventArgs e)
        {
            if (openLicenseDialog.ShowDialog(this) != DialogResult.OK) return;
            licenseFileNameBox.Text = openLicenseDialog.FileName;

            checkButton_Click(sender, e);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkButton.Enabled = true;
                XmlLicense l = Manager.CheckLicense(licenseFileNameBox.Text, keyFileNameBox.Text);

                licenseInfoBox.Text = "The license is valid\r\n" +
                                      "User: " + l.User + "\r\n" +
                                      "License Type: " + l.LicenseType + "\r\n" +
                                      "Expired: " + l.Expired + "\r\n" +
                                      "S/N: " + l.SerialNumber + "\r\n" +
                                      "Issued: " + l.Issued;
            }
            catch (BadLicense ex)
            {
                licenseInfoBox.Text = "BAD LICENSE: " + ex.Message;
            }
        }
    }
}