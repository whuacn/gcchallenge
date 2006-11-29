<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ResultDetailsWebForm.aspx.cs" Inherits="GMATClubTest.Web.ResultDetailsWebForm" Title="Result Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<asp:label id="statusLabel" runat="server" CssClass="Title"></asp:label>
   <table id="Table4" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr>
         <td align="center">
            <table id="Table6" align="center" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td style="font-weight: bold">
                     Section:</td>
               </tr>
            </table>
            <asp:DataGrid ID="setStutusDataGrid" runat="server" AutoGenerateColumns="False" DataMember="QuestionSets"
               DataSource="<%# questionSetsResultDetailsSet %>" OnSelectedIndexChanged="setStutusDataGrid_SelectedIndexChanged">
               <HeaderStyle Font-Bold="True" />
               <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="Name" HeaderText="Section name"
                     Text="Select"></asp:ButtonColumn>
                  <asp:BoundColumn DataField="Name" HeaderText="Section name" SortExpression="Name"
                     Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Score" HeaderText="Score" SortExpression="Score"></asp:BoundColumn>
               </Columns>
            </asp:DataGrid></td>
      </tr>
   </table>
   <table id="Table2" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr>
         <td align="center">
            <table id="Table7" align="center" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td style="font-weight: bold">
                     Questions:</td>
               </tr>
            </table>
            <asp:Table ID="questionStatusTable" runat="server" GridLines="Both">
            </asp:Table>
         </td>
      </tr>
   </table>
   <table id="Table5" align="center" border="0" cellpadding="1" cellspacing="1">
      <tr>
         <td>
            <asp:ImageButton ID="OkImageButton" runat="server" ImageUrl="images/OkButton.gif" /></td>
      </tr>
   </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

