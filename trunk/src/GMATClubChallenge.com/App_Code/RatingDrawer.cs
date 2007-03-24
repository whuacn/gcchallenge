using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for RatingDrawer
/// </summary>
namespace GMATClubTest.Web
{
   public class RatingDrawer
   {
      public RatingDrawer(bool showp)
      {
         shp=showp;
      }
      public string draw(int Id,int rating)
      {
         
         return String.Format(
         @"
         <table cellpadding='0' cellspacing='0' border='0' width='100%'>
         <tr><td width='80'>
         <img width='80' height='16' alt='{0}' ID='i_rate_{0}'  
         onclick='javascript: handle_rate_click(this);' 
         onmouseout='javascript: handle_rate_out(this);' 
         onmousemove='javascript: handle_rate_move(this,{2});' 
         style='cursor: pointer;' src='i/stars/stars{1}.gif'/></td>
         <td align='right' width='30' style='font-family: Verdana; font-size: 9px;'>
         <div ID='i_rate_{0}_div' style='display:inline; text-align: right;' >&nbsp;</div></td>
         </tr>                  
         </table>"
         ,Id,(int)(rating+9)/10,shp?1:0);
         //Rating.aspx?r={1}
      }
      protected bool shp;
   }
}