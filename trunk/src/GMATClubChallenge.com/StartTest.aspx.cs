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
            testId = Int32.Parse(Request["testid"]);
         }
         catch (System.Exception )
         {
            Response.Redirect("Tests.aspx");
         }
         base.Page_Load(sender,e);
         
         DoTestById(testId);
      }

      public override void DoLoad(object sender, EventArgs e)
      {
         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Starting Test...");
      }

      public override void on_access_granted()
      {

      }  
      
      public override bool on_access_denied(string reason)
      {
         throw new System.Exception("You must pay for this test: "+reason);
         return true;
      }
      

      public override string current_function_name()
      {
         return String.Format("test_{0}",testId);
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


      protected int testId = -1;
      public TestSet testSet = new GmatClubTest.Data.TestSet();
   }

}