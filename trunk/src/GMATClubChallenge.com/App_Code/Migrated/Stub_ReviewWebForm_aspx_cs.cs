//===========================================================================
// This file was generated as part of an ASP.NET 2.0 Web project conversion.
// This code file 'App_Code\Migrated\Stub_ReviewWebForm_aspx_cs.cs' was created and contains an abstract class 
// used as a base class for the class 'Migrated_ReviewWebForm' in file 'ReviewWebForm.aspx.cs'.
// This allows the the base class to be referenced by all code files in your project.
// For more information on this code pattern, please refer to http://go.microsoft.com/fwlink/?LinkId=46995 
//===========================================================================


using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Web;


namespace GMATClubTest.Web
 {


abstract public class ReviewWebForm :  Page
{
    //public System.Web.UI.WebControls.HyperLink loginStatusHyperLink;
    //public System.Web.UI.WebControls.Table questionTable;
    //public System.Web.UI.WebControls.Table setsTable;
    //public System.Web.UI.WebControls.Label errorLabel;
    //public System.Web.UI.WebControls.ImageButton imageButton;
    //public System.Web.UI.WebControls.HyperLink adminHyperLink;

    abstract public HyperLink LoginStatusHyperLink { get;}
    abstract public HyperLink AdminHyperLink { get;}
    abstract public Image ImageButton { get;}
    abstract public Table QuestionTable { get;}
    abstract public Table SetsTable { get;}
    abstract public Label ErrorLabel { get;}
   
}



}
