using System;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GMATClubTest.Web;

/// <summary>
/// Summary description for ReviewFormController
/// </summary>
public class ReviewFormController: WebTestController, IReviewFormController
{
    private QuestionAnswerSet _qas;
    private ReviewWebForm _reviewWebForm;

    public ReviewFormController(TestSet.TestsRow testRow, Manager manager) : base(testRow, manager)
    {
    }

    #region IReviewFormController Members


    public void reviewFlagged_Click(object sender, ImageClickEventArgs e)
    {
        //int activeSet;
        //activeSet = Convert.ToInt32(((LinkButton)sender).ID);
        TransitionOnSelectSet(activSetNumber);
        //reviewWebForm.Response.Redirect("reviewWebForm.aspx");
        //base.TransitionOnSelectSet();
    }

    public void reviewIncorrect_Click(object sender, ImageClickEventArgs e)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    public void Init(ReviewWebForm form)
    {
        _reviewWebForm = form;
        if (!((navigator.HasNextSet) || (navigator.HasNextQuestion)))
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
        for (int i = 0; i < navigator.QuestionsAnswers.Length; i++)
        {
            int cells = 0;
            tr = new TableRow();

            form.SetsTable.Rows.Add(tr);
            form.SetsTable.Rows[rows].Cells.Add(tc);
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.SetsTable.Rows[rows].Cells.Add(tc);
            form.SetsTable.Rows[rows].Cells[cells].Text = (i + 1).ToString();
            form.SetsTable.Rows[rows].Cells[cells].ForeColor = Color.White;
            ++cells;
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Groove;
            form.SetsTable.Rows[rows].Cells.Add(tc);
            LinkButton setLinkButton = new LinkButton();
            setLinkButton.Text = navigator.Sets.QuestionSets[i].Name;
            setLinkButton.ID = i.ToString();
            setLinkButton.Click += new EventHandler(setLinkButton_Click);
            form.SetsTable.Rows[rows].Cells[cells].Controls.Add(setLinkButton);
            ++cells;
            _qas = navigator.QuestionsAnswers[i];
            questionCount = navigator.QuestionsAnswers[i].Questions.Count;
            double setScore = 0;
            for (int j = 0; j < questionCount; ++j)
            {
                status = navigator.GetQuestionStatus(_qas.Questions[j].Id);
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

        _qas = navigator.QuestionsAnswers[activSetNumber];
        questionCount = navigator.QuestionsAnswers[activSetNumber].Questions.Count;


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

            status = navigator.GetQuestionStatus(_qas.Questions[i].Id);
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
            //form.questionTable.Rows[rows].Cells[cells].Text = "<input type=\"image\" src=/" + "images/status/" + Question.Status.StatusType.GetName(typeof(Question.Status.StatusType), (int)status.status).ToString() + ".bmp"+">";
            questoinLinkButton.Text = "<input type=\"image\" src=" + "images/status/" +
                                      Question.Status.StatusType.GetName(typeof(Question.Status.StatusType),
                                                                         (int)status.status).ToString() + ".gif" +
                                      ">";
            questoinLinkButton.Text += renderer.RenderToString(_qas.Questions[i].Text);
            questoinLinkButton.ID = i.ToString();
            questoinLinkButton.Click += new EventHandler(questoinLinkButton_Click);
            questoinLinkButton.ID = "questoinLinkButton" + i.ToString();
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
        TransitionOnSelectSet(sn);
        _reviewWebForm.Response.Redirect("_reviewWebForm.aspx");
    }

    private void questoinLinkButton_Click(object sender, EventArgs e)
    {
        int qn = Convert.ToInt32(((LinkButton)sender).ID.Substring(18));
        TransitionOnSelectQuestion(qn, activSetNumber);
        GetActivQuestion();
        _reviewWebForm.Response.Redirect("practicewebform.aspx");
    }
    
    
}
