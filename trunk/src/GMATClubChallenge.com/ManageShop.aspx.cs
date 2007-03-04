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
using Shop;
namespace GMATClubTest.Web
{
   public partial class ManageShop : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender,e);
      }
     
      public override void DoLoad(object sender, EventArgs e)
      {
         if (null != Session["created_flag"]) created_flag = ((Boolean)Session["created_flag"]);
         usersgrid.PageSize = 90;
         errorText.Visible = false;
         curpanel=Request["panel"];
         if(null==curpanel || ""==curpanel)
         {
            curpanel="items";
         }
         curpanel_idx=getPanelIdx(curpanel);
         switchPanel();
         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("Shop manager - " + annotation(curpanel));
         
         if(!IsPostBack)
         {
            if(null!=Request["q"]) 
            {
               filter.Text=Request["q"];
            }
         }
         if (filter.Text == "")
         {
            statDso.SelectCommand = "SELECT * FROM [sold_items]";
         }
         else
         {
            statDso.SelectCommand = String.Format("SELECT * FROM [sold_items] where name like '%{0}%' or login like '%{0}%';", Request["q"]);
         }
      }

      public string annotation(string name)
      {
         if ("items" == name) return "items";
         if ("pdfs" == name) return "downloads";
         if ("stats" == name) return "statistic";
         if ("baskets" == name) return "baskets";
         return "?";
      }
      public override string current_function_name()
      {
         return Request["panel"] != null ? "manageshop_" + Request["panel"].ToString() : "manageshop_items";
      }
      
      protected int getPanelIdx(string name)
      {
         if( "items" == name) return 0;
         if ("pdfs" == name) return 1;
         if ("stats" == name) return 2;
         if ("baskets" == name) return 3;

         return 0;
      }
      
      protected void switchPanel()
      {
         items.Visible=false;
         baskets.Visible=false;
         stats.Visible=false;
         pdfs.Visible = false;
         current_panel().Visible=true;
      }

      System.Web.UI.WebControls.ObjectDataSource current_ods()
      {
         switch (curpanel_idx)
         {
         case 0:
            return itemsDso;
         case 1:
            return pdfsDso;
         case 2:
            return null;
         default:
            return itemsDso;
         }
      }

      System.Web.UI.WebControls.Panel current_panel()
      {
         switch(curpanel_idx)
         {
            case 0:
               return items;
            case 1:
               return pdfs;
            case 2:
               return stats;                                             
            case 3:
               return baskets;                              
            default:
               return items;  
         }
      }  
      System.Web.UI.WebControls.GridView current_grid()
      {
         switch (curpanel_idx)
         {
            case 0:
               return itemsGv;
            case 1:
               return pdfsGv;
            case 2:
               return usersgrid;
            case 3:
               return statGv;
            default:
               return itemsGv;
         }
      }

      protected void row_Updated(object sender, GridViewUpdatedEventArgs e)
      {
         created_flag = false;
         Session.Remove("created_flag");
      }

      protected void new_object_Click(object sender, EventArgs e)
      {
         
         try
         {
            Session["created_flag"] = true;
            System.Web.UI.WebControls.ObjectDataSource ods = current_ods();
            if(null==ods) return;
            System.Web.UI.WebControls.GridView gv = current_grid();
            if (null==gv) return;
            if (null==ods) return;
            ods.SelectMethod = "GetData";
            ods.SelectParameters.Clear();
            int i = ods.Insert();
            gv.EditIndex = gv.Rows.Count;
            this.DataBind();
         }
         catch(System.Exception ee)
         {
            errorText.Text=ee.InnerException!=null?ee.InnerException.Message:ee.Message;
            errorText.Visible=true;
         }
      }

      protected void row_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
      {
         if (created_flag)
         {
            created_flag = false;
            Session.Remove("created_flag");
            current_ods().DeleteParameters[0].DefaultValue = ((GridView)sender).DataKeys[e.RowIndex].Value.ToString();
            current_ods().Delete();
            ((GridView)sender).DataBind();
            current_ods().DeleteParameters[0].DefaultValue = null;
         }
      }
      
      
      protected string curpanel;
      protected int curpanel_idx;
      protected Boolean created_flag = false;
      
      protected void groupsDso_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters["name"]="new_group";
      }
      protected void itemsDso_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters["guididx"] = System.Guid.NewGuid().ToString();
         e.InputParameters["name"]="new_type";
      }
      protected void pdfsDso_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
      {
         e.InputParameters["name"] = "new_type";
      }

      protected void itemsGv_RowUpdating(object sender, GridViewUpdateEventArgs e)
      {
         if(e.NewValues["limit"]==null)
         {
            e.NewValues["limit"]="0";
         }
         if (e.NewValues["expires_after"] == null)
         {
            e.NewValues["expires_after"] = "0";
         }
         if (e.NewValues["item_price"] == null)
         {
            e.NewValues["item_price"] = "0";
         }
         if (e.NewValues["full_price"] == null)
         {
            e.NewValues["full_price"] = "0";
         }
         if (e.NewValues["full_price"] == null)
         {
            e.NewValues["full_price"] = "0";
         }
         if(e.NewValues["name"].Equals("new_type"))
         {
            errorText.Text = "Please provide apropriate name for row"; errorText.Visible = true;
            e.Cancel=true;         
         } 
      }
      protected void itemsDso_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         Shop.shop_itemTableAdapters.shop_itemTableAdapter inst = (Shop.shop_itemTableAdapters.shop_itemTableAdapter)e.ObjectInstance;
         inst.SqlConnection = connection_;
      }
      protected void groupsDso_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         Shop.shop_item_groupTableAdapters.shop_item_groupTableAdapter inst = (Shop.shop_item_groupTableAdapters.shop_item_groupTableAdapter)e.ObjectInstance;
         inst.SqlConnection = connection_;
      }
      protected void pdfsDso_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         Shop.pdf_downloadTableAdapters.pdf_downloadTableAdapter inst = (Shop.pdf_downloadTableAdapters.pdf_downloadTableAdapter)e.ObjectInstance;
         inst.SqlConnection = connection_;
      }
      protected void row_Updated(object sender, ObjectDataSourceStatusEventArgs e)
      {

      }
      protected void dso_Updated(object sender, ObjectDataSourceStatusEventArgs e)
      {
         if (null != e.Exception)
         {
            errorText.Visible = true;
            errorText.Text = e.Exception.InnerException.Message.IndexOf("IX_shop_item_name") != -1 ? "Duplicate name provided" : e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
         }
      }
      protected void filter_button_Click(object sender, EventArgs e)
      {
         Response.Redirect("ManageShop.aspx?panel=stats&q="+filter.Text);
      }
}
}
