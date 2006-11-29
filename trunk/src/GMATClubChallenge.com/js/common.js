       function show_close_button()
       {
         document.getElementById('close_id').style.position='absolute';
         document.getElementById('close_id').style.left=500-17;
         document.getElementById('close_id').style.top=2;
         document.getElementById('close_id').style.zIndex=1000;
       };
       
       function show_data(data,is_error)
       {
         var elt;
         if(is_error)
         {
            elt=document.getElementById('op_e_place');
         }
         else
         {
            document.getElementById('op_e_place').innerHTML="";
            elt=document.getElementById('c_place');         
         };
         
         elt.innerHTML=data;
       };

function show_ajax_window(left_offset)
{
      if(null==left_offset) left_offset=500;
      var elt=document.getElementById("cnt");
      
      if(null==elt) return false;
      elt.style.left=dragger.mouseX - left_offset +'px';
      elt.style.top=dragger.mouseY +'px';
      elt.style.position='absolute';
      elt.style.visibility='';
      elt.style.zIndex=100;
      
      show_close_button(dragger.mouseX,dragger.mouseY);
}

function on_response(error,http,left_offset)
{
  if(null!=error)
  {
     show_data(error,true);
  }
  else
  {
     show_data(http.responseText,false);
  }
  show_ajax_window(left_offset);
}
