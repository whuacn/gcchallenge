using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using GMATClubTest.Web;
using Manco.Chart;
using Manco.Chart.Data;

public partial class UserChart : BasePage
{
   protected void Page_Load(object sender, EventArgs e)
   {
      base.Page_Load(sender,e);
      drawChart();
   }
   
   protected void drawChart()
   {
      int qType=1;
      try
      {
         qType=Int32.Parse(Request["t"].ToString());
      }
      catch (Exception )
      {
      	
      }
        


      string sWidth = Request.QueryString["w"];
      string sHeight = Request.QueryString["h"];
       if(sWidth == null)
       {
           sWidth = "10";
       }
       if (sHeight == null)
       {
           sHeight = "10";
       }
      Size imageSize = new Size(Int32.Parse(sWidth), Int32.Parse(sHeight));
       
       
      ChartControl control = new ChartControl();
      control.HttpServer = this.Server;
      control.Size = imageSize;

      XmlDocument xmlChartDocument = new XmlDocument();
      ResourceLoader.WebServer = this.Server;
      Stream stream = ResourceLoader.GetFileStream("charts/UserChart.xml");
      xmlChartDocument.Load(stream);
      stream.Close();

      control.LoadTheme(xmlChartDocument["Charts"]);



      SqlCommand cmd = connection_.CreateCommand();
      cmd.CommandText = "select idx,user_idx,measured,q_type,result from StatisticResult where user_idx=@UserId order by measured desc;";
      cmd.Parameters.Add(new SqlParameter("@UserId", base.access_manager_.UserId));

      int liCategoryCount = 7;	// Set desirable number of the categories
      int liSeriesCount = 1;		// Set desirable number of the series
      double[,] ldaData = new double[liCategoryCount, liSeriesCount];
      DateTime[] dates=new DateTime[liCategoryCount];

      using (SqlDataReader reader = cmd.ExecuteReader())
      {
         int cnt = 6;
         while (reader.Read())
         {
            if ((int)reader[3] == qType)
            {
               ldaData[cnt, 0] = (int)reader[4];
               DateTime d = (DateTime)reader[2];
               dates[cnt]=d;
               cnt--;
               if (cnt < 0) break;
            }


         }
         reader.Close();
      }

      
      // Declare array of doubles
      


      IChartDataSource loDataSource = new ArrayDataSource(ldaData, DataOrientation.CategoryInRow);


      control.Charts[0].LoadData(loDataSource, false, true);

      for (int i = 0; i < liCategoryCount; ++i)
      {
         DateTime d=dates[i];
         control.Charts[0].Layout.Categories[i].Title.Text = d.Day.ToString() + "/" + d.Month.ToString();   
      }
      
      


control.Charts[0].Name="asdsad";

      control.Draw();


      MemoryStream imageStream = new MemoryStream();
      control.Image.Save(imageStream, ImageFormat.Png);


      // return byte array to caller with image type
      Response.ContentType = "image/png";
      Response.BinaryWrite(imageStream.GetBuffer());

      // Don't forget to dispose chart control after use.
      control.Dispose();   
   }
}
