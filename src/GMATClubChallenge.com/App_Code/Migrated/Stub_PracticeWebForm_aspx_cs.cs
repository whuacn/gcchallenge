//===========================================================================
// This file was generated as part of an ASP.NET 2.0 Web project conversion.
// This code file 'App_Code\Migrated\Stub_PracticeWebForm_aspx_cs.cs' was created and contains an abstract class 
// used as a base class for the class 'Migrated_PracticeGeneralWebForm' in file 'PracticeWebForm.aspx.cs'.
// This allows the the base class to be referenced by all code files in your project.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================


using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Web;


namespace GMATClubTest.Web
 {

  
abstract public class PracticeGeneralWebForm :  Page
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

    abstract public ImageButton ExitImageButton { get;}
    abstract public ImageButton ReviewImageButton { get;}
    abstract public ImageButton HelpImageButton { get;}
    abstract public ImageButton AnswerCheckImageButton { get;}
    abstract public ImageButton NextImageButton { get;}
    abstract public ImageButton PrewImageButton { get;}
    abstract public Image QuestionImage { get;}
    abstract public Image PassageImage { get;}
    abstract public Panel QuestionPanel { get;}
    abstract public Panel PassagePanel { get;}
    abstract public RadioButtonList AnswerRadioButtonList { get;}
    abstract public Label StatusLabel { get;}
    abstract public Label TimeLabel { get;}
   //bstract public HyperLink AdminHyperLink { get;}
    abstract public HyperLink LoginStatusHyperLink { get;}
    
    public string clockHiddenParam ="";
    public string status = "";

    
}

 }
