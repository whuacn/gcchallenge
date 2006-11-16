//===========================================================================
// This file was generated as part of an ASP.NET 2.0 Web project conversion.
// This code file 'App_Code\Migrated\Stub_TestWebForm_aspx_cs.cs' was created and contains an abstract class 
// used as a base class for the class 'Migrated_TestWebForm' in file 'TestWebForm.aspx.cs'.
// This allows the the base class to be referenced by all code files in your project.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================


using System.Web.UI;
using System.Web.UI.WebControls;

namespace GMATClubTest.Web
{
    public abstract class TestWebForm : Page
    {
        //public string answerConfirmClickScript;
        //public string nextClickScript;
        //public string status;
        //public System.Web.UI.WebControls.ImageButton helpImageButton = new ImageButton();
        //public System.Web.UI.WebControls.RadioButtonList answerRadioButtonList = new RadioButtonList();
        //public System.Web.UI.WebControls.Image passageImage= new Image();
        //public System.Web.UI.WebControls.Panel passagePanel=new Panel();
        //public System.Web.UI.WebControls.Image questionImage = new Image();
        //public System.Web.UI.WebControls.Panel questionPanel=new Panel();
        //public System.Web.UI.WebControls.Panel Panel=new Panel();
        //public System.Web.UI.WebControls.HyperLink loginStatusHyperLink = new HyperLink();
        //public System.Web.UI.WebControls.HyperLink AdminHyperLink = new HyperLink();
        //public System.Web.UI.WebControls.Label statusLabel = new Label();
        //public ImageButton answerConfirmImagebutton = new ImageButton();
        //public System.Web.UI.WebControls.Label timeLabel = new Label();

        // abstract public ImageButton ExitImageButton { get;}
        //abstract public ImageButton ReviewImageButton { get;}
        public abstract ImageButton HelpImageButton { get; }
        //abstract public ImageButton AnswerCheckImageButton { get;}
        //abstract public ImageButton NextImageButton { get;}
        //abstract public ImageButton PrewImageButton { get;}
        public abstract Image QuestionImage { get; }
        public abstract Image PassageImage { get; }
        public abstract Panel QuestionPanel { get; }
        public abstract Panel PassagePanel { get; }
        public abstract RadioButtonList AnswerRadioButtonList { get; }
        public abstract Label StatusLabel { get; }
        // abstract public Label TimeLabel { get;}
        //abstract public HyperLink AdminHyperLink { get;}
        public abstract Label TestNameLabel { get; }
        public abstract HyperLink LoginStatusHyperLink { get; }

        public string clockHiddenParam;
        public string answerConfirmClickScript;
        public string nextClickScript;
        public string status;
    }
}