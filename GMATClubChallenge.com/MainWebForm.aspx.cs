using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.Web;

namespace GMATClubTest.Web
{
    /// <summary>
    /// Summary description for MainWebForm.6
    /// </summary>
    public partial class MainWebForm : Page
    {
        public TestSet testSet = new GmatClubTest.Data.TestSet();
        private Manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            manager = (Manager) Session["Manager"];
            if ((Request["testId"] != null) && (Request["testId"] != ""))
            {
                DoTestById(Convert.ToInt32(Request["testId"]));
                return;
            }
            if (!IsPostBack)
            {
                manager.GetTests(testSet);
                Session.Add("TestSet", testSet);
                UserSet us = new UserSet();
                manager.GetUser(manager.UserId, us);
                Session.Add("UserLogin", us.Users[0].Name);
                logOutLinkButton.Text = "Log out [" + us.Users[0].Name + "]";
            }
            int practiceNam = 0;
            int testsNam = 0;
            for (int i = 0; i < testSet.Tests.Count; ++i)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                if (testSet.Tests[i].IsPractice)
                {
                    ++practiceNam;
                    practiceTable.Rows.Add(tr);
                    HyperLink hl = new HyperLink();
                    hl.Text = testSet.Tests[i].Name;
                    hl.ID = Convert.ToString(testSet.Tests[i].Id);
                    hl.NavigateUrl = "mainwebform.aspx?testId=" + Convert.ToString(testSet.Tests[i].Id);
                    //lb.Click += new EventHandler(linkButton_Click);
                    tc.Controls.Add(hl);
                    practiceTable.Rows[practiceNam].Cells.Add(tc);
                }
                else
                {
                    ++testsNam;
                    testsTable.Rows.Add(tr);
                    HyperLink hl = new HyperLink();
                    hl.Text = testSet.Tests[i].Name;
                    hl.ID = Convert.ToString(testSet.Tests[i].Id);
                    hl.NavigateUrl = "mainwebform.aspx?testId=" + Convert.ToString(testSet.Tests[i].Id);
                    tc.Controls.Add(hl);
                    testsTable.Rows[testsNam].Cells.Add(tc);
                }
            }
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            DoTestById(Convert.ToInt32(((LinkButton) sender).ID));
        }


        private void link_click(object sender, EventArgs e)
        {
            DoTestById(Convert.ToInt32(((LinkButton) sender).Attributes["TestId"]));
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
        }

        #endregion

        private void DoTest(int number)
        {
            WebTestController webTestController = new WebTestController(testSet.Tests[number], manager);
            Session.Add("WebTestController", webTestController);
            Response.Redirect("descriptionwebform.aspx");
        }

        private void DoTestById(int id)
        {
            manager.GetTests(testSet);
            TestSet.TestsRow tr = testSet.Tests.FindById(id);

            Session.Add("TestSet", testSet);
            WebTestController webTestController = new WebTestController(tr, manager);
            Session.Add("WebTestController", webTestController);
            Response.Redirect("descriptionwebform.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DoTest(3);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session.Add("pageSender", "mainWebForm.aspx");
            Response.Redirect("resultsWebForm.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            DoTestById(1);
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            DoTestById(2);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DoTestById(6);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            DoTestById(7);
        }

        protected void logOutLinkButton_Click(object sender, EventArgs e)
        {
            //manager.Dispose();
            //Session["Manager"] = null;
            Response.Redirect("loginWebForm.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            DoTestById(25);
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            DoTestById(22);
        }
    }
}