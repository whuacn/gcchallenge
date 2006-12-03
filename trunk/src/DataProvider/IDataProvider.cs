using System;
using GmatClubTest.Data;
using System.Data;

namespace GmatClubTest.DataProvider
{
   public interface IDataProvider
   {
      void Open();
      void Close();
      
      /*void GetUsers(UserSet users);
      void Update(UserSet users);
      void GetUser(int id, UserSet user);
        */
        
      void GetTests(TestSet tests);
      void GetQuestionSetsByTestId(int testId, QuestionSetSet questionSets);
      void GetQuestionsAnswersByQuestionSetId(int questionSetId, QuestionAnswerSet questionsAnswers);
      void GetQuestionsAnswersByQuestionSetIdAndZone(int questionSetId, byte questionZone, QuestionAnswerSet questionsAnswers);
      void GetQuestion(int questionId, QuestionSet question);

      void GetPassageToQuestions(int questionId, PassageToQuestionSet passageToQuestions);

      void Update(ResultResultDetailSet results);

        
      void GetResults(int userId, DateTime beginTime, DateTime endTime, ResultSet  results);
      void GetQuestionSetsResultDetailsSet(int resultId, QuestionSetsResultDetailsSet questionSetsResultsDetailsEx);
      

      IDbConnection getConnection();


   }
}
