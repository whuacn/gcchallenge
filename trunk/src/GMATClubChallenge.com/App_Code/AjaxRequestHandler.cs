using System;
using System.Collections;
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
               return;
            }

            string function = context.Request.Params["handler_name"];

            System.Data.SqlClient.SqlConnection conn_=(System.Data.SqlClient.SqlConnection)am.Connection;
            
            //tr=conn_.BeginTransaction();
            
            am.can_do(function);
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
            
            //tr.Commit();
            am.Transaction=null;
            if(!processed) throw new System.Exception("No such handler:" + function);
         }
         catch(System.Exception ee)
         {
            if(null!=tr) tr.Rollback();
            am.Transaction = null;            
            context.Response.Write("error: "+ee.Message);
         }
      }
   }
}
