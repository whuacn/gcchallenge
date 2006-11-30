<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="RegisterNewUser.aspx.cs" Inherits="GMATClubTest.Web.RegisterNewUser" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   <asp:SqlDataSource ID="props" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
      SelectCommand="SELECT [idx], [name], [human_name], [nesses], [is_user_editable], [is_internal] FROM [acl_property] WHERE (([is_internal] = @is_internal) AND ([is_user_editable] = @is_user_editable))">
      <SelectParameters>
         <asp:Parameter DefaultValue="false" Name="is_internal" Type="Boolean" />
         <asp:Parameter DefaultValue="true" Name="is_user_editable" Type="Boolean" />
      </SelectParameters>
   </asp:SqlDataSource>
   <asp:Label ID="errorLabel" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"
      Visible="False"></asp:Label><br />
   Login &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="login" runat="server" CssClass="itt"></asp:TextBox>
   <asp:HyperLink ID="chl" runat="server" CssClass="itt" NavigateUrl="javascript: do_check_login();">Check login</asp:HyperLink><br />
   Password&nbsp;
   <asp:TextBox ID="pwd" runat="server" CssClass="itt" TextMode="Password"></asp:TextBox><br />
   &nbsp;
   &nbsp;&nbsp;
   
   <asp:Panel ID="Panel1" runat="server" Height="50px" Width="631px">
   
      <asp:GridView ID="propsview" runat="server" AutoGenerateColumns="False" DataKeyNames="idx"
         DataSourceID="props" Caption="Other user info" CaptionAlign="Left">
         <Columns>
            <asp:TemplateField HeaderText="idx" InsertVisible="False" SortExpression="idx" Visible="False">
               <ItemTemplate>
                  <asp:Label ID="idxlbl" runat="server" Text='<%# Bind("idx") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" Visible="False">
               <ItemStyle CssClass="itt" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="human_name" HeaderText="Property" SortExpression="idx">
               <ItemStyle CssClass="itt" Width="200px" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="nesses" HeaderText="nesses" SortExpression="nesses"
               Visible="False" />
            <asp:TemplateField HeaderText="Value" SortExpression="idx">
               <ItemStyle CssClass="itt" Width="200px" />
               <ItemTemplate>
                  <asp:TextBox Width="200px" CssClass="itt" ID="value_box" runat="server" Text='<%# Bind("human_name") %>'></asp:TextBox>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>
      <br />
      <br />
      
      <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
      <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Text="Cancel" /></asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
<script language="javascript">

       function do_check_login()
       {
         var ar=new Array();
         ar.push("login");
         ar.push(document.getElementById("_ctl0_content_login").value);
         exec_http_req(
                        "UserManager::check_login",
                        ar,
                        function (error,http) { on_response(error,http,1); } );
       };

</script>
      <div style="width:500px; visibility:hidden; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;" id="cnt" >
         <img id='close_id' style='cursor: pointer; border: none; 0pt;' src='i/x.gif' height='15' width='15' alt='Close' onclick="javascript: document.getElementById('cnt').style.visibility='hidden'; return false;"/>
         <div id="c_place" style="border: none; 2px; "></div>
         <div id="op_e_place" style="border: none; 2px;  color: red;"></div>
    </div>

</asp:Content>

