<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="DescriptionWebForm.aspx.cs" Inherits="GMATClubTest.Web.DescriptionWebForm" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
        <hr noshade="" size="1" width="100%" />
        <table style="text-align: center">
            <tr>
                <td style="width: 700px">
                    <br />
                        <%=descriptionString%>
                </td>
            </tr>
        </table>
        &nbsp;<table>
            <tr>
                <td>
                    <asp:ImageButton ID="cancelImageButton" runat="server" ImageUrl="~/images/cancelButton.gif" OnClick="cancelImageButton_Click" /></td>
                <td>
                    <asp:ImageButton ID="OkImageButton" runat="server" ImageUrl="~/images/OkButton.gif"
                        OnClick="OkImageButton_Click" /></td>
            </tr>
        </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
</asp:Content>

