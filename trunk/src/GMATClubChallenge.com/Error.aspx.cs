using System;

namespace GMATClubTest.Web
{
    public partial class Error : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (Session["error_message"] != null)
            {
                err.Text = Session["error_message"].ToString();
            }

            if (Session["error_stack"] != null)
            {
                strace.Text = Session["error_stack"].ToString();
            }
            else
            {
                strace.Text = "";
            }

            Session.Remove("error_message");
            Session.Remove("error_stack");
        }
    }
}