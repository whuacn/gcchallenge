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
using Manco.Chart.Data;
using System.Drawing;
using System.Xml;
using System.IO;

public partial class DrawChart : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

      // Get char width and height from the query string
      string sWidth = Request.QueryString["w"];
      string sHeight = Request.QueryString["h"];
      Size imageSize=new Size(Int32.Parse(sWidth),Int32.Parse(sHeight));
      

      ChartControl control = new ChartControl();
      control.HttpServer = this.Server;
      control.Size = imageSize;

      XmlDocument xmlChartDocument = new XmlDocument();
      ResourceLoader.WebServer = this.Server;
      Stream stream = ResourceLoader.GetFileStream("charts/UserChart.xml");
      xmlChartDocument.Load(stream);
      stream.Close();
      
      control.LoadTheme(xmlChartDocument["Charts"]);


      int liCategoryCount = 7;	// Set desirable number of the categories
      int liSeriesCount = 1;		// Set desirable number of the series

      // Declare array of doubles
      double[,] ldaData = new double[liCategoryCount, liSeriesCount];

      // Fill array with data here
      // ....
      for (int j = 0; j < liCategoryCount; ++j)
      {
         ldaData[j, 0] = j;
      }


      IChartDataSource loDataSource = new ArrayDataSource(ldaData, DataOrientation.CategoryInRow);
      
      
      control.Charts[0].LoadData(loDataSource, false, true);

      for (int i = 0; i < liCategoryCount; ++i)
      {
         control.Charts[0].Layout.Categories[i].Title.Text = "Cat" + i.ToString();
      }
      
      
      
      
      
      
      control.Draw();


      MemoryStream imageStream = new MemoryStream();
      control.Image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);


      // return byte array to caller with image type
      Response.ContentType = "image/png";
      Response.BinaryWrite(imageStream.GetBuffer());

      // Don't forget to dispose chart control after use.
      control.Dispose();   

   }
}
