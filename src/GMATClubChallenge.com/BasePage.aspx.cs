using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AccessControl;
using log4net;

namespace GMATClubTest.Web
{
   public partial class BasePage : System.Web.UI.Page, AccessControl.IStatusHandler
   {
      protected BasePage ()
      {
         logger = LogManager.GetLogger(this.GetType().ToString());
      }
      
      protected void Page_Load(object sender, EventArgs e)
      {
      
         access_manager_ = (AccessControl.AccessManager)(Session["access_manager"]);
         manager_ = (GmatClubTest.BusinessLogic.Manager)(Session["manager"]);
         

         // check if user perfom a login or logoff
         // here a handler to
         if(!access_manager_.manage_session(
                                        Request,
                                        Response,
                                        System.Configuration.ConfigurationManager.AppSettings["AccessManager.Cookie"],
                                        this
                                       ))
                                       {
                                          return;
                                       }
         string fn_ = current_function_name();                                       
         try
         {
            
            if(""!=fn_ && null!=fn_)          
            {
               access_manager_.can_do(fn_);
               on_access_granted();
            }
            try
            {
               DoLoad(sender, e);
            }
            catch(System.Exception eee)
            {
               Response.Redirect("error.aspx");
            }
         }
         catch(System.Exception ee)
         {
            LogManager.GetLogger("access_control").WarnFormat("Access Denied for '{0}' to {1}", access_manager_.UserLogin, fn_);
            if(!on_access_denied(ee.Message))
            {
               Response.Redirect("Default.aspx");
            }
         }
      }

      public virtual void on_logon() { manager_.UserId = access_manager_.UserId; }

      public virtual bool on_logof() 
      {
         manager_.UserId = access_manager_.UserId;
         
         string logoff_page = System.Configuration.ConfigurationManager.AppSettings["AccessManager.ByePage"];
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
      
      
      protected string current_function_="";
      protected string login_error_ = "";
      protected string onLoadScript="";
      protected AccessControl.AccessManager access_manager_ = null;
      protected GmatClubTest.BusinessLogic.Manager manager_ = null; 
      
      protected log4net.ILog logger = null;
   }

}
