using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class Rating : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      int r=Int32.Parse(Request["r"]);
      float s=((float)r*(float)5.0)/(float)100.0;
      int fn=(int)s/10;
      Response.Redirect(String.Format("i/stars/stars{0}.gif",fn));
      

      /*Response.ContentType="image/gif";
      
      Bitmap b=new Bitmap(16*5,16);
      Graphics g=Graphics.FromImage(b);
      Bitmap b_star = new Bitmap(Server.MapPath("./i/stars/b_star.gif"));
      
      Bitmap h_star = new Bitmap(Server.MapPath("./i/stars/h_star.gif"));
      
      Bitmap f_star = new Bitmap(Server.MapPath("./i/stars/f_star.gif"));
      
      
      b_star.MakeTransparent(b_star.GetPixel(1, 1));
      h_star.MakeTransparent(h_star.GetPixel(1, 1));
      f_star.MakeTransparent(f_star.GetPixel(1, 1));

      
      
      g.FillRectangle(Brushes.White,0,0,16*5,16);
      
      for(int i=0;i<5;++i)
      {
         if (i < (int)s) g.DrawImage(f_star, i * 16, 0, 16, 16);
         
         if( i == (int)s)
         {
            float c=s-((float)(int)s);
            if (c < 0.2) g.DrawImage(b_star, i * 16, 0, 16, 16);
            if (c >= 0.2 && c < 0.8) g.DrawImage(h_star, i * 16, 0, 16, 16);
            if (c >= 0.8) g.DrawImage(f_star, i * 16, 0, 16, 16);
         }

         if (i > (int)s) g.DrawImage(b_star, i * 16, 0, 16, 16);
      }
      
      b.MakeTransparent(Color.White);

      using(System.IO.MemoryStream ms = new System.IO.MemoryStream())
      {
         b.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
         Response.ContentType = "image/gif";
         Response.BinaryWrite(ms.GetBuffer());
      }   */
   }
}
