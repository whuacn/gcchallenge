using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Web;
using AccessControl;
using GmatClubTest.BusinessLogic;
using log4net;
using log4net.Config;
using System.IO;
using System.Net;
using System.Text;
//[assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "log4net", Watch = true)]

namespace GMATClubTest.Web
{
   public class Global : HttpApplication
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private IContainer components = null;
      private System.Threading.Thread myThread= null;

      public Global()
      {
         InitializeComponent();
      }

      
      protected void Application_Start(Object sender, EventArgs e)
      {

         XmlConfigurator.Configure(new FileInfo(Server.MapPath(".")+"/log4net.config"));
         LogManager.GetLogger(typeof(Global)).Info("Application started");
         
         myThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadMethod));
         myThread.Start();
         
      }

      AccessManager get_access_manager
      {
         get { return (AccessManager)Session["access_manager"]; }
      }


      public void ThreadMethod()
      {
         LogManager.GetLogger(typeof(Global)).Info("Thread started");
         DateTime td=DateTime.Now;
         DateTime nex_dt=td;//new DateTime(td.Year,td.Month,td.Day,16,49,0);
         
         for(;;)
         {
            try
            {
               DateTime d = DateTime.Now;
               if(d.Day==nex_dt.Day && d.Hour==nex_dt.Hour && d.Minute==nex_dt.Minute)
               {
                  nex_dt=nex_dt.AddMinutes(1);
                  HttpWebRequest  request  = (HttpWebRequest)WebRequest.Create("http://localhost:3866/GMATClubChallenge.com/handler.ajx.aspx?handler_name=StatisticCollector::updateResults");
                  HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                  Stream resStream = response.GetResponseStream();
                  byte[]        buf = new byte[8192];
                  int count=0;
                  string tempString="";
                  do
                  {
                     count = resStream.Read(buf, 0, buf.Length);
                     if(count!=0)
                     {
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                     }
                  }while(count>0);
                  
                  LogManager.GetLogger(typeof(Global)).Info("Upgrade statistic command send. Response: "+tempString);
               }
               

            }
            catch(System.Exception e)
            {
               LogManager.GetLogger(typeof(Global)).Info("Erro: " + e.Message);
            }
            System.Threading.Thread.Sleep(2000);   
         }
      
      }
      public static Hashtable init_managers(HttpRequest req)
      {

         
         Hashtable ret = new Hashtable();
         Manager manager = Manager.CreareManagerUseSql(ConfigurationManager.ConnectionStrings["gmatConnectionString"].ConnectionString);
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
         Hashtable ht = init_managers(Request);
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