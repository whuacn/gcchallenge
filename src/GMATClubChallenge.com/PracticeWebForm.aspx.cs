//===========================================================================
// This file was modified as part of an ASP.NET 2.0 Web project conversion.
// The class name was changed and the class modified to inherit from the abstract base class 
// in file 'App_Code\Migrated\Stub_PracticeWebForm_aspx_cs.cs'.
// During runtime, this allows other classes in your web application to bind and access 
// the code-behind page using the abstract base class.
// The associated content page 'PracticeWebForm.aspx' was also modified to refer to the new class name.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Web;

namespace GMATClubTest.Web
{
	/// <summary>
	/// Summary description for PracticeWebForm.
	/// </summary>
    public partial class Migrated_PracticeGeneralWebForm : PracticeGeneralWebForm
	{
     
	
		protected void Page_Load(object sender, EventArgs e)
		{
           
            ((WebTestController)Session["WebTestController"]).PracticeWebForm_Load(this);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
            this.InitializeComponent();

            //exitImageButton = new ImageButton();
            //reviewImageButton = new ImageButton();
            //helpImageButton = new ImageButton();
            //answerCheckImageButton = new ImageButton();
            //nextImageButton = new ImageButton();
            //prewImageButton = new ImageButton();
            //Panel = new Panel();
            //questionImage = new Image();
            //passageImage = new Image();
            //questionPanel = new Panel();
            //passagePanel = new Panel();
            //answerRadioButtonList = new RadioButtonList();
            //statusLabel = new Label();
            //timeLabel = new Label();
            //AdminHyperLink = new HyperLink();
            //loginStatusHyperLink = new HyperLink();

            //clockHiddenParam = "";

            //status = "";
            base.OnInit(e);
            this.status = this.Request["isAnswerConfirm"];
            ((WebTestController)this.Session["WebTestController"]).PracticeGeneralWebForm_Init(this);
			
		}
	    
		private void InitializeComponent()
		{    
			this.reviewImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.reviewImageButton_Click);
			this.answerCheckImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.answerCheckImageButton_Click);
			this.helpImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.helpImageButton_Click);
			this.prewImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.prewImageButton_Click);
			this.nextImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.nextImageButton_Click);

		}
		#endregion



      
		private void nextImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		  
		  ((WebTestController)Session["WebTestController"]).PracticeWebForm_NextButtonClick(this);
		}

		private void prewImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			((WebTestController)Session["WebTestController"]).PracticeWebForm_PrewButtonClick(this);
		}

		private void answerCheckImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			((WebTestController)Session["WebTestController"]).PracticeWebForm_answerCheckClick(this);
		}

		private void reviewImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			((WebTestController)Session["WebTestController"]).PracticeWebForm_ReviewClick(this);
		}

		protected void answerRadioButtonList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((WebTestController)Session["WebTestController"]).PracticeWebForm_answerSelectedIndexChanged(this, sender);
		}

		private void helpImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			((WebTestController)Session["WebTestController"]).showHelp(this);
		}

        public override Image PassageImage
        {
            get { return passageImage; }
        }
	    
	    public override ImageButton ExitImageButton
	    {
            get { return exitImageButton; }
	    }

	    public override ImageButton ReviewImageButton
	    {
            get { return reviewImageButton; }
	    }

	    public override ImageButton HelpImageButton
	    {
            get { return helpImageButton; }
	    }

	    public override ImageButton AnswerCheckImageButton
	    {
            get { return answerCheckImageButton; }
	    }

	    public override ImageButton NextImageButton
	    {
            get { return nextImageButton; }
	    }

	    public override ImageButton PrewImageButton
	    {
            get { return prewImageButton; }
	    }

	    public override Image QuestionImage
	    {
            get { return questionImage; }
	    }
	  
	    public override Panel QuestionPanel
	    {
            get { return questionPanel; }
	    }

	    public override Panel PassagePanel
	    {
            get { return passagePanel; }
	    }

	    public override RadioButtonList AnswerRadioButtonList
	    {
            get { return answerRadioButtonList; }
	    }

	    public override Label StatusLabel
	    {
            get { return statusLabel; }
	    }

	    public override Label TimeLabel
	    {
            get { return timeLabel; }
	    }

	 
	    public override HyperLink LoginStatusHyperLink
	    {
            get { return loginStatusHyperLink; }
	    }
        protected void exitImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((WebTestController)Session["WebTestController"]).PracticeGeneralWebForm_Exit(this);
        }
}
}