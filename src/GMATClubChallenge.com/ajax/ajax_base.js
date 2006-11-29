function getHTTPObject() {
var objXMLHttp=null
if (window.XMLHttpRequest)
{
   objXMLHttp=new XMLHttpRequest();
}
else if (window.ActiveXObject)
{
   objXMLHttp=new ActiveXObject("Microsoft.XMLHTTP");
}
return objXMLHttp;
}

var http = getHTTPObject();


function exec_http_req(remote_handler,vars,handler)
{
   var url = "handler.ajx?handler_name="+encodeURI(remote_handler);
   var h_part="";
   if(null!=vars)
   {
      for(i=0;i<vars.length;i+=2)
      {
         h_part+=("&"+encodeURI(vars[i])+"="+encodeURI(vars[i+1]));
      }
      if(""!=h_part)
      {
         url+=h_part;
      }
   }
   http.open("GET", url, true);
   http.setRequestHeader("If-Modified-Since", "Sat, 1 Jan 2000 00:00:00 GMT");
   http.onreadystatechange = function()
   {      
      if(http.readyState == 4) 
      {
         if(http.responseText.indexOf("error:")==0)
         {
            handler( http.responseText.substr(6,http.responseText.length-6) , null);
         }
         else
         {
            handler( null , http);
         };
      }
   }
   http.send(null);  
}


var m_controller=null;

function getMouseXY(event) 
{
   if(!event) event=window.event;
   dragger.update(event);
   if(m_controller)
   {
      m_controller.handle();
   }
   return true;
}  
