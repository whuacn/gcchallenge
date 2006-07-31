<%@ Page Language="C#" AutoEventWireup="true" CodeFile="errorWebForm.aspx.cs" Inherits="errorWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" width="739">
            <tr>
                <td align="left" width="20%">
                </td>
                <td align="left" width="40%">
                    <table id="Table3" border="0" cellpadding="1" cellspacing="1">
                        <tr>
                            <td>
                                <img align="left" alt="" height="190" src="images/gmatclub.jpg" width="390" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="statusLabel" runat="server" CssClass="Title"></asp:Label></td>
                <td align="left" width="20%">
                    <p>
                        &nbsp;</p>
                    <p>
                        <asp:HyperLink ID="loginStatusHyperLink" runat="server"></asp:HyperLink></p>
                </td>
            </tr>
        </table>
        <hr noshade="" size="1" width="100%" />
        <span style="font-size: 14pt">Sorry, your request cannot be processed now.<br />
            Administrators were notified about this problem. Please, try to submit your request
            later or try another one.</span><br />
    
    </div>
        <hr noshade="" size="1" width="100%" />
        <table id="Table12" align="center" border="0" cellpadding="1" cellspacing="1">
            <tr>
                <td style="font-size: 12px; text-transform: none; font-style: italic; font-variant: normal">
                    @2006 GMATClubTest</td>
            </tr>
        </table>
    </form>
</body>
</html>
