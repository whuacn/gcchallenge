using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace GmatClubTest.BusinessLogic
{
   public class StatisticCollector
   {
      public static string updateResults(System.Data.SqlClient.SqlConnection conn)
      {
         System.Collections.Generic.List<Int32> users=new System.Collections.Generic.List<Int32>();
         SqlCommand cmd=conn.CreateCommand();
         cmd.CommandText="select idx from acl_user; ";
         using(SqlDataReader reader=cmd.ExecuteReader())
         {
            while(reader.Read())
            {
               users.Add((int)reader[0]);           
            }
         }
         
         SqlCommand userRaiting=conn.CreateCommand();
         userRaiting.CommandText=
@"
INSERT INTO StatisticResult
SELECT     @UserId AS UserId, GETDATE() AS measured, QuestionTypes.Id, AVG(results.ge * 100 / results.all_cnt) AS Result
FROM         (SELECT     Results_3.TestId AS tid, MAX(all_res.cnt) AS all_cnt, COUNT(1) AS ge, MAX(us.max_score) AS max_score, MAX(us.mid) AS mid
                       FROM          Results AS Results_3 INNER JOIN
                                                  (SELECT     MAX(Id) AS mid, MAX(Score) AS max_score, TestId
                                                    FROM          Results AS Results_1
                                                    WHERE      (UserId = @UserId)
                                                    GROUP BY TestId) AS us ON us.TestId = Results_3.TestId AND us.max_score >= Results_3.Score INNER JOIN
                                                  (SELECT     TestId, COUNT(1) AS cnt
                                                    FROM          Results AS Results_2
                                                    GROUP BY TestId) AS all_res ON all_res.TestId = Results_3.TestId
                       GROUP BY Results_3.TestId) AS results INNER JOIN
                      Tests ON results.tid = Tests.Id INNER JOIN
                          (SELECT     TestContents.TestId AS id, SUM(QuestionSets.NumberOfQuestionsToPick) AS value
                            FROM          TestContents INNER JOIN
                                                   QuestionSets ON TestContents.QuestionSetId = QuestionSets.Id
                            GROUP BY TestContents.TestId) AS q_cnt ON q_cnt.id = Tests.Id INNER JOIN
                      QuestionTypes ON Tests.QuestionTypeId = QuestionTypes.Id
GROUP BY QuestionTypes.Id
";
         userRaiting.Parameters.AddWithValue("@UserId",0);
         
         foreach(int iUser in users)
         {
            userRaiting.Parameters[0]=new SqlParameter("@UserId", iUser);
            userRaiting.ExecuteNonQuery();
         }
         return users.Count.ToString() + " statistic rows updated";
      }
      
      public static string rate_it(System.Data.SqlClient.SqlConnection conn,System.Web.HttpRequest req)
      {
         int idx=Int32.Parse(req["idx"].ToString());
         int vote=Int32.Parse(req["vote"].ToString());
         
         SqlCommand cmd=conn.CreateCommand();
         cmd.CommandText="select current_rating,votes from TestRating where idx="+idx.ToString()+";";
         int current_rating=0;
         int votes=0;
         using(SqlDataReader reader=cmd.ExecuteReader())
         {
            if (reader.HasRows)
            {
               reader.Read();
               current_rating = (int)reader[0];
               votes = (int)reader[1];
               reader.Close();
            }
            else
            {
               reader.Close();
               SqlCommand cmd2=conn.CreateCommand();
               cmd2.CommandText=String.Format("insert into TestRating (idx,current_rating,votes) values({0},0,0);",idx);
               cmd2.ExecuteNonQuery();
            }
          }

         current_rating=(current_rating*votes+vote)/(votes+1);
         votes++;
         
         SqlCommand cmd3 = conn.CreateCommand();
         cmd3.CommandText = String.Format(@"
update TestRating set current_rating={0},votes={1} where idx={2};
update Tests set rating={0} where Id={2};
",current_rating,votes,idx);
         cmd3.ExecuteNonQuery();
         return current_rating.ToString();
         
      }
   }
}
