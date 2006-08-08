using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GMATClubTest.Web
{

	public partial class LoginWebForm : Page
	{
		protected UserSet userSet;
		protected DataView dataView;
		private Manager manager;
		protected void Page_Load(object sender, EventArgs e)
		{
			manager = (Manager)Session["Manager"];
			manager = Manager.CreareManagerUseSql(ConfigurationManager.AppSettings["DataSource"], ConfigurationManager.AppSettings["DataSourceUserName"], ConfigurationManager.AppSettings["DataSourcePassword"]);
			Session["Manager"] = manager;
			manager.GetUsers(userSet);
            //errorLabel.Visible = false;
			if (!IsPostBack)
			{ 
				//#if DEBUG 
                //passwordTextBox.Text = "27005";
                //#else
                //#endif
			}
			
		}
        #region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{

			InitializeComponent();
			base.OnInit(e);
		}
		

		private void InitializeComponent()
		{    
			this.userSet = new GmatClubTest.Data.UserSet();
			this.dataView = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.userSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			this.OkImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.OkImageButton_Click1);
			// 
			// userSet
			// 
			this.userSet.DataSetName = "UserSet";
			this.userSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataView
			// 
			this.dataView.Table = this.userSet.Users;
			((System.ComponentModel.ISupportInitialize)(this.userSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();

		}
		#endregion

		
        protected void newUserImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("newUserWebForm.aspx");
        }
        protected void OkImageButton_Click1(object sender, ImageClickEventArgs e)
        {
               //#if DEBUG
            //{
            //    int userId = 2104;// Id User name yuve
            //    Session.Add("UserId", userId);
            //    Response.Redirect("MainWebForm.aspx");
				
            //}
            //#else
            //#endif
            int userId = -1;
            if ((loginTextBox.Text == null) || (loginTextBox.Text == ""))
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Login or passwords is incorrect. If you not registered on site, please click New User button.";
                return;
            }
            for (int i = 0; i < userSet.Users.Count; i++ )
            {
                if (userSet.Users[i].Login == loginTextBox.Text)
                {
                    userId = userSet.Users[i].Id;
                    break;
                }
            }
            if (userId != -1)
            {
                if(manager.IsPasswordValid(userSet.Users.FindById(Convert.ToInt16(userId)), passwordTextBox.Text))
                {
                    Session.Add("UserId", userId);
                    manager.UserId = userId;
                    Response.Redirect("MainWebForm.aspx");

                }else
                {
                    errorLabel.Visible = true;
                    errorLabel.Text = "Login or passwords is incorrect. If you not registered on site, please click New User button.";
                }
            }else
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Login or passwords is incorrect. If you not registered on site, please click New User button.";
            }

        }
}
}
