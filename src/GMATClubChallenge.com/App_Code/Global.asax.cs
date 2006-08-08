using System;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Web;

namespace GMATClubTest.Web 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	
	
	public class Global : HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			Manager manager;
            manager = Manager.CreareManagerUseSql(ConfigurationManager.AppSettings["DataSourceHost"], ConfigurationManager.AppSettings["DataSourceUserName"], ConfigurationManager.AppSettings["DataSourcePassword"]);
		    
			Session.Add("Manager", manager);
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			Response.Redirect("errorWebForm.aspx");
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			
		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new Container();
		}
		#endregion
	}
}

