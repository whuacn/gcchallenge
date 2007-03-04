<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="GMATClubTest.Web.Error" Title="Error description" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   <asp:Label ID="err" runat="server" Font-Bold="True" ForeColor="Red" Text="error"></asp:Label><br />
   <asp:Panel ID="edescr" runat="server" BackColor="#FFFFC0" BorderColor="#FFC080" BorderStyle="Solid"
      BorderWidth="1px" Height="50px" Width="100%">
      <pre><asp:Label ID="strace" runat="server" Text="Label"></asp:Label></pre></asp:Panel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

