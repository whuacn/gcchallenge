using System;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Common;
using GmatClubTest.Data;
using GMATClubTest.Web;

/// <summary>
/// Summary description for PracticeFormController
/// </summary>
public class PracticeFormController : WebTestController , IPracticeFormController
{

    public PracticeFormController(TestSet.TestsRow testRow, Manager manager)
        : base(testRow, manager)
    {

    }
   
    /// <summary>
    /// Load form
    /// </summary>
    /// <param name="form"></param>
    public void Load(PracticeGeneralWebForm form)
    {
        practicelWebForm = form;
        practicelWebForm.clockHiddenParam += "<INPUT id=\"timehh\" type=\"hidden\" value=\"" +
                                             navigator.RemainedTime.Hours + "\" name=\"timehh\">";
        practicelWebForm.clockHiddenParam += "<INPUT id=\"timemm\" type=\"hidden\" value=\"" +
                                             navigator.RemainedTime.Minutes + "\" name=\"timemm\">";
        practicelWebForm.clockHiddenParam += "<INPUT id=\"timess\" type=\"hidden\" value=\"" +
                                             navigator.RemainedTime.Seconds + "\" name=\"timess\">";

        if (practicelWebForm.IsPostBack)
        {
            return;
        }
        Init(practicelWebForm);
    }


    /// <summary>
    /// Init form
    /// </summary>
    /// <param name="practicelWebForm"></param>
    private  void Init(PracticeGeneralWebForm practicelWebForm)
    {
        GetActivQuestion();

        practicelWebForm.ReviewFlag.Value = bool.FalseString;

        if (navigator.ReviewState == ReviewState.ReviewFlagged || navigator.ReviewState == ReviewState.ReviewIncorrect)
        {
            practicelWebForm.ExplanationPanel.Visible = false;
            practicelWebForm.EplainAnswerImageButton.Visible = true;
            practicelWebForm.ShowAnswerImageButton.Visible = true;
            practicelWebForm.AnswerCheckImageButton.Visible = true;
     
        }
        else
        {
            practicelWebForm.ExplanationPanel.Visible = false;
            practicelWebForm.EplainAnswerImageButton.Visible = false;
            practicelWebForm.ShowAnswerImageButton.Visible = false;
            practicelWebForm.ShowAnswerImageButton.Visible = false;
            practicelWebForm.AnswerCheckImageButton.Visible = false;
        }

        loginStatusHyperLink.Text = "Log out...";
        loginStatusHyperLink.NavigateUrl = "loginWebForm.aspx";
        practicelWebForm.PracticeNameLabel.Text = testRow.Name;
        questionGUID = Guid.NewGuid();

        statusLabel.Visible = false;
        practicelWebForm.PassageImage.Visible = false;
        // practicelWebForm.PassageImage.Visible = true;
        if (question.SubtypeId == (int)BuisinessObjects.Subtype.ReadingComprehensionPassage)
        {
            throw new ApplicationException("Not valid databese! Navigator return ReadingComprehensionPassage questio.");
        }
        if (question.SubtypeId == (int)BuisinessObjects.Subtype.ReadingComprehensionQuestionToPassage)
        {
            passageGUID = Guid.NewGuid();
            imageSet = renderer.Render(question);
            //practicelWebForm.PassageImage.Visible = true;
            practicelWebForm.PassageImage.Visible = true;
            imageSet.Question.Save(
                mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID + ".gif",
                ImageFormat.Gif);
            practicelWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" +
                                                      questionGUID + ".gif";
            (renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id))).Save(
                mapPath + @"\images\Question&AnswerTempPictures\" + passageGUID + ".gif", ImageFormat.Gif);
            practicelWebForm.PassageImage.ImageUrl = @"images/Question&AnswerTempPictures/" + passageGUID +
                                                     ".gif";
            PrepareAndRenderAnswers();
        }
        else
        {
            imageSet = renderer.Render(question);
            //imageSet.Question.Save(HttpContext.Current.Request.MapPath("www.GMATClubChallenge.com") + mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif", ImageFormat.Gif);
            string path = (mapPath + "\\images\\Question&AnswerTempPictures\\" + questionGUID + ".gif");
            imageSet.Question.Save(path, ImageFormat.Gif);
            practicelWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" +
                                                      questionGUID + ".gif";
            PrepareAndRenderAnswers();
        }

        if (!navigator.HasPreviousQuestion)
        {
            practicelWebForm.PrewImageButton.Enabled = false;
        }
        else
        {
            practicelWebForm.PrewImageButton.Enabled = true;
        }
    }

   

    /// <summary>
    /// Next question
    /// </summary>
    /// <param name="form"></param>
    public void NextButtonClick(PracticeGeneralWebForm form)
    {
        int id = questionAnswerSet.Answers[selectedAnswer].Id;
        navigator.SetUserAnswer(id, Convert.ToBoolean(form.ReviewFlag.Value));

        if (navigator.ReviewState == ReviewState.ReviewFlagged || navigator.ReviewState == ReviewState.ReviewIncorrect)
        {
            if (!navigator.HasNextQuestion)
            {
                form.Response.Redirect("reviewWebForm.aspx");
            }
        }

        if (navigator.HasNextQuestion)
        {
            GetNextQuestion();
            Init(form);
        }
        else
        {
            if (navigator.HasNextSet)
            {
                GetNextSet();
                form.Response.Redirect("descriptionwebform.aspx");
            }
            else
            {
                navigator.CommitResult();

                form.Session.Add("IsEndTest", true);
                form.Response.Redirect("ManagePersonal.aspx?panel=results");
            }
        }
    }

    /// <summary>
    /// Prevision question
    /// </summary>
    /// <param name="form"></param>
    public void PrewButtonClick(PracticeGeneralWebForm form)
    {
        if (navigator.HasPreviousQuestion)
        {
            GetPrevQuestion();
            Init(form);
        }
        else
        {
            if (navigator.HasPreviousSet)
            {
                GetPrevSet();
                GetPrevQuestion();
                form.Response.Redirect("descriptionwebform.aspx");
            }
            else
            {
                //form.Response.Redirect("_reviewWebForm.aspx");
            }
        }
    }

    /// <summary>
    /// Check ansver
    /// </summary>
    public void AnswerCheckClick(PracticeGeneralWebForm form)
    {
        statusLabel.Visible = true;
        if (answerRadioButtonList.SelectedIndex != -1)
        {
            if (answersRow[answerRadioButtonList.SelectedIndex].IsCorrect)
            {
                statusLabel.Text = "Your answer is correct.";
            }
            else
            {
                statusLabel.Text = "Your answer is incorrect.";
            }
        }
        else
        {
            statusLabel.Text = "Your answer is incorrect.";
        }
    }

    /// <summary>
    /// Review question
    /// </summary>
    /// <param name="form"></param>
    public void ReviewClick(PracticeGeneralWebForm form)
    {
        form.Response.Redirect("reviewWebForm.aspx");
    }

    /// <summary>
    /// Set selected answer
    /// </summary>
    /// <param name="form"></param>
    /// <param name="sender">RadioButtonList</param>
    public void AswerSelectedIndexChanged(PracticeGeneralWebForm form, object sender)
    {
        selectedAnswer = ((RadioButtonList)sender).SelectedIndex;
    }

    /// <summary>
    /// End test
    /// </summary>
    /// <param name="form"></param>
    public void Exit(PracticeGeneralWebForm form)
    {
        navigator.CommitResult();
        form.Session.Add("IsEndTest", true);
        form.Response.Redirect("ManagePersonal.aspx?panel=results");
    }

    public void ExplainAnswer(PracticeGeneralWebForm form)
    {
        Init(form);
        practicelWebForm.ExplanationPanel.Visible = true;
        System.Drawing.Image explanatio = renderer.Render(navigator.GetExplanation());
        Guid explanatioGuid = Guid.NewGuid();
        string pathInWebServer = @"images\Question&AnswerTempPictures\" + explanatioGuid + ".gif";
        string fullPath = mapPath + "\\" + pathInWebServer;
        explanatio.Save(fullPath, ImageFormat.Gif);
        practicelWebForm.ExplanationImage.ImageUrl = pathInWebServer.Replace("\\", "/");
    }


    public void GeneralInit(PracticeGeneralWebForm practicelWebForm)
    {
        answerRadioButtonList = practicelWebForm.AnswerRadioButtonList;
        statusLabel = practicelWebForm.StatusLabel;
        timeLabel = practicelWebForm.TimeLabel;
        loginStatusHyperLink = practicelWebForm.LoginStatusHyperLink;
        practicelWebForm.StatusLabel.Visible = false;
        if (practicelWebForm.IsPostBack)
        {
            DeletePicturesFiles();
        }

        switch (practicelWebForm.IsAnsverConfirm)
        {
            case "NONE":
                break;
            case "answerConfirm":
                break;
            case "sectionExit":
                SectionExit(practicelWebForm);
                break;
            case "exit":
                break;
        }
    }
}
