using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GmatClubTest.Common;
using GmatClubTest.ImportExport.Data;
using ImportExport;
using ImportExport.Data;

namespace GmatClubTest.ImportExport
{
    public class ImEx : IDisposable
    {
        private Provider2 provider;
        private Dataset dataset = new Dataset();
        private Provider propv1;
        // private string fileName = "";
        //  private string serverName = "";
        private string dbName = "GmatClubChallenge";
        private string userName = "re2085";

        public ImEx()
        {
            provider = new Provider2();
            propv1 = new Provider();
        }

        private static string DB_FILE_NAME = "GmatClubTest.mdb";
        // private static string DB_FILE_NAME = "GmatClubTest.mdb";
        // private static string APP_CAPTION = "GMAT Club Test - Practice";
        public void InitConnection(bool isSQL)
        {
            // 
            if (isSQL)
            {
                provider.ConnectToSql("127.0.0.1", dbName, userName, "sys1175");
            }
            else
            {
                provider.ConnectToAccess(DB_FILE_NAME, "q&b3pz>#_24");
            }
        }


        public void InitSQLConnection(string serverName, string dbName, string userName, string password)
        {
            provider.ConnectToSql(serverName, dbName, userName, password);
        }

        public void InitAccessConnection(string DB_FILE_NAME)
        {
            provider.ConnectToAccess(DB_FILE_NAME, "q&b3pz>#_24");
        }


        public void DeleteOldTest(int testId)
        {
            //provider.DeleteOldTest(testId);
        }

        ~ImEx()
        {
            Dispose();
        }


        public void ImportFromTextFile(string filePath)
        {
            DataSet2 test = new DataSet2();
            StreamReader s = new StreamReader(filePath);
            Guid guid = Guid.NewGuid();
            test.Tests.AddTestsRow("Test from typed file(by parser v11)", true, "unknown", 3, 3, guid.ToString(), 1, 0);
            test.QuestionSets.AddQuestionSetsRow("Set from typed file", "unknown", 0, int.MaxValue, 3, 3, 0, 0, 0);
            //Todo Updete Number of question
            int correctQiestionNamber = 0;
            int curentQuestionNumber = -1;
            int numberZone1 = 0;
            int numberZone2 = 0;
            int numberZone3 = 0;
            byte curentAnswerNumber = 0;
           
          
            DataTable questionSubtypesTable = propv1.GetQuestionSubtypesTable();
                        
            while (!s.EndOfStream)
            {
                string line = s.ReadLine();
                while (line == "")
                {
                    line = s.ReadLine();
                }
                if (line == null)
                {
                    break;
                }
                if (line[0] == '#')
                {
                    string question = "";
                    string ts = (line[line.Length - 3].ToString() + line[line.Length - 2].ToString());
                    int questDifficutly = Convert.ToInt32(ts);
                    int questionSubType = 0;
                    switch (questDifficutly)
                    {
                        case 25:
                            questDifficutly = 1;
                            ++numberZone1;
                            break;
                        case 50:
                            questDifficutly = 2;
                            ++numberZone2;
                            break;
                        case 75:
                            questDifficutly = 3;
                            ++numberZone3;
                            break;
                    }

                    //parse questionSubtype
                    string[] splitedStrs = line.Split(',');
                    string questionSubtype = splitedStrs[1];

                    DataRow[] rows = questionSubtypesTable.Select(string.Format("name like '%{0}%'", questionSubtype.Trim()));
                    if(rows.Length > 0)
                    {
                        questionSubType = (int)rows[0]["id"];
                    }
                    else
                    {
                        if (questionSubtype.Trim() == "WP")
                        {
                            questionSubType = (int)BuisinessObjects.Subtype.WordProblems;
                        }
                    }
                   
                    while ((line == "") || (line[1] < 'A') || (line[1] > 'Z'))
                    {
                        line = s.ReadLine();
                        question += line;
                    }
                    test.Questions.AddQuestionsRow(1, questionSubType, questDifficutly, question, null);
                    curentQuestionNumber++;
                }
                if (line[0] == '(')
                {
                    string answer = "";
                    while ((line == "") || (line[0] == '('))
                    {
                        answer = line;
                        line = s.ReadLine();
                        if (answer != "")
                        {
                            test.Answers.AddAnswersRow(curentQuestionNumber, answer, false, curentAnswerNumber);
                        }
                        curentAnswerNumber++;
                    }
                }
                if (line[0] == '{')
                {
                    correctQiestionNamber = (int) (line[1] - 64);
                    int temp = 0;
                    for (int i = 0; i < test.Answers.Count; ++i)
                    {
                        if (test.Answers[i].QuestionId == curentQuestionNumber)
                        {
                            temp++;
                        }
                        if (temp == correctQiestionNamber)
                        {
                            test.Answers[i].IsCorrect = true;
                            break;
                        }
                    }
                    string explanation = string.Empty;
                    while(line != null && line != string.Empty)
                    {
                        explanation += line;
                        line = s.ReadLine();
                    }
                    if(!string.IsNullOrEmpty(explanation))
                    {
                        test.explanations.AddexplanationsRow(curentQuestionNumber, explanation);
                    }
                }
            }
            test.QuestionSets[0].NumberOfQuestionsToPick = test.Questions.Count;
            test.QuestionSets[0].NumberOfQuestionsInZone1 = numberZone1;
            test.QuestionSets[0].NumberOfQuestionsInZone2 = numberZone2;
            test.QuestionSets[0].NumberOfQuestionsInZone3 = numberZone3;
            //test.QuestionSets[0].QuestionSubtypeId = questionSubType;
            test.TestContents.AddTestContentsRow(0, 0, 0);
            for (byte i = 0; i < test.Questions.Count; ++i)
            {
                test.SetsToQuestions.AddSetsToQuestionsRow(0, i, 1, i);
            }
            provider.SetTest(test);
        }

        public void ExportTest(int testId, string filePath)
        {
            propv1.GetTestById(dataset, testId);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dataset);
            stream.Close();
        }

        public int theadTestId;
        public string theadFilePath;

        public void ExportTestOnNewTheader()

        {
            propv1.GetTestById(dataset, theadTestId);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(theadFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dataset);
            stream.Close();
        }

        public void ImportTestOnNewTheader()
        {
            IFormatter formatter = new BinaryFormatter();
            if (theadFilePath.LastIndexOf(".txt") != -1)
            {
                ImportFromTextFile(theadFilePath);
                return;
            }
            Stream stream = new FileStream(theadFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            dataset = (Dataset) formatter.Deserialize(stream);
            stream.Close();
            propv1.SetTest(dataset);
        }

        public void ImportTest(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            dataset = (Dataset) formatter.Deserialize(stream);
            stream.Close();

            propv1.SetTest(dataset);
        }

        public void Dispose()
        {
            propv1.Dispose();
        }
    }
}