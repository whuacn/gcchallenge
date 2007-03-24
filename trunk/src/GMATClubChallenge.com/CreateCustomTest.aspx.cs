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
   public partial class CreateCustomTest : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender,e);
      }
      
      public override void DoLoad(object sender, EventArgs e)
      {  
         if(Request["idx"]!=null)            test_idx = Int32.Parse(Request["idx"]);    else test_idx=-1;
         
         if(test_idx!=-1)
         {
            if (!GmatClubTest.BusinessLogic.CustomTestsLogic.is_custom(test_idx, access_manager_))
            {
               throw new System.Exception("This is not a custom test!");   
            }
            if (!GmatClubTest.BusinessLogic.CustomTestsLogic.is_owner(test_idx, access_manager_))
            {
               throw new System.Exception("This test is not belongs to you!");
            }
         }
      }
      
      public override string current_function_name()
      {
         return "Custom test creation";
      }
      protected int test_idx=-1;
   }
}
