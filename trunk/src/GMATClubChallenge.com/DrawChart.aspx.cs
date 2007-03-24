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
using Manco.Chart;
using System.Drawing;
using System.Xml;
using System.IO;

public partial class DrawChart : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      Manco.Chart.ChartControl control = new ChartControl();
      control.Size = new Size(Int32.Parse(Request["w"]),Int32.Parse(Request["h"]));
      control.BackColor = Color.White;
      control.HttpServer = this.Server;

      //control.WebPage = this;

        XmlDocument d = new XmlDocument();
        d.Load(HttpContext.Current.Server.MapPath("charts/IntroChart.xml"));
        
        
        
      control.ChartDocument = d;
	   double[,] ldaData = new double[8,1];

      for(int i=0;i<8;++i)
      {
         ldaData[i,0]=i+2;
      }
	   // Load array to the chart
	   Manco.Chart.Layouts.Layout loLayout = (Manco.Chart.Layouts.Layout)control.ComponentLayout.LayoutList[0];
	   loLayout.LoadData(ldaData, false, true);

	
      control.Draw();
      System.IO.MemoryStream ms=new System.IO.MemoryStream();
      control.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
      
      Response.ContentType="image/png";
      Response.BinaryWrite(ms.GetBuffer());
   }
}
