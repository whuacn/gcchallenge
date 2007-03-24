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
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GMATClubTest.Web;
using Manco.Chart;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Data.SqlClient;


public partial class UserChart : BasePage
{
   protected void Page_Load(object sender, EventArgs e)
   {
      base.Page_Load(sender,e);
      drawChart();
   }
   
   protected void drawChart()
   {

      SqlCommand cmd=connection_.CreateCommand();
      cmd.CommandText="select idx,user_idx,measured,q_type,result from StatisticResults where user_idx=@UserId;";
      
      
      
      Manco.Chart.ChartControl control = new ChartControl();
      control.Size = new Size(Int32.Parse(Request["w"]), Int32.Parse(Request["h"]));
      control.BackColor = Color.White;
      control.HttpServer = this.Server;

      XmlDocument d = new XmlDocument();
      d.Load(HttpContext.Current.Server.MapPath("charts/UserChart.xml"));

      control.ChartDocument = d;
      double[,] ldaData = new double[8, 1];

      for (int i = 0; i < 8; ++i)
      {
         ldaData[i, 0] = i + 2;
      }
      
      // Load array to the chart
      Manco.Chart.Layouts.Layout loLayout = (Manco.Chart.Layouts.Layout)control.ComponentLayout.LayoutList[0];
      loLayout.LoadData(ldaData, false, true);

      control.Draw();
      System.IO.MemoryStream ms = new System.IO.MemoryStream();
      control.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

      Response.ContentType = "image/png";
      Response.BinaryWrite(ms.GetBuffer());
   }
}
