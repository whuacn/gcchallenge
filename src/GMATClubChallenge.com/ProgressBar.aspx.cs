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


public partial class ProgressBar : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      int w=Int32.Parse(Request["w"]);
      int h=Int32.Parse(Request["h"]);
      int p=Int32.Parse(Request["p"]);
      Bitmap b=new Bitmap(w,h);
      Graphics g = Graphics.FromImage(b);


      Color used = Color.FromArgb(unchecked((int)0xFFFFD940));
      Color back = Color.FromArgb(unchecked((int)0xFFF2C202));
      
      g.FillRectangle(new SolidBrush(back), new Rectangle(0, 0, w, h));

      g.FillRectangle(new SolidBrush(used), new Rectangle(0, 0, w * p / 100, h));
      g.DrawRectangle(Pens.Gray, new Rectangle(0, 0, w * p / 100, h - 1));

      g.DrawRectangle(Pens.Black, new Rectangle(0, 0, w - 1, h - 1));
      
      g.DrawString(p.ToString()+"%",new Font(FontFamily.GenericSansSerif,10,FontStyle.Bold),new SolidBrush(Color.Black),new PointF(w-40,(h-2)/2-5-1));

      using(System.IO.MemoryStream ms=new System.IO.MemoryStream())
      {
         b.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
         Response.ContentType = "image/png";
         Response.BinaryWrite(ms.GetBuffer());
      }

   }
}
