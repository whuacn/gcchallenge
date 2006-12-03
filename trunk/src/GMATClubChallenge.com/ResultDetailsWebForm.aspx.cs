using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;

namespace GMATClubTest.Web
{
   public partial class ResultDetailsWebForm : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender, e);
      }

      public override void DoLoad(object sender, EventArgs e)
      {
         questionSetsResultDetailsSet.Clear();
         resultId = (int)Session["resultId"];
         manager_.GetQuestionSetsResultDetailsSet(resultId, questionSetsResultDetailsSet);
         Renderer renderer = new Renderer();
         renderer.RenderToString(questionSetsResultDetailsSet);
         setStutusDataGrid.DataBind();

         if (!IsPostBack)
         {
            selectedSet = 0;
            initQuestionStatusTable();
         }
      }


      public override string current_function_name()
      {
         return "show_details";
      }


      private void initQuestionStatusTable()
      {
         TableRow tr = new TableRow();
         TableCell tc = new TableCell();
         tc.BorderStyle = BorderStyle.Double;
         int rows = 0;
         questionStatusTable.Rows.Add(tr);
         tc.Text = "<b>#</b>";
         questionStatusTable.Rows[rows].Cells.Add(tc);
         tc = new TableCell();
         tc.BorderStyle = BorderStyle.Double;
         tc.Text = "<b>Question</b>";
         questionStatusTable.Rows[rows].Cells.Add(tc);
         tc = new TableCell();
         tc.BorderStyle = BorderStyle.Double;
         tc.Text = "<b>Difficulty</b>";
         questionStatusTable.Rows[rows].Cells.Add(tc);
         tc = new TableCell();
         tc.BorderStyle = BorderStyle.Double;
         tc.Text = "<b></b>";
         questionStatusTable.Rows[rows].Cells.Add(tc);

         for (int i = 0; i <= questionSetsResultDetailsSet.Answers.Count - 1; ++i)
         {
            tr = new TableRow();


            ++rows;
            questionStatusTable.Rows.Add(tr);


            int answerSatisfactoryOfSelectedSet = -1;
            int j;
            for (j = 0; j <= questionSetsResultDetailsSet.Answers.Count - 1; ++j)
            {
               if (questionSetsResultDetailsSet.Answers[j].SetId ==
                   questionSetsResultDetailsSet.QuestionSets[selectedSet].Id)
               {
                  ++answerSatisfactoryOfSelectedSet;
                  if (answerSatisfactoryOfSelectedSet == i)
                  {
                     break;
                  }
               }
            }
            if (j == questionSetsResultDetailsSet.Answers.Count)
            {
               break;
            }

            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Double;

            //tc.Text = questionSetsResultDetailsSet.Answers[j].QuestionOrder.ToString();

            tc.Text = (i + 1).ToString();

            questionStatusTable.Rows[rows].Cells.Add(tc);

            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Double;
            if (questionSetsResultDetailsSet.Answers[j].QuestionText.Length > 50)
            {
               int lastIndex = questionSetsResultDetailsSet.Answers[j].QuestionText.LastIndexOf(" ", 50, 10);
               string questionString = questionSetsResultDetailsSet.Answers[j].QuestionText.Substring(0, lastIndex);
               tc.Text = questionString + "...";
            }
            else
            {
               tc.Text = questionSetsResultDetailsSet.Answers[j].QuestionText;
            }

            questionStatusTable.Rows[rows].Cells.Add(tc);
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Double;

            tc.Text = questionSetsResultDetailsSet.Answers[j].QuestionDifficultyLevel;

            questionStatusTable.Rows[rows].Cells.Add(tc);
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.Double;

            // IMG alt="" src="images/gmatclub.jpg"
            //tc.Text = ((questionSetsResultDetailsSet.Answers[j].IsCorrect) ? ("<input type=\"image\" src=images/status/ANSWER_IS_CORRECT.gif>") : ("<input type=\"image\" src=images/status/ANSWER_IS_INCORRECT.gif>"));
            tc.Text = ((questionSetsResultDetailsSet.Answers[j].IsCorrect)
                           ? ("<IMG alt=\"\" src=images/status/ANSWER_IS_CORRECT.gif>")
                           : ("<IMG alt=\"\" src=images/status/ANSWER_IS_INCORRECT.gif>"));
            tc.Enabled = false;

            questionStatusTable.Rows[rows].Cells.Add(tc);
         }
      }

      #region Web Form Designer generated code

      protected override void OnInit(EventArgs e)
      {
         //
         // CODEGEN: This call is required by the ASP.NET Web Form Designer.
         //
         InitializeComponent();
         base.OnInit(e);
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.questionSetsResultDetailsSet = new GmatClubTest.Data.QuestionSetsResultDetailsSet();
         ((System.ComponentModel.ISupportInitialize)(this.questionSetsResultDetailsSet)).BeginInit();
         this.OkImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.OkImageButton_Click);
         // 
         // questionSetsResultDetailsSet
         // 
         this.questionSetsResultDetailsSet.DataSetName = "QuestionSetsResultDetailsSet";
         this.questionSetsResultDetailsSet.Locale = new System.Globalization.CultureInfo("en-US");
         ((System.ComponentModel.ISupportInitialize)(this.questionSetsResultDetailsSet)).EndInit();
      }

      #endregion

      private void OkImageButton_Click(object sender, ImageClickEventArgs e)
      {
         string pageSender = (string)Session["pageSender"];
         if ((pageSender != "") && (pageSender != null))
         {
            Session["pageSender"] = "";
            Response.Redirect(pageSender);
         }
         else
         {
            Response.Redirect("mainWebForm.aspx");
         }
      }

      protected void setStutusDataGrid_SelectedIndexChanged(object sender, EventArgs e)
      {
         selectedSet = ((DataGrid)sender).SelectedIndex;
         initQuestionStatusTable();
      }

      protected QuestionSetsResultDetailsSet questionSetsResultDetailsSet;
      protected int resultId = new int();
      protected int selectedSet;
   }
}