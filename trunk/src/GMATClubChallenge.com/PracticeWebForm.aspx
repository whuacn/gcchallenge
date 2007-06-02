<%@ Page language="c#" Inherits="GMATClubTest.Web.Migrated_PracticeGeneralWebForm" CodeFile="PracticeWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMAT Club Test - Practice</title>
	    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<scripts>
		    <script language="javascript" src="pageJS/clock.js"></script>
		    <script language="javascript" src="pageJS/reviewFlag.js"></script>
		    <script language="javascript">	
    		
		    var dateStart = new Date();
            function onStart()
            {
	            dateStart = new Date();
	            //window.setTimeout('clock();',100)
	            clock();
	            initReviewFlag();
            }          

		    </script>
		</scripts>
	</HEAD>
	<body onload="onStart()" bgcolor="#006daa" style="text-align: center">
		<form id="Form1" metod="post" runat="server">
            &nbsp;<asp:HiddenField ID="reviewFlag" runat="server" Value="False" />
            <asp:HiddenField ID="isAnswerConfirm" runat="server" Value="False" />
            <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" width="739">
                <tr>
                    <td align="left" width="20%">
                    </td>
                    <td align="center" style="width: 40%">
                        <table id="Table3" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <img align="left" alt="" height="136" src="images/gmatclub.jpg" width="280" /></td>
                            </tr>
                        </table>
						<asp:label id="timeLabel" runat="server" CssClass="Title" ForeColor="White"></asp:label>
                        <asp:Label ID="statusLabel" runat="server" CssClass="Title" ForeColor="White"></asp:Label></td>
                    <td align="left" width="20%">
                        <p>
                            &nbsp;</p>
                        <p>
                            <asp:HyperLink ID="loginStatusHyperLink" runat="server" ForeColor="White" Visible="False">[loginStatusHyperLink]</asp:HyperLink></p>
                    </td>
                </tr>
            </table>
			<%=clockHiddenParam%>
			<HR width="100%" noShade SIZE="1" style="color: white">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="665" align="center" border="0" style="border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge">
                <tr>
                    <td rowspan="" style="height: 0px; width: 946px; text-align: right;">
                        <table>
                            <tr>
                                <td style="vertical-align: middle; width: 12%; text-align: left; background-color: #80aee1;">
                                    <asp:Label ID="practiceNameLabel" runat="server" Text="Label" Width="100%" Font-Size="Medium" ForeColor="White"></asp:Label></td>
                                <td style="vertical-align: top; width: 20%; text-align: right; background-color: #80aee1;" rowspan="">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="font-weight: bold; vertical-align: middle; color: #006daa; text-align: right; width: 70%;">
                                                <img src="TimeRemaining.gif" style="vertical-align: middle" />Time Remaining</td>
                                            <td style="vertical-align: middle; width: 30%; text-align: center">
									    <IMG height="21" src="images/clock/nb.gif" width="16" name="hour1">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="hour2"><IMG height="21" src="images/clock/nc.gif" width="9" name="colon"><IMG height="21" src="images/clock/nb.gif" width="16" name="minute1"><IMG height="21" src="images/clock/nb.gif" width="16" name="minute2"><IMG height="21" src="images/clock/nc.gif" width="9" name="colon"><IMG height="21" src="images/clock/nb.gif" width="16" name="second1"><IMG height="21" src="images/clock/nb.gif" width="16" name="second2"></td>
                                        </tr>
                                    </table>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                </td>
                                            <td style="height: 27px">
                                                </td>
                                            <td style="height: 27px; width: 1px;">
                                                </td>
                                            <td style="height: 27px">
                                                <IMG src="FlagForReview.gif" onclick = "reviewFlag_Click()" style="cursor: hand" name="reviewFlagImg"/></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="answerCheckImageButton" runat="server" ImageUrl="~/CheckAnswer.gif" Visible="False" /></td>
                                            <td>
                                                <asp:ImageButton ID="showAnswerImageButton" runat="server" ImageUrl="~/ShowAnswer.gif" Visible="False" /></td>
                                            <td style="height: 27px; width: 1px;">
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="explainAnswer" runat="server" ImageUrl="~/ExplainAnswer.gif" O Visible="False" OnClick="explainAnswer_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Panel ID="questionTextPanel" runat="server" BackColor="White" BorderColor="White"
                                        BorderWidth="1px" GroupingText="Question" Height="100%">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <tr>
								
									<TD style="background-color: white; height: 69px;">
										<asp:Panel id="questionPanel" runat="server">
											<asp:Image id="questionImage" runat="server"></asp:Image>
										</asp:Panel></TD>
									<TD style="background-color: white; height: 69px;" colspan="">
										<asp:Panel id="passagePanel" runat="server">
											<asp:Image id="passageImage" runat="server"></asp:Image>
										</asp:Panel></TD>
                                </tr>
								
							</TABLE>
                                    </asp:Panel>
                                            <asp:Panel id="explanationPanel" runat="server" BackColor="White" BorderColor="White" Width="100%" GroupingText="Explanation" BorderWidth="1px">
                                                <asp:Image ID="explanationImage" runat="server" />
                                            </asp:Panel>
                                <asp:panel id="Panel" runat="server" Width="100%" BackColor="White" BorderColor="White" BorderWidth="1px" GroupingText="Answers">
							<asp:RadioButtonList id="answerRadioButtonList" runat="server" onselectedindexchanged = "answerRadioButtonList_SelectedIndexChanged"></asp:RadioButtonList>
						</asp:panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>				
                <tr>
                    <td rowspan="1" style="width: 946px; height: 0px; text-align: right">
                    </td>
                </tr>
			</TABLE>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" align="center" border="0" style="width: 665px;">
				<TR>
					<TD style="height: 31px; width: 9%;">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="45" align="left" border="0">
							<TR>
								<TD style="width: 79px">
						<asp:imagebutton id="exitImageButton" runat="server" ImageUrl="~/EndExam.gif" OnClick="exitImageButton_Click"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
                    <td style="width: 7%; height: 31px">
                        <asp:ImageButton ID="reviewImageButton" runat="server" ImageUrl="~/ReviewAll.gif" /></td>
					<TD style="height: 31px; width: 7%;">
						<asp:imagebutton id="helpImageButton" runat="server" ImageUrl="~/Help.gif" OnClick="helpImageButton_Click"></asp:imagebutton></TD>
					<TD style="vertical-align: text-bottom; text-align: center; height: 31px; background-color: #006daa; width: 248px;">
					</TD>
					<TD width="5%" style="height: 31px">
                        </TD>
					<TD width="5%" style="height: 31px">
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><asp:imagebutton id="prewImageButton" runat="server" ImageUrl="~/Previous.gif" OnClick="prewImageButton_Click"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 5%; height: 31px">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD style="height: 27px"><asp:imagebutton id="nextImageButton" runat="server" ImageUrl="~/Next.gif" OnClick="nextImageButton_Click" EnableTheming="True"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1" style="border-left-color: white; border-bottom-color: white; border-top-style: solid; border-top-color: white; border-right-style: solid; border-left-style: solid; border-right-color: white; border-bottom-style: solid">
			<TABLE id="Table12" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD style="FONT-SIZE: 12px; TEXT-TRANSFORM: none; FONT-STYLE: italic; FONT-VARIANT: normal; width: 120px; color: white; height: 17px;">@2006 
						GMATClubTest</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
