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

namespace GMATClubTest.Web
{
    /// <summary>
    /// Summary description for PracticeWebForm.
    /// </summary>
    public partial class Migrated_PracticeGeneralWebForm : PracticeGeneralWebForm
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).GeneralInit(this);
            ((IPracticeFormController)Session["IPracticeFormController"]).Load(this);
        }

        #region Web Form Designer generated code





        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }






        private void InitializeComponent()
        {
            this.reviewImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.reviewImageButton_Click);
            this.answerCheckImageButton.Click +=
                new System.Web.UI.ImageClickEventHandler(this.answerCheckImageButton_Click);
            this.helpImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.helpImageButton_Click);
            this.prewImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.prewImageButton_Click);
            this.nextImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.nextImageButton_Click);
        }

        #endregion

        protected void nextImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).NextButtonClick(this);
        }

        protected void prewImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).PrewButtonClick(this);
        }

        protected void answerCheckImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).AnswerCheckClick(this);
        }

        protected void reviewImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).ReviewClick(this);
        }

        protected void answerRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).AswerSelectedIndexChanged(this, sender);
        }

        protected void helpImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((WebTestController)Session["WebTestController"]).showHelp(this);
        }

        protected void exitImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).Exit(this);
        }

        public override Image PassageImage
        {
            get { return passageImage;}
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

        public override Panel ExplanationPanel
        {
            get { return explanationPanel; }
        }

        public override Image ExplanationImage
        {
            get { return explanationImage; }
        }
       
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public override Label PracticeNameLabel
        {
            get { return practiceNameLabel; }
        }

        public override ImageButton ShowAnswerImageButton
        {
            get { return showAnswerImageButton; }
        }

        public override ImageButton EplainAnswerImageButton
        {
            get { return explainAnswer; }
        }

        public override HiddenField ReviewFlag
        {
            get { return reviewFlag; }
        }

        public override string IsAnsverConfirm
        {
            get { return isAnswerConfirm.Value; }
        }

        protected void flagForReviewImageButton_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void explainAnswer_Click(object sender, ImageClickEventArgs e)
        {
            ((IPracticeFormController)Session["IPracticeFormController"]).ExplainAnswer(this);
        }
}
}