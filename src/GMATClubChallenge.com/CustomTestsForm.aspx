<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="CustomTestsForm.aspx.cs" Inherits="GMATClubTest.Web.CustomTestsForm" Title="Custom tests" %>
<asp:Content ID="Content3" ContentPlaceHolderID="add_js" Runat="Server">
<script type="text/javascript" language="javascript" src="js/rate_it.js"></script>
</asp:Content>

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
         SelectCommand="SELECT * from [custom_tests] WHERE (hidden = 0 OR hidden IS NULL) and (mistakes=0 or mistakes is null)" OnUpdating="custom_tests_Updating" UpdateCommand="update customtests set hidden=@hidden,enabled=@enabled where Test_Id=@Id" DeleteCommand="delete from customtests where Test_Id=@Id; delete from questionsets where id in (select questionsetid from TestContents where testid=@Id); delete from tests where Id=@Id;" >
         <UpdateParameters>
            <asp:Parameter Name="hidden" />
            <asp:Parameter Name="enabled" />
            <asp:Parameter Name="Id" />
         </UpdateParameters>
      </asp:SqlDataSource>
      Filter &nbsp;<asp:TextBox ID="search_str" runat="server" CssClass="itt" OnTextChanged="search_Click"></asp:TextBox>&nbsp;
      <asp:LinkButton ID="search" runat="server" OnClick="search_Click">[Go]</asp:LinkButton>
      &nbsp; |&nbsp;
      <asp:LinkButton ID="create" runat="server" OnClick="create_Click">[Create Custom Test]</asp:LinkButton>
      <asp:GridView ID="view" runat="server" AllowSorting="True" AutoGenerateColumns="False"
         DataKeyNames="Id" DataSourceID="custom_tests" PageSize="25" Width="100%">
         <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
               SortExpression="Id" Visible="False" />
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
               <ItemTemplate>
                  <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Name") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"enabled").Equals((bool)true)?("StartTest.aspx?idx="+DataBinder.Eval(Container.DataItem,"Id")+"&type=test&pkg_idx=-1"):"" %>'></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField  DataField="Description" HeaderText="Description" SortExpression="Description">
            <ItemStyle Width="250" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Rating" SortExpression="rating">
               <ItemTemplate>
               <%# rdrawer.draw((int)DataBinder.Eval(Container.DataItem, "Id"), (int)DataBinder.Eval(Container.DataItem, "rating"))%>
               </ItemTemplate>
               <ItemStyle Width="110" />
            </asp:TemplateField>
            <asp:BoundField DataField="questions" HeaderText="Size" SortExpression="questions" />
            <asp:TemplateField SortExpression="created" HeaderText="Created">
               <ItemTemplate>
                  <asp:Label ID="created" runat="server" Text='<%# ((DateTime)(DataBinder.Eval(Container.DataItem,"created"))).ToShortDateString() %>'  />
               </ItemTemplate>
               <ItemStyle Width="80" />
            </asp:TemplateField>
            
            <asp:BoundField DataField="login" HeaderText="Creator" SortExpression="login" />
         </Columns>
         <HeaderStyle BackColor="#E0E0E0" />
         <AlternatingRowStyle BackColor="Transparent" />
      </asp:GridView>
      
      <asp:GridView Visible="False" ID="adm_view" runat="server" AllowSorting="True" AutoGenerateColumns="False"
         DataKeyNames="Id" DataSourceID="custom_tests" PageSize="25" Width="100%" OnRowUpdating="adm_view_RowUpdating">
         <Columns>
            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
               <ItemTemplate>
                  <asp:Label ID="id_lbl" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
               <ItemTemplate>
                  <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Name") %>' NavigateUrl='<%# "StartTest.aspx?idx="+DataBinder.Eval(Container.DataItem,"Id")+"&type=test&pkg_idx=-1" %>'></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ReadOnly="True">
               <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Rating" SortExpression="rating">
               <ItemTemplate>
                  <%# rdrawer.draw((int)DataBinder.Eval(Container.DataItem, "Id"), (int)DataBinder.Eval(Container.DataItem, "rating"))%>
               </ItemTemplate>
               <ItemStyle Width="110" />
            </asp:TemplateField>
            <asp:BoundField DataField="questions" HeaderText="Size" SortExpression="questions" ReadOnly="True"/>
            <asp:TemplateField SortExpression="created" HeaderText="Created">
               <ItemTemplate>
                  <asp:Label ID="created" runat="server" Text='<%# ((DateTime)(DataBinder.Eval(Container.DataItem,"created"))).ToShortDateString() %>'  />
               </ItemTemplate>
               <ItemStyle Width="80" />
            </asp:TemplateField>
            <asp:BoundField DataField="login" HeaderText="Creator" SortExpression="login" ReadOnly="True"/>
            <asp:CheckBoxField DataField="enabled" HeaderText="Enabled" SortExpression="enabled" />
            <asp:CheckBoxField DataField="hidden" HeaderText="Hidden" SortExpression="hidden" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
         </Columns>
         <HeaderStyle BackColor="#E0E0E0" />
         <AlternatingRowStyle BackColor="Transparent" />
      </asp:GridView>
      
   </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

