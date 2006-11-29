<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="Tests.aspx.cs" Inherits="GMATClubTest.Web.Tests" Title="Tests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   &nbsp;
   <asp:DataList ID="list" runat="server" CellPadding="0" DataKeyField="idx" DataSourceID="data"
      ForeColor="#333333" GridLines="Horizontal" RepeatColumns="3" RepeatDirection="Horizontal"
      ShowHeader="False" Width="100%">
      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      <ItemTemplate > 
      <div style="vertical-align:top; height: 300px;">
      <table width="100%" border="0" cellpadding="0" cellspacing="3" >
      <tr style="background-color: #B7C6FF; height: 24px; "><td><b><asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>'></asp:Label></b><br /></td></tr>
      <tr><td> <asp:Label ID="Label1" runat="server" Text='<%# show_contents( Eval("idx"),Eval("descr")) %>'></asp:Label><br /> </td></tr>
      </table>
      </div>
      <div style="vertical-align:bottom">
      <table width="100%" border="0" cellpadding="0" cellspacing="3">
      <tr><td style="border-top: 1px solid #444444; font-size: 8pt;"><asp:Label ID="descrLabel" runat="server" Text=''><%# show_descr( Eval("descr") , 1 )%></asp:Label><br /></td></tr>
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
   &nbsp;&nbsp;
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

