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

namespace GMATClubTest.Web
{
   public partial class DoPdfDownload : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender, e);
      }
      public override void DoLoad(object sender, EventArgs e)
      {
         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Staring PDF Download....");      
      }
      public override string current_function_name()
      {
         return "Common_Page";
      }
   }
}