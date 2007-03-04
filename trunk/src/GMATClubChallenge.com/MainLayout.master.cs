using System;
using System.IO;
using System.Web.UI;
using AccessControl;

namespace GMATClubTest.Web
{
   public partial class MainLayout : MasterPage
   {
   
      protected void Page_Load(object sender, EventArgs e)
      {
         access_manager_ = (AccessManager)(Session["access_manager"]);  
         if(null==access_manager_)                                            
         {
            throw new Exception("Access manager must be configured in start session");
         }
         if(""!=access_manager_.LastError && null!=access_manager_.LastError)
         {
            add_client_on_load("show_login_error(\"" + access_manager_.LastError.Replace("\r\n","<br/>")+"\");");
         }
      }
      
      public void add_client_on_load(string v)
      {
         onLoadScript+="\n"+v;
      }
      
      public void setPageHead(string v)
      {
         pageHead=v;
      }
      
      protected string generateTopMenu()
      {
         return "";
      }
      
      public string adminPanel()
      {  
         if(access_manager_.check_do("control_panel"))
         {
            return File.ReadAllText(access_manager_.SiteRoot+"/rc/admin_panel.rc.html");
         }
         return "";
      }
      public string topMenu()
      {
         return "<a href='Default.aspx'>Home</a> | <a href='Tests.aspx'>Tests</a> | <a href='CustomTestsForm.aspx'>Custom GMAT tests</a>" + generateTopMenu();     
      }
      
      protected AccessManager access_manager_ ;
      protected string onLoadScript;
      protected string pageHead;
   }
}
