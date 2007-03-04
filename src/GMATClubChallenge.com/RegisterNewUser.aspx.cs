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

namespace GMATClubTest.Web
{
   public partial class RegisterNewUser : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender, e);
      }

      public override void DoLoad(object sender, EventArgs e)
      {
         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("New user registration");
      }
      protected void submit_Click(object sender, EventArgs e)
      {
         if (!lgnreq.IsValid || !cpr.IsValid || !pwdreq.IsValid) return;
         System.Collections.Hashtable ht = new System.Collections.Hashtable();
         for (int i = 0; i < propsview.Rows.Count; ++i)
         {
            ht.Add(Int32.Parse(((Label)propsview.Rows[i].Cells[3].FindControl("idxlbl")).Text),
                   ((TextBox)propsview.Rows[i].Cells[3].FindControl("value_box")).Text);
         }
         


         try
         {
            access_manager_.create_user(login.Text, pwd.Text, ht);
            Response.Redirect("Default.aspx");
         }
         catch (System.Exception ee)
         {
            errorLabel.Text = ee.Message;
            errorLabel.Visible = true;

         }
         
      }
      protected void cancel_Click(object sender, EventArgs e)
      {
         Response.Redirect("Default.aspx");
      }
}
};
