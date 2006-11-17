<%@ Page language="c#" Inherits="GMATClubTest.Web.NewUserWebForm" CodeFile="NewUserWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NewUserWebForm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body style="text-align: center" bgcolor="#026caa">
		<form id="Form1" method="post" runat="server">
            &nbsp; &nbsp; &nbsp;
            <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" width="739">
                <tr>
                    <td align="left" width="20%">
                    </td>
                    <td align="center" width="40%">
                        <table id="Table3" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <img align="left" alt="" height="136" src="images/gmatclub.jpg"
                                        width="280" /></td>
                            </tr>
                        </table>
                        <asp:Label ID="timeLabel" runat="server" CssClass="Title"></asp:Label><asp:Label
                            ID="statusLabel" runat="server" CssClass="Title"></asp:Label>
                        <asp:Label ID="errorTextBox" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                    <td align="left" style="width: 20%">
                        <p>
                            &nbsp;</p>
                        <p>
                            <asp:HyperLink ID="loginStatusHyperLink" runat="server"></asp:HyperLink></p>
                    </td>
                </tr>
            </table>
            <hr noshade="noshade" size="1" width="100%" />
            <table border="0" style="text-align: left; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge;">
                <tr>
                    <td style="height: 21px">
                        <asp:Label ID="Label1" runat="server" Text="Login" Font-Size="Medium" ForeColor="White"></asp:Label></td>
                    <td style="width: 5px; height: 21px">
                        <asp:TextBox ID="loginTextBox"  runat="server" Width="155px" BackColor="#80AEE1" Font-Size="Medium" ForeColor="White" ></asp:TextBox></td>
                    <td style="width: 5px; height: 21px">
                        <asp:RegularExpressionValidator ID="loginRegularExpressionValidator" runat="server"
                            ControlToValidate="loginTextBox" Display="Dynamic" ErrorMessage="*" ValidationExpression=".{4,100}" Font-Size="Medium"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <asp:Label ID="Label2" runat="server" Text="Name" Font-Size="Medium" ForeColor="White"></asp:Label></td>
                    <td style="width: 5px; height: 24px;">
                        <asp:TextBox ID="nameTextBox" runat="server" Width="155px" BackColor="#80AEE1" Font-Size="Medium" ForeColor="White"></asp:TextBox></td>
                    <td style="width: 5px; height: 24px">
                        <asp:RegularExpressionValidator ID="nameRegularExpressionValidator" runat="server" ControlToValidate="loginTextBox"
                            Display="Dynamic" ErrorMessage="*" ValidationExpression=".{4,100}" Font-Size="Medium"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Password" Font-Size="Medium" ForeColor="White"></asp:Label></td>
                    <td style="width: 5px; height: 21px">
                        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" Width="155px" BackColor="#80AEE1" Font-Size="Medium" ForeColor="White"></asp:TextBox></td>
                    <td style="width: 5px; height: 21px">
                        <asp:RegularExpressionValidator ID="passwordRegularExpressionValidator" runat="server"
                            ControlToValidate="passwordTextBox" Display="Dynamic" ErrorMessage="*" ValidationExpression=".{4,100}" Font-Size="Medium"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Confirm password" Font-Size="Medium" ForeColor="White"></asp:Label></td>
                    <td style="width: 5px; height: 21px">
                        <asp:TextBox ID="confirmTextBox" runat="server" TextMode="Password" Width="155px" BackColor="#80AEE1" Font-Size="Medium" ForeColor="White"></asp:TextBox></td>
                    <td style="width: 5px; height: 21px">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="passwordTextBox"
                            ControlToValidate="confirmTextBox" Display="Dynamic" ErrorMessage="*" Font-Size="Medium"></asp:CompareValidator></td>
                </tr>
            </table>
            <br />
            <table border="0">
                <tr>
                    <td style="width: 31px; height: 34px">
                        <asp:ImageButton ID="okImageButton" runat="server" ImageUrl="images/OkButton.gif" OnClick="okImageButton_Click" /></td>
                    <td style="width: 99px; height: 34px">
                        <asp:ImageButton ID="cancelImageButton" runat="server" ImageUrl="images/cancelButton.gif" OnClick="cancelImageButton_Click" /></td>
                </tr>
            </table>
            <hr noshade="noshade" size="1" width="100%" />
            <table id="Table12" align="center" border="0" cellpadding="1" cellspacing="1">
                <tr>
                    <td style="font-size: 12px; text-transform: none; font-style: italic; font-variant: normal; color: #ffffff; height: 17px;">
                        @2006 GMATClubTest</td>
                </tr>
            </table>
		</form>
	</body>
</HTML>
