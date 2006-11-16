<%@ Page language="c#" Inherits="GMATClubTest.Web.Migrated_PracticeGeneralWebForm" CodeFile="PracticeWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMAT Club Test - Practice</title>
	    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">	
		var dateStart = new Date();
function onStart()
{
	dateStart = new Date();
	//window.setTimeout('clock();',100)
	clock();
}

function clock() {
  dateNow = new Date();
  hh = dateNow.getHours() - dateStart.getHours();
 
  mm = dateNow.getMinutes() - dateStart.getMinutes();
  if (mm<0)
  {
	hh=hh-1;
	if (hh<0)
	{
		hh=hh+24;
	}
	mm=mm+60;
  }
  ss = dateNow.getSeconds() - dateStart.getSeconds();
  if (ss<0)
  {
	mm=mm-1;
	if (mm<0)
	{
		hh=hh-1;
		mm=mm+60;
		if (hh<0)
		{
			hh=hh+24;
		}
	 }
	ss=ss+60;
  }
  
  
  rhh = document.Form1.timehh.value - hh;
  if (rhh<0)
  {
	rhh=rhh+24;
  }
  rmm = document.Form1.timemm.value - mm;
   if (rmm<0)
  {
	rhh=rhh-1;
	if (rhh<0)
	{
		rhh=rhh+24;
	}
	rmm=rmm+60;
  }
  rss = document.Form1.timess.value - ss;
  if (rss<0)
  {
	rmm=rmm-1;
	if (rmm<0)
	{
		rhh=rhh-1;
		rmm=rmm+60;
		if (rhh<0)
		{
			rhh=rhh+24;
		}
	 }
	rss=rss+60;
  }
  

  hh = rhh;
  mm = rmm;
  ss = rss;

  document.images['hour1'].src ="images/clock/" + Url(hh/10);
  document.images['hour2'].src ="images/clock/" + Url(hh%10);
  document.images['minute1'].src = "images/clock/"+ Url(mm/10);
  document.images['minute2'].src = "images/clock/"+ Url(mm%10);
  document.images['second1'].src = "images/clock/"+ Url(ss/10);
  document.images['second2'].src = "images/clock/"+ Url(ss%10);

  if (hh+mm+ss == 0)
  {
	alert("You time by this section is up!");
	document.Form1.isAnswerConfirm.value = "sectionExit";
	document.Form1.submit(''); 	
  }
  window.setTimeout("clock()",1000);
}

function Url(num)
 {
	 num = Math.floor(num);
	return "n" + num + ".gif";
  }
		</script>
	</HEAD>
	<body onload="onStart()" bgcolor="#006daa">
		<form id="Form1" metod="post" runat="server">
			<INPUT id="isAnswerConfirm" type="hidden" value="false" name="isAnswerConfirm">
			<%=clockHiddenParam%>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" align="center" border="0" style="border-left-color: white; border-bottom-color: white; width: 100%; border-top-color: white; border-right-color: white;">
				<TR>
					<TD align="left" width="20%" style="height: 137px;"></TD>
					<TD align="center" width="40%" style="height: 137px; width: 100%;">
                        <table id="Table3" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td style="width: 290px">
                                    <img align="left" alt="" height="136" src="images/gmatclub.jpg" width="280" /></td>
                            </tr>
                        </table>
						<asp:label id="timeLabel" runat="server" CssClass="Title" ForeColor="White"></asp:label><asp:label id="statusLabel" runat="server" CssClass="Title" Font-Bold="True" ForeColor="AliceBlue"></asp:label></TD>
					<TD align="left" style="width: 20%; height: 137px; background-color: #006daa;">
						<P>
                            &nbsp;</P>
						<P><asp:hyperlink id="loginStatusHyperLink" runat="server" Visible="False" ForeColor="White">[loginStatusHyperLink]</asp:hyperlink></P>
					</TD>
				</TR>
			</TABLE><HR width="100%" noShade SIZE="1" style="color: white">
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="660" align="center" border="0" style="border-top-style: ridge; border-right-style: ridge; border-left-style: ridge; border-bottom-style: ridge">
                <tr>
                    <td rowspan="" style="height: 0px; width: 946px; text-align: right;">
                        <table>
                            <tr>
                                <td style="vertical-align: middle; width: 17%; text-align: left; height: 44px; background-color: #80aee1;">
                                    <asp:Label ID="practiceNameLabel" runat="server" Text="Label" Width="100px"></asp:Label></td>
                                <td style="vertical-align: top; width: 20%; text-align: right; height: 44px; background-color: #80aee1;">
                                    <table>
                                        <tr>
                                            <td style="font-weight: bold; vertical-align: middle; color: #006daa; text-align: right">
                                                <img src="TimeRemaining.gif" style="vertical-align: middle" />Time Remaining</td>
                                            <td>
									    <IMG height="21" src="images/clock/nb.gif" width="16" name="hour1">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="hour2"><IMG height="21" src="images/clock/nc.gif" width="9" name="colon"><IMG height="21" src="images/clock/nb.gif" width="16" name="minute1"><IMG height="21" src="images/clock/nb.gif" width="16" name="minute2"><IMG height="21" src="images/clock/nc.gif" width="9" name="colon"><IMG height="21" src="images/clock/nb.gif" width="16" name="second1"><IMG height="21" src="images/clock/nb.gif" width="16" name="second2"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>				
					<TD style="width: 946px; height: 103px"><asp:panel id="Panel" runat="server" Width="100%" BackColor="White" BorderColor="White">
							<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="650" border="0">
								
									<TD style="height: 55px">
										<asp:Panel id="questionPanel" runat="server">
											<asp:Image id="questionImage" runat="server"></asp:Image>
										</asp:Panel></TD>
									<TD style="height: 55px">
										<asp:Panel id="passagePanel" runat="server">
											<asp:Image id="passageImage" runat="server"></asp:Image>
										</asp:Panel></TD>
								
							</TABLE>
							<asp:RadioButtonList id="answerRadioButtonList" runat="server" onselectedindexchanged = "answerRadioButtonList_SelectedIndexChanged"></asp:RadioButtonList>
						</asp:panel></TD>				
			</TABLE>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" align="center" border="0" style="width: 662px;">
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
                        <asp:ImageButton ID="answerCheckImageButton" runat="server" ImageUrl="~/CheckAnswer.gif" /></TD>
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
								<TD><asp:imagebutton id="nextImageButton" runat="server" ImageUrl="~/Next.gif" OnClick="nextImageButton_Click" BorderStyle="Solid" EnableTheming="True"></asp:imagebutton></TD>
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
