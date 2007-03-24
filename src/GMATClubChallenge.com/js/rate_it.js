function handle_rate_move(where,p)
{
   if(p==null || p==1)
   {
      var s=event.offsetX*100/80;
      where.title=s.toString().split('.')[0]+"%";
      document.getElementById(where.id+"_div").innerText=where.title;
   }
}
function handle_rate_out(where)
{
   document.getElementById(where.id+"_div").innerHTML="&nbsp;";
}

function handle_rate_click(where)
{
   
   var idx=where.alt;
   var new_vote=event.offsetX*100/80;
   exec_http_req(
      "StatisticCollector::rate_it", new Array("idx",idx,"vote",new_vote),
      function(error,http)
      {
         if(error)
         {
            alert(error);
         }
         else
         {

            var str=((parseInt(http.ResponseText)+9)/10).toString();
            where.src="i/stars/stars"+str.split('.')[0]+".gif";
         }
      });
         

   //document.getElementById(where.id+"_div").innerHTML="&nbsp;";
}
