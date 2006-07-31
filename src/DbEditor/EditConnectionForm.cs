using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;

namespace GmatClubTest.DbEditor
{
	public class EditConnectionForm : Form
	{
		private Button buttonOk;
		private Button buttonCancel;
		private GroupBox groupBoxAccess;
		private RadioButton radioButtonAccessDb;
		private RadioButton radioButtonSqlDb;
		private TextBox textBoxFileName;
		private Button buttonBrowse;
		private Label label1;
		private TextBox textBoxAccessPassword;
		private Label label2;
		private Button buttonTestConnection;
		private Label label3;
		private TextBox textBoxServerName;
		private TextBox textBoxSqlPassword;
		private Label label4;
		private Label label5;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private GroupBox groupBoxSql;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxDatabaseName;
		private System.Windows.Forms.TextBox textBoxSqlUserName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private Connection connection;

		public EditConnectionForm(Connection connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.connection = connection;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditConnectionForm));
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxAccess = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFileName = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textBoxAccessPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.radioButtonAccessDb = new System.Windows.Forms.RadioButton();
			this.radioButtonSqlDb = new System.Windows.Forms.RadioButton();
			this.buttonTestConnection = new System.Windows.Forms.Button();
			this.groupBoxSql = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxServerName = new System.Windows.Forms.TextBox();
			this.textBoxSqlPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxSqlUserName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxDatabaseName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.groupBoxAccess.SuspendLayout();
			this.groupBoxSql.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOk.Location = new System.Drawing.Point(239, 289);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.TabIndex = 5;
			this.buttonOk.Text = "OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCancel.Location = new System.Drawing.Point(372, 289);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			// 
			// groupBoxAccess
			// 
			this.groupBoxAccess.Controls.Add(this.label1);
			this.groupBoxAccess.Controls.Add(this.textBoxFileName);
			this.groupBoxAccess.Controls.Add(this.buttonBrowse);
			this.groupBoxAccess.Controls.Add(this.textBoxAccessPassword);
			this.groupBoxAccess.Controls.Add(this.label2);
			this.groupBoxAccess.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBoxAccess.Location = new System.Drawing.Point(136, 16);
			this.groupBoxAccess.Name = "groupBoxAccess";
			this.groupBoxAccess.Size = new System.Drawing.Size(376, 80);
			this.groupBoxAccess.TabIndex = 2;
			this.groupBoxAccess.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "File";
			// 
			// textBoxFileName
			// 
			this.textBoxFileName.Location = new System.Drawing.Point(64, 14);
			this.textBoxFileName.Name = "textBoxFileName";
			this.textBoxFileName.ReadOnly = true;
			this.textBoxFileName.Size = new System.Drawing.Size(216, 20);
			this.textBoxFileName.TabIndex = 0;
			this.textBoxFileName.Text = "";
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonBrowse.Location = new System.Drawing.Point(288, 13);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(80, 23);
			this.buttonBrowse.TabIndex = 1;
			this.buttonBrowse.Text = "Browse...";
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// textBoxAccessPassword
			// 
			this.textBoxAccessPassword.Location = new System.Drawing.Point(64, 50);
			this.textBoxAccessPassword.Name = "textBoxAccessPassword";
			this.textBoxAccessPassword.PasswordChar = '*';
			this.textBoxAccessPassword.Size = new System.Drawing.Size(216, 20);
			this.textBoxAccessPassword.TabIndex = 2;
			this.textBoxAccessPassword.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Password";
			// 
			// radioButtonAccessDb
			// 
			this.radioButtonAccessDb.Checked = true;
			this.radioButtonAccessDb.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButtonAccessDb.Location = new System.Drawing.Point(16, 24);
			this.radioButtonAccessDb.Name = "radioButtonAccessDb";
			this.radioButtonAccessDb.TabIndex = 0;
			this.radioButtonAccessDb.TabStop = true;
			this.radioButtonAccessDb.Text = "Access Database";
			this.radioButtonAccessDb.CheckedChanged += new System.EventHandler(this.radioButtonAccessDb_CheckedChanged);
			// 
			// radioButtonSqlDb
			// 
			this.radioButtonSqlDb.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButtonSqlDb.Location = new System.Drawing.Point(16, 113);
			this.radioButtonSqlDb.Name = "radioButtonSqlDb";
			this.radioButtonSqlDb.Size = new System.Drawing.Size(112, 24);
			this.radioButtonSqlDb.TabIndex = 1;
			this.radioButtonSqlDb.Text = "MS SQL Database";
			// 
			// buttonTestConnection
			// 
			this.buttonTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonTestConnection.Location = new System.Drawing.Point(77, 289);
			this.buttonTestConnection.Name = "buttonTestConnection";
			this.buttonTestConnection.Size = new System.Drawing.Size(104, 23);
			this.buttonTestConnection.TabIndex = 4;
			this.buttonTestConnection.Text = "Test Connection";
			this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
			// 
			// groupBoxSql
			// 
			this.groupBoxSql.Controls.Add(this.label3);
			this.groupBoxSql.Controls.Add(this.textBoxServerName);
			this.groupBoxSql.Controls.Add(this.textBoxSqlPassword);
			this.groupBoxSql.Controls.Add(this.label4);
			this.groupBoxSql.Controls.Add(this.textBoxSqlUserName);
			this.groupBoxSql.Controls.Add(this.label5);
			this.groupBoxSql.Controls.Add(this.textBoxDatabaseName);
			this.groupBoxSql.Controls.Add(this.label6);
			this.groupBoxSql.Enabled = false;
			this.groupBoxSql.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBoxSql.Location = new System.Drawing.Point(136, 105);
			this.groupBoxSql.Name = "groupBoxSql";
			this.groupBoxSql.Size = new System.Drawing.Size(376, 152);
			this.groupBoxSql.TabIndex = 3;
			this.groupBoxSql.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Server Name";
			// 
			// textBoxServerName
			// 
			this.textBoxServerName.Location = new System.Drawing.Point(94, 14);
			this.textBoxServerName.Name = "textBoxServerName";
			this.textBoxServerName.Size = new System.Drawing.Size(274, 20);
			this.textBoxServerName.TabIndex = 0;
			this.textBoxServerName.Text = "";
			// 
			// textBoxSqlPassword
			// 
			this.textBoxSqlPassword.Location = new System.Drawing.Point(94, 122);
			this.textBoxSqlPassword.Name = "textBoxSqlPassword";
			this.textBoxSqlPassword.PasswordChar = '*';
			this.textBoxSqlPassword.Size = new System.Drawing.Size(274, 20);
			this.textBoxSqlPassword.TabIndex = 3;
			this.textBoxSqlPassword.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Password";
			// 
			// textBoxSqlUserName
			// 
			this.textBoxSqlUserName.Location = new System.Drawing.Point(94, 86);
			this.textBoxSqlUserName.Name = "textBoxSqlUserName";
			this.textBoxSqlUserName.Size = new System.Drawing.Size(274, 20);
			this.textBoxSqlUserName.TabIndex = 2;
			this.textBoxSqlUserName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "User Name";
			// 
			// textBoxDatabaseName
			// 
			this.textBoxDatabaseName.Location = new System.Drawing.Point(94, 50);
			this.textBoxDatabaseName.Name = "textBoxDatabaseName";
			this.textBoxDatabaseName.Size = new System.Drawing.Size(274, 20);
			this.textBoxDatabaseName.TabIndex = 1;
			this.textBoxDatabaseName.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 53);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Database Name";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(56, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(28, 28);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(56, 145);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(28, 28);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(16, 273);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 2);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "mdb";
			this.openFileDialog.Filter = "MS Access Files|*.mdb";
			// 
			// EditConnectionForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(524, 324);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.radioButtonAccessDb);
			this.Controls.Add(this.groupBoxAccess);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.radioButtonSqlDb);
			this.Controls.Add(this.buttonTestConnection);
			this.Controls.Add(this.groupBoxSql);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditConnectionForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connection to database";
			this.Load += new System.EventHandler(this.AddConnectionForm_Load);
			this.groupBoxAccess.ResumeLayout(false);
			this.groupBoxSql.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void AddConnectionForm_Load(object sender, EventArgs e)
		{
			radioButtonAccessDb.Checked = connection.DbType == Connection.Type.Access;
			radioButtonSqlDb.Checked = !radioButtonAccessDb.Checked;

			textBoxFileName.DataBindings.Add("Text", connection, "fileName");
			textBoxAccessPassword.DataBindings.Add("Text", connection, "password");
			textBoxServerName.DataBindings.Add("Text", connection, "serverName");
			textBoxDatabaseName.DataBindings.Add("Text", connection, "dbName");
			textBoxSqlUserName.DataBindings.Add("Text", connection, "userName");
			textBoxSqlPassword.DataBindings.Add("Text", connection, "password");

			EnableDisableGroups();
		}

		private void EnableDisableGroups()
		{
			if (radioButtonAccessDb.Checked)
			{
				connection.DbType = Connection.Type.Access;
				groupBoxAccess.Enabled = true;
				groupBoxSql.Enabled = false;
			} else
			{
				connection.DbType = Connection.Type.Sql;
				groupBoxAccess.Enabled = false;
				groupBoxSql.Enabled = true;
			}
		}

		private void radioButtonAccessDb_CheckedChanged(object sender, System.EventArgs e)
		{
			EnableDisableGroups();
		}

		private void buttonTestConnection_Click(object sender, System.EventArgs e)
		{
			try
			{
				connection.TestConnection();
				MessageBox.Show("Test connection succeed.", ApplicationController.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
			} catch (Exception ex)
			{
				MessageBox.Show("Cannot connect to the database: " + ex.Message, ApplicationController.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonBrowse_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBoxFileName.Text = openFileDialog.FileName;
				connection.FileName = openFileDialog.FileName;
			}
		}

		public Connection Connection
		{
			get {return connection;}
		}
	}
}
