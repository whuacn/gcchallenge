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

namespace GMATClubTest.Web
{
   public partial class CustomTestsForm : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      
         base.Page_Load(sender,e);
         if(access_manager_.UserMainRole=="admins")
         {
            view.Visible=false;
            adm_view.Visible=true;
            custom_tests.SelectCommand = "select * from [custom_tests]  where (mistakes=0 or mistakes is null) ";
         }
         if(!IsPostBack)
         {
            if(null!=Request["q"] && ""!=Request["q"])
            {
               search_str.Text = Request["q"];

               custom_tests.SelectCommand = 
               String.Format("select * from [custom_tests] where (name like '%{0}%' or description like '%{0}%')", Request["q"]);
               if (access_manager_.UserMainRole != "admins")
               {
                  custom_tests.SelectCommand+=" and ( hidden=0 or hidden is null ) and (mistakes=0 or mistakes is null) ";   
               }
            }
            else
            {
               search_str.Text ="";
               custom_tests.SelectCommand = "select * from [custom_tests]   where (mistakes=0 or mistakes is null) ";
               if (access_manager_.UserMainRole != "admins")
               {
                  custom_tests.SelectCommand += " select * from [custom_tests]  where ( hidden=0 or hidden is null ) and (mistakes=0 or mistakes is null);";   
               }
            }
         }
         if (!IsPostBack) this.DataBind();   
         
      }

      public override void DoLoad(object sender, EventArgs e)
      {
         
      }
      protected void search_Click(object sender, EventArgs e)
      {
         Response.Redirect("CustomTestsForm.aspx?q="+search_str.Text);
      }
      protected void create_Click(object sender, EventArgs e)
      {
         Response.Redirect("CreateCustomTest.aspx");
      }
      protected void adm_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {
         //update_idx = Int32.Parse(((Label)(adm_view.Rows[e.RowIndex].Cells[0].FindControl("id_lbl"))).Text);
         /*((GridView)sender).EditIndex=-1;     
         int idx=
         GmatClubTest.BusinessLogic.CustomTestsLogic.set_test_flags(connection_, idx, (bool)e.NewValues["enabled"], (bool)e.NewValues["hidden"]);*/
      }
      protected void custom_tests_Updating(object sender, SqlDataSourceCommandEventArgs e)
      {
      //custom_tests.UpdateParameters["Id"]=e.
         //e.Command.Parameters["@Id"].Value=update_idx;
      }
      protected int update_idx=-1;
      protected static RatingDrawer rdrawer=new RatingDrawer(true);
}
}
/*

               <table cellpadding='0' cellspacing='0' border='0'>
               <tr>
               <td width='80'><img runat='server' width='80' height='16' ID='i_rate'  onclick='javascript: handle_rate_click(this);' alt='<%# Bind('Id') %>' onmouseout='javascript: handle_rate_out(this);' onmousemove='javascript: handle_rate_move(this);' style='cursor: pointer;' src='<%# 'Rating.aspx?r='+DataBinder.Eval(Container.DataItem,'rating') %>'/></td>
               <td align='right' width='60' style='font-family: Verdana; font-size: 9px;'><div runat='server' ID='i_rate_div' style='display:inline; text-align: right;' >&nbsp;</div></td>
               </tr>                  
               </table>                  
*/
/*
 
               <table cellpadding="0" cellspacing="0" border="0">
               <tr>
               <td width="80"><img runat="server" width="80" height="16" ID="i_rate"  onclick='javascript: handle_rate_click(this);' alt='<%# Bind("Id") %>' onmouseout="javascript: handle_rate_out(this);" onmousemove="javascript: handle_rate_move(this);" style="cursor: pointer;" src='<%# "Rating.aspx?r="+DataBinder.Eval(Container.DataItem,"rating") %>'/></td>
               <td align="right" width="60" style="font-family: Verdana; font-size: 9px;"><div runat="server" ID="i_rate_div" style="display:inline; text-align: right;" >&nbsp;</div></td>
               </tr>                  
               </table>                  
*/