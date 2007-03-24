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
using GmatClubTest.Web;

namespace GMATClubTest.Web
{

   public partial class StartTest : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         
         try
         {
            idx = Int32.Parse(Request["idx"]);
            type=Request["type"].ToString();
            pkg_idx = Int32.Parse(Request["pkg_idx"].ToString());
            if (type == "group") pkg_idx = idx;
         }
         catch (System.Exception )
         {
            Response.Redirect("Tests.aspx");
         }
         base.Page_Load(sender,e);



         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Starting Test...");
         
         if(CustomTestsLogic.is_custom(idx,access_manager_))
         {
            DoTestById(idx);
         }
         else
         {
            try
            {
               Shop.ShopManager.check_sold_item(access_manager_, idx, type, pkg_idx);
            }
            catch(System.Exception ee)
            {
               denied.Visible=true;
               deniedLbl.Text=ee.Message;
            }

         }


         if (denied.Visible != true)
         {
            if ("test" == type)
            {
               DoTestById(idx);
            }
            else if ("download" == type)
            {
               DoPdfDownload(idx);
            }
            else if ("group" == type)
            {
               DoSelectTest(idx);
            }
         }         
      }

      public override void DoLoad(object sender, EventArgs e)
      {
      }

      public override string current_function_name()
      {
         return "Common_Page";
      }
      public override void on_access_granted()
      {

      }  
      
      public override bool on_access_denied(string reason)
      {
         denied.Visible=true;
         deniedLbl.Text = reason;

         return true;
      }

      private void DoSelectTest(int idx)
      {
         System.Collections.ArrayList arr=Shop.ShopManager.get_item_cont_by_idx(connection_,null,idx);   
         string ret="";
         resources.Visible=true;
         ta.SqlConnection=connection_;
         ta.FillByIdx(sh_it,idx);


         Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter si_ta = new Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter();
         si_ta.SqlConnection = connection_;
         Shop.shop_sold_item.shop_sold_itemDataTable si = si_ta.GetByItt(idx,Shop.ShopManager.type2code("group"),access_manager_.UserGuid);
         
         if(sh_it.Rows.Count!=0 && si.Rows.Count!=0)
         {
            if (sh_it[0].limit!=0)
            {
               description ="<span style='color:red;'>Warning </span> this package is limited by administartor so you can use just: "+sh_it[0].limit.ToString()+" items from the list.";                
               description+="<br><span style='color:red'>Left</span> " + (si[0].sold_count-si[0].use_count).ToString() + " items to select.";
               if (si[0].sold_count == si[0].use_count)
               {
                  pPayAgain.Visible = true;
               }
            }
         }
         
         
         foreach(System.Collections.Hashtable i in arr)
         {
            if(""!=i["bound"].ToString())
            {
               if(2 == (int)i["type"])
               {
                  ret += String.Format("<a href='StartTest.aspx?idx={0}&type=test&pkg_idx={2}'>{1}</a><br>", i["idx"], i["name"],idx);
               }
               if (3 == (int)i["type"])
               {
                  ret += String.Format("<a href='StartTest.aspx?idx={0}&type=download&pkg_idx={2}'>{1}</a><br>", i["idx"], i["name"], idx);
               }
            }
         }
         resourcelist=ret;
      }
      private void DoPdfDownload(int idx)
      {
         Response.Redirect("DoPdfDownload.aspx?idx="+idx.ToString());   
      }
      
      
      private void DoTestById(int id)
      {
         try
         {
            manager_.GetTests(testSet);
            TestSet.TestsRow tr = testSet.Tests.FindById(id);

            Session.Add("TestSet", testSet);
            if (tr.IsPractice)
            {
                PracticeFormController pc = new PracticeFormController(tr, manager_);
                Session.Add("IPracticeFormController", pc);
                Session.Add("WebTestController", pc as WebTestController);
            }
            else
            {
                WebTestController webTestController = new WebTestController(tr, manager_);
                Session.Add("WebTestController", webTestController);
            }
           
            Response.Redirect("descriptionwebform.aspx");
         }
         catch (System.Exception) { }
      }


      protected int idx = -1;
      protected string type="";
      protected int pkg_idx = -1;
      protected string resourcelist="";
      protected string description = "";
      public TestSet testSet = new GmatClubTest.Data.TestSet();
      Shop.shop_item.shop_itemDataTable sh_it=new Shop.shop_item.shop_itemDataTable();
      Shop.shop_itemTableAdapters.shop_itemTableAdapter ta = new Shop.shop_itemTableAdapters.shop_itemTableAdapter();

      protected void lbPayAgain_Click(object sender, EventArgs e)
      {
         Response.Redirect(String.Format("PayItem.aspx?idx={0}&type={1}&pkg_idx={2}",idx,type,pkg_idx));   
      }
   }
}