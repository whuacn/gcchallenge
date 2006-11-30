using System;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Data;
using System.Collections;
using GmatClubTest.BusinessLogic;
using AccessControl;
using log4net;

//[assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "log4net", Watch = true)]

namespace GMATClubTest.Web
{
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
         log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"log4net.config"));
         LogManager.GetLogger(typeof(Global)).Info("Application started");
      }

      AccessControl.AccessManager get_access_manager
      {
         get { return (AccessControl.AccessManager)Session["access_manager"]; }
      }


      public static System.Collections.Hashtable init_managers(HttpRequest req)
      {

         
         System.Collections.Hashtable ret = new System.Collections.Hashtable();
         Manager manager = Manager.CreareManagerUseSql(System.Configuration.ConfigurationManager.ConnectionStrings["gmatConnectionString"].ConnectionString);
         manager.DataProvider.getConnection().Open();

         ret.Add("Manager", manager);
         AccessManager access_manager = new AccessManager(manager.DataProvider.getConnection());

         if (null != req.Cookies["GMAT_ACC_CTX"])           
         {

            if (null != req.Cookies["GMAT_ACC_CTX"] && req.Cookies["GMAT_ACC_CTX"].Value != "null")
            {
               access_manager.init_access_status(req.Cookies["GMAT_ACC_CTX"].Value);
            }
            manager.UserId=access_manager.UserId;
         }
         ret.Add("access_manager", access_manager);
         return ret;
      }

      protected void Session_Start(Object sender, EventArgs e)
      {
         System.Collections.Hashtable ht = init_managers(Request);
         ((AccessManager)ht["access_manager"]).SiteRoot = Server.MapPath(".");
         
         Session.Add("Manager", ht["Manager"]);
         Session.Add("access_manager", ht["access_manager"]);
         
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
      }

      protected void Session_End(Object sender, EventArgs e)
      {                                                           
        
      }

      protected void Application_End(Object sender, EventArgs e)
      {
         LogManager.GetLogger(typeof(Global)).Info("Application ended");
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