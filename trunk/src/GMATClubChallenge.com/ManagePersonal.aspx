<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ManagePersonal.aspx.cs" Inherits="GMATClubTest.Web.ManagePersonal" Title="User profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   &nbsp;
   <asp:HyperLink ID="lTests" runat="server" NavigateUrl="ManagePersonal.aspx?panel=tests">[Active tests]</asp:HyperLink>
   |
   <asp:HyperLink ID="lProfile" runat="server" NavigateUrl="ManagePersonal.aspx?panel=profile">[Profile settings]</asp:HyperLink>
   |
   <asp:HyperLink ID="lResults" runat="server" NavigateUrl="ManagePersonal.aspx?panel=results">[Results]</asp:HyperLink>
   <asp:Panel ID="pTests" runat="server" Height="50px" Width="100%">
      <b>Active tests:</b><asp:GridView ID="gvTests" runat="server" AutoGenerateColumns="False" CellPadding="0" Width="100%">
         <Columns>
            <asp:BoundField DataField="idx" Visible="False"  />
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:Image Width="16" Height="16" ID="Image1" runat="server" ImageUrl='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"expires_at")) < DateTime.Now && ((DateTime)DataBinder.Eval(Container.DataItem,"expires_at"))!=((DateTime)DataBinder.Eval(Container.DataItem,"sold_at")) ?"i/expired.gif":"i/blank.gif" %>'/>
               </ItemTemplate>
               <ItemStyle Width="16"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
               <ItemTemplate>
                  <asp:Image Width="16" Height="16" ID="Image1" runat="server" ImageUrl='<%# ((int)DataBinder.Eval(Container.DataItem,"type")) == 1?"i/package.gif":((int)DataBinder.Eval(Container.DataItem,"type")) == 2?"i/test.gif":"i/pdf.gif" %>'/>
               </ItemTemplate>
               <ItemStyle Width="16" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Name">
               <ItemTemplate>
                 <asp:Label ID="lbl2" runat="server"  Text='<%#((int)DataBinder.Eval(Container.DataItem,"type")) != 1 && ((int)DataBinder.Eval(Container.DataItem,"parent"))!=-1?"&nbsp;":" " %>' />
                 <asp:HyperLink ID="lTests" runat="server" NavigateUrl='<%# build_url(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"name") %>'></asp:HyperLink> 
               </ItemTemplate>
               <ItemStyle Width="40%" />
            </asp:TemplateField>
            <asp:BoundField DataField="sold_at" HeaderText="Sold at" />
            <asp:TemplateField HeaderText="Left">
               <ItemTemplate>
                  <asp:Label ID="lLeft2" runat="server" Text='<%# build_left(Container.DataItem) %>'/>
               </ItemTemplate>
               
            </asp:TemplateField>
            
            
         </Columns>
      </asp:GridView>
      &nbsp;&nbsp;
   </asp:Panel>
   <asp:Panel ID="pProfile" runat="server" Height="50px" Visible="False" Width="100%">
      <strong>Profile:</strong>
      <br />
      Login &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="login" runat="server" CssClass="itt"
         ReadOnly="True"></asp:TextBox>
      <asp:RequiredFieldValidator ID="lgnreq" runat="server" ControlToValidate="login"
         ErrorMessage="Login Required"></asp:RequiredFieldValidator><br />
      Password&nbsp;
      <asp:TextBox ID="pwd" runat="server" CssClass="itt" TextMode="Password"></asp:TextBox>
      <asp:CompareValidator ID="cpr" runat="server" ControlToCompare="pwd_check" ControlToValidate="pwd"
         ErrorMessage="Passwords not equal"></asp:CompareValidator>
      <asp:RequiredFieldValidator ID="pwdreq" runat="server" ControlToValidate="pwd" ErrorMessage="Password can't be empty"></asp:RequiredFieldValidator><br />
      Password&nbsp;
      <asp:TextBox ID="pwd_check" runat="server" CssClass="itt" TextMode="Password"></asp:TextBox>
      again<br />
      <asp:LinkButton ID="chgPwd" runat="server" CausesValidation="False" OnClick="chgPwd_Click">Change password</asp:LinkButton>&nbsp;
      <br />
      <hr style="height: 1px; width:100%" />
      <asp:SqlDataSource id="props" runat="server" SelectCommand="SELECT acl_user_prop_value.idx as prop_idx, acl_property.idx AS template_idx, acl_user_prop_value.user_idx, acl_user_prop_value.value as value, acl_property.name as name, acl_property.human_name as human_name, acl_property.nesses as nesses, acl_property.is_user_editable as is_user_editable, acl_property.is_internal as is_internal &#13;&#10;FROM acl_property LEFT OUTER JOIN acl_user_prop_value ON &#13;&#10;(acl_property.idx = acl_user_prop_value.prop_idx &#13;&#10;AND (acl_user_prop_value.user_idx = @user_idx OR acl_user_prop_value.user_idx IS NULL)&#13;&#10;) &#13;&#10;WHERE (acl_property.is_internal = @is_internal) AND (acl_property.is_user_editable = @is_user_editable) order by acl_property.idx;" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>">
      <SelectParameters>
         <asp:SessionParameter Name="user_idx" SessionField="UserId" Type="Int32" />
         <asp:Parameter DefaultValue="false" Name="is_internal" Type="Boolean" />
         <asp:Parameter DefaultValue="true" Name="is_user_editable" Type="Boolean" />
      </SelectParameters>
   </asp:SqlDataSource><asp:GridView id="propsview" runat="server" CaptionAlign="Left" Caption="Other user info" DataSourceID="props" DataKeyNames="name" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField HeaderText="name" SortExpression="name" Visible="False">
               <ItemTemplate>
                  <asp:Label ID="name" runat="server" Text='<%# Bind("name") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="idx" SortExpression="idx" Visible="False">
               <ItemTemplate>
                  <asp:Label ID="lblidx" runat="server" Text='<%# Bind("prop_idx") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="human_name" HeaderText="Property" SortExpression="idx">
               <ItemStyle CssClass="itt" Width="200px"  />
            </asp:BoundField>
            
            <asp:CheckBoxField DataField="nesses" HeaderText="nesses" SortExpression="nesses"
               Visible="False" ></asp:CheckBoxField>
               
            <asp:TemplateField HeaderText="Value" SortExpression="idx">
               <ItemStyle CssClass="itt" Width="200px"  />
               <ItemTemplate>
                  <asp:TextBox Width="200px" CssClass="itt" ID="value_box" runat="server" Text='<%# Bind("value") %>'></asp:TextBox>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>      
      <br />
      &nbsp;<asp:LinkButton ID="save" runat="server" OnClick="save_Click" CausesValidation="False">Save changes</asp:LinkButton></asp:Panel>
   <asp:Panel ID="pResults" runat="server" Height="50px" Visible="False" Width="100%">
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
         <td align="left" style="height: 239px">
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
   
   </asp:Panel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

