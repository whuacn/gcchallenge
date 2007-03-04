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
   public partial class CustomTestsForm : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender,e);
         if(!IsPostBack)
         {
            if(null!=Request["q"] && ""!=Request["q"])
            {
               search_str.Text = Request["q"];
               custom_tests.SelectCommand = String.Format("SELECT * FROM [custom_tests] where name like '%{0}%' or description like '%{0}%';",Request["q"]);
            }
            else
            {
               search_str.Text ="";
               custom_tests.SelectCommand = "SELECT * FROM [custom_tests] ";
            }
         }
         
      }

      public override void DoLoad(object sender, EventArgs e)
      {
         this.DataBind();   
      }
      protected void search_Click(object sender, EventArgs e)
      {
         Response.Redirect("CustomTestsForm.aspx?q="+search_str.Text);
      }
      protected void create_Click(object sender, EventArgs e)
      {
         Response.Redirect("CreateCustomTest.aspx");
      }
}
}