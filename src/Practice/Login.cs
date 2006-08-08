using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.Data;
using GmatClubTest.BusinessLogic;

namespace GmatClubTest.Practice
{
   /// <summary>
   /// Summary description for Login.
   /// </summary>
   public class Login : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ComboBox loginComboBox;
      private System.Windows.Forms.TextBox passwordTextBox;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public Login()
      {
         //Manager.Instance.GetUsers().DataSetName.ToString();
         
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         BindLoginComboBox();
      }

      protected void BindLoginComboBox()
      {
         Data.UserSet u =  Manager.Instance.GetUsers();
         loginComboBox.Items.Add(u.Users);
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
         this.loginComboBox = new System.Windows.Forms.ComboBox();
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // loginComboBox
         // 
         this.loginComboBox.ItemHeight = 13;
         this.loginComboBox.Location = new System.Drawing.Point(280, 120);
         this.loginComboBox.Name = "loginComboBox";
         this.loginComboBox.Size = new System.Drawing.Size(152, 21);
         this.loginComboBox.TabIndex = 0;
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(280, 184);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(144, 20);
         this.passwordTextBox.TabIndex = 1;
         this.passwordTextBox.Text = "";
         // 
         // Login
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(704, 414);
         this.Controls.Add(this.passwordTextBox);
         this.Controls.Add(this.loginComboBox);
         this.Name = "Login";
         this.Text = "Login";
         this.ResumeLayout(false);

      }
      #endregion
   }
}
