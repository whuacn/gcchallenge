 function do_logof()
{
   var url=window.location.href;
   if(url.indexOf("?")!=-1)
   {
      url+="&logoff=true";
   }
   else
   {
      url+="?logoff=true";
   };
   window.location=url;
} 

function do_login()
{
   var url=window.location.href;
   if(url.indexOf("?")!=-1)
   {
      url+="&";
   }
   else
   {
      url+="?";
   };
   document.login_form.action=window.location.href;
   document.login_form.submit();
}

if(window.location.href.indexOf("logoff=true")!=-1)
{
   window.location.href="Default.aspx";
}
if(document.getElementById('login_error')) document.getElementById('login_error').innerHTML="";

function show_login_error(txt)
{
   document.getElementById('login_error').innerHTML=txt;
   document.getElementById('login_error').style.display='';
}
