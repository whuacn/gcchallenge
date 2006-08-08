using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Crownwood.Magic.Menus;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.ImportExport;
using GmatClubTest.License;
using GmatClubTest.UnexpectedExceptionDialog;
using Microsoft.Win32;
using Manager=GmatClubTest.BusinessLogic.Manager;

namespace GmatClubTest.Practice
{
    /// <summary>
    /// Main Form
    /// </summary>
    ///    
    public class MainForm : Form
    {
        internal static XmlLicense license;
        public static RegistryKey registryKey;
        private MenuControl menuControl;
        private MenuCommand menuCmdFile;
        private MenuCommand menuCmdPrctice;
        private MenuCommand menuCmdExit;
        private MenuCommand menuCommandSep;
        private MenuCommand menuCommandImport;
        private MenuCommand menuCommandDownload;
        private MenuCommand menuCommandAbout;
        private GroupBox groupBoxPractice;
        private Panel panelPractice;
        private GroupBox groupBoxTests;
        private Panel panelTests;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private LinkLabel linkImportPractice;
        private LinkLabel linkDownloadPractice;
        private LinkLabel linkDownloadTest;
        private LinkLabel linkImportTest;
        private StatusBar statusBar;
        private ImageList imageList;
        private IContainer components;
        private Font stringFont = new Font("Tahoma", 8, FontStyle.Underline | FontStyle.Bold);

        private static Manager manager;
        private MenuCommand menuPrcticeVerbal;
        private MenuCommand menuPrcticeQuantitative;
        private MenuCommand menuTestsVerbal;
        private MenuCommand menuTestsQuantitative;
        private MenuCommand menuCmdTests;
        private TestSet testSet = new TestSet();
        private static HelpForm helpForm = new HelpForm();

        private static string DB_FILE_NAME = "GmatClubTest.mdb";
        private static string PUBLIC_KEY_FILE_NAME = Application.StartupPath + "\\DefaultGmatClubPublicKey.gck";
        public static string APP_CAPTION = "GMAT Club Test - Practice";
        private MenuCommand menuCommandResults;
        private MenuCommand menuCommandSep2;
        private MenuCommand menuCommandHelp;
        private MenuCommand menuHelp;
        private MenuCommand menuCommandAddLicense;
        private MenuCommand menuCommandSep3;
        private LinkLabel linkLabel1;

        private TestController activeTestController = null;

        public MainForm()
        {
            InitializeComponent();
            InitLinksAndMenu();
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


        private void InitLinksAndMenu()
        {
            //create tests muny, Link
            manager.GetTests(testSet);
            int num = testSet.Tests.Count;
            int i = 0;
            int pracTest = 0;
            string textLink;
            string textMenu;
            for (i = 0, textLink = "" , textMenu = ""; i < num; i++)
            {
                textLink += testSet.Tests[i].Name.ToString();
                textMenu += testSet.Tests[i].Name.ToString();
                if (!(testSet.Tests[i].IsQuestionTypeIdNull()))
                {
                    textLink += ((textLink != "") ? (", ") : ("")) +
                                Question.Type.GetName(typeof (Question.Type), testSet.Tests[i].QuestionTypeId);
                }
                if (!(testSet.Tests[i].IsQuestionSubtypeIdNull()))
                {
                    textLink += ((textLink != "") ? (", ") : ("")) +
                                Question.Subtype.GetName(typeof (Question.Subtype), testSet.Tests[i].QuestionSubtypeId).
                                    ToString();
                    textMenu += ((textLink != "") ? (", ") : ("")) +
                                Question.Subtype.GetName(typeof (Question.Subtype), testSet.Tests[i].QuestionSubtypeId).
                                    ToString();
                }
                CreateLinkLabel(textLink, ((testSet.Tests[i].IsPractice) ? (pracTest) : (i - pracTest)),
                                testSet.Tests[i], i + 4, testSet.Tests[i].IsPractice);
                CreateMenuItem(textMenu,
                               ((testSet.Tests[i].IsQuestionTypeIdNull()) ? (-1) : (testSet.Tests[i].QuestionTypeId)),
                               testSet.Tests[i], testSet.Tests[i].IsPractice);
                if (testSet.Tests[i].IsPractice)
                {
                    pracTest++;
                }
                textLink = "";
                textMenu = "";
            }
            //end create tests Link
        }

        private void CreateMenuItem(string text, int type, TestSet.TestsRow row, bool isPractice)
        {
            MenuCommand menu = new MenuCommand();
            if (isPractice)
            {
                if (!menuCmdPrctice.Enabled)
                {
                    menuCmdPrctice.Enabled = true;
                }
                switch (type)
                {
                    case -1:
                        menuCmdPrctice.MenuCommands.AddRange(new MenuCommand[] {menu});
                        break;
                    case 1:
                        if (!menuPrcticeQuantitative.Enabled)
                        {
                            menuPrcticeQuantitative.Enabled = true;
                        }
                        menuPrcticeQuantitative.MenuCommands.AddRange(new MenuCommand[] {menu});
                        break;
                    case 2:
                        if (!menuPrcticeVerbal.Enabled)
                        {
                            menuPrcticeVerbal.Enabled = true;
                        }
                        menuPrcticeVerbal.MenuCommands.AddRange(new MenuCommand[] {menu});
                        break;
                }
            }
            else
            {
                if (!menuCmdTests.Enabled)
                {
                    menuCmdTests.Enabled = true;
                }
                switch (type)
                {
                    case -1:
                        menuCmdTests.MenuCommands.AddRange(new MenuCommand[] {menu});
                        break;
                    case 1:
                        if (!menuTestsQuantitative.Enabled)
                        {
                            menuTestsQuantitative.Enabled = true;
                        }
                        menuTestsQuantitative.MenuCommands.AddRange(new MenuCommand[] {menu});
                        break;
                    case 2:
                        if (!menuTestsVerbal.Enabled)
                        {
                            menuTestsVerbal.Enabled = true;
                        }
                        menuTestsVerbal.MenuCommands.AddRange(new MenuCommand[] {menu});
                        break;
                }
            }
            //menu.Description = "Description";
            menu.ImageList = imageList;
            menu.ImageIndex = 0;
            menu.Tag = row;
            menu.Text = text;
            //menu. MouseEnter += new System.EventHandler(linkLabel_MouseEnter);
            //menu.MouseLeave += new System.EventHandler(linkLabel_MouseLeave);
            menu.Click += new EventHandler(menu_Click);
        }

        private void CreateLinkLabel(string text, int number, TestSet.TestsRow row, int tabIndex, bool isPractice)
        {
            LinkLabel linkLabel = new LinkLabel();
            if (isPractice)
            {
                panelPractice.Controls.Add(linkLabel);
            }
            else
            {
                panelTests.Controls.Add(linkLabel);
            }
            linkLabel.Tag = row;

            Graphics e = linkLabel.CreateGraphics();
            SizeF textSize = e.MeasureString(text, stringFont);
            linkLabel.Font = stringFont;
            linkLabel.Text = text;
            linkLabel.TabStop = true;
            linkLabel.TabIndex = tabIndex;
            linkLabel.ImageAlign = ContentAlignment.MiddleLeft;
            linkLabel.ImageIndex = 0;
            linkLabel.ImageList = imageList;
            linkLabel.Location =
                new Point(8, number*(((int) textSize.Height < 23) ? (23) : ((int) textSize.Height)) + 105);
            int linkWidth = (int) Math.Ceiling(textSize.Width) + 20;
            int linkHeight = ((int) textSize.Height < 23) ? (23) : ((int) textSize.Height);
            linkLabel.Size = new Size(linkWidth, linkHeight);
            linkLabel.TextAlign = ContentAlignment.MiddleRight;

            linkLabel.FlatStyle = FlatStyle.System;
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
            linkLabel.Enter += new EventHandler(linkLabel_MouseEnter);
            linkLabel.Leave += new EventHandler(linkLabel_MouseLeave);
            linkLabel.MouseEnter += new EventHandler(linkLabel_MouseEnter);
            linkLabel.MouseLeave += new EventHandler(linkLabel_MouseLeave);
            e.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof (MainForm));
            this.menuControl = new Crownwood.Magic.Menus.MenuControl();
            this.menuCmdFile = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandResults = new Crownwood.Magic.Menus.MenuCommand();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuCommandSep2 = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandDownload = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandImport = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandSep = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCmdExit = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCmdPrctice = new Crownwood.Magic.Menus.MenuCommand();
            this.menuPrcticeVerbal = new Crownwood.Magic.Menus.MenuCommand();
            this.menuPrcticeQuantitative = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCmdTests = new Crownwood.Magic.Menus.MenuCommand();
            this.menuTestsVerbal = new Crownwood.Magic.Menus.MenuCommand();
            this.menuTestsQuantitative = new Crownwood.Magic.Menus.MenuCommand();
            this.menuHelp = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandHelp = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandAddLicense = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandSep3 = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandAbout = new Crownwood.Magic.Menus.MenuCommand();
            this.groupBoxPractice = new System.Windows.Forms.GroupBox();
            this.panelPractice = new System.Windows.Forms.Panel();
            this.linkDownloadPractice = new System.Windows.Forms.LinkLabel();
            this.linkImportPractice = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxTests = new System.Windows.Forms.GroupBox();
            this.panelTests = new System.Windows.Forms.Panel();
            this.linkDownloadTest = new System.Windows.Forms.LinkLabel();
            this.linkImportTest = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBoxPractice.SuspendLayout();
            this.panelPractice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.groupBoxTests.SuspendLayout();
            this.panelTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuControl
            // 
            this.menuControl.AnimateStyle = Crownwood.Magic.Menus.Animation.System;
            this.menuControl.AnimateTime = 100;
            this.menuControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menuControl.Direction = Crownwood.Magic.Common.Direction.Horizontal;
            this.menuControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuControl.Font =
                new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.World);
            this.menuControl.HighlightTextColor = System.Drawing.SystemColors.MenuText;
            this.menuControl.Location = new System.Drawing.Point(0, 0);
            this.menuControl.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[]
                                                       {
                                                           this.menuCmdFile,
                                                           this.menuCmdPrctice,
                                                           this.menuCmdTests,
                                                           this.menuHelp
                                                       });
            this.menuControl.Name = "menuControl";
            this.menuControl.Size = new System.Drawing.Size(712, 25);
            this.menuControl.Style = Crownwood.Magic.Common.VisualStyle.IDE;
            this.menuControl.TabIndex = 0;
            this.menuControl.TabStop = false;
            this.menuControl.Text = "mc";
            // 
            // menuCmdFile
            // 
            this.menuCmdFile.Description = "File";
            this.menuCmdFile.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[]
                                                       {
                                                           this.menuCommandResults,
                                                           this.menuCommandSep2,
                                                           this.menuCommandDownload,
                                                           this.menuCommandImport,
                                                           this.menuCommandSep,
                                                           this.menuCmdExit
                                                       });
            this.menuCmdFile.Text = "&File";
            // 
            // menuCommandResults
            // 
            this.menuCommandResults.Description = "MenuItem";
            this.menuCommandResults.ImageIndex = 7;
            this.menuCommandResults.ImageList = this.imageList;
            this.menuCommandResults.Text = "&History of Results...";
            this.menuCommandResults.Click += new System.EventHandler(this.menuCommandResults_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream =
                ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            // 
            // menuCommandSep2
            // 
            this.menuCommandSep2.Description = "MenuItem";
            this.menuCommandSep2.Text = "-";
            // 
            // menuCommandDownload
            // 
            this.menuCommandDownload.Description = "MenuItem";
            this.menuCommandDownload.ImageIndex = 1;
            this.menuCommandDownload.ImageList = this.imageList;
            this.menuCommandDownload.Text = "&Download test/practice sets...";
            this.menuCommandDownload.Click += new System.EventHandler(this.menuCommandDownload_Click);
            // 
            // menuCommandImport
            // 
            this.menuCommandImport.Description = "MenuItem";
            this.menuCommandImport.ImageIndex = 2;
            this.menuCommandImport.ImageList = this.imageList;
            this.menuCommandImport.Text = "&Import test/practce sets...";
            // 
            // menuCommandSep
            // 
            this.menuCommandSep.Description = "MenuItem";
            this.menuCommandSep.Text = "-";
            // 
            // menuCmdExit
            // 
            this.menuCmdExit.Description = "MenuItem";
            this.menuCmdExit.ImageIndex = 3;
            this.menuCmdExit.ImageList = this.imageList;
            this.menuCmdExit.Text = "E&xit";
            this.menuCmdExit.Click += new System.EventHandler(this.menuCmdExit_Click);
            // 
            // menuCmdPrctice
            // 
            this.menuCmdPrctice.Description = "Practice in selected area";
            this.menuCmdPrctice.Enabled = false;
            this.menuCmdPrctice.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[]
                                                          {
                                                              this.menuPrcticeVerbal,
                                                              this.menuPrcticeQuantitative
                                                          });
            this.menuCmdPrctice.Text = "&Practice";
            // 
            // menuPrcticeVerbal
            // 
            this.menuPrcticeVerbal.Description = "MenuItem";
            this.menuPrcticeVerbal.Enabled = false;
            this.menuPrcticeVerbal.ImageIndex = 5;
            this.menuPrcticeVerbal.ImageList = this.imageList;
            this.menuPrcticeVerbal.Text = "&Verbal";
            // 
            // menuPrcticeQuantitative
            // 
            this.menuPrcticeQuantitative.Description = "MenuItem";
            this.menuPrcticeQuantitative.Enabled = false;
            this.menuPrcticeQuantitative.ImageIndex = 5;
            this.menuPrcticeQuantitative.ImageList = this.imageList;
            this.menuPrcticeQuantitative.Text = "&Quantitative";
            // 
            // menuCmdTests
            // 
            this.menuCmdTests.Description = "Computer-adaptive tests";
            this.menuCmdTests.Enabled = false;
            this.menuCmdTests.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[]
                                                        {
                                                            this.menuTestsVerbal,
                                                            this.menuTestsQuantitative
                                                        });
            this.menuCmdTests.Text = "&Tests";
            // 
            // menuTestsVerbal
            // 
            this.menuTestsVerbal.Description = "Verbal";
            this.menuTestsVerbal.Enabled = false;
            this.menuTestsVerbal.ImageIndex = 5;
            this.menuTestsVerbal.ImageList = this.imageList;
            this.menuTestsVerbal.Text = "&Verbal";
            // 
            // menuTestsQuantitative
            // 
            this.menuTestsQuantitative.Description = "Quantitative";
            this.menuTestsQuantitative.Enabled = false;
            this.menuTestsQuantitative.ImageIndex = 5;
            this.menuTestsQuantitative.ImageList = this.imageList;
            this.menuTestsQuantitative.Text = "&Quantitative";
            // 
            // menuHelp
            // 
            this.menuHelp.Description = "MenuItem";
            this.menuHelp.ImageList = this.imageList;
            this.menuHelp.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[]
                                                    {
                                                        this.menuCommandHelp,
                                                        this.menuCommandAddLicense,
                                                        this.menuCommandSep3,
                                                        this.menuCommandAbout
                                                    });
            this.menuHelp.Text = "&Help";
            // 
            // menuCommandHelp
            // 
            this.menuCommandHelp.Description = "MenuItem";
            this.menuCommandHelp.ImageIndex = 6;
            this.menuCommandHelp.ImageList = this.imageList;
            this.menuCommandHelp.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuCommandHelp.Text = "&Help";
            this.menuCommandHelp.Click += new System.EventHandler(this.menuCommandHepl_Click);
            // 
            // menuCommandAddLicense
            // 
            this.menuCommandAddLicense.Description = "Manage Licences";
            this.menuCommandAddLicense.ImageIndex = 8;
            this.menuCommandAddLicense.ImageList = this.imageList;
            this.menuCommandAddLicense.Text = "Manage Licences...";
            this.menuCommandAddLicense.Click += new System.EventHandler(this.menuCommandAddLicense_Click);
            // 
            // menuCommandSep3
            // 
            this.menuCommandSep3.Description = "MenuItem";
            this.menuCommandSep3.Text = "-";
            // 
            // menuCommandAbout
            // 
            this.menuCommandAbout.Description = "MenuItem";
            this.menuCommandAbout.Text = "&About GMAT Club Test...";
            this.menuCommandAbout.Click += new System.EventHandler(this.menuCommandAbout_Click);
            // 
            // groupBoxPractice
            // 
            this.groupBoxPractice.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxPractice.Controls.Add(this.panelPractice);
            this.groupBoxPractice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxPractice.Font =
                new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.groupBoxPractice.Location = new System.Drawing.Point(5, 32);
            this.groupBoxPractice.Name = "groupBoxPractice";
            this.groupBoxPractice.Size = new System.Drawing.Size(346, 351);
            this.groupBoxPractice.TabIndex = 1;
            this.groupBoxPractice.TabStop = false;
            this.groupBoxPractice.Text = "Practices";
            // 
            // panelPractice
            // 
            this.panelPractice.AutoScroll = true;
            this.panelPractice.Controls.Add(this.linkLabel1);
            this.panelPractice.Controls.Add(this.linkDownloadPractice);
            this.panelPractice.Controls.Add(this.linkImportPractice);
            this.panelPractice.Controls.Add(this.pictureBox1);
            this.panelPractice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPractice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panelPractice.Location = new System.Drawing.Point(3, 29);
            this.panelPractice.Name = "panelPractice";
            this.panelPractice.Size = new System.Drawing.Size(340, 319);
            this.panelPractice.TabIndex = 0;
            // 
            // linkDownloadPractice
            // 
            this.linkDownloadPractice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.linkDownloadPractice.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkDownloadPractice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDownloadPractice.ImageIndex = 1;
            this.linkDownloadPractice.ImageList = this.imageList;
            this.linkDownloadPractice.Location = new System.Drawing.Point(112, 16);
            this.linkDownloadPractice.Name = "linkDownloadPractice";
            this.linkDownloadPractice.Size = new System.Drawing.Size(168, 23);
            this.linkDownloadPractice.TabIndex = 0;
            this.linkDownloadPractice.TabStop = true;
            this.linkDownloadPractice.Text = "Download practice set";
            this.linkDownloadPractice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkDownloadPractice.Enter += new System.EventHandler(this.linkDownloadPractice_MouseEnter);
            this.linkDownloadPractice.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkDownloadPractice.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownloadPractice_LinkClicked);
            this.linkDownloadPractice.Leave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkDownloadPractice.MouseEnter += new System.EventHandler(this.linkDownloadPractice_MouseEnter);
            // 
            // linkImportPractice
            // 
            this.linkImportPractice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.linkImportPractice.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkImportPractice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportPractice.ImageIndex = 2;
            this.linkImportPractice.ImageList = this.imageList;
            this.linkImportPractice.Location = new System.Drawing.Point(112, 56);
            this.linkImportPractice.Name = "linkImportPractice";
            this.linkImportPractice.Size = new System.Drawing.Size(152, 23);
            this.linkImportPractice.TabIndex = 1;
            this.linkImportPractice.TabStop = true;
            this.linkImportPractice.Text = "Import practice set";
            this.linkImportPractice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkImportPractice.Enter += new System.EventHandler(this.linkImportPractice_MouseEnter);
            this.linkImportPractice.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkImportPractice.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImportPractice_LinkClicked);
            this.linkImportPractice.Leave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkImportPractice.MouseEnter += new System.EventHandler(this.linkImportPractice_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxTests
            // 
            this.groupBoxTests.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                 ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTests.Controls.Add(this.panelTests);
            this.groupBoxTests.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxTests.Font =
                new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.groupBoxTests.Location = new System.Drawing.Point(360, 32);
            this.groupBoxTests.Name = "groupBoxTests";
            this.groupBoxTests.Size = new System.Drawing.Size(346, 351);
            this.groupBoxTests.TabIndex = 2;
            this.groupBoxTests.TabStop = false;
            this.groupBoxTests.Text = "Computer-Adaptive Tests";
            // 
            // panelTests
            // 
            this.panelTests.AutoScroll = true;
            this.panelTests.Controls.Add(this.linkDownloadTest);
            this.panelTests.Controls.Add(this.linkImportTest);
            this.panelTests.Controls.Add(this.pictureBox2);
            this.panelTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panelTests.Location = new System.Drawing.Point(8, 29);
            this.panelTests.Name = "panelTests";
            this.panelTests.Size = new System.Drawing.Size(336, 319);
            this.panelTests.TabIndex = 0;
            // 
            // linkDownloadTest
            // 
            this.linkDownloadTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.linkDownloadTest.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkDownloadTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDownloadTest.ImageIndex = 1;
            this.linkDownloadTest.ImageList = this.imageList;
            this.linkDownloadTest.Location = new System.Drawing.Point(112, 16);
            this.linkDownloadTest.Name = "linkDownloadTest";
            this.linkDownloadTest.Size = new System.Drawing.Size(144, 23);
            this.linkDownloadTest.TabIndex = 2;
            this.linkDownloadTest.TabStop = true;
            this.linkDownloadTest.Text = "Download test set";
            this.linkDownloadTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkDownloadTest.Enter += new System.EventHandler(this.linkDownloadTest_MouseEnter);
            this.linkDownloadTest.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkDownloadTest.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownloadTest_LinkClicked);
            this.linkDownloadTest.Leave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkDownloadTest.MouseEnter += new System.EventHandler(this.linkDownloadTest_MouseEnter);
            // 
            // linkImportTest
            // 
            this.linkImportTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.linkImportTest.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkImportTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportTest.ImageIndex = 2;
            this.linkImportTest.ImageList = this.imageList;
            this.linkImportTest.Location = new System.Drawing.Point(112, 56);
            this.linkImportTest.Name = "linkImportTest";
            this.linkImportTest.Size = new System.Drawing.Size(128, 23);
            this.linkImportTest.TabIndex = 3;
            this.linkImportTest.TabStop = true;
            this.linkImportTest.Text = "Import test set";
            this.linkImportTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkImportTest.Enter += new System.EventHandler(this.linkImportTest_MouseEnter);
            this.linkImportTest.MouseLeave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkImportTest.Leave += new System.EventHandler(this.linkLabel_MouseLeave);
            this.linkImportTest.MouseEnter += new System.EventHandler(this.linkImportTest_MouseEnter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(96, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 384);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(712, 22);
            this.statusBar.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.ImageIndex = 2;
            this.linkLabel1.ImageList = this.imageList;
            this.linkLabel1.Location = new System.Drawing.Point(112, 105);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(152, 23);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "export practice test";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(712, 406);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.groupBoxTests);
            this.Controls.Add(this.groupBoxPractice);
            this.Controls.Add(this.menuControl);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMAT Club Test - Practice";
            this.groupBoxPractice.ResumeLayout(false);
            this.panelPractice.ResumeLayout(false);
            this.panelPractice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.groupBoxTests.ResumeLayout(false);
            this.panelTests.ResumeLayout(false);
            this.panelTests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private static MainForm mainForm = null;

        #region Exception management

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception.GetType() == typeof (TimeIsUpException) && mainForm != null)
            {
                try
                {
                    mainForm.activeTestController.TimeIsUp();
                }
                catch /* We should get EndTestException*/
                {
                }
            }
            else
            {
                if (e.Exception.GetType() == typeof (EndTestException) && mainForm != null)
                {
                    if (e.Exception.Message.Length != 0)
                    {
                        MessageBox.Show(e.Exception.Message, APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
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
            }

            if (mainForm.activeTestController != null)
            {
                mainForm.activeTestController.EndTest();
            }
            else if (!mainForm.Visible) mainForm.Show();
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>      
        private static DialogResult ShowLicenseDialog()
        {
            LicenseForm licenseForm = new LicenseForm(PUBLIC_KEY_FILE_NAME);
            licenseForm.ShowDialog();
            return licenseForm.DialogResult;
        }

        private static void Uninstall()
        {
            string lf = (String) registryKey.GetValue("LicenseFileName");

            string appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                            "\\GmatClubTest - Practice";
            string pathToDb = appDir + "\\" + DB_FILE_NAME;

            if (lf != null && File.Exists(lf))
                if (MessageBox.Show("Do you want to remove a copy of your license?", APP_CAPTION,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(lf);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Cannot remove the license file: " + e.Message, APP_CAPTION,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            if (File.Exists(pathToDb))
                if (MessageBox.Show("Do you want to remove your GMAT Club Test database?", APP_CAPTION,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(pathToDb);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Cannot remove the database file: " + e.Message, APP_CAPTION,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            RegistryKey r = Registry.CurrentUser.CreateSubKey("Software\\GmatClubTest\\");
            r.DeleteSubKeyTree("Practice");
        }

        [STAThread]
        private static void Main(String[] args)
        {
            registryKey = Registry.CurrentUser.CreateSubKey("Software\\GmatClubTest\\Practice\\");

            if (args.Length == 1 && args[0] == "-u_qw92578ert")
            {
                Uninstall();
                return;
            }

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            try
            {
                //copying database if needed...
                string appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                "\\GmatClubTest - Practice";
                string pathToDb = appDir + "\\" + DB_FILE_NAME;
                string dbSrc1 = Application.StartupPath + "\\" + DB_FILE_NAME;
                string dbSrc2 = @"c:\Projects\GmatClubTest\src\db\" + DB_FILE_NAME;
                if ((string) registryKey.GetValue("DatabaseCopied", "false") == "false" || !File.Exists(pathToDb))
                {
                    Directory.CreateDirectory(appDir);
                    if (File.Exists(dbSrc1))
                        File.Copy(dbSrc1, pathToDb, true);
                    else if (File.Exists(dbSrc2))
                        File.Copy(dbSrc2, pathToDb, true);
                    else
                    {
                        MessageBox.Show("Cannot find database file.", APP_CAPTION,
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    registryKey.SetValue("DatabaseCopied", "true");
                }

                //making hackers crazy...

                byte[] a;
                byte[] h;
                Random r;
                string publickKeyFileName = "";

                //byte[] a = Convert.FromBase64String(TestController._undefinedName2 + "=");
                a = Convert.FromBase64String(TestController._undefinedName1 + "=");
                h = new byte[20];
                r = new Random(13);
                r.NextBytes(h);
                for (int i = 0; i < 20; i++)
                    h[i] = (byte) (a[i] ^ h[i]);
                string s = Convert.ToBase64String(h);

                string licenseFileName = (String) registryKey.GetValue("LicenseFileName");
                publickKeyFileName = PUBLIC_KEY_FILE_NAME;

                if (!File.Exists(publickKeyFileName))
                {
                    MessageBox.Show("No file with public key: " + publickKeyFileName, APP_CAPTION, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    License.Manager.CheckHash(publickKeyFileName, h);

                    bool licenseChecked;
                    for (licenseChecked = false; !licenseChecked;)
                    {
                        if (licenseFileName == null) break;

                        if (!File.Exists(licenseFileName))
                        {
                            MessageBox.Show("No license file: '" + licenseFileName + "'", APP_CAPTION,
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        license = License.Manager.CheckLicense(licenseFileName, publickKeyFileName);
                        licenseChecked = true;
                    }

                    if (!licenseChecked)
                        if (ShowLicenseDialog() != DialogResult.OK) return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Bad license: " + e.Message, APP_CAPTION, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    if (ShowLicenseDialog() != DialogResult.OK) return;
                }

                //string pwd = "q&b3pz>#_24";
                //a = new byte[pwd.Length];

                //for (int i = 0; i < a.Length; ++i)
                //    a[i] = (byte)pwd[i];

                //h = new byte[a.Length];
                //r = new Random(357);
                //r.NextBytes(h);
                //for (int i = 0; i < a.Length; i++)
                //    h[i] = (byte)(a[i] ^ h[i]);   

                //string v = Convert.ToBase64String(h);
                //a = Convert.FromBase64String(v);

                a = Convert.FromBase64String(TestController._undefinedName3 + "=");

                h = new byte[a.Length];
                r = new Random(357);
                r.NextBytes(h);
                for (int i = 0; i < a.Length; i++)
                    h[i] = (byte) (a[i] ^ h[i]);

                StringBuilder p = new StringBuilder(a.Length);
                for (int i = 0; i < a.Length; ++i)
                    p.Append((char) h[i]);

                //manager = Manager.CreareManagerUseSql(SystemInformation.ComputerName);
                manager = Manager.CreareManagerUseAccess(pathToDb, p.ToString());

                LoginForm loginForm = new LoginForm(manager);
                DialogResult res = loginForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    mainForm = new MainForm();
                    Application.Run(mainForm);
                }
            }
            catch (Exception e)
            {
                ExceptionBox.Show(e);
            }
        }


        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestController c =
                new TestController((TestSet.TestsRow) (((LinkLabel) sender).Tag),
                                   manager.RunTest((TestSet.TestsRow) (((LinkLabel) sender).Tag)), this, manager);
            c.Run();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            TestController c =
                new TestController((TestSet.TestsRow) (((MenuCommand) sender).Tag),
                                   manager.RunTest((TestSet.TestsRow) (((MenuCommand) sender).Tag)), this, manager);
            Hide();
            c.Run();
        }

        private void menuCmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuCommandAbout_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog();
        }

        public void RegisterTestController(TestController testController)
        {
            activeTestController = testController;
        }

        public void UnregisterTestController(TestController testController)
        {
            activeTestController = null;
        }

        private void menuCommandResults_Click(object sender, EventArgs e)
        {
            ResultsForm resurtForm = new ResultsForm(manager);
            resurtForm.ShowDialog();
        }

        private void linkDownloadPractice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.gmatclub.com/downloadtests?practice");
        }

        private void linkDownloadTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.gmatclub.com/downloadtests?test");
        }

        private void linkLabel_MouseEnter(object sender, EventArgs e)
        {
            TestSet.TestsRow testsRow = (TestSet.TestsRow) (((LinkLabel) sender).Tag);
            statusBar.Text = "Run";
            if (testsRow.IsPractice)
            {
                statusBar.Text += " practice ";
            }
            else
            {
                statusBar.Text += " computer-adaptive test ";
            }

            statusBar.Text += testsRow.Name;
        }

        private void linkLabel_MouseLeave(object sender, EventArgs e)
        {
            statusBar.Text = "";
        }

        private void menuCommandHepl_Click(object sender, EventArgs e)
        {
            ShowHelpForm(HelpForm.HelpSubtype.Main);
        }

        private void linkImportPractice_MouseEnter(object sender, EventArgs e)
        {
            statusBar.Text += "Import practice set";
        }

        private void linkDownloadPractice_MouseEnter(object sender, EventArgs e)
        {
            statusBar.Text += "Download practice set";
        }

        private void linkDownloadTest_MouseEnter(object sender, EventArgs e)
        {
            statusBar.Text += "Download computer-adaptive set";
        }

        private void linkImportTest_MouseEnter(object sender, EventArgs e)
        {
            statusBar.Text += "Import computer-adaptive set";
        }

        private void menuCommandAddLicense_Click(object sender, EventArgs e)
        {
            LicenseForm licenseForm = new LicenseForm(PUBLIC_KEY_FILE_NAME);
            licenseForm.ShowDialog();
        }

        public static void ShowHelpForm(HelpForm.HelpSubtype helpSubtype)
        {
            helpForm.helpTypeId = (int) helpSubtype;
            helpForm.Show();
        }

        private void menuCommandDownload_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.gmatclub.com/downloadtests");
        }

        private void linkImportPractice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImEx imEx = new ImEx();
            imEx.InitConnection(true);
            imEx.ExportTest(7, "c:\\test.tst");
            MessageBox.Show("Export - OK", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            imEx.ImportTest("c:\\test.tst");
        }
    }
}