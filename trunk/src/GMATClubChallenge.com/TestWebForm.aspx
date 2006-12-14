<%@ Page language="c#" Inherits="GMATClubTest.Web.Migrated_TestWebForm" CodeFile="TestWebForm.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GMATClubTest - Test</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">	
		var dateStart = new Date();
function onStart()
{
	dateStart = new Date();
	//window.setTimeout('clock();',1000)
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



function nextClick()
{
	<%=nextClickScript%>
}			
function answerConfirmClick()
{
	<%=answerConfirmClickScript%>
}

function exitClick()
{
	if (confirm("You will not be able to continue the test. Do you really want to exit?"))
	{ 
		document.Form1.isAnswerConfirm.value = "exit";
		document.Form1.submit(''); 
	}
}
function sectionExitClick()
{
	if (confirm("You will not be able to return to this section. Do you really want to exit from the current section?")) 
	 {
		document.Form1.isAnswerConfirm.value="sectionExit";
		document.Form1.submit('');
	 }
            }
            

		</script>
	</HEAD>
	<body onload="onStart()" style="text-align: center;" bgcolor="#026caa">
		<form id="Form1" method="post" runat="server">
			<INPUT id="isAnswerConfirm" type="hidden" value="false" name="isAnswerConfirm">
			<%=clockHiddenParam%>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="739" align="center" border="0">
				<TR>
					<TD align="left" width="20%"></TD>
					<TD align="center" style="width: 40%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD><IMG height="136" alt="" src="images/gmatclub.jpg" width="280"
										align="left"></TD>
							</TR>
						</TABLE>
						<asp:label id="statusLabel" runat="server" CssClass="Title" ForeColor="White"></asp:label></TD>
					<TD align="left" width="20%">
						<P>
                            &nbsp;</P>
						<P><asp:hyperlink id="loginStatusHyperLink" runat="server" Visible="False" ForeColor="White">[loginStatusHyperLink]</asp:hyperlink></P>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
            <table style="border-top-style: groove; border-right-style: groove; border-left-style: groove;
                text-align: center; border-bottom-style: groove">
                <tr>
                    <td style="width: 48px">
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="660" align="center" border="0" style="background-color: #ffffff">
				<tr>
                    <td rowspan="" style="height: 0px; width: 946px; text-align: right;">
                        <table>
                           <tr> 
                                <td style="vertical-align: middle; width: 21%; text-align: left; height: 44px; background-color: #80aee1;">
                                    <asp:Label ID="testNameLabel" runat="server" Font-Bold="True" Font-Italic="False"
                                        Font-Size="Medium" ForeColor="White"></asp:Label></td>
                                <td style="vertical-align: middle; width: 20%; text-align: right; height: 44px; background-color: #80aee1;">
                                    <table>
                                        <tr>
                                            <td style="font-weight: bold; vertical-align: middle; color: #006daa; text-align: right">
                                                <img src="TimeRemaining.gif" style="vertical-align: middle" />Time Remaining</td>
                                            <td>
                                                &nbsp;<IMG height="21" src="images/clock/nb.gif" width="16" name="hour1"><IMG height="21" src="images/clock/nb.gif" width="16" name="hour2"><IMG height="21" src="images/clock/nc.gif" width="9" name="colon"><IMG height="21" src="images/clock/nb.gif" width="16" name="minute1"><IMG height="21" src="images/clock/nb.gif" width="16" name="minute2"><IMG height="21" src="images/clock/nc.gif" width="9" name="colon"><IMG height="21" src="images/clock/nb.gif" width="16" name="second1"><IMG height="21" src="images/clock/nb.gif" width="16" name="second2"></td>
                                        </tr>
                                    </table>
                               </td>  
                            </tr>
                        </table>
                    </td>
                </tr>	
				
				
				<!--<TR> -->
					<TD style="height: 139px"><asp:panel id="Panel" runat="server" Width="100%">
							<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="650" border="0">
								<TR>
								
									<TD>
										<asp:Panel id="questionPanel" runat="server">
											<asp:Image id="questionImage" runat="server"></asp:Image>
										</asp:Panel></TD>
									<TD>
										<asp:Panel id="passagePanel" runat="server">
											<asp:Image id="passageImage" runat="server"></asp:Image>
										</asp:Panel>
                              </TD>
								</TR>
							</TABLE>
							<asp:RadioButtonList id="answerRadioButtonList" runat="server"></asp:RadioButtonList>
						</asp:panel></TD>
				<!--</TR>-->
			</TABLE>
                    </td>
                </tr>
            </table>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="660" align="center" border="0">
				<TR>
					<TD width="5%">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="45" align="left" border="0">
							<TR>
								<TD><IMG id="exit" onclick="exitClick()" alt="" src="EndExam.gif" style="cursor: hand"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="5%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="45" align="left" border="0">
							<TR>
								<TD><IMG id="sectionExit" onclick="sectionExitClick()" alt="" src="EndReview.gif" style="cursor: hand"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="40%">
					</TD>
					<TD width="5%">
						<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><asp:imagebutton id="helpImageButton" runat="server" ImageUrl="~/Help.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="5%">
						<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><IMG  id="answerConfirmImg" onclick="answerConfirmClick()" alt="" src="images/_answerConfirm.gif" style="cursor: hand"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 5%">
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="45" align="right" border="0">
							<TR>
								<TD><IMG  id="nextButton" onclick="nextClick()" src="Next.gif"
										name="next" style="cursor: hand"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<HR width="100%" noShade SIZE="1">
			<TABLE id="Table12" cellSpacing="1" cellPadding="1" align="center" border="0">
				<TR>
					<TD style="FONT-SIZE: 12px; TEXT-TRANSFORM: none; FONT-STYLE: italic; FONT-VARIANT: normal; width: 129px; color: #ffffff; height: 17px;">@2006 
						GMATClubTest</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
