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
	<body onload="onStart()">
		<form id="Form1" metod="post" runat="server">
			<INPUT id="isAnswerConfirm" type="hidden" value="false" name="isAnswerConfirm">
			<%=clockHiddenParam%>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="739" align="center" border="0">
				<TR>
					<TD align="left" width="20%" style="height: 160px"></TD>
					<TD align="center" width="40%" style="height: 160px">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><IMG height="136" alt="" src="images/gmatclub.jpg" width="280"
										align="left"></TD>
							</TR>
						</TABLE>
						<asp:label id="timeLabel" runat="server" CssClass="Title"></asp:label><asp:label id="statusLabel" runat="server" CssClass="Title" Font-Bold="True" ForeColor="DarkBlue"></asp:label></TD>
					<TD align="left" style="width: 20%; height: 160px;">
						<P>
                            &nbsp;</P>
						<P><asp:hyperlink id="loginStatusHyperLink" runat="server" Visible="False">[loginStatusHyperLink]</asp:hyperlink></P>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="660" align="center" border="0">
				<TR>
					<TD><asp:panel id="Panel" runat="server" Width="100%">
							<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="650" border="0">
								<TR>
									<TD>
										<asp:Panel id="questionPanel" runat="server">
											<asp:Image id="questionImage" runat="server"></asp:Image>
										</asp:Panel></TD>
									<TD>
										<asp:Panel id="passagePanel" runat="server">
											<asp:Image id="passageImage" runat="server"></asp:Image>
										</asp:Panel></TD>
								</TR>
							</TABLE>
							<asp:RadioButtonList id="answerRadioButtonList" runat="server" onselectedindexchanged = "answerRadioButtonList_SelectedIndexChanged"></asp:RadioButtonList>
						</asp:panel></TD>
				</TR>
			</TABLE>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="660" align="center" border="0">
				<TR>
					<TD width="5%">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="45" align="left" border="0">
							<TR>
								<TD><asp:imagebutton id="exitImageButton" runat="server" ImageUrl="images/exitButton.gif" OnClick="exitImageButton_Click"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="5%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="45" align="left" border="0">
							<TR>
								<TD><asp:imagebutton id="reviewImageButton" runat="server" ImageUrl="images/reviewButton.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="40%">
						<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><asp:imagebutton id="answerCheckImageButton" runat="server" ImageUrl="images/answerCheckButton.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
						<TABLE id="clockTable" cellSpacing="1" cellPadding="1" align="center" border="0">
							<TR>
								<TD>
									<P><IMG height="21" src="images/clock/nb.gif" width="16" name="hour1">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="hour2">
										<IMG height="21" src="images/clock/nc.gif" width="9" name="colon">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="minute1">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="minute2">
										<IMG height="21" src="images/clock/nc.gif" width="9" name="colon">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="second1">
										<IMG height="21" src="images/clock/nb.gif" width="16" name="second2">
									</P>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="5%">
						<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><asp:imagebutton id="helpImageButton" runat="server" ImageUrl="images/helpButton.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="5%">
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><asp:imagebutton id="prewImageButton" runat="server" ImageUrl="images/prevButton.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="5%">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><asp:imagebutton id="nextImageButton" runat="server" ImageUrl="images/nextButton.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table12" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD style="FONT-SIZE: 12px; TEXT-TRANSFORM: none; FONT-STYLE: italic; FONT-VARIANT: normal">@2006 
						GMATClubTest</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
