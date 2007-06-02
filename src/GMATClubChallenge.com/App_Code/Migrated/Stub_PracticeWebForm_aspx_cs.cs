//===========================================================================
// This file was generated as part of an ASP.NET 2.0 Web project conversion.
// This code file 'App_Code\Migrated\Stub_PracticeWebForm_aspx_cs.cs' was created and contains an abstract class 
// used as a base class for the class 'Migrated_PracticeGeneralWebForm' in file 'PracticeWebForm.aspx.cs'.
// This allows the the base class to be referenced by all code files in your project.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================


using System.Web.UI;
using System.Web.UI.WebControls;

namespace GMATClubTest.Web
{
    public abstract class PracticeGeneralWebForm : Page
    {
        //ImageButton exitImageButton = new ImageButton();
        //ImageButton reviewImageButton = new ImageButton();
        //ImageButton helpImageButton = new ImageButton();
        //ImageButton nextImageButton = new ImageButton();
        //ImageButton prewImageButton = new ImageButton();
        //Panel panel = new Panel();
        //Image questionImage = new Image();
        //Image passageImage = new Image();
        //Panel questionPanel = new Panel();
        //Panel passagePanel = new Panel();
        //RadioButtonList answerRadioButtonList = new RadioButtonList();
        //Label statusLabel = new Label();
        //Label timeLabel = new Label();
        //HyperLink adminHyperLink = new HyperLink();
        //HyperLink loginStatusHyperLink = new HyperLink();
        //ImageButton answerCheckImageButton = new ImageButton();

        public abstract ImageButton ExitImageButton { get; }
        public abstract ImageButton ReviewImageButton { get; }
        public abstract ImageButton HelpImageButton { get; }
      
        public abstract ImageButton NextImageButton { get; }
        public abstract ImageButton PrewImageButton { get; }
        public abstract Image QuestionImage { get; }
        public abstract Image PassageImage { get; }
        public abstract Panel QuestionPanel { get; }
        public abstract Panel PassagePanel { get; }
        public abstract RadioButtonList AnswerRadioButtonList { get; }
        public abstract Label StatusLabel { get; }
        public abstract Label TimeLabel { get; }
        //bstract public HyperLink AdminHyperLink { get;}
        public abstract Label PracticeNameLabel { get;}
        public abstract HyperLink LoginStatusHyperLink { get; }

        public abstract string IsAnsverConfirm { get; }

        public string clockHiddenParam = "";
        public string status = "";

        public abstract Panel ExplanationPanel { get; }
        public abstract Image ExplanationImage { get; }

        public abstract ImageButton AnswerCheckImageButton { get; }
        public abstract ImageButton ShowAnswerImageButton { get; }
        public abstract ImageButton EplainAnswerImageButton { get; }


        public abstract HiddenField ReviewFlag { get; }
    }
}