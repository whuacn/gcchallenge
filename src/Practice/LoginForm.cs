using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GmatClubTest.Practice
{
	/// <summary>
	/// Summary description for LoginForm.
	/// </summary>
	public class LoginForm : Form
	{
		private UserSet userSet;
		private DataView userView;
		private ComboBox userCombo;
		private Button cancelButton;
		private Label userNameLabel;
		private ImageList imageList;
		private ImageList imageList24x24;
		private Button addButton;
		private Label label3;
		private Label label4;
		private TextBox passwordTextBox;
		private IContainer components;
		private bool isLoginOk = false;
		private System.Windows.Forms.Button okButton;

		private Manager manager;
		
		public LoginForm()
		{
			InitializeComponent();
		}

		public LoginForm(Manager manager)
		{
			
			this.manager = manager;
			InitializeComponent();
			manager.GetUsers(userSet);
			if (userSet.Users.Count == 0)
			{
				NewUserForm newUserForm = new NewUserForm(manager);
				newUserForm.ShowDialog();
				if (newUserForm.DialogResult == DialogResult.OK)
				{
					userCombo.SelectionStart = 1;
					manager.GetUsers(userSet);
					UpdateNameLabel();
				}
			}else
			{
				userCombo.SelectionStart = 1;
				UpdateNameLabel();
			}
			#if DEBUG 
				passwordTextBox.Text = "27005";
			#else
			#endif
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LoginForm));
			this.userSet = new GmatClubTest.Data.UserSet();
			this.userCombo = new System.Windows.Forms.ComboBox();
			this.userView = new System.Data.DataView();
			this.imageList24x24 = new System.Windows.Forms.ImageList(this.components);
			this.cancelButton = new System.Windows.Forms.Button();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.addButton = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.userSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
			this.SuspendLayout();
			// 
			// userSet
			// 
			this.userSet.DataSetName = "UserSet";
			this.userSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// userCombo
			// 
			this.userCombo.DataSource = this.userView;
			this.userCombo.DisplayMember = "Login";
			this.userCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.userCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.userCombo.Location = new System.Drawing.Point(80, 16);
			this.userCombo.Name = "userCombo";
			this.userCombo.Size = new System.Drawing.Size(248, 21);
			this.userCombo.TabIndex = 4;
			this.userCombo.ValueMember = "Id";
			this.userCombo.SelectedIndexChanged += new System.EventHandler(this.userCombo_SelectedIndexChanged);
			// 
			// userView
			// 
			this.userView.AllowDelete = false;
			this.userView.AllowEdit = false;
			this.userView.AllowNew = false;
			this.userView.Sort = "Login DESC";
			this.userView.Table = this.userSet.Users;
			// 
			// imageList24x24
			// 
			this.imageList24x24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList24x24.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList24x24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24x24.ImageStream")));
			this.imageList24x24.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cancelButton.ImageIndex = 1;
			this.cancelButton.ImageList = this.imageList24x24;
			this.cancelButton.Location = new System.Drawing.Point(232, 104);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(96, 32);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// userNameLabel
			// 
			this.userNameLabel.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.userNameLabel.ForeColor = System.Drawing.Color.Navy;
			this.userNameLabel.Location = new System.Drawing.Point(80, 40);
			this.userNameLabel.Name = "userNameLabel";
			this.userNameLabel.Size = new System.Drawing.Size(248, 23);
			this.userNameLabel.TabIndex = 1;
			this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// addButton
			// 
			this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.addButton.ImageIndex = 0;
			this.addButton.ImageList = this.imageList;
			this.addButton.Location = new System.Drawing.Point(120, 104);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(96, 32);
			this.addButton.TabIndex = 8;
			this.addButton.Text = "&New User";
			this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(28, 28);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(8, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Login";
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label4.Location = new System.Drawing.Point(8, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Password";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.passwordTextBox.Location = new System.Drawing.Point(80, 64);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(248, 20);
			this.passwordTextBox.TabIndex = 6;
			this.passwordTextBox.Text = "";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.okButton.ImageIndex = 0;
			this.okButton.ImageList = this.imageList24x24;
			this.okButton.Location = new System.Drawing.Point(8, 104);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(96, 32);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "&Ok";
			this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// LoginForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(338, 144);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.userNameLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.userCombo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login to GMAT Club Test - Practice";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.LoginForm_Closing);
			this.Activated += new System.EventHandler(this.LoginForm_Activated);
			((System.ComponentModel.ISupportInitialize)(this.userSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		private void UpdateNameLabel()
		{
			if (userCombo.Items.Count != 0)
			{
				userNameLabel.Text = userSet.Users.FindById((int)userCombo.SelectedValue).Name;
			}
			else
			{
				if (userNameLabel.Text == "")
				{
					userNameLabel.Text = "Please add a new user";
				}
			}
		}

		private void userCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateNameLabel();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (passwordTextBox.Text != "")
			{
				if (manager.IsPasswordValid(userSet.Users.FindById((int)userCombo.SelectedValue), passwordTextBox.Text))
				{
					manager.UserId = (int)userCombo.SelectedValue;
					isLoginOk = true;
				}else
				{
					MessageBox.Show("Provided login or password is invalid.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}else
			{	
                MessageBox.Show("Please specify a password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			NewUserForm newUserForm = new NewUserForm(manager);
			newUserForm.ShowDialog();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void LoginForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = (DialogResult == DialogResult.OK) && !isLoginOk;
		}

		private void LoginForm_Activated(object sender, System.EventArgs e)
		{
			manager.GetUsers(userSet);
			UpdateNameLabel();
		}

	}
}
