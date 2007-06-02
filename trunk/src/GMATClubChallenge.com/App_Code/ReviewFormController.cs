using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Common;
using GmatClubTest.Data;
using GMATClubTest.Web;

/// <summary>
/// Summary description for ReviewFormController
/// </summary>
public class ReviewFormController: IReviewFormController
{
    private QuestionAnswerSet _qas;
    private ReviewWebForm _reviewWebForm;
    private WebTestController _webTestController;
    public ReviewFormController(WebTestController webTestController)
    {
        _webTestController = webTestController;
    }

    #region IReviewFormController Members

    /// <summary>
    /// End/next button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void imageButton_Click(object sender, ImageClickEventArgs e)
    {
        throw new NotImplementedException();
    }

    public void reviewFlagged_Click(object sender, ImageClickEventArgs e)
    {
        _webTestController.navigator.SetReviewState(ReviewState.ReviewFlagged);
        _webTestController.navigator.SetFirstReviewQuestion();
        _reviewWebForm.Response.Redirect("practiceWebForm.aspx");

    }

    public void reviewIncorrect_Click(object sender, ImageClickEventArgs e)
    {
        _webTestController.navigator.SetReviewState(ReviewState.ReviewIncorrect);
        _reviewWebForm.Response.Redirect("practiceWebForm.aspx");
    }


    public void Init(ReviewWebForm form)
    {
        _reviewWebForm = form;
        if (!((_webTestController.navigator.HasNextSet) || (_webTestController.navigator.HasNextQuestion)))
        {
            form.ImageButton.ImageUrl = @"images/exitTestButton.gif";
        }
        else
        {
            form.ImageButton.ImageUrl = @"images/returnButton.gif";
        }

        //form.ImageButton.Click += new ImageClickEventHandler(imageButton_Click);

        int questionCount;
        Question.Status status;
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        tc.BorderStyle = BorderStyle.Groove;
        int rows = 0;
        form.SetsTable.Rows.Add(tr);
        form.SetsTable.Rows[rows].Cells.Add(tc);
        form.SetsTable.Rows[rows].Cells[0].Text = "#";
        form.SetsTable.Rows[rows].Cells[0].Font.Size = FontUnit.Medium;
        form.SetsTable.Rows[rows].Cells[0].ForeColor = Color.White;
        form.SetsTable.Rows[rows].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        form.SetsTable.Rows[rows].Cells[0].BackColor = Color.FromArgb(8433377);
        tc = new TableCell();
        tc.BorderStyle = BorderStyle.Groove;
        form.SetsTable.Rows[rows].Cells.Add(tc);
        form.SetsTable.Rows[rows].Cells[1].Text = "Section name";
        form.SetsTable.Rows[rows].Cells[1].Font.Size = FontUnit.Medium;
        form.SetsTable.Rows[rows].Cells[1].ForeColor = Color.White;
        form.SetsTable.Rows[rows].Cells[1].HorizontalAlign = HorizontalAlign.Center;
        form.SetsTable.Rows[rows].Cells[1].BackColor = Color.FromArgb(8433377);
        tc = new TableCell();
        tc.BorderStyle = BorderStyle.Groove;
        form.SetsTable.Rows[rows].Cells.Add(tc);
        form.SetsTable.Rows[rows].Cells[2].Text = "Score";
        form.SetsTable.Rows[rows].Cells[2].Font.Size = FontUnit.Medium;
        form.SetsTable.Rows[rows].Cells[2].ForeColor = Color.White;
        form.SetsTable.Rows[rows].Cells[2].HorizontalAlign = HorizontalAlign.Center;
        form.SetsTable.Rows[rows].Cells[2].BackColor = Color.FromArgb(8433377);
        ++rows;
        for (int i = 0; i < _webTestController.navigator.QuestionsAnswers.Length; i++)
        {
            int cells = 0;
            tr = new TableRow();

            form.SetsTable.Rows.Add(tr);
            form.SetsTable.Rows[rows].Cells.Add(tc);
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.SetsTable.Rows[rows].Cells.Add(tc);
            form.SetsTable.Rows[rows].Cells[cells].Text = (i + 1).ToString();
            //form.SetsTable.Rows[rows].Cells[cells].Font.Size = FontUnit.XSmall;
            form.SetsTable.Rows[rows].Cells[cells].ForeColor = Color.White;
            ++cells;
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.SetsTable.Rows[rows].Cells.Add(tc);
            LinkButton setLinkButton = new LinkButton();
            setLinkButton.Text = _webTestController.navigator.Sets.QuestionSets[i].Name;
            setLinkButton.ForeColor = Color.White;
            setLinkButton.ID = i.ToString();
            setLinkButton.Click += new EventHandler(setLinkButton_Click);
            form.SetsTable.Rows[rows].Cells[cells].Controls.Add(setLinkButton);
            ++cells;
            _qas = _webTestController.navigator.QuestionsAnswers[i];
            questionCount = _webTestController.navigator.QuestionsAnswers[i].Questions.Count;
            double setScore = 0;
            for (int j = 0; j < questionCount; ++j)
            {
                status = _webTestController.navigator.GetQuestionStatus(_qas.Questions[j].Id);
                setScore += status.score;
            }
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.SetsTable.Rows[rows].Cells[cells].Text = setScore.ToString();
            form.SetsTable.Rows[rows].Cells[cells].ForeColor = Color.White;
            ++rows;
        }

        _qas = _webTestController.navigator.QuestionsAnswers[_webTestController.activSetNumber];
        questionCount = _webTestController.navigator.QuestionsAnswers[_webTestController.activSetNumber].Questions.Count;


        tr = new TableRow();
        tc = new TableCell();

        tc.BorderStyle = BorderStyle.Groove;

        rows = 0;

        tc = new TableCell();
        tc.BorderStyle = BorderStyle.Groove;
        form.QuestionTable.Rows.Add(tr);
        form.QuestionTable.Rows[rows].Cells.Add(tc);
        form.QuestionTable.Rows[rows].Cells[0].Text = "#";
        form.QuestionTable.Rows[rows].Cells[0].ForeColor = Color.White;
        form.QuestionTable.Rows[rows].Cells[0].Font.Size = FontUnit.Medium;
        form.QuestionTable.Rows[rows].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        form.QuestionTable.Rows[rows].Cells[0].BackColor = Color.FromArgb(8433377);
        tc = new TableCell();
        tc.BorderStyle = BorderStyle.Groove;
        form.QuestionTable.Rows[rows].Cells.Add(tc);
        form.QuestionTable.Rows[rows].Cells[1].Text = "Question";
        form.QuestionTable.Rows[rows].Cells[1].ForeColor = Color.White;
        form.QuestionTable.Rows[rows].Cells[1].Font.Size = FontUnit.Medium;
        form.QuestionTable.Rows[rows].Cells[1].HorizontalAlign = HorizontalAlign.Center;
        form.QuestionTable.Rows[rows].Cells[1].BackColor = Color.FromArgb(8433377);
        tc = new TableCell();
        tc.BorderStyle = BorderStyle.Groove;
        form.QuestionTable.Rows[rows].Cells.Add(tc);
        form.QuestionTable.Rows[rows].Cells[2].Text = "Status";
        form.QuestionTable.Rows[rows].Cells[2].ForeColor = Color.White;
        form.QuestionTable.Rows[rows].Cells[2].Font.Size = FontUnit.Medium;
        form.QuestionTable.Rows[rows].Cells[2].HorizontalAlign = HorizontalAlign.Center;
        form.QuestionTable.Rows[rows].Cells[2].BackColor = Color.FromArgb(8433377);
        ++rows;


        for (int i = 0; i < questionCount; ++i)
        {
            int cells = 0;
            tr = new TableRow();
            form.QuestionTable.Rows.Add(tr);

            status = _webTestController.navigator.GetQuestionStatus(_qas.Questions[i].Id);
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.QuestionTable.Rows[rows].Cells.Add(tc);
            form.QuestionTable.Rows[rows].Cells[cells].Text += (i + 1).ToString();
            form.QuestionTable.Rows[rows].Cells[cells].ForeColor = Color.White;
            ++cells;

            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.QuestionTable.Rows[rows].Cells.Add(tc);
            LinkButton questoinLinkButton = new LinkButton();
            questoinLinkButton.ForeColor = Color.White;
            //form.questionTable.Rows[rows].Cells[cells].Text = "<input type=\"image\" src=/" + "images/status/" + Question.Status.StatusType.GetName(typeof(Question.Status.StatusType), (int)status.status).ToString() + ".bmp"+">";
            questoinLinkButton.Text = "<input type=\"image\" src=" + "images/status/" +
                                      BuisinessObjects.StatusType.GetName(typeof(BuisinessObjects.StatusType),
                                                                         (int)status.status).ToString() + ".gif" +
                                      ">";
            questoinLinkButton.Text += _webTestController.renderer.RenderToString(_qas.Questions[i].Text);
            questoinLinkButton.ID = i.ToString();
            questoinLinkButton.Click += new EventHandler(questoinLinkButton_Click);
            questoinLinkButton.ID = "questoinLinkButton" + i.ToString();
            questoinLinkButton.Font.Size = FontUnit.Small;
            form.QuestionTable.Rows[rows].Cells[cells].Controls.Add(questoinLinkButton);
            ++cells;

            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.QuestionTable.Rows[rows].Cells.Add(tc);
            switch ((int)status.status)
            {
                case 0:
                    form.QuestionTable.Rows[rows].Cells[cells].Text = "Not seen";
                    break;
                case 1:
                    form.QuestionTable.Rows[rows].Cells[cells].Text = "Not answered";
                    break;
                case 2:
                    form.QuestionTable.Rows[rows].Cells[cells].Text = "Correct";
                    break;
                case 3:
                    form.QuestionTable.Rows[rows].Cells[cells].Text = "Incorrect";
                    break;
            }
            form.QuestionTable.Rows[rows].Cells[cells].ForeColor = Color.White;
            ++rows;
        }
    }
    
    #endregion

    private void setLinkButton_Click(object sender, EventArgs e)
    {
        int sn;
        sn = Convert.ToInt32(((LinkButton)sender).ID);
        _webTestController.TransitionOnSelectSet(sn);
        _reviewWebForm.Response.Redirect("_reviewWebForm.aspx");
    }

    private void questoinLinkButton_Click(object sender, EventArgs e)
    {
        _webTestController.navigator.SetReviewState(ReviewState.none);
        int qn = Convert.ToInt32(((LinkButton)sender).ID.Substring(18));
        _webTestController.TransitionOnSelectQuestion(qn, _webTestController.activSetNumber);
        _webTestController.GetActivQuestion();
        _reviewWebForm.Response.Redirect("practicewebform.aspx");
    }
    
    
}
