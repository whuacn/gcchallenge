<%@ Page language="c#" Inherits="GMATClubTest.Web.Migrated_ReviewWebForm" CodeFile="ReviewWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMATClubTest - Review</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body style="background-color: #026caa">
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
						<asp:label id="errorLabel" runat="server" ForeColor="Red"></asp:label></TD>
					<TD align="left" width="20%">
						<P><asp:hyperlink id="adminHyperLink" runat="server" NavigateUrl="GMATClubChallenge/LoginWebForm.aspx" Visible="False">Admin login</asp:hyperlink></P>
						<P><asp:hyperlink id="loginStatusHyperLink" runat="server" Visible="False">[loginStatusHyperLink]</asp:hyperlink></P>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="739" align="center" border="0">
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0" style="background-color: #026caa">
							<TR>
								<TD style="FONT-WEIGHT: bold; background-color: #026caa; color: #ffffff; height: 71px;" align="center">Sets:<asp:table id="setsTable" runat="server" GridLines="Both" BorderStyle="Groove" Font-Bold="True" Font-Size="Medium">
										<asp:TableRow runat="server">
											<asp:TableCell runat="server"></asp:TableCell>
										</asp:TableRow>
									</asp:table></TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; height: 71px; color: #ffffff; background-color: #026caa;" align="center">Questions:<asp:table id="questionTable" runat="server" GridLines="Both" BorderStyle="Groove" Font-Bold="True" Font-Size="Medium"></asp:table></TD>
							</TR>
						</TABLE>
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD style="width: 31px"><asp:imagebutton id="imageButton" runat="server" OnClick="imageButton_Click"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table10" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD style="FONT-SIZE: 12px; TEXT-TRANSFORM: none; FONT-STYLE: italic; FONT-VARIANT: normal; width: 119px; color: #ffffff;">@2006 
						GMATClubTest</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
