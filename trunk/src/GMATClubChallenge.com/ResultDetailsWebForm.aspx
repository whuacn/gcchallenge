<%@ Page language="c#" Inherits="GMATClubTest.Web.ResultDetailsWebForm" CodeFile="ResultDetailsWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMATClubTest - Result details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body style="text-align: center" bgcolor="#006daa">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="739" align="center" border="0">
				<TR>
					<TD align="left" width="20%" style="height: 161px"></TD>
					<TD align="center" width="40%" style="height: 161px">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><IMG height="136" alt="" src="images/gmatclub.jpg" width="280"
										align="left"></TD>
							</TR>
						</TABLE>
						<asp:label id="statusLabel" runat="server" CssClass="Title"></asp:label></TD>
					<TD align="left" width="20%" style="height: 161px">
						<P>
                            &nbsp;</P>
						<P><asp:hyperlink id="loginStatusHyperLink" runat="server" Visible="False" BackColor="#006DAA" BorderStyle="None" ForeColor="White">[loginStatusHyperLink]</asp:hyperlink></P>
					</TD>
				</TR>
			</TABLE>
            <table style="width: 732px; border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge;">
                <tr>
                    <td style="width: 50px; height: 21px; background-color: #80aee1;">
                        <asp:HyperLink ID="homeHyperLink" runat="server" Font-Bold="True" ForeColor="#CCE2EE"
                            NavigateUrl="mainwebform.aspx" Font-Size="Medium">Home</asp:HyperLink></td>
                    <td style="width: 50px; height: 21px; background-color: #80aee1">
                        <asp:HyperLink ID="historyHyperLink" runat="server" Font-Bold="True" ForeColor="#CCE2EE"
                            NavigateUrl="resultswebform.aspx" BackColor="#80AEE1" Font-Size="Medium">History</asp:HyperLink></td>
                    <td style="width: 630px; height: 21px; background-color: #80aee1; text-align: right">
                        <asp:HyperLink ID="logoutHyperLink" runat="server" Font-Bold="True" ForeColor="#CCE2EE"
                            NavigateUrl="loginwebform.aspx" Font-Size="Medium">Log out</asp:HyperLink></td>
                </tr>
            </table>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD align="center" style="border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge; text-align: center;">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" border="0" style="text-align: center">
							<TR>
								<TD style="FONT-WEIGHT: bold; font-size: medium; width: 57px; color: white;">
                                    Section:</TD>
							</TR>
						</TABLE>
						<asp:datagrid id=setStutusDataGrid runat="server" DataSource="<%# questionSetsResultDetailsSet %>" DataMember="QuestionSets" AutoGenerateColumns="False" onselectedindexchanged="setStutusDataGrid_SelectedIndexChanged" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White">
							<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" DataTextField="Name" HeaderText="Section name" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="Name" SortExpression="Name" HeaderText="Section name"></asp:BoundColumn>
								<asp:BoundColumn DataField="Score" SortExpression="Score" HeaderText="Score"></asp:BoundColumn>
							</Columns>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" />
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" align="center" border="0" style="border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge">
				<TR>
					<TD align="center">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD style="FONT-WEIGHT: bold; font-size: medium; color: white;">Questions:</TD>
							</TR>
						</TABLE>
						<asp:table id="questionStatusTable" runat="server" GridLines="Both"></asp:table></TD>
				</TR>
			</TABLE>
			<TABLE id="Table5" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD><asp:imagebutton id="OkImageButton" runat="server" ImageUrl="images/OkButton.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table10" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD style="FONT-SIZE: 12px; TEXT-TRANSFORM: none; FONT-STYLE: italic; FONT-VARIANT: normal; color: #ffffff;">@2006 
						GMATClubTest</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
