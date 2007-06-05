using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data.SqlClient;

using GMATClubTest.Web;

public partial class MistakesTest : GMATClubTest.Web.BasePage
{
   protected void Page_Load(object sender, EventArgs e)
   {
      base.Page_Load(sender,e);
      //DateTime fr=DateTime.Parse(;
      IFormatProvider culture = new CultureInfo("en-US", true);
      DateTime fr=DateTime.Parse(Request["fr"].ToString(),culture,DateTimeStyles.AllowWhiteSpaces);
      DateTime to=DateTime.Parse(Request["to"].ToString(),culture,DateTimeStyles.AllowWhiteSpaces);
      int type=Int32.Parse(Request["type"].ToString());
      string name=Request["name"].ToString();
      Response.Redirect(String.Format("StartTest.aspx?idx={0}&type=test&pkg_idx=-1",composeCustomTest(fr,to,type,name)));
   }
   
   public override string current_function_name()                          
   {
      return "Common_Page";
   }
   protected int composeCustomTest(DateTime fr,DateTime to,int type,string qtypename)
   {
      {
      
         SqlCommand cmd=connection_.CreateCommand();   
         cmd.CommandText=String.Format("select idx from CustomTests where mistakes=1 and author={0}",access_manager_.UserId);
         object o=cmd.ExecuteScalar();
         
         if(null!=o && o.GetType()!=typeof(DBNull))
         {
            SqlCommand cmd_del=connection_.CreateCommand();     
            cmd_del.CommandText=String.Format(
@"delete from customtests where Test_Id={0};
  delete from questionsets where id in (select questionsetid from TestContents where testid={0}); 
  delete from tests where Id={0};"
  ,o.ToString());
            cmd_del.ExecuteNonQuery();
         }
      }
               
      string name=String.Format("My mistakes between {0} and {1}",fr.ToShortDateString(),to.ToShortDateString());
      string descr = name + String.Format(" ({0}) ", qtypename);
      
      SqlCommand select_q=connection_.CreateCommand();
      select_q.CommandText=
      @"
      SELECT     Questions.Id
      FROM         Results INNER JOIN
                            ResultsDetails ON Results.Id = ResultsDetails.ResultId INNER JOIN
                            Questions ON ResultsDetails.QuestionId = Questions.Id INNER JOIN
                            Answers ON ResultsDetails.AnswerId = Answers.Id AND Questions.Id = Answers.QuestionId
      WHERE     (Results.StartTime >= @fr) AND (Results.StartTime <= @to) AND (Results.UserId = @UserId)      
      ";

      if(type!=-1)  select_q.CommandText+=String.Format(" and questions.SubtypeId={0} ",type);
      
      select_q.CommandText +=" group by Questions.Id";
      
      
      select_q.Parameters.Add(new SqlParameter("@fr", fr));
      select_q.Parameters.Add(new SqlParameter("@to", to));
      select_q.Parameters.Add(new SqlParameter("@UserId", access_manager_.UserId));
      
      List<string> qs=new List<string>();
      using(SqlDataReader reader=select_q.ExecuteReader())
      {
         
         while(reader.Read())
         {
            qs.Add(reader[0].ToString());
            
         }
      }
      int i=0;
      string[] q=new string[qs.Count];

      foreach(string iq in qs)        q[i++]=iq;

      int idx=GmatClubTest.BusinessLogic.CustomTestsLogic.create_test_(connection_,access_manager_,name,descr,q,3600,2,type==-1?14:type);
      
      {
         SqlCommand cmd = connection_.CreateCommand();
         cmd.CommandText = String.Format("update CustomTests set mistakes=1 where test_id={0}", idx);
         cmd.ExecuteNonQuery();
      }
      
      return idx;
   }
}
