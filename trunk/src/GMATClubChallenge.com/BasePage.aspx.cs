using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Web.UI;
using AccessControl;
using GmatClubTest.BusinessLogic;
using log4net;

namespace GMATClubTest.Web
{
   public partial class BasePage : Page, IStatusHandler
   {
      protected BasePage ()
      {
         logger = LogManager.GetLogger(this.GetType().ToString());
      }
      
      protected void Page_Load(object sender, EventArgs e)
      {
      
         access_manager_ = (AccessManager)(Session["access_manager"]);
         manager_ = (Manager)(Session["manager"]);
         connection_ = (SqlConnection)(manager_.DataProvider.getConnection());
         

         // check if user perfom a login or logoff
         // here a handler to
         if(!access_manager_.manage_session(
                                        Request,
                                        Response,
                                        ConfigurationManager.AppSettings["AccessManager.Cookie"],
                                        this
                                       ))
                                       {
                                          return;
                                       }
         Session["UserId"] = access_manager_.UserId;
         string fn_ = current_function_name();                                       
         try
         {
            
            if(""!=fn_ && null!=fn_)          
            {
               access_manager_.can_do(fn_);
               LogManager.GetLogger("access_control").WarnFormat("Access granted for '{0}' to {1}", access_manager_.UserLogin, fn_);
               on_access_granted();
            }
            try
            {
               DoLoad(sender, e);
            }
            
            catch(Exception eee)
            {
               show_error_(eee,true);
            }
         }
         catch(ThreadAbortException ee)
         {
         
         }
         catch(Exception ee)
         {
            LogManager.GetLogger("access_control").WarnFormat("Access Denied for '{0}' to {1}", access_manager_.UserLogin, fn_);
            show_error_(ee,false);
         }
      }

      public virtual void on_logon() 
      {
         Session["UserId"] = access_manager_.UserId;
         manager_.UserId = access_manager_.UserId; 
      }

      public virtual bool on_logof() 
      {
         Session["UserId"] = null;
         manager_.UserId = access_manager_.UserId;
         
         string logoff_page = ConfigurationManager.AppSettings["AccessManager.ByePage"];
         if (null == logoff_page || "" == logoff_page)
         {
            Response.Redirect("/");
         }
         else
         {
            Response.Redirect(logoff_page);
         }
         return false;
      }
      public virtual string current_function_name()                          
      {
         return "";
      }

      // on_access_denied may be implemented in derived class an must provide functionality related 
      // to security violation error
      // must return false if redirection to default security violation page must be done
      // or must return true if such issue was resolved in derived class
      public virtual bool on_access_denied(string msg)
      {
         return false;
      }
      
      public virtual void on_access_granted()
      {
      
      }

      public virtual string getPageHead()
      {
         return "<red>Please provide page head in: " + this.GetType().ToString() + "</red>";
      }
      
      public virtual void DoLoad(object sender, EventArgs e)
      {
         //throw std::ru
      }

      protected void show_error_(Exception ee,bool trace)
      {
         logger.ErrorFormat("Error: {0}",ee.Message);
         logger.ErrorFormat("   at: {0}",ee.StackTrace);

         Session["error_message"]=ee.Message;

         Session["error_stack"] = "";
         if(trace)
         {
            Session["error_stack"]=ee.StackTrace;
         }
         
         Response.Redirect("Error.aspx");
      }
      
      
      protected string current_function_="";
      protected string login_error_ = "";
      protected string onLoadScript="";
      protected AccessManager access_manager_ = null;
      protected Manager manager_ = null; 
      protected SqlConnection connection_=null;
      
      protected ILog logger = null;
   }

}
