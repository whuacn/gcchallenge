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
using AccessControl;
using GMATClubTest.Web;

namespace GMATClubTest.Web
{
   public partial class ManageAccessControl : BasePage
   {

      protected string[] panel_styles = {"block","none","none","none"};
      protected Boolean created_flag = false;
      private string panel_name="";
      
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender,e);
      }  
      
      public override void DoLoad(object sender, EventArgs e)
      {
         if (null != Session["created_flag"]) created_flag = ((Boolean)Session["created_flag"]);
         switchTool(Request["panel"]);

         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Access control manager");
         ((GMATClubTest.Web.MainLayout)(Master)).
         add_client_on_load
         (
            @"document.getElementById('_ctl0_content_searchStr').select();
              document.getElementById('_ctl0_content_searchStr').focus();
             "
         );

         
      }

      public override string current_function_name() 
      {
         return Request["panel"]!=null?"manage_"+Request["panel"].ToString():"manage_users";
      }
      
      protected void switchTool(string panel)
      {
         grid_error_panel.Visible=false;

         usersgrid.Visible=false;
         groupsgrid.Visible = false;
         funcsgrid.Visible = false;
         propsgrid.Visible = false;
         if(""==panel || null==panel)
         {
            panel="users";
         }
         for (int i = 0; i < panel_styles.Length; ++i)
         {
            panel_styles[i] = "none";
         }

         if ("users" == panel)
         {
            panel_styles[0] = "block";
            new_object.Text = "[New User]";
            usersgrid.Visible = true;
         }
         if ("groups" == panel)
         {
            panel_styles[1] = "block";
            new_object.Text = "[New Group]";
            groupsgrid.Visible = true;
         }
         if ("functions" == panel)
         {
            panel_styles[2] = "block";
            new_object.Text = "[New Function]";
            funcsgrid.Visible = true;
         }
         if ("properties" == panel)
         {
            panel_styles[3] = "block";
            new_object.Text = "[New Property]";
            propsgrid.Visible = true;
         }
         panel_name=panel;
      }

      protected void clearFilter_Click(object sender, EventArgs e)
      {
         searchStr.Text = "";
         findItem_Click(sender, e);
      }
      protected void searchStr_TextChanged(object sender, EventArgs e)
      {
         searchStr.DataBind();
         findItem_Click(sender, e);
      }

      System.Web.UI.WebControls.ObjectDataSource current_ods()
      {
         System.Web.UI.WebControls.ObjectDataSource ods = null;
         if ("block" == panel_styles[0]) ods = users;
         if ("block" == panel_styles[1]) ods = groups;
         if ("block" == panel_styles[2]) ods = funcs;
         if ("block" == panel_styles[3]) ods = props;
         return ods;
      }

      System.Web.UI.WebControls.GridView current_grid()
      {
         System.Web.UI.WebControls.GridView gv = null;
         if ("block" == panel_styles[0]) gv = usersgrid;
         if ("block" == panel_styles[1]) gv = groupsgrid;
         if ("block" == panel_styles[2]) gv = funcsgrid;
         if ("block" == panel_styles[3]) gv = propsgrid;
         return gv;
      }

      protected void findItem_Click(object sender, EventArgs e)
      {
         System.Web.UI.WebControls.ObjectDataSource ods = current_ods();

         if ("" != searchStr.Text)
         {
            ods.SelectMethod = "GetDataWithFilter";
            if (0 == ods.SelectParameters.Count)
            {
               ods.SelectParameters.Add("value", TypeCode.String, "%" + searchStr.Text + "%");
            }
            else
            {
               ods.SelectParameters[0].Name = "value";
               ods.SelectParameters[0].DefaultValue = "%" + searchStr.Text + "%";
            }
         }
         else
         {
            ods.SelectMethod = "GetData";
            ods.SelectParameters.Clear();
         }
      }
      protected void new_object_Click(object sender, EventArgs e)
      {
         Session["created_flag"] = true;
         System.Web.UI.WebControls.ObjectDataSource ods = current_ods();
         System.Web.UI.WebControls.GridView gv = current_grid();
         ods.SelectMethod = "GetData";
         ods.SelectParameters.Clear();
         int i=ods.Insert();
         gv.EditIndex = gv.Rows.Count;
         this.DataBind();
      }


      protected void gridError(string text)
      {
         grid_error_panel.Visible = true;
         grid_error_label.Text = text;
      }
      
      
      protected void users_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters.Clear();
         e.InputParameters["guididx"] = Guid.NewGuid().ToString();
         e.InputParameters["login"] = "new_one";
         e.InputParameters["pwd"] = "";
         e.InputParameters["first_name"] = "...";
         e.InputParameters["last_name"] = "...";
         e.InputParameters["email"] = "...";
      }
      protected void groups_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters["guididx"] = System.Guid.NewGuid().ToString();
         e.InputParameters["name"] = "new_group";
      }
      protected void props_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters["name"] = "new_property";
      }
      protected void funcs_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters["name"] = "new_function";
      }
      
      
      protected void usersgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {
         if(e.NewValues["login"].Equals("new_one"))
         {
            e.Cancel=true;
            gridError("Can't save user with 'new_one' login");
            return;
         }
         try
         {
            AccessControl.acl_user.can_set_login(((AccessControl.AccessManager)Session["access_manager"]).Connection, (int)e.Keys["idx"], e.NewValues["login"].ToString());
         }
         catch(System.Exception ee)
         {
            e.Cancel = true;
            gridError(ee.Message);
         }
         
      }
      protected void propsgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {
         if (e.NewValues["name"].Equals("new_property"))
         {
            e.Cancel = true;
            gridError("Can't save property with 'new_property' name");
            return;
         }

         try
         {
            AccessControl.acl_property.can_set_name(((AccessControl.AccessManager)Session["access_manager"]).Connection, (int)e.Keys["idx"], e.NewValues["name"].ToString());
         }
         catch (System.Exception ee)
         {
            e.Cancel = true;
            gridError(ee.Message);
         }
      }
      
      protected void groupsgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {
         if (e.NewValues["name"].Equals("new_group"))
         {
            e.Cancel = true;
            gridError("Can't save user with 'new_one' login");
            return;
         }
         try
         {
            AccessControl.acl_group.can_set_name(((AccessControl.AccessManager)Session["access_manager"]).Connection, (int)e.Keys["idx"], e.NewValues["name"].ToString());
         }
         catch (System.Exception ee)
         {
            e.Cancel = true;
            gridError(ee.Message);
         }
      }
      protected void row_Updated(object sender, GridViewUpdatedEventArgs e)
      {
         created_flag=false;
         Session.Remove("created_flag");
      }
      
      protected void row_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
      {
         if(created_flag)
         {
            Session.Remove("created_flag");
            current_ods().DeleteParameters[0].DefaultValue = ((GridView)sender).DataKeys[e.RowIndex].Value.ToString();
            current_ods().Delete();
            ((GridView)sender).DataBind();
            current_ods().DeleteParameters[0].DefaultValue = null;         
         }     
      }
      protected void funcsview_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {
         if (e.NewValues["name"].Equals("new_function"))
         {
            e.Cancel = true;
            gridError("Can't save function with 'new_funciton' name");
            return;
         }
         try
         {
            AccessControl.acl_function.can_set_name(((AccessControl.AccessManager)Session["access_manager"]).Connection, (int)e.Keys["idx"], e.NewValues["name"].ToString());
         }
         catch (System.Exception ee)
         {
            e.Cancel = true;
            gridError(ee.Message);
         }
      }
      protected void users_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         AccessControl.acl_userTableAdapters.base_user_infoTableAdapter inst = (AccessControl.acl_userTableAdapters.base_user_infoTableAdapter)e.ObjectInstance;
         inst.SqlConnection = (System.Data.SqlClient.SqlConnection)access_manager_.Connection;
         
      }
      protected void groups_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         AccessControl.acl_groupTableAdapters.acl_groupTableAdapter inst = (AccessControl.acl_groupTableAdapters.acl_groupTableAdapter)e.ObjectInstance;
         inst.SqlConnection = (System.Data.SqlClient.SqlConnection)access_manager_.Connection;
      }
      protected void funcs_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         AccessControl.acl_functionTableAdapters.acl_functionTableAdapter inst = (AccessControl.acl_functionTableAdapters.acl_functionTableAdapter)e.ObjectInstance;
         inst.SqlConnection = (System.Data.SqlClient.SqlConnection)access_manager_.Connection;
      }

      protected void props_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         AccessControl.acl_propertyTableAdapters.acl_propertyTableAdapter inst = (AccessControl.acl_propertyTableAdapters.acl_propertyTableAdapter)e.ObjectInstance;
         inst.SqlConnection = (System.Data.SqlClient.SqlConnection)access_manager_.Connection;
      }
}
}
