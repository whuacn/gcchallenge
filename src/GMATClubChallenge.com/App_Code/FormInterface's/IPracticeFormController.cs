using System;
using System.Web.UI;
using GMATClubTest.Web;

/// <summary>
/// Summary description for IPracticeFormController
/// </summary>
public interface IPracticeFormController
{
    /// <summary>
    /// General form init
    /// </summary>
    /// <param name="practicelWebForm"></param>
    void GeneralInit(PracticeGeneralWebForm practicelWebForm);

    ///// <summary>
    ///// Init form
    ///// </summary>
    ///// <param name="form"></param>
    //void Init(PracticeGeneralWebForm form);

    /// <summary>
    /// Load form
    /// </summary>
    /// <param name="form"></param>
    void Load(PracticeGeneralWebForm form);

    /// <summary>
    /// Next question
    /// </summary>
    /// <param name="form"></param>
    void NextButtonClick(PracticeGeneralWebForm form);


    /// <summary>
    /// Prevision question
    /// </summary>
    /// <param name="form"></param>
    void PrewButtonClick(PracticeGeneralWebForm form);


    /// <summary>
    /// Check ansver
    /// </summary>
    void AnswerCheckClick(PracticeGeneralWebForm form);


    /// <summary>
    /// Review question
    /// </summary>
    /// <param name="form"></param>
    void ReviewClick(PracticeGeneralWebForm form);

    /// <summary>
    /// Set selected answer
    /// </summary>
    /// <param name="form"></param>
    /// <param name="sender">RadioButtonList</param>
    void AswerSelectedIndexChanged(PracticeGeneralWebForm form, object sender);

    /// <summary>
    /// End tes
    /// </summary>
    /// <param name="form"></param>
    void Exit(PracticeGeneralWebForm form);

}
