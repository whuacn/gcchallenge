<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ResultDetailsWebForm.aspx.cs" Inherits="GMATClubTest.Web.ResultDetailsWebForm" Title="Result Details" %>
<asp:Content ID="Content3" ContentPlaceHolderID="add_js" Runat="Server">
<script type="text/javascript" language="javascript" src="js/rate_it.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   
   <asp:HyperLink ID="lMain" runat="server" NavigateUrl="ManagePersonal.aspx?panel=main">[Main]</asp:HyperLink>
   |
   <asp:HyperLink ID="lTests" runat="server" NavigateUrl="ManagePersonal.aspx?panel=tests">[Active tests]</asp:HyperLink>
   |
   <asp:HyperLink ID="lProfile" runat="server" NavigateUrl="ManagePersonal.aspx?panel=profile">[Profile settings]</asp:HyperLink>
   |
   <asp:HyperLink ID="lResults" runat="server" NavigateUrl="ManagePersonal.aspx?panel=results">[Results]</asp:HyperLink>&nbsp;
<br />   
<br />
<table cellpadding="0" cellspacing="0" border="0"><tr><td><b>Rate it:</b></td><td><%=testRater %></td></tr></table>
<br />
<table border="0" cellspacing="0" width="100%">
<tr>
<td width="200" valign="top">
            <asp:DataGrid ID="setStutusDataGrid" runat="server" AutoGenerateColumns="False" DataMember="QuestionSets"
               DataSource="<%# questionSetsResultDetailsSet %>" OnSelectedIndexChanged="setStutusDataGrid_SelectedIndexChanged" Width="100%" GridLines="None">
               <HeaderStyle Font-Bold="True" />
               <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="Name" HeaderText="Section name"
                     Text="Select"></asp:ButtonColumn>
                  <asp:BoundColumn DataField="Name" HeaderText="Section name" SortExpression="Name"
                     Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Score" HeaderText="Score" SortExpression="Score"></asp:BoundColumn>
               </Columns>
               <AlternatingItemStyle BackColor="AliceBlue" />
            </asp:DataGrid></td>
<td valign="top" align="left">
<asp:Table ID="questionStatusTable" runat="server" Width="100%" CellPadding="0" CellSpacing="0"></asp:Table>


</td>           
</tr>
</table>
<table width="100%" border="0">
   <tr><td><b>Result annotation</b></td><td width="100">&nbsp;</td></tr>
   <tr><td align="left">
      <asp:TextBox ID="ann_TextBox" runat="server" TextMode="MultiLine" Width="642px" Height="86px" ></asp:TextBox>
      </td>
      <td>&nbsp;</td>
   </tr>
   <tr>
   <td align="right" style="height: 30px"><br /><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">[Save annotation]</asp:LinkButton></td><td style="height: 30px">&nbsp;</td>
   </tr>
   
</table>
   <br />
   
   <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

