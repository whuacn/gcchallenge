<%@ Page language="c#" Inherits="GMATClubTest.Web.ResultsWebForm" CodeFile="ResultsWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMATClubTest - Results</title>
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
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD>
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD style="FONT-WEIGHT: bold">Results:</TD>
							</TR>
						</TABLE>
						<asp:datagrid id=resultsGrid runat="server" AutoGenerateColumns="False" DataMember="Results" DataSource="<%# resultsSet %>" onselectedindexchanged="resultsGrid_SelectedIndexChanged">
							<HeaderStyle Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Test name" DataTextField="TestName" HeaderText="Test name" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="TestName" SortExpression="TestName" ReadOnly="True" HeaderText="Test name"></asp:BoundColumn>
								<asp:BoundColumn DataField="StartTime" SortExpression="StartTime" ReadOnly="True" HeaderText="Start time"
									DataFormatString="{0:g}"></asp:BoundColumn>
								<asp:BoundColumn DataField="EndTime" SortExpression="EndTime" ReadOnly="True" HeaderText="End time"
									DataFormatString="{0:g}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Score" SortExpression="Score" ReadOnly="True" HeaderText="Score"></asp:BoundColumn>
								<asp:TemplateColumn></asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="Id" SortExpression="Id" HeaderText="Id"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="UserId" SortExpression="UserId" HeaderText="UserId"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestId" SortExpression="TestId" HeaderText="TestId"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="300" align="center" border="0">
				<TR>
					<TD style="FONT-WEIGHT: bold" align="center">
                        <span lang="EN-US" style="font-size: 12pt; color: black; font-family: 'Times New Roman';
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA">Show</span><span lang="EN-US" style="font-size: 12pt; color: black;
                                font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: RU;
                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA"> </span><span lang="EN-US"
                                    style="font-size: 12pt; color: black; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                    results</span><span lang="EN-US" style="font-size: 12pt; color: black; font-family: 'Times New Roman';
                                        mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: RU; mso-fareast-language: EN-US;
                                        mso-bidi-language: AR-SA"> </span><span lang="EN-US" style="font-size: 12pt; color: black;
                                            font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US;
                                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA">for</span><span lang="EN-US"
                                                style="font-size: 12pt; color: black; font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                                                mso-ansi-language: RU; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"> </span>
                        <span lang="EN-US" style="font-size: 12pt; color: black; font-family: 'Times New Roman';
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                            mso-bidi-language: AR-SA">period</span>:</TD>
				</TR>
			</TABLE>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="500" align="center" border="0">
				<TR>
					<TD style="height: 239px">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD>From</TD>
							</TR>
						</TABLE>
						<asp:calendar id="beginCalendar" runat="server" ShowGridLines="True" Width="232px" onselectionchanged="beginCalendar_SelectionChanged"></asp:calendar></TD>
					<TD align="center" style="height: 239px">
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD>To</TD>
							</TR>
						</TABLE>
						<asp:calendar id="endCalendar" runat="server" ShowGridLines="True" Width="232px" FirstDayOfWeek="Monday" onselectionchanged="endCalendar_SelectionChanged" EnableTheming="True"></asp:calendar></TD>
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
