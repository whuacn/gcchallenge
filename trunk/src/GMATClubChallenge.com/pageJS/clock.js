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
