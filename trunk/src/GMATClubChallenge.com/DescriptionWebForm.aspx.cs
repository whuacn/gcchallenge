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
   public partial class DescriptionWebForm : BasePage, IDescription
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if(null == ((GMATClubTest.Web.WebTestController)Session["WebTestController"]))
         {
            Response.Redirect("Default.aspx");
         }
         base.Page_Load(sender, e);
      }

      public override string current_function_name()
      {
         return "Common_Page";
      }

      public override void DoLoad(object sender, EventArgs e)
      {
        ((GMATClubTest.Web.WebTestController)Session["WebTestController"]).PrepareDescription(this);
      }

      
      public virtual void Caption(string caption)
      {
         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead(caption);
      }

      public virtual void DescriptionString(string desString)
      {
         descriptionString = desString;
      } 

      protected void OkImageButton_Click(object sender, ImageClickEventArgs e)
      {
         ((WebTestController)(Session["WebTestController"])).OnDescriptionOk(this);
      }

      protected void cancelImageButton_Click(object sender, ImageClickEventArgs e)
      {
         Response.Redirect("Tests.aspx");
      }

      public string descriptionString = "";
   }
}