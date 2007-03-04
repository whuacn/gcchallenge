<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ManageShop.aspx.cs" Inherits="GMATClubTest.Web.ManageShop" Title="Shop Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<asp:LinkButton id="new_object" onclick="new_object_Click" runat="server">[New]</asp:LinkButton>&nbsp;
   <asp:Label ID="errorText" runat="server" ForeColor="Red" Text="sa" Visible="False"></asp:Label>
<hr style="height: 1px" />
<a href="ManageShop.aspx?panel=items">Items categories</a> | <a href="ManageShop.aspx?panel=pdfs">Pdfs</a> |  <a href="ManageShop.aspx?panel=stats">Shop Statistic</a> | <a href="ManageShop.aspx?panel=baskets">
   Users baskets</a> 
<hr style="height: 1px" />
   <asp:Panel ID="items" runat="server" Visible="False" Width="100%">
      <asp:ObjectDataSource ID="itemsDso" runat="server" DeleteMethod="DeleteQuery" InsertMethod="InsertQuery"
         OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Shop.shop_itemTableAdapters.shop_itemTableAdapter"
         UpdateMethod="UpdateItem" OnInserting="itemsDso_Inserting" OnObjectCreated="itemsDso_ObjectCreated" OnUpdated="dso_Updated">
         <DeleteParameters>
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </DeleteParameters>
         <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="item_price" Type="Decimal" />
            <asp:Parameter Name="amount" Type="Int32" />
            <asp:Parameter Name="rdr" Type="Int32" />
            <asp:Parameter Name="expires_after" Type="Int32" />
            <asp:Parameter Name="full_price" Type="Decimal" />
            <asp:Parameter Name="limit" Type="Int32" />
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
            <asp:Parameter Name="expires_after" Type="Int32" />
            <asp:Parameter Name="full_price" Type="Decimal" />
            <asp:Parameter Name="limit" Type="Int32" />
         </InsertParameters>
      </asp:ObjectDataSource>
      <div style="width:100%; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;">
      &nbsp; &nbsp; &nbsp; &nbsp; <strong>P.price</strong> is a price of a full package,
         whereas <strong>I. price</strong> is a price of an item in this package. If a <strong>
            P.price </strong>is not set the package can't be bought. But an item in it could
         be...<br />
         &nbsp; &nbsp; &nbsp; <b>Order</b> column specifies order in which packages are rendered in Test.aspx page. 
      Negative value means that the item is not rendered. This trick can be used to create a sub package that must be rendered just inside it's parent container... 
      <br>&nbsp; &nbsp; &nbsp; If a <b>Descr</b> field text contains '---' string then the part above '---' will be placed into the content of the 
      Tests.aspx page cell and the part below '---' will be used as a bottom cell text.&nbsp;<br />
      </div>
      <asp:GridView ID="itemsGv" runat="server" AutoGenerateColumns="False" DataKeyNames="idx"
         DataSourceID="itemsDso" AllowPaging="True" PageSize="20" OnRowCancelingEdit="row_RowCancelingEdit" OnRowUpdating="itemsGv_RowUpdating" AllowSorting="True" Width="100%" OnRowUpdated="row_Updated">
         <Columns>
            <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
               SortExpression="idx" Visible="False" />
            <asp:BoundField DataField="guididx" HeaderText="guididx" InsertVisible="False" SortExpression="guididx" Visible="False" />

            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CancelText="Cncl" DeleteText="Del" EditText="Edt" InsertText="Ins" SelectText="" UpdateText="Upd" >
               <ItemStyle Width="80px" />
               <ControlStyle Width="80px" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Name" SortExpression="name">
               <EditItemTemplate>
                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
               </EditItemTemplate>
               <ControlStyle CssClass="itt" Width="150px" />
               <ItemStyle Width="150px" />
               <ItemTemplate>
                  <asp:HyperLink ID="lnk" runat="server" NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"ShopManager::show_item_cont\", Array(\"guididx\",\""+Eval("guididx")+"\",\"name\",\""+Eval("name")+"\"),function (error,http) {    on_response(error,http,1); })"%>' Text='<%# Bind("name") %>'></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="full_price" HeaderText="P. price" SortExpression="full_price" DataFormatString="{0:N2}" NullDisplayText="0,00">
               <ControlStyle CssClass="itt" Width="60px" />
               <ItemStyle CssClass="itt" Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="item_price" HeaderText="I. price" SortExpression="item_price" DataFormatString="{0:N2}" NullDisplayText="0,00" >
               <ControlStyle CssClass="itt" Width="60px" />
               <ItemStyle CssClass="itt" Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="expires_after" HeaderText="Expires" SortExpression="expires_after" NullDisplayText="0">
               <ControlStyle CssClass="itt" Width="40px" />
               <ItemStyle CssClass="itt" Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="amount" HeaderText="Posts" SortExpression="amount" NullDisplayText="0" >
               <ControlStyle CssClass="itt" Width="40px" />
               <ItemStyle CssClass="itt" Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="limit" HeaderText="Limit" NullDisplayText="0" SortExpression="limit">
               <ControlStyle CssClass="itt" Width="40px" />
               <ItemStyle CssClass="itt" Width="40px" />
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
   <asp:Panel ID="baskets" runat="server" Visible="False" Width="100%">
      &nbsp;
   &nbsp;<asp:ObjectDataSource ID="usersDso" runat="server" DeleteMethod="DeleteUser"
         InsertMethod="InsertUserAdv" OldValuesParameterFormatString="original_{0}" 
         SelectMethod="GetData"
         TypeName="AccessControl.acl_userTableAdapters.base_user_infoTableAdapter" UpdateMethod="UpdateUserAdv">
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
      <asp:GridView ID="usersgrid" runat="server" AllowPaging="True" AllowSorting="True"
         AutoGenerateColumns="False" CaptionAlign="Left" DataKeyNames="idx" DataSourceID="usersDso"
         EditRowStyle-BackColor="AliceBlue" 
         PageSize="20"
         Width="100%">
         <Columns>
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
                  <asp:HyperLink ID="lnk" runat="server" NavigateUrl='<%# "javascript:document.getElementById(\"c_place\").innerHTML=\"\";exec_http_req(\"UserManager::show_user_basket\", Array(\"guididx\",\""+Eval("guididx") +"\"),function (error,http) { on_response(error,http,1); } );"%>'
                     Text='<%# Bind("login") %>'></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name">
               <ControlStyle CssClass="itt" />
               <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name">
               <ControlStyle CssClass="itt" />
               <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email">
               <ControlStyle CssClass="itt" />
               <ItemStyle Width="100px" />
            </asp:BoundField>
         </Columns>
         <RowStyle BorderStyle="Inset" Height="18px" />
         <EditRowStyle BackColor="AliceBlue" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
      </asp:GridView>
   </asp:Panel>
   <asp:Panel ID="stats" runat="server" Visible="False" Width="100%">
      &nbsp;<asp:SqlDataSource ID="statDso" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
         SelectCommand="SELECT * FROM [sold_items] order by sold_at"></asp:SqlDataSource>
      Filter
      <asp:TextBox ID="filter" runat="server" CssClass="itt" Width="203px" OnTextChanged="filter_button_Click"></asp:TextBox>&nbsp;
      <asp:LinkButton ID="filter_button" runat="server" OnClick="filter_button_Click">[Go]</asp:LinkButton>
      <br />
      <br />
      <asp:GridView ID="statGv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
         DataSourceID="statDso" PageSize="20" Width="100%">
         <Columns>
            <asp:BoundField DataField="name" HeaderText="Item name" SortExpression="name" />
            <asp:BoundField DataField="login" HeaderText="User login" SortExpression="login" />
            <asp:BoundField DataField="sold_at" HeaderText="Sold at" SortExpression="sold_at" />
            <asp:BoundField DataField="expires_at" HeaderText="Expires at" SortExpression="expires_at" />
            <asp:TemplateField HeaderText="Sold / Use" SortExpression="use_count">
               <ItemTemplate>
                  <asp:Label ID="Label2" runat="server" Text='<%# Eval("sold_count").ToString() + "/" + Eval("use_count").ToString()  %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="type">
               <ItemTemplate>
                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("type").ToString()=="1"?"[pkg]":Eval("type").ToString()=="2"?"[test]":"[pdf]" %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="payed" HeaderText="Money" SortExpression="payed" />
         </Columns>
      </asp:GridView>
   </asp:Panel><asp:Panel ID="pdfs" runat="server" Visible="False" Width="100%">
      <asp:ObjectDataSource ID="pdfsDso" runat="server" DeleteMethod="DeleteQuery" InsertMethod="InsertQuery"
         OldValuesParameterFormatString="original_{0}"
         SelectMethod="GetData" TypeName="Shop.pdf_downloadTableAdapters.pdf_downloadTableAdapter"
         UpdateMethod="UpdateQuery" OnObjectCreated="pdfsDso_ObjectCreated" OnInserting="pdfsDso_Inserting">
         <DeleteParameters>
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </DeleteParameters>
         <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="descr" Type="String" />
            <asp:Parameter Name="filename" Type="String" />
            <asp:Parameter Name="Original_idx" Type="Int32" />
         </UpdateParameters>
         <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="descr" Type="String" />
            <asp:Parameter Name="filename" Type="String" />
         </InsertParameters>
      </asp:ObjectDataSource>
      <asp:GridView ID="pdfsGv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
         DataKeyNames="idx" DataSourceID="pdfsDso" OnRowCancelingEdit="row_RowCancelingEdit" Width="100%" AllowPaging="True" PageSize="20" OnRowUpdated="row_Updated">
         <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True">
               <ItemStyle Width="150px" />
               <ControlStyle Width="150px" />
            </asp:CommandField>
            <asp:BoundField DataField="idx" HeaderText="idx" InsertVisible="False" ReadOnly="True"
               SortExpression="idx" />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" >
               <ControlStyle CssClass="itt" Width="100px" />
               <ItemStyle CssClass="itt" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="filename" HeaderText="Filename" SortExpression="filename" >
               <ControlStyle CssClass="itt" Width="100px" />
               <ItemStyle CssClass="itt" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="descr" HeaderText="Description" SortExpression="descr" >
               <ControlStyle CssClass="itt" Width="200px" />
               <ItemStyle CssClass="itt" Width="200px" />
            </asp:BoundField>
         </Columns>
      </asp:GridView>
   </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
<script language="javascript" type="text/javascript">
var oFCKeditor ;
function delete_bought_items()
{
   var del_frm=document.forms['to_delete_items'];
   if(null==del_frm)
   {
      alert('No items form -> to_delete_items');
   }

   var ar=new Array();   
   for(i=0;i<del_frm.elements.length;++i)
   {
      if(del_frm.elements[i].name.indexOf("to_del_idx_")==0)
      {
         if(del_frm.elements[i].checked)
         {
            ar.push(del_frm.elements[i].name);
            ar.push(del_frm.elements[i].value);
         }
      }
      if(del_frm.elements[i].name=='guididx')
      {
         ar.push(del_frm.elements[i].name);
         ar.push(del_frm.elements[i].value);      
      }
   }
   exec_http_req("ShopManager::delete_bought_items",ar,on_apply_respone);
}
function add_selected_items()
{
   var del_frm=document.forms['to_purchase_items'];
   if(null==del_frm)
   {
      alert('No items form -> to_purchase_items');
   }

   var ar=new Array();   
   for(i=0;i<del_frm.elements.length;++i)
   {
      if(del_frm.elements[i].name.indexOf("buy_it_")==0)
      {
         if(del_frm.elements[i].checked)
         {
            ar.push(del_frm.elements[i].name);
            ar.push(del_frm.elements[i].value);
         }
      }
      if(del_frm.elements[i].name=='guididx')
      {
         ar.push(del_frm.elements[i].name);
         ar.push(del_frm.elements[i].value);      
      }
   }
   exec_http_req("ShopManager::purchase_items",ar,on_apply_respone);
}

 
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

