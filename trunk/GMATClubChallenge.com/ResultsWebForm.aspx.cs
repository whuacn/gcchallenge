using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GMATClubTest.Web
{
    /// <summary>
    /// Summary description for ResultsWebForm1.
    /// </summary>
    public partial class ResultsWebForm : Page
    {
        protected ResultSet resultsSet;
        protected Manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                endCalendar.VisibleDate = DateTime.Now;
                endCalendar.SelectedDate = DateTime.Today;
                DateTime dt = new DateTime();
                dt = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
                beginCalendar.SelectedDate = dt;
                beginCalendar.VisibleDate = dt;
                dt = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);
                endCalendar.SelectedDate = dt;
                endCalendar.VisibleDate = dt;
            }

            logoutHyperLink.Text = "Log out" + " [" + Session["UserLogin"] + "]";
            resultsSet.Clear();
            manager = (Manager) Session["Manager"];
            manager.GetResults(manager.UserId, beginCalendar.SelectedDate, endCalendar.SelectedDate, resultsSet);
            try
            {
                if (Convert.ToBoolean(Session["IsEndTest"]))
                {
                    Session["IsEndTest"] = false;
                    //int i = resultsSet.Results[resultsSet.Results.Count - 1];
                    int resId = resultsSet.Results[resultsSet.Results.Count - 1].Id;
                    Session.Add("resultId", resId);
                    Session["pageSender"] = "resultsWebForm.aspx";
                    Response.Redirect("resultDetailsWebForm.aspx");
                }
            }
            catch
            {
            }
            resultsGrid.DataBind();
            for (int i = 0; i < resultsGrid.Items.Count; ++i)
            {
                resultsGrid.Items[i].Cells[5].Text = ((resultsSet.Results[i].TestIsPractice) ? ("Practice") : ("Test"));
            }
            // Put user code to initialize the page here
        }

        public ResultSet getResultSet()
        {
            return resultsSet;
        }

        public void setResultSet(ResultSet resultSet)
        {
            resultsSet = resultSet;
        }

        public Calendar getEndCalendar()
        {
            return endCalendar;
        }

        public Calendar getBeginCalendar()
        {
            return beginCalendar;
        }

        public void setEndCalendar(Calendar endCalendar)
        {
            this.endCalendar = endCalendar;
        }

        public void setBeginCalendar(Calendar beginCalendar)
        {
            this.beginCalendar = beginCalendar;
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
            this.resultsSet = new GmatClubTest.Data.ResultSet();
            ((System.ComponentModel.ISupportInitialize) (this.resultsSet)).BeginInit();
            this.OkImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.OkImageButton_Click);
            // 
            // resultsSet
            // 
            this.resultsSet.DataSetName = "ResultSet";
            this.resultsSet.Locale = new System.Globalization.CultureInfo("en-US");
            ((System.ComponentModel.ISupportInitialize) (this.resultsSet)).EndInit();
        }

        #endregion

        protected void resultsGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ((DataGrid) (sender)).SelectedIndex;
            int resId = resultsSet.Results[i].Id;
            Session.Add("resultId", resId);
            Session["pageSender"] = "resultsWebForm.aspx";
            Response.Redirect("resultDetailsWebForm.aspx");
        }

        private void OkImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string pageSender = (string) Session["pageSender"];
            if ((pageSender != "") & (pageSender != null))
            {
                Response.Redirect(pageSender);
            }
            else
            {
                Response.Redirect("mainWebForm.aspx");
            }
        }

        protected void beginCalendar_SelectionChanged(object sender, EventArgs e)
        {
            resultsSet.Clear();
            manager = (Manager) Session["Manager"];
            manager.GetResults(manager.UserId, beginCalendar.SelectedDate, endCalendar.SelectedDate, resultsSet);
            resultsGrid.DataBind();
            for (int i = 0; i < resultsGrid.Items.Count; ++i)
            {
                resultsGrid.Items[i].Cells[5].Text = ((resultsSet.Results[i].TestIsPractice)
                                                          ? ("<IMG alt=\"\" src=images/status/SEEN.gif>")
                                                          : ("<IMG alt=\"\" src=images/status/ANSWER_IS_CORRECT.gif>"));
                resultsGrid.Items[i].Cells[5].Enabled = false;
            }
        }

        protected void endCalendar_SelectionChanged(object sender, EventArgs e)
        {
            resultsSet.Clear();
            manager = (Manager) Session["Manager"];
            manager.GetResults(manager.UserId, beginCalendar.SelectedDate, endCalendar.SelectedDate, resultsSet);
            resultsGrid.DataBind();
            for (int i = 0; i < resultsGrid.Items.Count; ++i)
            {
                resultsGrid.Items[i].Cells[5].Text = ((resultsSet.Results[i].TestIsPractice)
                                                          ? ("<IMG alt=\"\" src=images/status/SEEN.gif>")
                                                          : ("<IMG alt=\"\" src=images/status/ANSWER_IS_CORRECT.gif>"));
            }
        }
    }
}