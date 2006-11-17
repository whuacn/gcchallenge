using System;
using System.Web.UI;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GMATClubTest.Web
{
    /// <summary>
    /// Summary description for NewUserWebForm.
    /// </summary>
    public partial class NewUserWebForm : Page
    {
        private Manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            errorTextBox.Visible = false;
            // Put user code to initialize the page here
        }

        #region Web Form Designer generated code

        protected override void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new EventHandler(this.Page_Load);
        }

        #endregion

        protected void okImageButton_Click(object sender, ImageClickEventArgs e)
        {
            createUser();
        }

        protected void createUser()
        {
            if (loginTextBox.Text != "")
            {
                try
                {
                    manager = (Manager) Session["Manager"];
                    UserSet userSet = new UserSet();
                    manager.GetUsers(userSet);
                    manager.CreateUser(loginTextBox.Text, passwordTextBox.Text, nameTextBox.Text, userSet);
                    Response.Redirect("loginWebForm.aspx");
                }
                catch
                {
                    errorTextBox.Visible = true;
                    errorTextBox.Text += "Login '" + loginTextBox.Text.ToString() +
                                         "' is already taken. Please, choose another login. ";
                }
            }
            else
            {
                loginRegularExpressionValidator.IsValid = false;
            }
        }

        protected void cancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("loginwebform.aspx");
        }
    }
}