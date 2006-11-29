<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ManageAccessControl.aspx.cs" Inherits="GMATClubTest.Web.ManageAccessControl" Title="Manage Access" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">

    <table border="0"><tr><td valign="top"><asp:LinkButton ID="new_object" runat="server" OnClick="new_object_Click">[New user]</asp:LinkButton>
          | <asp:TextBox OnTextChanged="searchStr_TextChanged" id="searchStr" runat="server" style="font-size: 8pt; font-family: Verdana; border: 1px solid black;"></asp:TextBox> | <asp:LinkButton id="findItem" runat="server" OnClick="findItem_Click">[Apply filter]</asp:LinkButton>  | <asp:LinkButton id="LinkButton3" runat="server" OnClick="clearFilter_Click">[Clear filter]</asp:LinkButton>
<hr width="100%" style="height: 1px;"/>                    
          </td></tr></table>

<table width="100%" border="0">
<tr><td style="height: 18px">
   <asp:HyperLink ID="m_users" runat="server" NavigateUrl="ManageAccessControl.aspx?panel=users">[Users]</asp:HyperLink>
   |
   <asp:HyperLink ID="m_groups" runat="server" NavigateUrl="ManageAccessControl.aspx?panel=groups">[Groups]</asp:HyperLink>
   |
   <asp:HyperLink ID="m_functions" runat="server" NavigateUrl="ManageAccessControl.aspx?panel=functions">[Functions]</asp:HyperLink>
   |
   <asp:HyperLink ID="m_prop" runat="server" NavigateUrl="ManageAccessControl.aspx?panel=properties">[Properties]</asp:HyperLink>   
   <hr width="100%" style="height: 1px;"/>
   <asp:Panel ID="grid_error_panel" runat="server" Height="20px" Visible="False" Width="100%">
      <asp:Label ID="grid_error_label" runat="server" ForeColor="Red"></asp:Label></asp:Panel>
<tr><td>

<div id="users" style="display: <% =panel_styles[0] %> ;">
       <asp:ObjectDataSource ID="users" runat="server" OldValuesParameterFormatString="original_{0}" OnInserting="users_Inserting"
          SelectMethod="GetData" TypeName="AccessControl.acl_userTableAdapters.base_user_infoTableAdapter" InsertMethod="InsertUserAdv" DeleteMethod="DeleteUser" UpdateMethod="UpdateUserAdv" OnObjectCreated="users_ObjectCreated">
          <InsertParameters>
             <asp:Parameter Name="guididx" Type="String" />
             <asp:Parameter Name="login" Type="String" />
             <asp:Parameter Name="pwd" Type="String" />
             <asp:Parameter Name="first_name" Type="String" />
             <asp:Parameter Name="last_name" Type="String" />
             <asp:Parameter Name="email" Type="String" />
          </InsertParameters>
          <DeleteParameters>
             <asp:Parameter Name="original_idx" Type="Int32" />
          </DeleteParameters>
          <UpdateParameters>
             <asp:Parameter Name="login" Type="String" />
             <asp:Parameter Name="first_name" Type="String" />
             <asp:Parameter Name="last_name" Type="String" />
             <asp:Parameter Name="email" Type="String" />
             <asp:Parameter Name="Original_idx" Type="Int32" />
          </UpdateParameters>
       </asp:ObjectDataSource>
       <asp:GridView ID="usersgrid" runat="server" AutoGenerateColumns="False" DataKeyNames="idx"  DataSourceID="users" AllowPaging="True" AllowSorting="True" CaptionAlign="Left" PageSize="20" EditRowStyle-BackColor="AliceBlue" OnRowUpdating="usersgrid_RowUpdating" OnRowCancelingEdit="row_RowCancelingEdit" OnRowUpdated="row_Updated" Width="100%">
          <Columns>
             <asp:CommandField ShowEditButton="True" />
             <asp:CommandField ShowDeleteButton="True" />
             <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
                SortExpression="idx" Visible="False" />
             <asp:BoundField DataField="guididx" HeaderText="guididx" SortExpression="guididx"
                Visible="False" />
             <asp:TemplateField HeaderText="login" SortExpression="login">
                <EditItemTemplate>
                   <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("login") %>'></asp:TextBox>
                </EditItemTemplate>
                <ControlStyle CssClass="itt" />
                <ItemStyle Width="120px" />
                <ItemTemplate>
                  <asp:HyperLink ID="lnk" runat="server" NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"UserManager::show_user_info_\", Array(\"guididx\",\""+Eval("guididx") +"\"),function (error,http) { on_response(error,http,1); } );"%>' Text='<%# Bind("login") %>'></asp:HyperLink>
                </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" >
                <ControlStyle CssClass="itt" />
                <ItemStyle Width="120px" />
             </asp:BoundField>
             <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" >
                <ControlStyle CssClass="itt" />
                <ItemStyle Width="120px" />
             </asp:BoundField>
             <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" >
                <ControlStyle CssClass="itt" />
                <ItemStyle Width="100px" />
             </asp:BoundField>
             <asp:TemplateField HeaderText="[]">
             <ItemTemplate>
                <asp:HyperLink ID="rst" runat="server" NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"UserManager::reset_pwd\", Array(\"guididx\",\""+Eval("guididx") +"\"),on_response);"%>' Text="Reset pwd"></asp:HyperLink>
             </ItemTemplate>
             </asp:TemplateField>
          </Columns>
          <RowStyle Height="18px" BorderStyle="Inset" />
          <EditRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" BackColor="AliceBlue" />
       </asp:GridView>
</div> <!--users end-->



<div id="groups" style="display: <% =panel_styles[1] %> ;">
<asp:ObjectDataSource ID="groups" runat="server" DeleteMethod="DeleteGroup" InsertMethod="InsertGroup" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="AccessControl.acl_groupTableAdapters.acl_groupTableAdapter" UpdateMethod="UpdateGroup" OnInserting="groups_Inserting" OnObjectCreated="groups_ObjectCreated">
   <DeleteParameters>
      <asp:Parameter Name="Original_idx" Type="Int32" />
   </DeleteParameters>
   <UpdateParameters>
      <asp:Parameter Name="grouplevel" Type="Int32" />
      <asp:Parameter Name="name" Type="String" />
      <asp:Parameter Name="descr" Type="String" />
      <asp:Parameter Name="Original_idx" Type="Int32" />
   </UpdateParameters>
   <InsertParameters>
      <asp:Parameter Name="guididx" Type="String" />
      <asp:Parameter Name="grouplevel" Type="Int32" />
      <asp:Parameter Name="name" Type="String" />
      <asp:Parameter Name="descr" Type="String" />
   </InsertParameters>
</asp:ObjectDataSource>
   <asp:GridView ID="groupsgrid" runat="server" AutoGenerateColumns="False" DataKeyNames="idx"
      DataSourceID="groups" AllowPaging="True" AllowSorting="True" OnRowUpdating="groupsgrid_RowUpdating" PageSize="20" OnRowCancelingEdit="row_RowCancelingEdit" OnRowUpdated="row_Updated" Width="100%">
      <Columns>
         <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
         <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
            SortExpression="idx" Visible="False" />
         <asp:BoundField DataField="guididx" HeaderText="guididx" SortExpression="guididx" ReadOnly="True" Visible="False" />
         <asp:TemplateField HeaderText="name" SortExpression="name">
            <EditItemTemplate>
               <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
            </EditItemTemplate>
            <ControlStyle CssClass="itt" Width="200px" />
            <ItemStyle Width="200px" />
            <ItemTemplate>
               <asp:HyperLink ID="lnk" runat="server" NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"UserManager::show_group_info_\", Array(\"guididx\",\""+Eval("guididx") +"\"),function (error,http) { on_response(error,http,1); } );"%>' Text='<%# Bind("name") %>'></asp:HyperLink>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:BoundField DataField="grouplevel" HeaderText="grouplevel" SortExpression="grouplevel" >
            <ControlStyle CssClass="itt" />
         </asp:BoundField>
         <asp:BoundField DataField="descr" HeaderText="descr" SortExpression="descr" >
            <ControlStyle CssClass="itt" Width="400px" />
            <ItemStyle Width="400px" />
         </asp:BoundField>
      </Columns>
      <RowStyle Height="18px" />
      <EditRowStyle BackColor="AliceBlue" />
   </asp:GridView>
</div><!--groups end-->
<div id="funcs" style="display: <% =panel_styles[2] %> ;">
   <asp:ObjectDataSource ID="funcs" runat="server" DeleteMethod="DeleteFunction" InsertMethod="InsertFunction"
      OldValuesParameterFormatString="original_{0}" OnInserting="funcs_Inserting" SelectMethod="GetData"
      TypeName="AccessControl.acl_functionTableAdapters.acl_functionTableAdapter" UpdateMethod="UpdateFunction" OnObjectCreated="funcs_ObjectCreated">
      <DeleteParameters>
         <asp:Parameter Name="Original_idx" Type="Int32" />
      </DeleteParameters>
      <UpdateParameters>
         <asp:Parameter Name="descr" Type="String" />
         <asp:Parameter Name="name" Type="String" />
         <asp:Parameter Name="Original_idx" Type="Int32" />
      </UpdateParameters>
      <InsertParameters>
         <asp:Parameter Name="name" Type="String" />
         <asp:Parameter Name="descr" Type="String" />
      </InsertParameters>
   </asp:ObjectDataSource>
   <asp:GridView ID="funcsgrid" runat="server" AllowPaging="True" AllowSorting="True"
      AutoGenerateColumns="False" DataKeyNames="idx" DataSourceID="funcs" OnRowCancelingEdit="row_RowCancelingEdit"
      OnRowUpdated="row_Updated" OnRowUpdating="funcsview_RowUpdating" PageSize="20" Width="100%" >
      <Columns>
         <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
            SortExpression="idx" Visible="False" />
         <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
         <asp:BoundField DataField="name" HeaderText="name" SortExpression="name">
            <ControlStyle CssClass="itt" />
            <ItemStyle Width="200px" />
         </asp:BoundField>
         <asp:BoundField DataField="descr" HeaderText="descr" SortExpression="descr">
            <ControlStyle CssClass="itt" Width="400px" />
            <ItemStyle Width="400px" />
         </asp:BoundField>
      </Columns>
      <EditRowStyle BackColor="AliceBlue" BorderColor="Black" />
   </asp:GridView>

</div> <!-- functions -->

<div id="props" style="display: <% =panel_styles[3] %> ;">
   <asp:ObjectDataSource ID="props" runat="server" DeleteMethod="DeleteProperty" InsertMethod="InsertPropertyAdv"
      OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="AccessControl.acl_propertyTableAdapters.acl_propertyTableAdapter"
      UpdateMethod="UpdateProperty" OnInserting="props_Inserting" OnObjectCreated="props_ObjectCreated">
      <DeleteParameters>
         <asp:Parameter Name="Original_idx" Type="Int32" />
      </DeleteParameters>
      <UpdateParameters>
         <asp:Parameter Name="name" Type="String" />
         <asp:Parameter Name="human_name" Type="String" />
         <asp:Parameter Name="nesses" Type="Boolean" />
         <asp:Parameter Name="is_internal" Type="Boolean" />
         <asp:Parameter Name="is_user_editable" Type="Boolean" />
         <asp:Parameter Name="Original_idx" Type="Int32" />
      </UpdateParameters>
      <InsertParameters>
         <asp:Parameter Name="name" Type="String" />
         <asp:Parameter Name="human_name" Type="String" />
         <asp:Parameter Name="nesses" Type="Boolean" />
         <asp:Parameter Name="is_internal" Type="Boolean" />
         <asp:Parameter Name="is_user_editable" Type="Boolean" />
      </InsertParameters>
   </asp:ObjectDataSource>
   <asp:GridView ID="propsgrid" runat="server" AllowPaging="True" AllowSorting="True"
      AutoGenerateColumns="False" DataKeyNames="idx" DataSourceID="props" PageSize="20" OnRowUpdating="propsgrid_RowUpdating" OnRowCancelingEdit="row_RowCancelingEdit" OnRowUpdated="row_Updated" Width="100%">
      <Columns>
         <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
            SortExpression="idx" Visible="False" />
         <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
         <asp:BoundField DataField="name" HeaderText="Short name" SortExpression="name" >
            <ControlStyle CssClass="itt" />
            <ItemStyle Width="200px" />
         </asp:BoundField>
         <asp:BoundField DataField="human_name" HeaderText="Full name" SortExpression="human_name" >
            <ControlStyle CssClass="itt" />
            <ItemStyle Width="300px" />
         </asp:BoundField>
         <asp:CheckBoxField DataField="nesses" HeaderText="Nes" SortExpression="nesses" >
            <ControlStyle CssClass="itt" />
            <ItemStyle CssClass="itt" />
         </asp:CheckBoxField>
         <asp:CheckBoxField DataField="is_internal" HeaderText="Int" SortExpression="is_internal" >
            <ControlStyle CssClass="itt" />
            <ItemStyle CssClass="itt" />
         </asp:CheckBoxField>
         <asp:CheckBoxField DataField="is_user_editable" HeaderText="User" SortExpression="is_user_editable" >
            <ControlStyle CssClass="itt" />
            <ItemStyle CssClass="itt" />
         </asp:CheckBoxField>
      </Columns>
      <RowStyle Height="18px" />
      <EditRowStyle BackColor="AliceBlue" BorderColor="Black" />
   </asp:GridView>
</div> <!--functions-->   
</td></tr></table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">       
       <br />
       <script language="javascript" type="text/javascript">
       
       
       function on_response_s(error,http)
       {
         document.getElementById('op_e_place').innerHTML="";
         if(null!=error)
         {
            show_data(error,true);
         }
         else
         {
            show_data(http.responseText,false);
         };
       }
       
       function handle_submit_props()
       {
         var ar=new Array();
         for(i=0;i<document.props_form.elements.length;++i)
         {
            ar.push(document.props_form.elements[i].name);
            ar.push(document.props_form.elements[i].value);
         }
         exec_http_req("UserManager::apply_props_",ar,on_response_s);
       };

       function handle_submit_groups()
       {
         var ar=new Array();
         for(i=0;i<document.groups_form.elements.length;++i)
         {
            if(document.groups_form.elements[i].name.indexOf("gm_")==0)
            {
               if(document.groups_form.elements[i].checked)
               {
                  ar.push(document.groups_form.elements[i].name);
                  ar.push(document.groups_form.elements[i].value);
               }
            }
            else
            {
               ar.push(document.groups_form.elements[i].name);
               ar.push(document.groups_form.elements[i].value);
            }
         }
         exec_http_req("UserManager::apply_groups_",ar,on_response_s);
       };
       
       function handle_submit_permissions()
       {
         var ar=new Array();
         for(i=0;i<document.grants_form.elements.length;++i)
         {
            if(document.grants_form.elements[i].name.indexOf("grants_")==0)
            {
               if(document.grants_form.elements[i].checked)
               {
                  ar.push(document.grants_form.elements[i].name);
                  ar.push(document.grants_form.elements[i].value);
               }
            }
            else
            {
               ar.push(document.grants_form.elements[i].name);
               ar.push(document.grants_form.elements[i].value);
            }
         }
         exec_http_req("UserManager::apply_grants_",ar,on_response_s);
       };
       
       
      </script>       
      
      <div style="width:500px; visibility:hidden; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;" id="cnt" >
         <img id='close_id' style='cursor: pointer; border: none; 0pt;' src='i/x.gif' height='15' width='15' alt='Close' onclick="javascript: document.getElementById('cnt').style.visibility='hidden'; return false;"/>
         <div id="c_place" style="border: none; 2px; "></div>
         <div id="op_e_place" style="border: none; 2px;  color: red;"></div>
    </div>
</asp:Content>




