using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using GmatClubTest.Data;

namespace GmatClubTest.BusinessLogic
{
   public class CustomTestsLogic
   {
      public static string list_tests(System.Data.SqlClient.SqlConnection conn)
      {
         System.IO.TextWriter tw=new System.IO.StringWriter();
         list_tests_(conn).WriteXml(tw);
         return tw.ToString();
      }

      protected static GmatClubTest.Data.TestSet list_tests_(System.Data.SqlClient.SqlConnection conn)
      {
         GmatClubTest.Data.TestSet set = new GmatClubTest.Data.TestSet();
         
         SqlDataAdapter ad=new SqlDataAdapter ("select * from Tests;",conn);
         ad.Fill(set.Tests);
         return set;
      }
      
   }
}