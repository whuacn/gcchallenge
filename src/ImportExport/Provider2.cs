using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ImportExport.DataSet2TableAdapters;

namespace ImportExport
{
    class Provider2
    {
        public void SetTest(DataSet2 test)
        {
            using (TestsTableAdapter testsTableAdapter = new TestsTableAdapter())
            {
                testsTableAdapter.Connection = Connection;
                testsTableAdapter.Update(test.Tests);
            }
            
            QuestionSetsTableAdapter questionSetsTableAdapter = new QuestionSetsTableAdapter();
            questionSetsTableAdapter.Connection = Connection;
            Dictionary<DataSet2.QuestionSetsRow, int> numberOfQuestionsToPick = new Dictionary<DataSet2.QuestionSetsRow, int>(test.QuestionSets.Rows.Count);
            foreach (DataSet2.QuestionSetsRow row in test.QuestionSets.Rows)
            {
                numberOfQuestionsToPick.Add(row, row.NumberOfQuestionsToPick);
                row.NumberOfQuestionsToPick = 0;
            }
            questionSetsTableAdapter.Update(test.QuestionSets);

            TestContentsTableAdapter testContentsTableAdapter = new TestContentsTableAdapter();
            testContentsTableAdapter.Connection = Connection;
            testContentsTableAdapter.Update(test.TestContents);

            QuestionsTableAdapter questionsTableAdapter = new QuestionsTableAdapter();
            questionsTableAdapter.Connection = Connection;
            questionsTableAdapter.Update(test.Questions);


            SetsToQuestionsTableAdapter setsToQuestionsTableAdapter = new SetsToQuestionsTableAdapter();
            setsToQuestionsTableAdapter.Connection = Connection;
            setsToQuestionsTableAdapter.Update(test.SetsToQuestions);

            foreach (KeyValuePair<DataSet2.QuestionSetsRow, int> pair in numberOfQuestionsToPick)
            {
                pair.Key.NumberOfQuestionsToPick = pair.Value;
            }
            questionSetsTableAdapter.Update(test.QuestionSets);


            PassagesToQuestionsTableAdapter sassagesToQuestionsTableAdapter =
                new PassagesToQuestionsTableAdapter();
            sassagesToQuestionsTableAdapter.Connection = Connection;
            sassagesToQuestionsTableAdapter.Update(test.PassagesToQuestions);

            AnswersTableAdapter answersTableAdapter = new AnswersTableAdapter();
            answersTableAdapter.Connection = Connection;
            answersTableAdapter.Update(test.Answers);

            explanationsTableAdapter explanationsTableAdapter = new explanationsTableAdapter();
            explanationsTableAdapter.Connection = Connection;
            explanationsTableAdapter.Update(test.explanations);
        }

        private SqlConnection _connection;

        private SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection();
                }
                return _connection;
            }
        }

        private static string SQL_Connection_STRING =
            //@"Auto Translate=True;User ID={2};Tag with column collation when possible=False;Data Source={0};Password=""{3}"";Initial Catalog={1};Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=True;Use Encryption for Data=False;Packet Size=4096";
            @"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password=""{3}""";
        private static string ACCESS_Connection_STRING =
            @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=""{1}"";Data Source=""{0}"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=True";

        public void ConnectToAccess(string fileName, string password)
        {
            if (Connection.State == ConnectionState.Open) Connection.Close();
            Connection.ConnectionString = String.Format(ACCESS_Connection_STRING, fileName, password);
            Connection.Open();
        }

        public void ConnectToSql(string serverName, string dbName, string userName, string password)
        {
            if (Connection.State == ConnectionState.Open) Connection.Close();
            Connection.ConnectionString = String.Format(SQL_Connection_STRING, serverName, dbName, userName, password);
            //Connection.ConnectionString = "Provider=SQLNCLI.1;Data Source=yuve;Integrated Security=SSPI;Initial Catalog=GmatClubTest";
            Connection.Open();
        }

        public bool Opened
        {
            get { return Connection.State == ConnectionState.Open; }
            set
            {
                if (value)
                {
                    if (Connection.State != ConnectionState.Open) Connection.Open();
                }
                else
                {
                    if (Connection.State != ConnectionState.Closed) Connection.Close();
                }
            }
        }

    }
}
