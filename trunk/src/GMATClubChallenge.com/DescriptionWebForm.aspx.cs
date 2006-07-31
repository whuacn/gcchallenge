using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Web;

public partial class DescriptionWebForm : IDescriptionWebForm
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        logoutHyperLink.Text = "Log out" + " [" + Session["UserLogin"] + "]";
        if (!IsPostBack)
        {
            ((WebTestController)(Session["WebTestController"])).PrepareTestDescription(this);
        }
  
    }
  

    public override void Caption(string caption)
    {
        this.Title = caption;
    }

    public override void DescriptionString(string desString)
    {
        descriptionString = desString;
    }
    protected void OkImageButton_Click(object sender, ImageClickEventArgs e)
    {
        ((WebTestController)(Session["WebTestController"])).PrepareSetDescription(this);
    }
    protected void cancelImageButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mainWebForm.aspx");
    }
}
