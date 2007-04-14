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

      public static string list_types(System.Data.SqlClient.SqlConnection conn)
      {
         System.IO.TextWriter tw = new System.IO.StringWriter();
         list_types_(conn).WriteXml(tw);
         return tw.ToString();
      }

      public static string list_subtypes(System.Data.SqlClient.SqlConnection conn)
      {
         System.IO.TextWriter tw = new System.IO.StringWriter();
         list_subtypes_(conn).WriteXml(tw);
         return tw.ToString();
      }


      public static string list_q_in_test(System.Data.SqlClient.SqlConnection conn,System.Web.HttpRequest req)
      {
         int test_id=Int32.Parse(req["test_id"]);
         SqlCommand cmd=conn.CreateCommand();
         cmd.CommandText=String.Format(
         @"SELECT     SetsToQuestions.QuestionId, Questions.text
FROM         Tests INNER JOIN
                      TestContents ON Tests.Id = TestContents.TestId INNER JOIN
                      QuestionSets ON TestContents.QuestionSetId = QuestionSets.Id INNER JOIN
                      SetsToQuestions ON QuestionSets.Id = SetsToQuestions.SetId INNER JOIN
                      Questions ON SetsToQuestions.QuestionId = Questions.Id
                      
WHERE     (Tests.Id = {0})
ORDER BY TestContents.QuestionSetOrder, SetsToQuestions.QuestionOrder"
,
test_id);

         string ret="";
         bool f=true;
         using(SqlDataReader reader=cmd.ExecuteReader())
         {
            
            while(reader.Read())
            {
               if(!f) ret+=";";
               if(f) f=false;
               ret+=reader[0].ToString();
               ret+="||";
               string s=reader[1].ToString();
               if(s.Length!=0) 
               {
                  ret+=s.Substring(0,s.Length>=32?32:s.Length)+"...";
               }
               else 
               {  
                  ret+=s+"...";
               }
            }
         }
         return ret;
      }

      
      public static string create_test(System.Data.SqlClient.SqlConnection conn,System.Web.HttpRequest req, AccessControl.AccessManager access_manager)
      {
         string name = req["name"];
         string descr = req["descr"];
         string[] q = req["questions"].Split(',');
         int time_limit = Int32.Parse(req["tl"]);
         int qtypeid = Int32.Parse(req["qtypeid"]);
         int qsubtypeid = Int32.Parse(req["qsubtypeid"]);
         create_test_(conn,access_manager,name,descr,q,time_limit,qtypeid,qsubtypeid);
         
         return "ok";
      }

      public static int create_test_(System.Data.SqlClient.SqlConnection conn, AccessControl.AccessManager access_manager, string name, string descr, string[] q, int time_limit, int qtypeid, int qsubtypeid)
      {
      
         //using(System.Data.SqlClient.SqlTransaction tr=conn.BeginTransaction())
         {
            TestsDataSet ds=new TestsDataSet();
            TestsDataSetTableAdapters.TestsTableAdapter tta=new TestsDataSetTableAdapters.TestsTableAdapter ();
            tta.Connection=conn;
            TestsDataSetTableAdapters.TestContentsTableAdapter tts=new TestsDataSetTableAdapters.TestContentsTableAdapter ();
            tts.Connection=conn;
            TestsDataSetTableAdapters.SetsToQuestionsTableAdapter qs = new TestsDataSetTableAdapters.SetsToQuestionsTableAdapter ();
            qs.Connection=conn;
            TestsDataSetTableAdapters.QuestionSetsTableAdapter qst=new TestsDataSetTableAdapters.QuestionSetsTableAdapter ();
            qst.Connection=conn;
            TestsDataSetTableAdapters.CustomTestsTableAdapter ctt = new TestsDataSetTableAdapters.CustomTestsTableAdapter();
            ctt.Connection = conn;

            ds.Tests.AddTestsRow(name, true, descr, qtypeid, qsubtypeid, Guid.NewGuid().ToString(),0,0);
            tta.Update(ds);
            
            
            ds.QuestionSets.AddQuestionSetsRow(name,descr,0,time_limit,qtypeid,qsubtypeid,q.Length,1,1);
            qst.Update(ds);
            
            for(int i=0;i<q.Length;++i)
            {
               ds.SetsToQuestions.AddSetsToQuestionsRow(ds.QuestionSets[0],Int32.Parse(q[i]),(byte)i,(byte)1);
            }
            qs.Update(ds);            
            
            
            ds.TestContents.AddTestContentsRow(ds.Tests[0],ds.QuestionSets[0],(byte)0);
            tts.Update(ds);                

            
            
            ds.CustomTests.AddCustomTestsRow(ds.Tests[0],access_manager.UserId,q.Length,DateTime.Now,true,false);
            ctt.Update(ds);
            
            ds.QuestionSets[0].NumberOfQuestionsToPick=q.Length;
            qst.Update(ds);

            return ds.Tests[0].Id;
         }
         
         
      }
      
      
      public static void del_test(System.Data.SqlClient.SqlConnection conn,int TestId)
      {
      
         SqlCommand cmd=conn.CreateCommand();
         cmd.CommandText=String.Format(
         @"
         delete from questionsets where id in (select questionsetid from testcontents where testid={0})
         delete from Tests where Id={0} and Id in (select test_id from customtests);"
         ,TestId);
         cmd.ExecuteNonQuery();
      }
      
      public static bool is_custom(int idx,AccessControl.AccessManager mgr)
      {
         SqlCommand cmd = ((SqlConnection)mgr.Connection).CreateCommand();
         cmd.CommandText = String.Format("select idx from customtests where test_id={0}", idx);
         object o = cmd.ExecuteScalar();
         if(null==o || o.GetType()==typeof(DBNull))
         {
            return false;  
         }
         return true;
      }
      
      public static bool is_owner(int idx,AccessControl.AccessManager mgr)
      {
         if(mgr.UserMainRole=="admin") return true;
         SqlCommand cmd=((SqlConnection)mgr.Connection).CreateCommand();
         cmd.CommandText=String.Format("select author from customtests where test_id={0}",idx);
         object o=cmd.ExecuteScalar();
      
         if(null==o) return false;   
         if(o.GetType()==typeof(int))
         {
            return mgr.UserId==(int)o;
         }
         return false;
      } 
      
      public static void set_test_flags(SqlConnection conn,int idx,bool enabled,bool hidden)
      {
         SqlCommand cmd=conn.CreateCommand();
         cmd.CommandText=String.Format("update customtests set enabled={0},hidden={1} where test_id={2};",enabled?1:0,hidden?1:0,idx);
         cmd.ExecuteNonQuery();
      }
      

      protected static GmatClubTest.Data.TestSet list_tests_(System.Data.SqlClient.SqlConnection conn)
      {
         GmatClubTest.Data.TestSet set = new GmatClubTest.Data.TestSet();
         
         SqlDataAdapter ad=new SqlDataAdapter ("select * from Tests;",conn);
         ad.Fill(set.Tests);
         return set;
      }

      protected static GmatClubTest.Data.QuestionTypes list_types_(System.Data.SqlClient.SqlConnection conn)
      {
         GmatClubTest.Data.QuestionTypes set = new GmatClubTest.Data.QuestionTypes();

         SqlDataAdapter ad = new SqlDataAdapter("select * from QuestionTypes;", conn);
         ad.Fill(set._QuestionTypes);
         return set;
      }

      protected static GmatClubTest.Data.QuestionSubTypes list_subtypes_(System.Data.SqlClient.SqlConnection conn)
      {
         GmatClubTest.Data.QuestionSubTypes set = new GmatClubTest.Data.QuestionSubTypes();

         SqlDataAdapter ad = new SqlDataAdapter("select * from QuestionSubTypes;", conn);
         ad.Fill(set.QuestionSubtypes);
         return set;
      }
      
   }
}