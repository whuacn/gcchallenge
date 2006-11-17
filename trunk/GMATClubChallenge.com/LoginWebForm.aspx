<%@ Page language="c#" Inherits="GMATClubTest.Web.LoginWebForm" CodeFile="LoginWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMATClubTest - Login</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body style="color: white" bgcolor="#026caa">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD align="left" width="20%"></TD>
					<TD align="left" width="40%" style="text-align: center;">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD style="width: 290px"><IMG height="136" alt="" src="images/gmatclub.jpg" width="280"
										align="left"></TD>
							</TR>
						</TABLE>
                        <asp:Label ID="errorLabel" runat="server" CssClass="Title" ForeColor="Red"></asp:Label></TD>
					<TD align="left" width="20%"></TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" align="center" border="0" style="border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge">
				<TR>
					<TD align="left" style="height: 52px">
						<TABLE id="Table5" style="WIDTH: 67px; HEIGHT: 23px" cellSpacing="1" cellPadding="1" align="right"
							border="0">
							<TR>
								<TD><asp:label id="Label1" runat="server" Width="60px" Font-Size="Medium">Login</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 52px">
						<P>
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" align="left" border="0">
								<TR>
									<TD style="height: 24px">
                                        <asp:TextBox ID="loginTextBox" runat="server" Width="300px" BackColor="#80AEE1" Font-Size="Medium" ForeColor="White"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</P>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="300" align="left" border="0">
							<TR>
								<TD align="right"><asp:label id="userNameLabel" runat="server" Width="300px" Visible="False" Height="24px"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table7" style="WIDTH: 67px; HEIGHT: 23px" cellSpacing="1" cellPadding="1" width="67"
							align="right" border="0">
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Size="Medium">Password</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
					<TD>
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="300" align="left" border="0">
							<TR>
								<TD><asp:textbox id="passwordTextBox" runat="server" Width="300px" TextMode="Password" BackColor="#80AEE1" Font-Size="Medium" ForeColor="White"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="300" align="center" border="0">
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><asp:imagebutton id="OkImageButton" runat="server" ImageUrl="images/OkButton.gif" OnClick="OkImageButton_Click1"></asp:imagebutton></TD>
					<TD><asp:imagebutton id="cancelImageButton" runat="server" ImageUrl="images/cancelButton.gif"></asp:imagebutton></TD>
					<TD>
                        <asp:ImageButton ID="btnNewUser" runat="server" Height="32px" ImageUrl="~/images/newUserButton.gif"
                            OnClick="newUserImageButton_Click" Width="96px" /></TD>
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
