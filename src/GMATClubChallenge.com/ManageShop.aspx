<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ManageShop.aspx.cs" Inherits="GMATClubTest.Web.ManageShop" Title="Shop Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<asp:LinkButton id="new_object" onclick="new_object_Click" runat="server">[New]</asp:LinkButton>&nbsp;
   <asp:Label ID="errorText" runat="server" ForeColor="Red" Text="sa" Visible="False"></asp:Label>
<hr style="height: 1px" />
<a href="ManageShop.aspx?panel=items">Items categories</a> | <a href="ManageShop.aspx?panel=groups">Groups</a> | <a href="ManageShop.aspx?panel=stats">Shop Statistic</a>
<hr style="height: 1px" />
   <asp:Panel ID="items" runat="server" Visible="False" Width="100%">
      <asp:ObjectDataSource ID="itemsDso" runat="server" DeleteMethod="DeleteItem" InsertMethod="InsertItem"
         OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Shop.shop_itemTableAdapters.shop_itemTableAdapter"
         UpdateMethod="UpdateItem" OnInserting="itemsDso_Inserting" OnObjectCreated="itemsDso_ObjectCreated">
         <DeleteParameters>
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </DeleteParameters>
         <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="item_price" Type="Decimal" />
            <asp:Parameter Name="amount" Type="Int32" />
            <asp:Parameter Name="rdr" Type="Int32" />
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </UpdateParameters>
         <InsertParameters>
            <asp:Parameter Name="guididx" Type="Object" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="item_group_idx" Type="Int32" />
            <asp:Parameter Name="parent_idx" Type="Int32" />
            <asp:Parameter Name="item_price" Type="Decimal" />
            <asp:Parameter Name="amount" Type="Int32" />
            <asp:Parameter Name="descr" Type="String" />
            <asp:Parameter Name="image" Type="String" />
            <asp:Parameter Name="rdr" Type="Int32" />
         </InsertParameters>
      </asp:ObjectDataSource>
      <div style="width:100%; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;">
      &nbsp; &nbsp; &nbsp; <b>Order</b> column specifies order in which packages are rendered in Test.aspx page. 
      Negative value means that the item is not rendered. This trick can be used to create a sub package that must be rendered just inside it's parent container... 
      <br>&nbsp; &nbsp; &nbsp; If a <b>Descr</b> field text contains '---' string then the part above '---' will be placed into the content of the 
      Tests.aspx page cell and the part below '---' will be used as a bottom cell text.
      </div>
      <asp:GridView ID="itemsGv" runat="server" AutoGenerateColumns="False" DataKeyNames="idx"
         DataSourceID="itemsDso" AllowPaging="True" PageSize="20" OnRowCancelingEdit="row_RowCancelingEdit" OnRowUpdating="itemsGv_RowUpdating" AllowSorting="True" Width="100%">
         <Columns>
            <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
               SortExpression="idx" Visible="False" />
            <asp:BoundField DataField="guididx" HeaderText="guididx" InsertVisible="False" SortExpression="guididx" Visible="False" />

            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="Name" SortExpression="name">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
               </EditItemTemplate>
               <ControlStyle CssClass="itt" Width="200px" />
               <ItemStyle Width="200px" />
               <ItemTemplate>
                  <asp:HyperLink ID="lnk" runat="server" NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"ShopManager::show_item_cont\", Array(\"guididx\",\""+Eval("guididx")+"\",\"name\",\""+Eval("name")+"\"),function (error,http) { on_response(error,http,1); })"%>' Text='<%# Bind("name") %>'></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="item_price" HeaderText="Price" SortExpression="item_price" DataFormatString="{0:N2}" >
               <ControlStyle CssClass="itt" Width="110px" />
               <ItemStyle Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" >
               <ControlStyle CssClass="itt" Width="110px" />
               <ItemStyle CssClass="itt" Width="110px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Descr" SortExpression="descr">
               <ItemTemplate>
                  <asp:HyperLink ID="lnk_descr" runat="server" Text="..." NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"ShopManager::edit_item_descr\", Array(\"guididx\",\""+Eval("guididx") +"\"),on_response_descr);"%>'></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="image" SortExpression="image">
               <ItemTemplate>
                  <asp:LinkButton ID="lnk_img" runat="server" Text="..."></asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order" SortExpression="rdr">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("rdr") %>'></asp:TextBox>
               </EditItemTemplate>
               <ControlStyle CssClass="itt" Width="30px" />
               <ItemStyle CssClass="itt" Width="30px" />
               <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("rdr") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
         <EditRowStyle BackColor="AliceBlue" BorderColor="Black" />
      </asp:GridView>
   </asp:Panel>
   <asp:Panel ID="groups" runat="server" Visible="False" Width="100%">
      <asp:ObjectDataSource ID="groupsDso" runat="server" DeleteMethod="DeleteGroup" InsertMethod="Insert"
         OldValuesParameterFormatString="original_{0}" OnInserting="groupsDso_Inserting"
         SelectMethod="GetData" TypeName="Shop.shop_item_groupTableAdapters.shop_item_groupTableAdapter"
         UpdateMethod="UpdateGroup" OnObjectCreated="groupsDso_ObjectCreated">
         <DeleteParameters>
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </DeleteParameters>
         <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </UpdateParameters>
         <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
         </InsertParameters>
      </asp:ObjectDataSource>
      <asp:GridView ID="groupsGv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
         DataKeyNames="idx" DataSourceID="groupsDso" OnRowCancelingEdit="row_RowCancelingEdit">
         <Columns>
            <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
               SortExpression="idx" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
         </Columns>
      </asp:GridView>
   </asp:Panel>
   <asp:Panel ID="stats" runat="server" Visible="False" Width="100%">
   </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
<script language="javascript" type="text/javascript">
var oFCKeditor ;
   function on_response_descr(error,http)
   {
      if(null!=error)
      {
         show_data(error,true);
         show_ajax_window();
      }
      else
      {
      
         show_data(http.responseText,false);
         show_ajax_window();
         document.getElementById("HereIsTheText").value=decodeURI(document.getElementById("HereIsTheText").value);
         oFCKeditor = new FCKeditor('HereIsTheText',"100%",300);
         oFCKeditor.BasePath = '/GMATClubChallenge.com/FCKeditor/';
         oFCKeditor.Config['CustomConfigurationsPath'] = oFCKeditor.BasePath+'editor.config.js' ;

         oFCKeditor.ToolbarSet   = 'MTB' ;

         oFCKeditor.ReplaceTextarea();

         
      }

   }
   
   function on_saved(error,http)
   {
      if(null!=error)
      {
        show_data(error,true);
      }
      else
      {
        show_data("Saved",true);
      }
   };

   function save_text(guididx)
   {
        for ( i = 0; i < parent.frames.length; ++i )
            if ( parent.frames[i].FCK )
                    parent.frames[i].FCK.UpdateLinkedField();
                                


      exec_http_req( 
                    "ShopManager::save_item_descr", 
                    Array("guididx",guididx,
                          "descr",encodeURI(document.getElementById("HereIsTheText").value)),
                    on_saved);
                    
      return false;
   }
   function on_apply_respone(error,http)
   {
      if(null!=error)
      {
        show_data(error,true);
      }
      else
      {
        show_data(http.responseText,false);
      }
   };
   function handle_apply_binds(guididx)
   {
      var ar=new Array();
      ar.push("guididx");
      ar.push(guididx);
      
      for(i=0;i<document.bindings_form.elements.length;++i)
      {
         if(document.bindings_form.elements[i].name.indexOf("idx_")==0)
         {
            if(document.bindings_form.elements[i].checked)
            {
               ar.push(document.bindings_form.elements[i].name);
               ar.push(document.bindings_form.elements[i].value);
            }
         }
         else
         {
            ar.push(document.bindings_form.elements[i].name);
            ar.push(document.bindings_form.elements[i].value);
         }
      }
      exec_http_req("ShopManager::apply_contents",ar,on_apply_respone);
   }
</script>
      <div style="width:500px; visibility:hidden; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;" id="cnt" >
         <img id='close_id' style='cursor: pointer; border: none; 0pt;' src='i/x.gif' height='15' width='15' alt='Close' onclick="javascript: document.getElementById('cnt').style.visibility='hidden'; return false;"/>
         <div id="c_place" style="border: none; 2px; "></div>
         <div id="op_e_place" style="border: none; 2px;  color: red;"></div>
    </div>
</asp:Content>

