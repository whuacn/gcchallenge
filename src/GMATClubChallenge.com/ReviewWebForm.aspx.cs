//===========================================================================
// This file was modified as part of an ASP.NET 2.0 Web project conversion.
// The class name was changed and the class modified to inherit from the abstract base class 
// in file 'App_Code\Migrated\Stub_ReviewWebForm_aspx_cs.cs'.
// During runtime, this allows other classes in your web application to bind and access 
// the code-behind page using the abstract base class.
// The associated content page 'ReviewWebForm.aspx' was also modified to refer to the new class name.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Web;

namespace GMATClubTest.Web
{
	/// <summary>
	/// Summary description for ReviewWebForm.
	/// </summary>
	public partial class Migrated_ReviewWebForm : ReviewWebForm
	{
		/*
		    public System.Web.UI.WebControls.HyperLink loginStatusHyperLink;
			public System.Web.UI.WebControls.Table questionTable;
			public System.Web.UI.WebControls.Table setsTable;
			public System.Web.UI.WebControls.Label errorLabel;
			public System.Web.UI.WebControls.ImageButton imageButton;
			public System.Web.UI.WebControls.HyperLink AdminHyperLink;
		*/
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new EventHandler(this.Page_Load);
			((WebTestController)Session["WebTestController"]).ReviewWebForm_Init(this);
            imageButton.Click += new ImageClickEventHandler(((WebTestController)Session["WebTestController"]).imageButton_Click);

		}
		#endregion

	    public override HyperLink LoginStatusHyperLink
	    {
            get { return loginStatusHyperLink; }
	    }

	    public override HyperLink AdminHyperLink
	    {
            get { return adminHyperLink; }
	    }

	    public override Image ImageButton
	    {
            get { return imageButton; }
	    }

	    public override Table QuestionTable
	    {
            get { return questionTable; }
	    }

	    public override Table SetsTable
	    {
            get { return setsTable; }
	    }

	    public override Label ErrorLabel
	    {
            get { return errorLabel; }
	    }
        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            bool b = true;
            this.Session.Add("IsEndTest", b);
            ((WebTestController)Session["WebTestController"]).imageButton_Click(sender, e);
        }
}
}
