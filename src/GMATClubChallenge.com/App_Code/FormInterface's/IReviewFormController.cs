using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GMATClubTest.Web;

/// <summary>
/// Summary description for IReviewFormController inteface
/// </summary>
public interface IReviewFormController
{

    /// <summary>
    /// End/next button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void imageButton_Click(object sender, ImageClickEventArgs e);

    /// <summary>
    /// Review only flagged questions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void reviewFlagged_Click(object sender, ImageClickEventArgs e);

    
    /// <summary>
    /// Review only incorrect questions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void reviewIncorrect_Click(object sender, ImageClickEventArgs e);

    /// <summary>
    /// Init ReviewWebForm
    /// </summary>
    /// <param name="form"></param>
    void Init(ReviewWebForm form);
    
    
}
