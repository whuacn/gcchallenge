using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.SessionState ;
using GmatClubTest.BusinessLogic;
using AccessControl;
using Shop;
using GmatClubTest.Web;


namespace GmatClubTest.Web
{
   class AjaxRequestHandler : 
    IHttpHandler,
    IRequiresSessionState
   {
      public bool IsReusable
      {
         get { return false; }
      }

      public void ProcessRequest(HttpContext context)
      {
      //   Global.init_managers(session);
         System.Data.SqlClient.SqlTransaction tr=null;

         AccessControl.AccessManager am=null;
         try
         {
            if (null == context.Session["access_manager"])
            {
               throw new System.Exception("Session must be started first...");
            }
            am=((AccessControl.AccessManager)context.Session["access_manager"]);
         }
         catch(System.Exception ee)
         {
            context.Response.Write("error: " + ee.Message);
         }
         try
         {
            if (null == context.Request.Params["handler_name"])
            {
               throw new System.Exception("Need function name to execute");
            }

            string function = context.Request.Params["handler_name"];

            System.Data.SqlClient.SqlConnection conn_=(System.Data.SqlClient.SqlConnection)am.Connection;
            
            //tr=conn_.BeginTransaction();
            
            if(function!="StatisticCollector::updateResults")
            {
               am.can_do(function);
            }
            //am.Transaction=tr;
            
            bool processed=false;
            if ("UserManager::reset_pwd" == function)
            {
               context.Response.Write(AccessControl.UserManager.reset_pwd(am, context.Request));
               processed = true;
            }
            if ("UserManager::check_login" == function)
            {
               context.Response.Write(AccessControl.UserManager.check_login(am, context.Request));
               processed = true;
            }

            if ("UserManager::show_user_info_" == function)
            {
               context.Response.Write(AccessControl.UserManager.build_user_info_(am, context.Request));
               processed=true;
            }
            if ("UserManager::apply_props_" == function)
            {
               context.Response.Write(AccessControl.UserManager.apply_props_(am, context.Request));
               processed = true;
            }
            if ("UserManager::apply_groups_" == function)
            {
               context.Response.Write(AccessControl.UserManager.apply_groups_(am, context.Request));
               processed = true;
            }
            if ("UserManager::show_group_info_" == function)
            {
               context.Response.Write(AccessControl.UserManager.show_group_info_(am, context.Request));
               processed = true;
            }
            if ("UserManager::apply_grants_" == function)
            {
               context.Response.Write(AccessControl.UserManager.apply_grants_(am, context.Request));
               processed = true;
            }
            
            if ("ShopManager::edit_item_descr" == function)
            {
               context.Response.Write(Shop.ShopManager.show_item_descr(conn_, context.Request,tr));
               processed = true;
            }
            if ("ShopManager::save_item_descr" == function)
            {
               context.Response.Write(Shop.ShopManager.save_item_descr(conn_, context.Request,tr));
               processed = true;
            }
            if ("ShopManager::show_item_cont" == function)
            {
               context.Response.Write(Shop.ShopManager.show_item_cont(conn_, context.Request,tr));
               processed = true;
            }
            if ("ShopManager::apply_contents" == function)
            {
               context.Response.Write(Shop.ShopManager.apply_contents(conn_, context.Request, am,tr));
               processed = true;
            }
            if ("ShopManager::item_click" == function)
            {
               context.Response.Write(Shop.ShopManager.item_click(conn_, context.Request, am, tr,"StartTest.aspx?idx={0}&type={1}&pkg_idx={2}","ajax:PayItem.aspx?idx={0}&type={1}&pkg_idx={2}"));
               processed = true;
            }
            if ("UserManager::show_user_basket" == function)
            {
               context.Response.Write(Shop.ShopManager.show_user_basket(conn_, context.Request, am, tr));
               processed = true;
            }

            if ("ShopManager::delete_bought_items" == function)
            {
               context.Response.Write(Shop.ShopManager.delete_bought_items(conn_, context.Request, am, tr));
               processed = true;
            }
            if ("ShopManager::purchase_items" == function)
            {
               context.Response.Write(Shop.ShopManager.purchase_items(conn_, context.Request, am, tr));
               processed = true;
            }
            if ("CustomTestsLogic::list_types" == function)
            {
               context.Response.ContentType = "text/xml";
               context.Response.Write(GmatClubTest.BusinessLogic.CustomTestsLogic.list_types(conn_));
               processed = true;
            }
            if ("CustomTestsLogic::list_subtypes" == function)
            {
               context.Response.ContentType = "text/xml";
               context.Response.Write(GmatClubTest.BusinessLogic.CustomTestsLogic.list_subtypes(conn_));
               processed = true;
            }
            
            if ("CustomTestsLogic::list_questions" == function)
            {
               context.Response.ContentType="text/xml";
               context.Response.Write(GmatClubTest.BusinessLogic.CustomTestsLogic.list_tests(conn_));
               processed = true;
            }
            if ("CustomTestsLogic::list_q_in_test" == function)
            {
               context.Response.ContentType="text/plain";
               context.Response.Write(GmatClubTest.BusinessLogic.CustomTestsLogic.list_q_in_test(conn_,context.Request));
               processed = true;
            }
            if ("CustomTestsLogic::create_test" == function)
            {
               context.Response.ContentType = "text/plain";
               context.Response.Write(GmatClubTest.BusinessLogic.CustomTestsLogic.create_test(conn_, context.Request,am));
               processed = true;            
            }
            if ("StatisticCollector::updateResults" == function)
            {
               context.Response.ContentType = "text/plain";
               context.Response.Write(GmatClubTest.BusinessLogic.StatisticCollector.updateResults((SqlConnection)conn_));
               processed = true;            
            }
            if ("StatisticCollector::rate_it" == function)
            {
               context.Response.ContentType = "text/plain";
               context.Response.Write(GmatClubTest.BusinessLogic.StatisticCollector.rate_it((SqlConnection)conn_, context.Request));
               processed = true;
            }
            
            am.Transaction=null;
            if(!processed) throw new System.Exception("No such handler:" + function);
         }
            catch(System.Exception ee)
         {
            if(null!=tr) tr.Rollback();
            am.Transaction = null;
            context.Response.ContentType = "text/plain";
            context.Response.Write("error: "+ee.Message);
         }
      }
   }
}
