<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DescriptionWebForm.aspx.cs" Inherits="DescriptionWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#026caa">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1">
            <tr>
                <td align="left" width="20%">
                </td>
                <td align="center" width="40%">
                    <table id="Table3" border="0" cellpadding="1" cellspacing="1">
                        <tr>
                            <td>
                                <img align="left" alt="" height="136" src="images/gmatclub.jpg" width="280" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="timeLabel" runat="server" CssClass="Title"></asp:Label><asp:Label
                        ID="statusLabel" runat="server" CssClass="Title"></asp:Label></td>
                <td align="left" style="width: 20%">
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                </td>
            </tr>
        </table>
        <table style="border-top-style: ridge; border-right-style: ridge; border-left-style: ridge;
            border-bottom-style: ridge">
            <tr>
                <td style="width: 735px; background-color: #80aee1">
        <table style="width: 732px">
            <tr>
                <td style="width: 50px; height: 21px; background-color: #80aee1;">
                    <asp:HyperLink ID="homeHyperLink" runat="server" Font-Bold="True" ForeColor="#CCE2EE"
                        NavigateUrl="mainwebform.aspx" Font-Size="Large">Home</asp:HyperLink></td>
                <td style="width: 50px; height: 21px; background-color: #80aee1">
                    <asp:HyperLink ID="historyHyperLink" runat="server" Font-Bold="True" ForeColor="#CCE2EE"
                        NavigateUrl="resultswebform.aspx" BackColor="#80AEE1" BorderColor="#80AEE1" Font-Size="Large">History</asp:HyperLink></td>
                <td style="width: 630px; height: 21px; background-color: #80aee1; text-align: right">
                    <asp:HyperLink ID="logoutHyperLink" runat="server" Font-Bold="True" ForeColor="#CCE2EE"
                        NavigateUrl="loginwebform.aspx" Font-Size="Large">Log out</asp:HyperLink></td>
            </tr>
        </table>
                </td>
            </tr>
        </table>
        <hr noshade="" size="1" width="100%" />
        <table style="text-align: center; border-top-style: groove; border-right-style: groove; border-left-style: groove; border-bottom-style: groove;">
            <tr>
                <td style="width: 700px; background-color: white;">
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
        <hr noshade="" size="1" width="100%" />
        <table id="Table10" align="center" border="0" cellpadding="1" cellspacing="1">
            <tr>
                <td style="font-size: 12px; text-transform: none; font-style: italic; font-variant: normal; color: white;">
                    @2006 GMATClubTest</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
