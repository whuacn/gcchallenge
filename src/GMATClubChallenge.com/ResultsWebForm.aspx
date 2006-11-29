<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ResultsWebForm.aspx.cs" Inherits="GMATClubTest.Web.ResultsWebForm" Title="Test results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   <table width="100%">
   <tr>
   <td valign="top">
   <table id="Table2" border="0" cellpadding="1" cellspacing="1" width="100%">
      <tr>
         <td >
            <table id="Table6" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td><b>Results:</b></td>
               </tr>
            </table>
            <asp:DataGrid ID="resultsGrid" runat="server" AutoGenerateColumns="False" DataMember="Results"
               DataSource="<%# resultsSet %>" OnSelectedIndexChanged="resultsGrid_SelectedIndexChanged" GridLines="Horizontal" Width="100%">
               <HeaderStyle Font-Bold="True" />
               <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="TestName" HeaderText="Test name"
                     Text="Test name"></asp:ButtonColumn>
                  <asp:BoundColumn DataField="TestName" HeaderText="Test name" ReadOnly="True" SortExpression="TestName"
                     Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="StartTime" DataFormatString="{0:g}" HeaderText="Start time"
                     ReadOnly="True" SortExpression="StartTime"></asp:BoundColumn>
                  <asp:BoundColumn DataField="EndTime" DataFormatString="{0:g}" HeaderText="End time"
                     ReadOnly="True" SortExpression="EndTime"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Score" HeaderText="Score" ReadOnly="True" SortExpression="Score">
                  </asp:BoundColumn>
                  <asp:TemplateColumn></asp:TemplateColumn>
                  <asp:BoundColumn DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False">
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="UserId" HeaderText="UserId" SortExpression="UserId" Visible="False">
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="TestId" HeaderText="TestId" SortExpression="TestId" Visible="False">
                  </asp:BoundColumn>
               </Columns>
               <AlternatingItemStyle BackColor="#E0E0E0" />
            </asp:DataGrid>
         </td>
      </tr>
   </table>
   </td>
   <td width="250">
   
   <table id="Table4" align="left" border="0" cellpadding="1" cellspacing="1" style="background-color:#eeeeee;">
      <tr>
         <td>
            <table id="Table7" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td><b>From</b></td>
               </tr>
            </table>
            <asp:Calendar ID="beginCalendar" runat="server" OnSelectionChanged="beginCalendar_SelectionChanged"
               ShowGridLines="True" Width="232px"></asp:Calendar>
         </td>
      </tr>
      <tr>
         <td align="center" style="height: 239px">
            <table id="Table8" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td><b>To</b></td>
               </tr>
            </table>
            <asp:Calendar ID="endCalendar" runat="server" EnableTheming="True" FirstDayOfWeek="Monday"
               OnSelectionChanged="endCalendar_SelectionChanged" ShowGridLines="True" Width="232px">
            </asp:Calendar>
         </td>
      </tr>
   </table>
   </td></tr>
   </table>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

