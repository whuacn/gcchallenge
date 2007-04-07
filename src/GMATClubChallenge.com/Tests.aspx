<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="Tests.aspx.cs" Inherits="GMATClubTest.Web.Tests" Title="Tests" %>
<asp:Content ID="Content3" ContentPlaceHolderID="add_js" Runat="Server">
<script type="text/javascript" language="javascript" src="js/rate_it.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<script type="text/javascript">
function on_shop_item_click(idx,type,pkg)
{
   exec_http_req("ShopManager::item_click", Array("idx",idx,"type",type,"pkg_idx",pkg),function (error,http) 
   { 
      if(error)
      {
         if(error.indexOf("Access denied")!=-1)
         {
            alert("You must login first...");
         }
         else
         {
            alert(error);
         };
         
      }
      else
      {
         var t=http.responseText;
         var aj=false;
         if(t.lastIndexOf("ajax:")==0)
         {
            t=http.responseText.substr(5);
            aj=true;
         }
         var iof=window.location.pathname.lastIndexOf("/",window.location.pathname.length);
         
         var npn=window.location.pathname.substr(0,iof+1)+t;
         
         
         if(false==aj)
         {
            window.location.pathname=npn;
         }
         else
         {
            http.open("GET", t, true);
            http.setRequestHeader("If-Modified-Since", "Sat, 1 Jan 2000 00:00:00 GMT");
            http.onreadystatechange = function()
            {      
               if(http.readyState == 4) 
               {
                  show_data(http.responseText);      
                  show_ajax_window(0);
               }
            }
            http.send(null);  
         }
      }
   });   
}
</script>
   <asp:DataList ID="list" runat="server" CellPadding="0" DataKeyField="idx" DataSourceID="data"
      ForeColor="#333333" GridLines="Horizontal" RepeatColumns="3" RepeatDirection="Horizontal"
      ShowHeader="False" Width="100%">
      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      <ItemTemplate > 
      <div style="vertical-align:top; height: 300px;">
      <table width="100%" border="0" cellpadding="0" cellspacing="3" >
      <tr style="background-color: #B7C6FF; height: 24px; "><td><b>
         <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>'></asp:Label></b><br /></td></tr>
      <tr><td> <asp:Label ID="Label1" runat="server" Text='<%# show_contents( Eval("idx"),Eval("descr")) %>'></asp:Label><br /> </td></tr>
      </table>
      </div>
      <div style="vertical-align:bottom">
      <table width="100%" border="0" cellpadding="0" cellspacing="3">
      <tr><td style="border-top: 1px solid #444444; font-size: 8pt;"><asp:Label ID="descrLabel" runat="server" Text='' CssClass='i_descr'><%# show_descr( Eval("descr") , 1 )%></asp:Label><br /></td></tr>
      </table>
      </div>
      </ItemTemplate>
      <AlternatingItemStyle BackColor="White" />
      <ItemStyle BackColor="#EFF3FB" HorizontalAlign="Left" Width="33%" VerticalAlign="Top" />
      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
   </asp:DataList>
   <asp:SqlDataSource ID="data" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
      SelectCommand="SELECT [name], [idx], [guididx], [descr], [rdr] FROM [shop_item] where rdr!=-1 ORDER BY [rdr]">
   </asp:SqlDataSource>
   &nbsp;&nbsp;&nbsp;&nbsp;
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
      <div style="width:500px; visibility:hidden; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;" id="cnt" >
         <img id='close_id' style='cursor: pointer; border: none; 0pt;' src='i/x.gif' height='15' width='15' alt='Close' onclick="javascript: document.getElementById('cnt').style.visibility='hidden'; return false;"/>
         <div id="c_place" style="border: none; 2px; "></div>
         <div id="op_e_place" style="border: none; 2px;  color: red;"></div>
    </div>
</asp:Content>

