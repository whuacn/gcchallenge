//===========================================================================
// This file was modified as part of an ASP.NET 2.0 Web project conversion.
// The class name was changed and the class modified to inherit from the abstract base class 
// in file 'App_Code\Migrated\Stub_TestWebForm_aspx_cs.cs'.
// During runtime, this allows other classes in your web application to bind and access 
// the code-behind page using the abstract base class.
// The associated content page 'TestWebForm.aspx' was also modified to refer to the new class name.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Web;

namespace GMATClubTest.Web
{
    /// <summary>
    /// Summary description for TestWebForm.
    /// </summary>
    public partial class Migrated_TestWebForm : TestWebForm
    {
        /*
       
      public string answerConfirmClickScript;
      public string nextClickScript;
      public string status;
      public System.Web.UI.WebControls.ImageButton helpImageButton;
      public System.Web.UI.WebControls.RadioButtonList answerRadioButtonList;
      public System.Web.UI.WebControls.Image passageImage;
      public System.Web.UI.WebControls.Panel passagePanel;
      public System.Web.UI.WebControls.Image questionImage;
      public System.Web.UI.WebControls.Panel questionPanel;
      public System.Web.UI.WebControls.Panel Panel;
      public System.Web.UI.WebControls.HyperLink loginStatusHyperLink;
      public System.Web.UI.WebControls.HyperLink AdminHyperLink;
      public System.Web.UI.WebControls.Label statusLabel;
      public ImageButton answerConfirmImagebutton;
      public System.Web.UI.WebControls.Label timeLabel;
      
      */

        protected void Page_Load(object sender, EventArgs e)
        {
            status = Request["isAnswerConfirm"];

            ((WebTestController) Session["WebTestController"]).TestWebForm_Init(this);
            ((WebTestController) Session["WebTestController"]).TestWebForm_Load(this);
            ((WebTestController) Session["WebTestController"]).TestWebForm_CreateScripts(this);
        }

        #region Web Form Designer generated code

        protected override void OnInit(EventArgs e)
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
            this.helpImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.helpImageButton_Click);
        }

        #endregion

        private void helpImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((WebTestController) Session["WebTestController"]).showHelp(this);
        }

        public override Image PassageImage
        {
            get { return passageImage; }
        }


        public override ImageButton HelpImageButton
        {
            get { return helpImageButton; }
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


        public override HyperLink LoginStatusHyperLink
        {
            get { return loginStatusHyperLink; }
        }
    }
}