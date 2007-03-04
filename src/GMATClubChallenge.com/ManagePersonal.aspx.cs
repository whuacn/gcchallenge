using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

using AccessControl;
using log4net;


namespace GMATClubTest.Web
{

   public partial class ManagePersonal: BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         apanel = (Request["panel"] != null) ? Request["panel"].ToString() : "tests";

         base.Page_Load(sender, e);
        

         showPanel(apanel);

      }
      public override void DoLoad(object sender, EventArgs e)
      {
         if (apanel == "profile") ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("User profile");
         if (apanel == "tests") ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Bought items");
         if (apanel == "results") ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("User results");
         
      }

      
      protected void showTests()
      {
         ta.SqlConnection = base.connection_;
         ta.FillByOwner(sold_items._shop_sold_item, access_manager_.UserGuid);
         sold_items_sorted=Shop.ShopManager.sort_sold_items(sold_items);
         gvTests.DataSource = sold_items_sorted;
         gvTests.DataBind();

         pTests.Visible = true;

      }


      public override string current_function_name()
      {
         if(apanel=="profile") return "manage_profile";
         if(apanel=="results") return "show_results";
         if(apanel=="tests")   return "show_user_bought";
         return "";
      }

      protected void showPanel(string name)
      {
         pResults.Visible = false;
         pTests.Visible = false;
         pProfile.Visible = false;
         if ("tests" == name)
         {
            showTests();
         }
         else if ("profile" == name)
         {
            showProfile();
         }
         else if ("results" == name)
         {
            showResults();
         }
      }

      protected string apanel;

      protected string build_url(object obj_)
      {
         try
         {
            System.Data.DataRowView obj = (System.Data.DataRowView)obj_;
            return String.Format("StartTest.aspx?idx={0}&type={1}&pkg_idx={2}",
               (int)obj["item_type_idx"],
               Shop.ShopManager.code2type((int)obj["type"]),
               (int)obj["parent_pkg_idx"]
               );
         }
         catch (System.Exception ee)
         {
            logger.ErrorFormat("Error: ", ee.Message);
         }
         return "bad_url_formatted";
      }

      protected string build_left(object obj_)
      {
         return Shop.ShopManager.build_left(obj_);
      }


      /// ///////////////////////////////////////////////////////////////////
      /// ///////////////////////////////////////////////////////////////////
      /// ///////////////////////////////////////////////////////////////////
      /// 

      protected void showResults()
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
         resultsSet.Clear();
         manager_.GetResults(access_manager_.UserId, beginCalendar.SelectedDate, endCalendar.SelectedDate, resultsSet);

         try
         {
            if (Convert.ToBoolean(Session["IsEndTest"]))
            {
               Session["IsEndTest"] = false;
               int resId = resultsSet.Results[resultsSet.Results.Count - 1].Id;
               Session.Add("resultId", resId);
               Session["pageSender"] = "ResultsWebForm.aspx";
               Response.Redirect("ResultDetailsWebForm.aspx");
               return;
            }
         }
         catch
         {
         }
         try
         {
            resultsGrid.DataBind();
            setTypes();
         }
         catch
         { }
         pResults.Visible = true;

      }
      protected void setTypes()
      {
         for (int i = 0; i < resultsGrid.Items.Count; ++i)
         {
            resultsGrid.Items[i].Cells[5].Text = ((resultsSet.Results[i].TestIsPractice) ? ("Practice") : ("Test"));
         }
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
         ((System.ComponentModel.ISupportInitialize)(this.resultsSet)).BeginInit();
         //this.OkImageButton.Click += new System.Web.UI.ImageClickEventHandler(this.OkImageButton_Click);
         // 
         // resultsSet
         // 
         this.resultsSet.DataSetName = "ResultSet";
         this.resultsSet.Locale = new System.Globalization.CultureInfo("en-US");
         ((System.ComponentModel.ISupportInitialize)(this.resultsSet)).EndInit();
      }

      #endregion

      protected void resultsGrid_SelectedIndexChanged(object sender, EventArgs e)
      {
         int i = ((DataGrid)(sender)).SelectedIndex;
         int resId = resultsSet.Results[i].Id;
         Session.Add("resultId", resId);
         Session["pageSender"] = "resultsWebForm.aspx";
         Response.Redirect("resultDetailsWebForm.aspx");
      }

      private void OkImageButton_Click(object sender, ImageClickEventArgs e)
      {
         string pageSender = (string)Session["pageSender"];
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

         manager_.GetResults(access_manager_.UserId, beginCalendar.SelectedDate, endCalendar.SelectedDate, resultsSet);
         resultsGrid.DataBind();
         for (int i = 0; i < resultsGrid.Items.Count; ++i)
         {
            resultsGrid.Items[i].Cells[5].Text = ((resultsSet.Results[i].TestIsPractice)
                                                      ? ("<IMG alt=\"\" src=images/status/SEEN.gif>")
                                                      : ("<IMG alt=\"\" src=images/status/ANSWER_IS_CORRECT.gif>"));
            resultsGrid.Items[i].Cells[5].Enabled = false;
         }
         setTypes();
      }

      protected void endCalendar_SelectionChanged(object sender, EventArgs e)
      {
         resultsSet.Clear();
         manager_.GetResults(access_manager_.UserId, beginCalendar.SelectedDate, endCalendar.SelectedDate, resultsSet);
         resultsGrid.DataBind();
         for (int i = 0; i < resultsGrid.Items.Count; ++i)
         {
            resultsGrid.Items[i].Cells[5].Text = ((resultsSet.Results[i].TestIsPractice)
                                                      ? ("<IMG alt=\"\" src=images/status/SEEN.gif>")
                                                      : ("<IMG alt=\"\" src=images/status/ANSWER_IS_CORRECT.gif>"));
         }
         setTypes();
      }

      /// ///////////////////////////////////////////////////////////////////
      /// ///////////////////////////////////////////////////////////////////
      /// ///////////////////////////////////////////////////////////////////
      public void showProfile()
      {
         Session["UserId"]=access_manager_.UserId;
         pProfile.Visible = true;
         login.Text = access_manager_.UserLogin;
      }




      protected ResultSet resultsSet;
      Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter ta = new Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter();
      Shop.shop_sold_item sold_items = new Shop.shop_sold_item();
      Shop.shop_sold_item sold_items_sorted = new Shop.shop_sold_item();

      
      protected void chgPwd_Click(object sender, EventArgs e)
      {
         cpr.Validate();
         pwdreq.Validate();
         if (!cpr.IsValid || !pwdreq.IsValid)
         {
            return;
         }
         access_manager_.set_pwd_current(pwd.Text);
      }
      protected void save_Click(object sender, EventArgs e)
      {
         try
         {
            logger.Info("Saving properties for: " + access_manager_.UserLogin);
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            for (int i = 0; i < propsview.Rows.Count; ++i)
            {
               string name = ((Label)propsview.Rows[i].Cells[0].FindControl("name")).Text;
               string idx = ((Label)propsview.Rows[i].Cells[1].FindControl("lblidx")).Text;
               string value = ((TextBox)propsview.Rows[i].Cells[4].FindControl("value_box")).Text;
               if (idx == null || idx == "") idx = "-1";
               ht[name]=new string[] { idx, value };
            }

            access_manager_.apply_props(access_manager_.UserGuid, ht);
            propsview.DataBind();
         }
         catch (System.Exception ee)
         {
            base.show_error_(ee, true);
         }

      }
}
}