<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="StartTest.aspx.cs" Inherits="GMATClubTest.Web.StartTest" Title="Starting Test..." %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   <asp:Panel ID="resources" runat="server" Height="50px" Width="100%" Visible="False">
      <%=description%><hr style="height:1px" />
      <%=resourcelist%></asp:Panel>
   <asp:Panel ID="denied" runat="server" Font-Bold="True" ForeColor="Red" Height="50px"
      Visible="False" Width="100%">
      Access denied!
      <asp:Label ID="deniedLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
      </asp:Panel>
   <asp:Panel ID="pPayAgain" runat="server" Height="50px" Width="100%" Visible="False">
   <hr style="height:1px" width="100%"/>
      &nbsp;
      <asp:LinkButton ID="lbPayAgain" runat="server" OnClick="lbPayAgain_Click">Buy more </asp:LinkButton></asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

