using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;

namespace GMATClubTest.Web
{
    public partial class ResultDetailsWebForm : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        public override void DoLoad(object sender, EventArgs e)
        {
            
            {
            
                questionSetsResultDetailsSet.Clear();
                resultId = (int) Session["resultId"];
                manager_.GetQuestionSetsResultDetailsSet(resultId, questionSetsResultDetailsSet);

                resultAndDetails = new GmatClubTest.Data.ResultAndDetails();

                {
                    GmatClubTest.Data.ResultAndDetailsTableAdapters.ResultsTableAdapter ta = new GmatClubTest.Data.ResultAndDetailsTableAdapters.ResultsTableAdapter();
                    ta.FillById(resultAndDetails.Results, resultId);
                }
                

                {
                    GmatClubTest.Data.ResultAndDetailsTableAdapters.ResultsDetailsTableAdapter ta = new GmatClubTest.Data.ResultAndDetailsTableAdapters.ResultsDetailsTableAdapter();
                    ta.FillByResultId(resultAndDetails.ResultsDetails,resultId);
                }

                {
                    GmatClubTest.Data.ResultAndDetailsTableAdapters.TestsTableAdapter ta = new GmatClubTest.Data.ResultAndDetailsTableAdapters.TestsTableAdapter();
                    ta.FillById(resultAndDetails.Tests, resultAndDetails.Results[0].TestId);
                }

                {
                    RatingDrawer rdrawer = new RatingDrawer(true);
                    testRater = rdrawer.draw(resultAndDetails.Tests[0].Id, resultAndDetails.Tests[0].rating);
                }

                Renderer renderer = new Renderer();
                renderer.RenderToString(questionSetsResultDetailsSet);
                setStutusDataGrid.DataBind();

                //if (!IsPostBack)
                {
                    selectedSet = 0;
                    initQuestionStatusTable();
                }
                
                {
                    if(typeof(System.DBNull)!=resultAndDetails.Results[0]["annotation"].GetType())
                    {
                        System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();                    
                        ann_TextBox.Text=encoding.GetString(Convert.FromBase64String(resultAndDetails.Results[0].annotation));
                    }
                }
                
            }


            ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Result details of: " + resultAndDetails.Tests[0].Name);
            
            testName=resultAndDetails.Tests[0].Name;
                        
        }


        public override string current_function_name()
        {
            return "show_details";
        }


        private void initQuestionStatusTable()
        {
            TableRow tr = new TableRow();
            
            TableCell tc = new TableCell();
            tc.BorderStyle = BorderStyle.None;
            
            int rows = 0;
            questionStatusTable.Rows.Clear();
            questionStatusTable.Rows.Add(tr);
            tc.Text = "<b>#</b>";
            questionStatusTable.Rows[rows].Cells.Add(tc);
            
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.None;
            tc.Text = "<b>Question</b>";
            questionStatusTable.Rows[rows].Cells.Add(tc);
            
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.None;
            tc.Text = "<b>Difficulty</b>";
            questionStatusTable.Rows[rows].Cells.Add(tc);

            tc = new TableCell();
            tc.BorderStyle = BorderStyle.None;
            tc.Text = "<b>Time</b>";
            questionStatusTable.Rows[rows].Cells.Add(tc);

            
            tc = new TableCell();
            tc.BorderStyle = BorderStyle.None;
            tc.Text = "<b>Status</b>";
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
                tc.BorderStyle = BorderStyle.None;

                //tc.Text = questionSetsResultDetailsSet.Answers[j].QuestionOrder.ToString();

                tc.Text = (i + 1).ToString();

                questionStatusTable.Rows[rows].Cells.Add(tc);

                tc = new TableCell();
                tc.BorderStyle = BorderStyle.None;
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
                tc.BorderStyle = BorderStyle.None;

                tc.Text = questionSetsResultDetailsSet.Answers[j].QuestionDifficultyLevel;

                questionStatusTable.Rows[rows].Cells.Add(tc);


                int rid=-1;
                for(int k=0;k<resultAndDetails.ResultsDetails.Count;++k)
                {
                    if(resultAndDetails.ResultsDetails[k].QuestionId==questionSetsResultDetailsSet.Answers[j].QuestionId)
                    {
                        rid=k;
                    }
                }
                
                // diff_time
                if(rid!=-1)
                {
                    tc = new TableCell();
                    tc.BorderStyle = BorderStyle.None;

                    System.TimeSpan ts=resultAndDetails.ResultsDetails[rid].EndTime-resultAndDetails.ResultsDetails[rid].StartTime;
                    string s=ts.ToString();
                    tc.Text = s.Substring(0,s.IndexOf('.'));
                    tc.Enabled = false;

                    questionStatusTable.Rows[rows].Cells.Add(tc);
                }

                
                // status
                {
                   tc = new TableCell();
                   tc.BorderStyle = BorderStyle.None;

                   tc.Text = ((questionSetsResultDetailsSet.Answers[j].IsCorrect)
                               ? ("<IMG alt=\"\" src=images/status/ANSWER_IS_CORRECT.gif>")
                               : ("<IMG alt=\"\" src=images/status/ANSWER_IS_INCORRECT.gif>"));
                   tc.Enabled = false;

                   questionStatusTable.Rows[rows].Cells.Add(tc);
                }
                
            }
        }


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
                Response.Redirect("ManagePersonal.aspx?panel=main");
            }
        }

        protected void setStutusDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSet = ((DataGrid)sender).SelectedIndex;
            initQuestionStatusTable();
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
            ((System.ComponentModel.ISupportInitialize) (this.questionSetsResultDetailsSet)).BeginInit();
                        // 
            // questionSetsResultDetailsSet
            // 
            this.questionSetsResultDetailsSet.DataSetName = "QuestionSetsResultDetailsSet";
            this.questionSetsResultDetailsSet.Locale = new System.Globalization.CultureInfo("en-US");
            ((System.ComponentModel.ISupportInitialize) (this.questionSetsResultDetailsSet)).EndInit();
        }

        #endregion

        protected QuestionSetsResultDetailsSet questionSetsResultDetailsSet;
        protected int resultId = new int();
        protected int selectedSet;
        protected GmatClubTest.Data.ResultAndDetails resultAndDetails=null;
        protected string testName="";
        protected string testRater="";
        
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
            string base64s=Convert.ToBase64String(encoding.GetBytes(ann_TextBox.Text));
            resultAndDetails.Results[0].annotation=base64s;
            GmatClubTest.Data.ResultAndDetailsTableAdapters.ResultsTableAdapter ta = new GmatClubTest.Data.ResultAndDetailsTableAdapters.ResultsTableAdapter();
            ta.Update(resultAndDetails.Results);
        }
}
}