<%@ Page language="c#" Inherits="GMATClubTest.Web.MainWebForm" CodeFile="MainWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainWebForm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body style="text-align: center">
		<form id="Form1" method="post" runat="server">
            &nbsp;&nbsp;
			<asp:LinkButton id="LinkButton4" style="Z-INDEX: 104; LEFT: 800px; POSITION: absolute; TOP: 47px"
				runat="server" onclick="LinkButton4_Click">Results</asp:LinkButton>
            <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1">
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
                            ID="statusLabel" runat="server" CssClass="Title"></asp:Label></td>
                    <td align="left" style="width: 20%">
                        <p>
                            &nbsp;</p>
                        <p>
                            &nbsp;</p>
                    </td>
                </tr>
            </table>
            <table style="width: 732px">
                <tr>
                    <td style="width: 50px; height: 21px">
                        <asp:HyperLink ID="homeHyperLink" runat="server" NavigateUrl="mainwebform.aspx" Font-Bold="True" ForeColor="DimGray">Home</asp:HyperLink></td>
                    <td style="width: 50px; height: 21px; background-color: white">
                        <asp:HyperLink ID="historyHyperLink" runat="server" NavigateUrl="resultswebform.aspx" Font-Bold="True" ForeColor="DimGray">History</asp:HyperLink></td>
                    <td style="width: 630px; height: 21px;
                        background-color: white; text-align: right">
                            <asp:LinkButton ID="logOutLinkButton" runat="server" OnClick="logOutLinkButton_Click" Font-Bold="True" ForeColor="DimGray">Log out</asp:LinkButton></td>
                </tr>
            </table>
            <hr noshade="noshade" size="1" width="100%" />
            <table border="0" style="vertical-align: text-top; text-align: left">
                <tr>
                    <td style="width: 3px; height: 21px; vertical-align: top;">
                        <table style="text-align: left">
                            <tr>
                                <td style="width: 2px; height: 23px">
                        <asp:Table ID="practiceTable" runat="server" HorizontalAlign="Left" Width="250px">
                            <asp:TableRow runat="server" Width="200px">
                                <asp:TableCell runat="server" Width="200px" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">Practice</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 3px; height: 21px">
                        <table>
                            <tr>
                                <td style="width: 2px; height: 28px">
                        <asp:Table ID="testsTable" runat="server" HorizontalAlign="Left" Width="250px">
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server" Width="200px" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">Adaptive test</asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            &nbsp;
            <hr noshade="" size="1" width="100%" />
            <table id="Table10" align="center" border="0" cellpadding="1" cellspacing="1">
                <tr>
                    <td style="font-size: 12px; text-transform: none; font-style: italic; font-variant: normal">
                        @2006 GMATClubTest</td>
                </tr>
            </table>
            <a href="http://localhost/GMATClubChallenge.com/App_Code/testsDataSet.xsd"></a>
            <a
                href="http://localhost/GMATClubChallenge.com/App_Code/testsDataSet.xsd"></a>
		</form>
	</body>
</HTML>
