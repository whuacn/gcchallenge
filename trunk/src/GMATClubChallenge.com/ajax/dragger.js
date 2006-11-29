
var dragger=new Object();

dragger.mouseX = 0;
dragger.mouseY = 0;
dragger.update=function(evt)
{
  var scrOfX = 0, scrOfY = 0;
  if( typeof( window.pageYOffset ) == 'number' ) {
    //Netscape compliant
    scrOfY = window.pageYOffset;
    scrOfX = window.pageXOffset;
  } else if( document.body && ( document.body.scrollLeft || document.body.scrollTop ) ) {
    //DOM compliant
    scrOfY = document.body.scrollTop;
    scrOfX = document.body.scrollLeft;
  } else if( document.documentElement && ( document.documentElement.scrollLeft || document.documentElement.scrollTop ) ) {
    //IE6 standards compliant mode
    scrOfY = document.documentElement.scrollTop;
    scrOfX = document.documentElement.scrollLeft;
  }
  this.mouseX = evt.clientX + scrOfX;
  this.mouseY = evt.clientY + scrOfY;
}


dragger.start_drag=function(obj)
{
   this.object=obj;
   this.xo=this.mouseX-parseInt(obj.style.left);
   this.yo=this.mouseY-parseInt(obj.style.top);
   m_controller=dragger;
}     


dragger.stop_drag=function()
{
   this.object=null;
   this.xo=null;
   this.yo=null;
   m_controller=null;
}     

dragger.handle=function()
{
   if(!this.object) return;
   this.object.style.left=this.mouseX-this.xo;
   this.object.style.top=this.mouseY-this.yo;
}     

