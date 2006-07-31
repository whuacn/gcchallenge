using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Crownwood.Magic.Common;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Menus;
using GmatClubTest.ImportExport;
using TabControl = Crownwood.Magic.Controls.TabControl;

namespace GmatClubTest.DbEditor
{
	public class MainForm : Form
	{
		private IContainer components;
		private MenuCommand menuCommandFile;
		private MenuCommand menuCommandEdit;
		private MenuCommand menuCommandWindow;
		private MenuCommand menuCommandHelp;
        private ToolBar toolBar;
        private ImageList imageList24;
		private ToolBarButton toolBarButtonSep1;
		private ToolBarButton toolBarButtonCut;
		private ToolBarButton toolBarButtonCopy;
		private ToolBarButton toolBarButtonPaste;
		private ToolBarButton toolBarButtonSep2;
		private MenuControl menuControl;
		private TabControl tabControl;
		private Tree.Tree tree = new Tree.Tree();
		private System.Windows.Forms.ToolBarButton toolBarButtonAddConnection;
		private System.Windows.Forms.ToolBarButton toolBarButtonImportToDb;
		private System.Windows.Forms.ToolBarButton toolBarButtonExportToAccess;
		private System.Windows.Forms.ToolBarButton toolBarButtonAddTest;
		private System.Windows.Forms.ToolBarButton toolBarButtonAddSet;
		private System.Windows.Forms.ToolBarButton toolBarButtonSep3;
        private MenuCommand addConnectionMenuCommand;
        private ImageList imageList16;
        private MenuCommand exitMenuCommand;
        private MenuCommand menuCommandSep1;
        private MenuCommand addTestMenuCommand;
        private MenuCommand addSetMenuCommand;
        private MenuCommand menuCommandEditSep1;
        private MenuCommand importTestmenuCommand;
        private MenuCommand exportTestmenuCommand;
        private MenuCommand helpMenuCommand;
        private MenuCommand aboutMenuCommand;
        private MenuCommand menuCommandHelpSep1;

		private DockingManager dockManager;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Create the docking manager instance
			dockManager = new DockingManager(this, VisualStyle.IDE);

			// Define innner/outer controls for correct docking operation
			dockManager.InnerControl = tabControl;
			dockManager.OuterControl = toolBar;

			tree.ImageList = imageList16;
		    
			// Create content instances
            Content c = dockManager.Contents.Add(Tree, "Connections", imageList16, 0);

            c.DisplaySize = new Size(230, c.DisplaySize.Height);
            c.AutoHideSize = new Size(230, c.DisplaySize.Height);
            c.FloatingSize = new Size(230, c.DisplaySize.Height);
            
			// Add to the display on the left hand side
			dockManager.AddContentWithState(c, State.DockLeft);

		 }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuControl = new Crownwood.Magic.Menus.MenuControl();
            this.menuCommandFile = new Crownwood.Magic.Menus.MenuCommand();
            this.addConnectionMenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.menuCommandSep1 = new Crownwood.Magic.Menus.MenuCommand();
            this.exitMenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandEdit = new Crownwood.Magic.Menus.MenuCommand();
            this.addTestMenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.addSetMenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandEditSep1 = new Crownwood.Magic.Menus.MenuCommand();
            this.importTestmenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.exportTestmenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandWindow = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandHelp = new Crownwood.Magic.Menus.MenuCommand();
            this.helpMenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.menuCommandHelpSep1 = new Crownwood.Magic.Menus.MenuCommand();
            this.aboutMenuCommand = new Crownwood.Magic.Menus.MenuCommand();
            this.imageList24 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarButtonAddConnection = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSep1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonAddTest = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonAddSet = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSep2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCut = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCopy = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPaste = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSep3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonImportToDb = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExportToAccess = new System.Windows.Forms.ToolBarButton();
            this.tabControl = new Crownwood.Magic.Controls.TabControl();
            this.SuspendLayout();
            // 
            // menuControl
            // 
            this.menuControl.AnimateStyle = Crownwood.Magic.Menus.Animation.System;
            this.menuControl.AnimateTime = 100;
            this.menuControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menuControl.Direction = Crownwood.Magic.Common.Direction.Horizontal;
            this.menuControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuControl.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.menuControl.HighlightTextColor = System.Drawing.SystemColors.MenuText;
            this.menuControl.Location = new System.Drawing.Point(0, 0);
            this.menuControl.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[] {
            this.menuCommandFile,
            this.menuCommandEdit,
            this.menuCommandWindow,
            this.menuCommandHelp});
            this.menuControl.Name = "menuControl";
            this.menuControl.Size = new System.Drawing.Size(1018, 25);
            this.menuControl.Style = Crownwood.Magic.Common.VisualStyle.IDE;
            this.menuControl.TabIndex = 0;
            this.menuControl.TabStop = false;
            this.menuControl.Text = "menuControl1";
            // 
            // menuCommandFile
            // 
            this.menuCommandFile.Description = "MenuItem";
            this.menuCommandFile.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[] {
            this.addConnectionMenuCommand,
            this.menuCommandSep1,
            this.exitMenuCommand});
            this.menuCommandFile.Text = "&File";
            // 
            // addConnectionMenuCommand
            // 
            this.addConnectionMenuCommand.Description = "Add connection";
            this.addConnectionMenuCommand.ImageIndex = 13;
            this.addConnectionMenuCommand.ImageList = this.imageList16;
            this.addConnectionMenuCommand.Text = "Add &Connection";
            this.addConnectionMenuCommand.Click += new System.EventHandler(this.addConnectionMenuCommand_Click);
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList16.Images.SetKeyName(0, "");
            this.imageList16.Images.SetKeyName(1, "Database-Disabled.bmp");
            this.imageList16.Images.SetKeyName(2, "Doc-Access.bmp");
            this.imageList16.Images.SetKeyName(3, "Doc-Access-Disabled.bmp");
            this.imageList16.Images.SetKeyName(4, "tests.bmp");
            this.imageList16.Images.SetKeyName(5, "sets.bmp");
            this.imageList16.Images.SetKeyName(6, "quantitative.bmp");
            this.imageList16.Images.SetKeyName(7, "verbal.bmp");
            this.imageList16.Images.SetKeyName(8, "mixed.bmp");
            this.imageList16.Images.SetKeyName(9, "test.bmp");
            this.imageList16.Images.SetKeyName(10, "set.bmp");
            this.imageList16.Images.SetKeyName(11, "adaptiveTest.bmp");
            this.imageList16.Images.SetKeyName(12, "practice2.bmp");
            this.imageList16.Images.SetKeyName(13, "Database-Add.bmp");
            this.imageList16.Images.SetKeyName(14, "AddTest.bmp");
            this.imageList16.Images.SetKeyName(15, "AddSet.bmp");
            this.imageList16.Images.SetKeyName(16, "Exit2.bmp");
            this.imageList16.Images.SetKeyName(17, "Import Database.bmp");
            this.imageList16.Images.SetKeyName(18, "Export Database.bmp");
            this.imageList16.Images.SetKeyName(19, "Help.bmp");
            // 
            // menuCommandSep1
            // 
            this.menuCommandSep1.Description = "MenuItem";
            this.menuCommandSep1.Text = "-";
            // 
            // exitMenuCommand
            // 
            this.exitMenuCommand.Description = "Exit";
            this.exitMenuCommand.ImageIndex = 16;
            this.exitMenuCommand.ImageList = this.imageList16;
            this.exitMenuCommand.Text = "&Exit";
            this.exitMenuCommand.Click += new System.EventHandler(this.exitMenuCommand_Click);
            // 
            // menuCommandEdit
            // 
            this.menuCommandEdit.Description = "MenuItem";
            this.menuCommandEdit.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[] {
            this.addTestMenuCommand,
            this.addSetMenuCommand,
            this.menuCommandEditSep1,
            this.importTestmenuCommand,
            this.exportTestmenuCommand});
            this.menuCommandEdit.Text = "&Edit";
            // 
            // addTestMenuCommand
            // 
            this.addTestMenuCommand.Description = "Add test";
            this.addTestMenuCommand.ImageIndex = 14;
            this.addTestMenuCommand.ImageList = this.imageList16;
            this.addTestMenuCommand.Text = "Add &Test";
            this.addTestMenuCommand.Click += new System.EventHandler(this.addTestMenuCommand_Click_1);
            // 
            // addSetMenuCommand
            // 
            this.addSetMenuCommand.Description = "Add set";
            this.addSetMenuCommand.ImageIndex = 15;
            this.addSetMenuCommand.ImageList = this.imageList16;
            this.addSetMenuCommand.Text = "Add &Set";
            this.addSetMenuCommand.Click += new System.EventHandler(this.addSetMenuCommand_Click_1);
            // 
            // menuCommandEditSep1
            // 
            this.menuCommandEditSep1.Description = "MenuItem";
            this.menuCommandEditSep1.Text = "-";
            // 
            // importTestmenuCommand
            // 
            this.importTestmenuCommand.Description = "Import test";
            this.importTestmenuCommand.ImageIndex = 17;
            this.importTestmenuCommand.ImageList = this.imageList16;
            this.importTestmenuCommand.Text = "&Import Test";
            this.importTestmenuCommand.Click += new System.EventHandler(this.importTestmenuCommand_Click);
            // 
            // exportTestmenuCommand
            // 
            this.exportTestmenuCommand.Description = "Export test";
            this.exportTestmenuCommand.ImageIndex = 18;
            this.exportTestmenuCommand.ImageList = this.imageList16;
            this.exportTestmenuCommand.Text = "&Export Test";
            this.exportTestmenuCommand.Click += new System.EventHandler(this.exportTestmenuCommand_Click);
            // 
            // menuCommandWindow
            // 
            this.menuCommandWindow.Description = "MenuItem";
            this.menuCommandWindow.Text = "&Window";
            this.menuCommandWindow.Visible = false;
            // 
            // menuCommandHelp
            // 
            this.menuCommandHelp.Description = "MenuItem";
            this.menuCommandHelp.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[] {
            this.helpMenuCommand,
            this.menuCommandHelpSep1,
            this.aboutMenuCommand});
            this.menuCommandHelp.Text = "&Help";
            // 
            // helpMenuCommand
            // 
            this.helpMenuCommand.Description = "Help";
            this.helpMenuCommand.ImageIndex = 19;
            this.helpMenuCommand.ImageList = this.imageList16;
            this.helpMenuCommand.Text = "&Help";
            this.helpMenuCommand.Click += new System.EventHandler(this.helpMenuCommand_Click);
            // 
            // menuCommandHelpSep1
            // 
            this.menuCommandHelpSep1.Description = "MenuItem";
            this.menuCommandHelpSep1.Text = "-";
            // 
            // aboutMenuCommand
            // 
            this.aboutMenuCommand.Description = "About";
            this.aboutMenuCommand.Text = "&About DbEditor";
            this.aboutMenuCommand.Click += new System.EventHandler(this.aboutMenuCommand_Click);
            // 
            // imageList24
            // 
            this.imageList24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24.ImageStream")));
            this.imageList24.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList24.Images.SetKeyName(0, "");
            this.imageList24.Images.SetKeyName(1, "");
            this.imageList24.Images.SetKeyName(2, "");
            this.imageList24.Images.SetKeyName(3, "");
            this.imageList24.Images.SetKeyName(4, "");
            this.imageList24.Images.SetKeyName(5, "");
            this.imageList24.Images.SetKeyName(6, "");
            this.imageList24.Images.SetKeyName(7, "");
            this.imageList24.Images.SetKeyName(8, "Import Database.bmp");
            this.imageList24.Images.SetKeyName(9, "Export Database.bmp");
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonAddConnection,
            this.toolBarButtonSep1,
            this.toolBarButtonAddTest,
            this.toolBarButtonAddSet,
            this.toolBarButtonSep2,
            this.toolBarButtonCut,
            this.toolBarButtonCopy,
            this.toolBarButtonPaste,
            this.toolBarButtonSep3,
            this.toolBarButtonExportToAccess,
            this.toolBarButtonImportToDb});
            this.toolBar.ButtonSize = new System.Drawing.Size(30, 30);
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList24;
            this.toolBar.Location = new System.Drawing.Point(0, 25);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(1018, 36);
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarButtonAddConnection
            // 
            this.toolBarButtonAddConnection.ImageIndex = 0;
            this.toolBarButtonAddConnection.Name = "toolBarButtonAddConnection";
            this.toolBarButtonAddConnection.ToolTipText = "Add a New Connection";
            // 
            // toolBarButtonSep1
            // 
            this.toolBarButtonSep1.Name = "toolBarButtonSep1";
            this.toolBarButtonSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonAddTest
            // 
            this.toolBarButtonAddTest.ImageIndex = 7;
            this.toolBarButtonAddTest.Name = "toolBarButtonAddTest";
            this.toolBarButtonAddTest.ToolTipText = "Add a New Test";
            // 
            // toolBarButtonAddSet
            // 
            this.toolBarButtonAddSet.ImageIndex = 6;
            this.toolBarButtonAddSet.Name = "toolBarButtonAddSet";
            this.toolBarButtonAddSet.ToolTipText = "Add a New Question Set";
            // 
            // toolBarButtonSep2
            // 
            this.toolBarButtonSep2.Name = "toolBarButtonSep2";
            this.toolBarButtonSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonCut
            // 
            this.toolBarButtonCut.ImageIndex = 1;
            this.toolBarButtonCut.Name = "toolBarButtonCut";
            this.toolBarButtonCut.ToolTipText = "Cut";
            this.toolBarButtonCut.Visible = false;
            // 
            // toolBarButtonCopy
            // 
            this.toolBarButtonCopy.ImageIndex = 2;
            this.toolBarButtonCopy.Name = "toolBarButtonCopy";
            this.toolBarButtonCopy.ToolTipText = "Copy";
            this.toolBarButtonCopy.Visible = false;
            // 
            // toolBarButtonPaste
            // 
            this.toolBarButtonPaste.ImageIndex = 3;
            this.toolBarButtonPaste.Name = "toolBarButtonPaste";
            this.toolBarButtonPaste.ToolTipText = "Paste";
            this.toolBarButtonPaste.Visible = false;
            // 
            // toolBarButtonSep3
            // 
            this.toolBarButtonSep3.Name = "toolBarButtonSep3";
            this.toolBarButtonSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButtonSep3.Visible = false;
            // 
            // toolBarButtonImportToDb
            // 
            this.toolBarButtonImportToDb.ImageIndex = 8;
            this.toolBarButtonImportToDb.Name = "toolBarButtonImportToDb";
            this.toolBarButtonImportToDb.ToolTipText = "Import Tests from a Database";
            // 
            // toolBarButtonExportToAccess
            // 
            this.toolBarButtonExportToAccess.ImageIndex = 9;
            this.toolBarButtonExportToAccess.Name = "toolBarButtonExportToAccess";
            this.toolBarButtonExportToAccess.ToolTipText = "Export Tests";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.IDEPixelArea = true;
            this.tabControl.ImageList = this.imageList16;
            this.tabControl.Location = new System.Drawing.Point(0, 61);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(1018, 675);
            this.tabControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1018, 736);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMAT Club Test - Database Editor";
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			ApplicationController.Instance.Start();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			tree.LoadTree();
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == toolBarButtonAddConnection) {ApplicationController.Instance.AddConnection(); return;}
		    if (e.Button == toolBarButtonExportToAccess)
		    {
		       ApplicationController.Instance.ExportTest();
		        return;
		    }
		    if (e.Button == toolBarButtonImportToDb)
		    {
		       ApplicationController.Instance.ImportTest();
		       return;
		    }
		    
		    if(e.Button == toolBarButtonAddTest)
		    {
                ApplicationController.Instance.AddNewTest();
                return;
		    }
		    if(e.Button == toolBarButtonAddSet)
		    {
                ApplicationController.Instance.AddNewQuestionSet();
                return;
		    }
		    
		}

		private void MainForm_Closed(object sender, System.EventArgs e)
		{
			tree.SaveTree();
		}

		public Tree.Tree Tree
		{
			get { return tree; }
		}

		public TabControl TabControl
		{
			get { return tabControl; }
		}

        private void addConnectionMenuCommand_Click(object sender, EventArgs e)
        {
            ApplicationController.Instance.AddConnection();
        }
          

        private void exitMenuCommand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exportTestmenuCommand_Click(object sender, EventArgs e)
        {
            ApplicationController.Instance.ExportTest();
        }

        private void importTestmenuCommand_Click(object sender, EventArgs e)
        {
            ApplicationController.Instance.ImportTest();
        }

        private void addTestMenuCommand_Click_1(object sender, EventArgs e)
        {
            ApplicationController.Instance.AddNewTest();
        }

        private void addSetMenuCommand_Click_1(object sender, EventArgs e)
        {
            ApplicationController.Instance.AddNewQuestionSet();
        }

        private void helpMenuCommand_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void aboutMenuCommand_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

	}
}
