<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="CreateCustomTest.aspx.cs" Inherits="GMATClubTest.Web.CreateCustomTest" Title="Custom test creation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<script language="javascript" type="text/javascript">
var tests=new Array();
if(tests.length==0)
{
   exec_http_req("CustomTestsLogic::list_questions",new Array(),
   function (error,http)
   {
      if(error)
      {
         alert("Error: "+error);
      }
      else
      {
         alert(http.responseText);
         var doc=http.responseXML.documentElement;
         for(var i=0;i<doc.childNodes.length;++i)
         {
            var elt=doc.childNodes(i);
            var id=elt.childNodes(0).text;
            var type=elt.childNodes(1).text;
            var sub_type=elt.childNodes(2).text;
            var dif_level=elt.childNodes(2).text;
            var text=elt.childNodes(2).text;
            alert(id);
         }
      }
   });
   
}
</script>
   <table width="100%">
   <tr>
   <td style="width: 104px">Test name</td><td>
      <asp:TextBox ID="test_name" runat="server" CssClass="itt" Width="450px"></asp:TextBox></td>
   </tr>
      <tr>
         <td style="width: 104px">
            Test description</td>
         <td>
            <asp:TextBox ID="test_description" runat="server" CssClass="itt" Width="450px" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
      </tr>
      <tr>
         <td colspan="2">
            <hr style="height: 1px;" width="100%" />
         </td>
      </tr>
      <tr>
         <td style="width: 104px">
         </td>
         <td>
         </td>
      </tr>
   </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

