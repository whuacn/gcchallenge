using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using ImportExport.Data;

namespace GmatClubTest.ImportExport.Data
{
	/// <summary>
	/// Summary description for Provider.
	/// </summary>
	public class Provider : Component
	{
		private OleDbConnection connection;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

        private static string SQL_CONNECTION_STRING = @"Auto Translate=True;User ID={2};Tag with column collation when possible=False;Data Source={0};Password=""{3}"";Initial Catalog={1};Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=True;Use Encryption for Data=False;Packet Size=4096";
		private System.Data.OleDb.OleDbDataAdapter testById;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private static string ACCESS_CONNECTION_STRING = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=""{1}"";Data Source=""{0}"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=True";
        private OleDbCommand oleDbSelectCommand1;
        private OleDbDataAdapter questionSetsByTestId;
        private OleDbCommand oleDbSelectCommand2;
        private OleDbCommand oleDbInsertCommand2;
        private OleDbCommand oleDbUpdateCommand2;
        private OleDbCommand oleDbDeleteCommand2;
        private OleDbDataAdapter testContentByTestId;
        private OleDbCommand oleDbSelectCommand3;
        private OleDbDataAdapter setsToQuestionByTestId;
        private OleDbCommand oleDbSelectCommand6;
        private OleDbDataAdapter answersByTestId;
        private OleDbCommand oleDbSelectCommand7;
        private OleDbDataAdapter passageToQuestions;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbUpdateCommand;
        private OleDbCommand oleDbSelectCommand5;
        private OleDbDataAdapter questionsByTestId;
        private OleDbCommand oleDbSelectCommand8;
        private OleDbCommand oleDbDeleteCommand3;
        private OleDbDataAdapter setQuestions;
        private OleDbCommand oleDbComand1;
        private OleDbDataAdapter questionEditorDataAdapter;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand3;
        private OleDbCommand oleDbInsertCommand;
        private OleDbConnection oleDbConnection1;
		private OleDbCommand idCmd;

		public Provider(IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			Init();
		}

		public Provider()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			Init();
		}

		private void Init()
		{
			idCmd = new OleDbCommand("SELECT @@IDENTITY", connection);
	
		}

	    public void DeleteOldTest(int testId)
	    {
            //Dataset test = new Dataset();
            //GetTestById(test, testId);
            string comS = "Delete From Tests where Id = " + testId;
            OleDbCommand oleC = new OleDbCommand(comS, connection);
            oleC.ExecuteNonQuery();
            oleC.Dispose(); 
	        
            //for (int i=0; i< test.QuestionSets.Count; ++i)
            //{
            //    if(i==0){ comS = "Delete From dbo.QuestionSets where (Id =" + test.QuestionSets[i].Id + ")";}
            //    else
            //    {
            //        comS += "OR ( Id =" + test.QuestionSets[i].Id + ")";
            //    }
	            
            //}
            //oleC = new OleDbCommand(comS, connection);
            //oleC.ExecuteNonQuery();
            //oleC.Dispose();

            //for (int i = 0; i < test.Questions.Count; ++i)
            //{
            //    if (i == 0) { comS = "Delete From dbo.Questions where (Id =" + test.Questions[i].Id + ")"; }
            //    else
            //    {
            //        comS += "OR ( Id =" + test.Questions[i].Id + ")";
            //    }

            //}
            //oleC = new OleDbCommand(comS, connection);
            //oleC.ExecuteNonQuery();
            //oleC.Dispose(); 
	        
	    }

        public void GetTestById(Dataset test, int testId)
        {
            test.Clear();
            testById.SelectCommand.Parameters[0].Value = testId;
            testById.Fill(test.Tests);

            questionsByTestId.SelectCommand.Parameters[0].Value = testId;
            questionsByTestId.Fill(test.Questions);
                        
            testContentByTestId.SelectCommand.Parameters[0].Value = testId;
            testContentByTestId.Fill(test.TestContents);

            questionSetsByTestId.SelectCommand.Parameters[0].Value = testId;
            questionSetsByTestId.Fill(test.QuestionSets);
            
            setsToQuestionByTestId.SelectCommand.Parameters[0].Value = testId;
            setsToQuestionByTestId.Fill(test.SetsToQuestions);

            answersByTestId.SelectCommand.Parameters[0].Value = testId;
            answersByTestId.Fill(test.Answers);

          
            passageToQuestions.Fill(test.PassagesToQuestions);


            
            for (int i = 0; i < test.PassagesToQuestions.Count; ++i)
            {
                if(test.Questions.FindById(test.PassagesToQuestions[i].QuestionId) != null)
                {
                    questionEditorDataAdapter.SelectCommand.Parameters[0].Value = test.PassagesToQuestions[i].PassageQuestionId;
                    Dataset sd = new Dataset();
                    questionEditorDataAdapter.Fill(sd.Questions);
                    test.Questions.AddQuestionsRow(sd.Questions[0].TypeId, sd.Questions[0].SubtypeId, sd.Questions[0].DifficultyLevelId, sd.Questions[0].Text, (sd.Questions[0].IsPictureNull() ? (null) : (sd.Questions[0].Picture)));
                }else
                {
                    test.PassagesToQuestions[i].Delete();
                }//int TypeId, int SubtypeId, int DifficultyLevelId, string Text, byte[] Picture
            }
		}

        public void SetTest(Dataset test)
	    {
            DataTable question = test.Questions;
            int questionsStartIdStartId = 0;
	        int questionSetsStartId = 0;
            int testsStartId = 0;
            //Import Questions
	        for (int i =0; i<test.Questions.Count; ++i)
	        {
                if(test.Questions[i].RowState == DataRowState.Deleted){continue;}
                //string comS = @"INSERT INTO dbo.Questions (TypeId, SubtypeId, DifficultyLevelId , Text,Picture) VALUES (N'" + test.Questions[i].TypeId + "',N' " + test.Questions[i].SubtypeId +"',N' " + test.Questions[i].DifficultyLevelId +"',N'" + test.Questions[i].Text.Replace("'", "\"")+"'";
                
                //try
                //{
                //    comS += ",N'" + test.Questions[i].Picture + "')";
                //}
                //catch
                //{
                //    comS += ",null" + ")";
                //}
           
                //OleDbCommand oleC = new OleDbCommand(comS, connection);
                //oleC.ExecuteNonQuery();
                //oleC.Dispose();
                questionEditorDataAdapter.InsertCommand.Connection = connection;
                questionEditorDataAdapter.InsertCommand.Parameters["TypeId"].Value = test.Questions[i].TypeId;
                questionEditorDataAdapter.InsertCommand.Parameters["SubtypeId"].Value = test.Questions[i].SubtypeId;
                questionEditorDataAdapter.InsertCommand.Parameters["DifficultyLevelId"].Value = test.Questions[i].DifficultyLevelId;
                questionEditorDataAdapter.InsertCommand.Parameters["Text"].Value = test.Questions[i].Text;
                // (TypeId, SubtypeId, DifficultyLevelId, [Text], Picture)
                if (!test.Questions[i].IsPictureNull())
                {
                    questionEditorDataAdapter.InsertCommand.Parameters["Picture"].Value = test.Questions[i].Picture;
                }
                else
                {
                    //questionEditorDataAdapter.InsertCommand.Parameters["Picture"].Value = null;
                }
                questionEditorDataAdapter.InsertCommand.ExecuteNonQuery();
	            
                //questionEditorDataAdapter.Update(new Dataset.QuestionsRow[] { test.Questions[i] });
	            if (i == 0)
	            {
                    OleDbCommand getLustQuestionId = new OleDbCommand("Select id from Questions ORDER BY id", connection);
                    OleDbDataReader dataReader = getLustQuestionId.ExecuteReader();
                   

                    while (dataReader.Read())
                    {
                        questionsStartIdStartId = (int)dataReader.GetValue(0);
                    }
	            }
            }
            //Import Answers
	        for (int i=0; i< test.Answers.Count; ++i)
	        {
                string comS = @"INSERT INTO Answers (QuestionId, [Text], IsCorrect , [Order]) VALUES (";
	            int j = 0;
                for (j=0; j< test.Questions.Count;++j)
                {
                    //Find Id
                    if(test.Answers[i].QuestionId == test.Questions[j].Id)
                    {
                        comS += "'" + (questionsStartIdStartId + j) + "'";
                        break;
                    }
                }

                comS += ",'" + test.Answers[i].Text + "'";
	            
	            if (test.Answers[i].IsCorrect)
	            {
                    comS += "," + '1' + "";
	            }else
	            {
                    comS += "," + '0' + "";
	            }

                comS += ",'" + test.Answers[i].Order + "')";
	            
                OleDbCommand oleC = new OleDbCommand(comS, connection);
                oleC.ExecuteNonQuery();
                oleC.Dispose();
	        }
            //Import PassagesToQuestions
	          for (int i=0; i< test.PassagesToQuestions.Count; ++i)
	          {
                  if(test.PassagesToQuestions[i].RowState == DataRowState.Deleted){continue;}
	              
                  string comS = @"INSERT INTO PassagesToQuestions (PassageQuestionId,QuestionId, QuestionOrder) VALUES (";
                  int j = 0;
                  bool flag = false;
                  for (j = 0; j < test.Questions.Count; ++j)
                  {
                      if (test.Questions[j].Id == test.PassagesToQuestions[i].PassageQuestionId)
                      {
                          comS += "'" + (questionsStartIdStartId + j) + "'";
                          flag = true;
                          break;
                      }
                  }
	              if(!flag)
	              {
                      comS += "'" + test.PassagesToQuestions[i].PassageQuestionId + "'";
	              }
	              
                  for (j = 0; j < test.Questions.Count; ++j)
                  {
                      if (test.PassagesToQuestions[i].QuestionId == test.Questions[j].Id)
                      {
                          comS += ",'" + (questionsStartIdStartId + j).ToString() + "'";
                          break;
                      }
                  }


                  comS += ",'" + test.PassagesToQuestions[i].QuestionOrder + "')";

                  OleDbCommand oleC = new OleDbCommand(comS, connection);
                  oleC.ExecuteNonQuery();
                  oleC.Dispose();
	          }
	       //Import QuestionSets
              for (int i = 0; i < test.QuestionSets.Count; ++i)
              {
                  string comS = @"Insert INTO QuestionSets (Name,Description,NumberOfQuestionsToPick,TimeLimit,QuestionTypeId,QuestionSubtypeId,NumberOfQuestionsInZone1,NumberOfQuestionsInZone2,NumberOfQuestionsInZone3) VALUES (";

                  comS += "'" + test.QuestionSets[i].Name + "'";
                  comS += ",'" + test.QuestionSets[i].Description + "'";
                 // comS += ",N'" + test.QuestionSets[i].NumberOfQuestionsToPick + "'";
                  //UPDETET Letter (on end import)
                  comS += ",'" + 0 + "'";
                  
                  try
                  {
                      comS += ",'" + test.QuestionSets[i].TimeLimit + "'";
                  }
                  catch
                  {
                      comS += "," + "null" + "";
                  }

                  try
                  {
                      comS += ",'" + test.QuestionSets[i].QuestionTypeId + "'";
                  }
                  catch
                  {
                      comS += "," + "null" + "";
                  }

                  try
                  {
                      comS += ",'" + test.QuestionSets[i].QuestionSubtypeId + "'";
                  }
                  catch 
                  {
                      comS += "," + "null" + "";
                  }


                  comS += ",'" + test.QuestionSets[i].NumberOfQuestionsInZone1 + "'";
                  comS += ",'" + test.QuestionSets[i].NumberOfQuestionsInZone2 + "'";
                  comS += ",'" + test.QuestionSets[i].NumberOfQuestionsInZone3 + "'" + ")";

                  OleDbCommand oleC = new OleDbCommand(comS, connection);
                  oleC.ExecuteNonQuery();
                  oleC.Dispose();
                  if (i == 0)
                  {
                      OleDbCommand getLustQuestionId = new OleDbCommand("Select id from QuestionSets ORDER BY id", connection);
                      OleDbDataReader dataReader = getLustQuestionId.ExecuteReader();

                      while (dataReader.Read())
                      {
                          questionSetsStartId = (int)dataReader.GetValue(0);
                      }
                  }
              }
              //Import SetsToQuestions
              for (int i = 0; i < test.SetsToQuestions.Count; ++i)
              {
                  string comS = @"Insert INTO SetsToQuestions (SetId,QuestionId,QuestionOrder,QuestionZone) VALUES (";
                  
                  for (int j = 0; j<test.QuestionSets.Count; ++j)
                  {
                    if(test.QuestionSets[j].Id == test.SetsToQuestions[i].SetId)
                    {
                        comS += "'" + (questionSetsStartId + j) + "'";
                        break;
                    }
                  }

                  for (int j = 0; j < test.Questions.Count; ++j)
                  {
                      if (test.Questions[j].Id == test.SetsToQuestions[i].QuestionId)
                      {
                          comS += ",'" + (questionsStartIdStartId + j) + "'";
                          break;
                      }
                  }

                  comS += ",'" + test.SetsToQuestions[i].QuestionOrder + "'";
                  comS += ",'" + test.SetsToQuestions[i].QuestionZone + "')";
                  
                  OleDbCommand oleC = new OleDbCommand(comS, connection);
                  oleC.ExecuteNonQuery();
                  oleC.Dispose();

              }
              //Import Tests
              for (int i = 0; i < test.Tests.Count; ++i)
              {
                  string comS = @"Insert INTO Tests (Name,IsPractice,Description,QuestionTypeId,QuestionSubtypeId,[GUID],Version) VALUES (";

                  comS += "'" + test.Tests[i].Name + "'";
                  if (test.Tests[i].IsPractice)
                  {
                      comS += "," + '1' + "";
                  }else
                  {
                      comS += "," + '0' + "";
                  }
                  
                  comS += ",'" + test.Tests[i].Description + "'";
                  
                  try
                  {
                      comS += ",'" + test.Tests[i].QuestionTypeId + "'";
                  }catch
                  {
                      comS += "," + "null" + "";
                  }
                  
                  try
                  {
                      comS += ",'" + test.Tests[i].QuestionSubtypeId + "'";
                  }
                  catch
                  {
                      comS += "," + "null" + "";
                  }

                  comS += ",'" + test.Tests[i].GUID + "'";

                  comS += ",'" + test.Tests[i].Version + "')";
                  
                  OleDbCommand oleC = new OleDbCommand(comS, connection);
                  oleC.ExecuteNonQuery();
                  oleC.Dispose();

                  if (i == 0)
                  {
                      OleDbCommand getLustQuestionId = new OleDbCommand("Select id from Tests ORDER BY id", connection);
                      OleDbDataReader dataReader = getLustQuestionId.ExecuteReader();

                      while (dataReader.Read())
                      {
                          testsStartId = (int)dataReader.GetValue(0);
                      }
                  }
              }
              //Import TestContents
              for (int i = 0; i < test.TestContents.Count; ++i)
              {
                  string comS = @"Insert INTO TestContents (TestId,QuestionSetId,QuestionSetOrder) VALUES (";

                  for (int j = 0; j < test.Tests.Count; ++j)
                  {
                      if (test.Tests[j].Id == test.TestContents[i].TestId)
                      {
                          comS += "'" + (testsStartId + j) + "'";
                          break;
                      }
                  }
                  
                  for (int j = 0; j < test.QuestionSets.Count; ++j)
                  {
                      if (test.QuestionSets[j].Id == test.TestContents[i].QuestionSetId)
                      {
                          comS += ",'" + (questionSetsStartId + j) + "'";
                          break;
                      }
                  }

                 

                  comS += ",'" + test.TestContents[i].QuestionSetOrder + "')";
                  

                  OleDbCommand oleC = new OleDbCommand(comS, connection);
                  oleC.ExecuteNonQuery();
                  oleC.Dispose();

              }
              for (int i = 0; i < test.QuestionSets.Count; ++i)
              {
                  string comS = @"UPDATE QuestionSets SET NumberOfQuestionsToPick =" +test.QuestionSets[i].NumberOfQuestionsToPick + " Where id = " + (questionSetsStartId +i);
                  
                  OleDbCommand oleC = new OleDbCommand(comS, connection);
                  oleC.ExecuteNonQuery();
                  oleC.Dispose();
              }

              
	    }

        protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void ConnectToAccess(string fileName, string password)
		{
			if (connection.State == ConnectionState.Open) connection.Close();
			connection.ConnectionString = String.Format(ACCESS_CONNECTION_STRING, fileName, password);
			connection.Open();
		}

		public void ConnectToSql(string serverName, string dbName, string userName, string password)
		{
			if (connection.State == ConnectionState.Open) connection.Close();
			connection.ConnectionString = String.Format(SQL_CONNECTION_STRING, serverName, dbName, userName, password);
            //connection.ConnectionString = "Provider=SQLNCLI.1;Data Source=yuve;Integrated Security=SSPI;Initial Catalog=GmatClubTest";
		    connection.Open();
		}

		public bool Opened
		{
			get {return connection.State == ConnectionState.Open;}
			set 
			{
				if (value)
				{
					if (connection.State != ConnectionState.Open) connection.Open();
				}
				else
				{
					if (connection.State != ConnectionState.Closed) connection.Close();
				}
			 }
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Provider));
            this.connection = new System.Data.OleDb.OleDbConnection();
            this.testById = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.questionSetsByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.testContentByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.setsToQuestionByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.answersByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
            this.passageToQuestions = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.questionsByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.setQuestions = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbComand1 = new System.Data.OleDb.OleDbCommand();
            this.questionEditorDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            // 
            // connection
            // 
            this.connection.ConnectionString = "Provider=SQLNCLI.1;Data Source=yuve;Integrated Security=SSPI;Initial Catalog=Gmat" +
                "ClubTest";
            // 
            // testById
            // 
            this.testById.DeleteCommand = this.oleDbDeleteCommand1;
            this.testById.InsertCommand = this.oleDbInsertCommand1;
            this.testById.SelectCommand = this.oleDbSelectCommand4;
            this.testById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Tests", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("IsPractice", "IsPractice"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("GUID", "GUID"),
                        new System.Data.Common.DataColumnMapping("Version", "Version")})});
            this.testById.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.connection;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsPractice", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsPractice", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Version", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Version", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Tests] ([Name], [IsPractice], [Description], [QuestionTypeId], [Ques" +
                "tionSubtypeId], [GUID], [Version]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.connection;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("IsPractice", System.Data.OleDb.OleDbType.Boolean, 0, "IsPractice"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("GUID", System.Data.OleDb.OleDbType.Char, 0, "GUID"),
            new System.Data.OleDb.OleDbParameter("Version", System.Data.OleDb.OleDbType.Integer, 0, "Version")});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT     Tests.*\r\nFROM         Tests\r\nWHERE     (Id = ?)";
            this.oleDbSelectCommand4.Connection = this.connection;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Current, "1")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.connection;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("IsPractice", System.Data.OleDb.OleDbType.Boolean, 0, "IsPractice"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("GUID", System.Data.OleDb.OleDbType.Char, 0, "GUID"),
            new System.Data.OleDb.OleDbParameter("Version", System.Data.OleDb.OleDbType.Integer, 0, "Version"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsPractice", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsPractice", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Version", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Version", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     QuestionSets.*\r\nFROM         QuestionSets  INNER JOIN\r\n               " +
                "       TestContents ON QuestionSets.Id = TestContents.QuestionSetId\r\nWHERE     (" +
                "TestContents.TestId = ?)";
            this.oleDbSelectCommand1.Connection = this.connection;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 4, "TestId")});
            // 
            // questionSetsByTestId
            // 
            this.questionSetsByTestId.DeleteCommand = this.oleDbDeleteCommand;
            this.questionSetsByTestId.SelectCommand = this.oleDbSelectCommand1;
            this.questionSetsByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsToPick", "NumberOfQuestionsToPick"),
                        new System.Data.Common.DataColumnMapping("TimeLimit", "TimeLimit"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone1", "NumberOfQuestionsInZone1"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone2", "NumberOfQuestionsInZone2"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3")})});
            this.questionSetsByTestId.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = resources.GetString("oleDbDeleteCommand.CommandText");
            this.oleDbDeleteCommand.Connection = this.connection;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsToPick", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone3", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.connection;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsToPick"),
            new System.Data.OleDb.OleDbParameter("TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, "TimeLimit"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone1"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone2"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone3"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsToPick", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone3", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT     TestContents.*\r\nFROM         TestContents\r\nWHERE     (TestId = ?)";
            this.oleDbSelectCommand2.Connection = this.connection;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 4, "TestId")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO [TestContents] ([TestId], [QuestionSetId], [QuestionSetOrder]) VALUES" +
                " (?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.connection;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSetId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionSetOrder")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE [TestContents] SET [TestId] = ?, [QuestionSetId] = ?, [QuestionSetOrder] =" +
                " ? WHERE (([TestId] = ?) AND ([QuestionSetId] = ?) AND ([QuestionSetOrder] = ?))" +
                "";
            this.oleDbUpdateCommand2.Connection = this.connection;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSetId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionSetOrder"),
            new System.Data.OleDb.OleDbParameter("Original_TestId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [TestContents] WHERE (([TestId] = ?) AND ([QuestionSetId] = ?) AND ([" +
                "QuestionSetOrder] = ?))";
            this.oleDbDeleteCommand2.Connection = this.connection;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_TestId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // testContentByTestId
            // 
            this.testContentByTestId.DeleteCommand = this.oleDbDeleteCommand2;
            this.testContentByTestId.InsertCommand = this.oleDbInsertCommand2;
            this.testContentByTestId.SelectCommand = this.oleDbSelectCommand2;
            this.testContentByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TestContents", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TestId", "TestId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetId", "QuestionSetId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetOrder", "QuestionSetOrder")})});
            this.testContentByTestId.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.connection;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 4, "TestId")});
            // 
            // setsToQuestionByTestId
            // 
            this.setsToQuestionByTestId.SelectCommand = this.oleDbSelectCommand3;
            this.setsToQuestionByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SetsToQuestions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SetId", "SetId"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("QuestionZone", "QuestionZone"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder")})});
            // 
            // oleDbSelectCommand6
            // 
            this.oleDbSelectCommand6.CommandText = resources.GetString("oleDbSelectCommand6.CommandText");
            this.oleDbSelectCommand6.Connection = this.connection;
            this.oleDbSelectCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 3, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Current, "115")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\GmatClubTest(UEditio" +
                "n).mdb;Persist Security Info=True;Jet OLEDB:Database Password=q&b3pz>#_24";
            // 
            // answersByTestId
            // 
            this.answersByTestId.SelectCommand = this.oleDbSelectCommand6;
            this.answersByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
                        new System.Data.Common.DataColumnMapping("Order", "Order")})});
            // 
            // oleDbSelectCommand7
            // 
            this.oleDbSelectCommand7.CommandText = "SELECT     PassageQuestionId, QuestionId, QuestionOrder\r\nFROM         PassagesToQ" +
                "uestions";
            this.oleDbSelectCommand7.Connection = this.connection;
            // 
            // passageToQuestions
            // 
            this.passageToQuestions.SelectCommand = this.oleDbSelectCommand7;
            this.passageToQuestions.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PassagesToQuestions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("PassageQuestionId", "PassageQuestionId"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder")})});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = resources.GetString("oleDbSelectCommand5.CommandText");
            this.oleDbSelectCommand5.Connection = this.connection;
            this.oleDbSelectCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Param1", System.Data.OleDb.OleDbType.Integer, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "101")});
            // 
            // questionsByTestId
            // 
            this.questionsByTestId.SelectCommand = this.oleDbSelectCommand5;
            this.questionsByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            // 
            // oleDbSelectCommand8
            // 
            this.oleDbSelectCommand8.CommandText = "SELECT     Id\r\nFROM         Questions";
            this.oleDbSelectCommand8.Connection = this.connection;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [Questions] WHERE (([Id] = ?))";
            this.oleDbDeleteCommand3.Connection = this.connection;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // setQuestions
            // 
            this.setQuestions.DeleteCommand = this.oleDbDeleteCommand3;
            this.setQuestions.InsertCommand = this.oleDbComand1;
            this.setQuestions.SelectCommand = this.oleDbSelectCommand8;
            this.setQuestions.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id")})});
            // 
            // questionEditorDataAdapter
            // 
            this.questionEditorDataAdapter.DeleteCommand = this.oleDbCommand1;
            this.questionEditorDataAdapter.InsertCommand = this.oleDbInsertCommand;
            this.questionEditorDataAdapter.SelectCommand = this.oleDbCommand2;
            this.questionEditorDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            this.questionEditorDataAdapter.UpdateCommand = this.oleDbCommand3;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [Questions] WHERE (([Id] = ?) AND ([TypeId] = ?) AND ([SubtypeId] = ?" +
                ") AND ([DifficultyLevelId] = ?) AND ([Text] = ?))";
            this.oleDbCommand1.Connection = this.connection;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DifficultyLevelId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = "INSERT INTO Questions\r\n                      (TypeId, SubtypeId, DifficultyLevelI" +
                "d, [Text], Picture)\r\nVALUES     (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"),
            new System.Data.OleDb.OleDbParameter("SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"),
            new System.Data.OleDb.OleDbParameter("DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Picture")});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "SELECT     Id, TypeId, SubtypeId, DifficultyLevelId, Text, Picture\r\nFROM         " +
                "Questions\r\nWHERE     (Id = ?)";
            this.oleDbCommand2.Connection = this.connection;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 4, "Id")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.connection;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"),
            new System.Data.OleDb.OleDbParameter("SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"),
            new System.Data.OleDb.OleDbParameter("DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Picture"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DifficultyLevelId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});

		}
		#endregion

    }
}
