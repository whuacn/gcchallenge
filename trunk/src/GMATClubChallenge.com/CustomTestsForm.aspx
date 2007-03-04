<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="CustomTestsForm.aspx.cs" Inherits="GMATClubTest.Web.CustomTestsForm" Title="Custom tests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   <table border="0" cellpadding="5" cellspacing="1" height="24" width="100%">
      <tr>
         <td style="height: 22px" valign="center">
            <div align="left" class="style6">
               Custom GMAT Tests
            </div>
         </td>
      </tr>
   </table>
   <p>
      One unique feature of GMAT Club's Tests is user input. No, we don't let people randomly
      create test questions, but we do let our members create sequences and combinations
      of questions. You can create tests with only questions that you want - easy, hard,
      or tricky - it is your choice! (Note: You need to have access to ALL tests.)<br />
      <br />
      <asp:SqlDataSource ID="custom_tests" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
         SelectCommand="SELECT * FROM [custom_tests]"></asp:SqlDataSource>
      Filter &nbsp;<asp:TextBox ID="search_str" runat="server" CssClass="itt" OnTextChanged="search_Click"></asp:TextBox>&nbsp;
      <asp:LinkButton ID="search" runat="server" OnClick="search_Click">[Go]</asp:LinkButton>
      &nbsp; |&nbsp;
      <asp:LinkButton ID="create" runat="server" OnClick="create_Click">[Create Custom Test]</asp:LinkButton>
      <asp:GridView ID="view" runat="server" AllowSorting="True" AutoGenerateColumns="False"
         DataKeyNames="Id" DataSourceID="custom_tests" PageSize="25" Width="100%">
         <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
               SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
            <asp:BoundField DataField="questions" HeaderText="questions" SortExpression="questions" />
            <asp:BoundField DataField="created" HeaderText="created" SortExpression="created" />
            <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
         </Columns>
         <HeaderStyle BackColor="#E0E0E0" />
         <AlternatingRowStyle BackColor="Lavender" />
      </asp:GridView>
   </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

