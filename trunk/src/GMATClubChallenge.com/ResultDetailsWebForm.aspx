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
	<body style="text-align: center">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="739" align="center" border="0">
				<TR>
					<TD align="left" width="20%"></TD>
					<TD align="center" width="40%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><IMG height="136" alt="" src="images/gmatclub.jpg" width="280"
										align="left"></TD>
							</TR>
						</TABLE>
						<asp:label id="statusLabel" runat="server" CssClass="Title"></asp:label></TD>
					<TD align="left" width="20%">
						<P>
                            &nbsp;</P>
						<P><asp:hyperlink id="loginStatusHyperLink" runat="server" Visible="False">[loginStatusHyperLink]</asp:hyperlink></P>
					</TD>
				</TR>
			</TABLE>
            <table style="width: 732px">
                <tr>
                    <td style="width: 50px; height: 21px">
                        <asp:HyperLink ID="homeHyperLink" runat="server" Font-Bold="True" ForeColor="DimGray"
                            NavigateUrl="mainwebform.aspx">Home</asp:HyperLink></td>
                    <td style="width: 50px; height: 21px; background-color: white">
                        <asp:HyperLink ID="historyHyperLink" runat="server" Font-Bold="True" ForeColor="DimGray"
                            NavigateUrl="resultswebform.aspx">History</asp:HyperLink></td>
                    <td style="width: 630px; height: 21px; background-color: white; text-align: right">
                        <asp:HyperLink ID="logoutHyperLink" runat="server" Font-Bold="True" ForeColor="DimGray"
                            NavigateUrl="loginwebform.aspx">Log out</asp:HyperLink></td>
                </tr>
            </table>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD align="center">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD style="FONT-WEIGHT: bold">
                                    Section:</TD>
							</TR>
						</TABLE>
						<asp:datagrid id=setStutusDataGrid runat="server" DataSource="<%# questionSetsResultDetailsSet %>" DataMember="QuestionSets" AutoGenerateColumns="False" onselectedindexchanged="setStutusDataGrid_SelectedIndexChanged">
							<HeaderStyle Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" DataTextField="Name" HeaderText="Section name" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="Name" SortExpression="Name" HeaderText="Section name"></asp:BoundColumn>
								<asp:BoundColumn DataField="Score" SortExpression="Score" HeaderText="Score"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD align="center">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD style="FONT-WEIGHT: bold">Questions:</TD>
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
					<TD style="FONT-SIZE: 12px; TEXT-TRANSFORM: none; FONT-STYLE: italic; FONT-VARIANT: normal">@2006 
						GMATClubTest</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
