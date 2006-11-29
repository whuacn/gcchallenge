var curdd="";

function hide_cur_dd()
{
   if(curdd=="") return;
   var elt=document.getElementById(curdd);
   if(!elt) return;
   elt.style.display='none';
};
function show_dd(dd_container_name)
{
   hide_cur_dd(curdd);
   curdd=dd_container_name+"_dd";
   document.getElementById(curdd).style.display='';
}