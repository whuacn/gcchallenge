using System;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GmatClubTest.Practice
{
    /// <summary>
    /// Summary description for NewUserForm.
    /// </summary>
    public class NewUserForm : Form
    {
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private TextBox confirmPasswordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox loginPictureBox;
        private PictureBox passwordPictureBox;
        private PictureBox namePictureBox;
        private TextBox nameTextBox;
        private PictureBox confirmPasswordPictureBox;
        private Button cancelButton;

        private Container components = null;
        private Button createButton;
        private Manager manager;
        private bool cancelCloseFlag = false;

        public NewUserForm(Manager manager)
        {
            this.manager = manager;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (NewUserForm));
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loginPictureBox = new System.Windows.Forms.PictureBox();
            this.passwordPictureBox = new System.Windows.Forms.PictureBox();
            this.namePictureBox = new System.Windows.Forms.PictureBox();
            this.confirmPasswordPictureBox = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.createButton.Enabled = false;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createButton.Image = ((System.Drawing.Image) (resources.GetObject("createButton.Image")));
            this.createButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createButton.Location = new System.Drawing.Point(34, 168);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(96, 32);
            this.createButton.TabIndex = 5;
            this.createButton.Text = "&Ok";
            this.createButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Image = ((System.Drawing.Image) (resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(162, 168);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 32);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(112, 8);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(136, 20);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Text = "";
            this.loginTextBox.TextChanged += new System.EventHandler(this.loginTextBox_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(112, 48);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(136, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "";
            this.nameTextBox.TextChanged += new System.EventHandler(this.NametextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(112, 88);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(136, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "";
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(112, 128);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.PasswordChar = '*';
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(136, 20);
            this.confirmPasswordTextBox.TabIndex = 4;
            this.confirmPasswordTextBox.Text = "";
            this.confirmPasswordTextBox.TextChanged += new System.EventHandler(this.confirmPasswordTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Confirm password";
            // 
            // loginPictureBox
            // 
            this.loginPictureBox.Image = ((System.Drawing.Image) (resources.GetObject("loginPictureBox.Image")));
            this.loginPictureBox.Location = new System.Drawing.Point(253, 3);
            this.loginPictureBox.Name = "loginPictureBox";
            this.loginPictureBox.Size = new System.Drawing.Size(24, 23);
            this.loginPictureBox.TabIndex = 15;
            this.loginPictureBox.TabStop = false;
            this.loginPictureBox.Visible = false;
            // 
            // passwordPictureBox
            // 
            this.passwordPictureBox.Image = ((System.Drawing.Image) (resources.GetObject("passwordPictureBox.Image")));
            this.passwordPictureBox.Location = new System.Drawing.Point(253, 83);
            this.passwordPictureBox.Name = "passwordPictureBox";
            this.passwordPictureBox.Size = new System.Drawing.Size(24, 23);
            this.passwordPictureBox.TabIndex = 17;
            this.passwordPictureBox.TabStop = false;
            this.passwordPictureBox.Visible = false;
            // 
            // namePictureBox
            // 
            this.namePictureBox.Image = ((System.Drawing.Image) (resources.GetObject("namePictureBox.Image")));
            this.namePictureBox.Location = new System.Drawing.Point(253, 43);
            this.namePictureBox.Name = "namePictureBox";
            this.namePictureBox.Size = new System.Drawing.Size(24, 23);
            this.namePictureBox.TabIndex = 18;
            this.namePictureBox.TabStop = false;
            this.namePictureBox.Visible = false;
            // 
            // confirmPasswordPictureBox
            // 
            this.confirmPasswordPictureBox.Image =
                ((System.Drawing.Image) (resources.GetObject("confirmPasswordPictureBox.Image")));
            this.confirmPasswordPictureBox.Location = new System.Drawing.Point(253, 123);
            this.confirmPasswordPictureBox.Name = "confirmPasswordPictureBox";
            this.confirmPasswordPictureBox.Size = new System.Drawing.Size(24, 23);
            this.confirmPasswordPictureBox.TabIndex = 19;
            this.confirmPasswordPictureBox.TabStop = false;
            this.confirmPasswordPictureBox.Visible = false;
            // 
            // NewUserForm
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.Controls.Add(this.confirmPasswordPictureBox);
            this.Controls.Add(this.namePictureBox);
            this.Controls.Add(this.passwordPictureBox);
            this.Controls.Add(this.loginPictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Profile";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NewUserForm_Closing);
            this.ResumeLayout(false);
        }

        #endregion

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((loginTextBox.Text != "") && (loginTextBox.Text.ToString().Length >= 4))
            {
                loginPictureBox.Show();
            }
            else loginPictureBox.Hide();
            if ((confirmPasswordPictureBox.Visible) && (passwordPictureBox.Visible) && (namePictureBox.Visible) &&
                (loginPictureBox.Visible))
            {
                createButton.Enabled = true;
            }
            else
            {
                createButton.Enabled = false;
            }
        }

        private void NametextBox_TextChanged(object sender, EventArgs e)
        {
            if ((nameTextBox.Text != "") && (nameTextBox.Text.ToString().Length >= 4))
            {
                namePictureBox.Show();
            }
            else namePictureBox.Hide();
            if ((confirmPasswordPictureBox.Visible) && (passwordPictureBox.Visible) && (namePictureBox.Visible) &&
                (loginPictureBox.Visible))
            {
                createButton.Enabled = true;
            }
            else
            {
                createButton.Enabled = false;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((passwordTextBox.Text != "") && (passwordTextBox.Text.ToString().Length >= 4))
            {
                passwordPictureBox.Show();
                if (passwordTextBox.Text == confirmPasswordTextBox.Text)
                {
                    confirmPasswordPictureBox.Show();
                }
                else
                {
                    confirmPasswordPictureBox.Hide();
                }
            }
            else passwordPictureBox.Hide();
            if ((confirmPasswordPictureBox.Visible) && (passwordPictureBox.Visible) && (namePictureBox.Visible) &&
                (loginPictureBox.Visible))
            {
                if (passwordTextBox.Text == confirmPasswordTextBox.Text)
                {
                    createButton.Enabled = true;
                }
                else
                {
                    createButton.Enabled = false;
                }
            }
            else
            {
                createButton.Enabled = false;
            }
        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((passwordTextBox.Text == confirmPasswordTextBox.Text) && (confirmPasswordTextBox.Text != "") &&
                (confirmPasswordTextBox.Text.ToString().Length >= 4))
            {
                confirmPasswordPictureBox.Show();
            }
            else confirmPasswordPictureBox.Hide();
            if ((confirmPasswordPictureBox.Visible) && (passwordPictureBox.Visible) && (namePictureBox.Visible) &&
                (loginPictureBox.Visible))
            {
                createButton.Enabled = true;
            }
            else
            {
                createButton.Enabled = false;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            UserSet u = new UserSet();

            try
            {
                manager.CreateUser(loginTextBox.Text, passwordTextBox.Text, nameTextBox.Text, u);
                DialogResult = DialogResult.OK;
                Dispose();
            }
            catch
            {
                MessageBox.Show(
                    "Login '" + loginTextBox.Text.ToString() + "' is already taken. Please, choose another login.",
                    "New user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cancelCloseFlag = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void NewUserForm_Closing(object sender, CancelEventArgs e)
        {
            if (cancelCloseFlag)
            {
                e.Cancel = true;
                cancelCloseFlag = false;
            }
        }
    }
}