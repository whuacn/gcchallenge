using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

namespace GmatClubTest.DbEditor.Data
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
        private System.Data.OleDb.OleDbDataAdapter allTestsAdapter;
		private System.Data.OleDb.OleDbDataAdapter allTestContentsAdapter;
		private System.Data.OleDb.OleDbDataAdapter testById;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private static string ACCESS_CONNECTION_STRING = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=""{1}"";Data Source=""{0}"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=True;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=True";
        //private static string ACCESS_CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""{0}"";Initial Catalog={1};User ID={2};Persist Security Info=True;Jet OLEDB:Database Password=""{3}"";Persist Security Info=True";
        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\GmatClubTestCopy.mdb;Persist Security Info=True;Jet OLEDB:Database Password=q&b3pz>#_24
		private System.Data.OleDb.OleDbDataAdapter questionSetById;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbDataAdapter questionSetsExByTestId;
        private OleDbCommand oleDbSelectCommand5;
        private OleDbDataAdapter allQuestionSetsExAdapter;
        private OleDbCommand oleDbDeleteCommand4;
        private OleDbCommand oleDbUpdateCommand4;
        private OleDbCommand oleDbInsertCommand4;
        private OleDbCommand oleDbSelectCommand2;
        private OleDbDataAdapter allQuestionSetsAdapter;
        private OleDbCommand oleDbSelectCommand8;
        private OleDbDataAdapter questionsExByTestId;
        private OleDbCommand oleDbSelectCommand9;
        private OleDbDataAdapter passagesEx;
        private OleDbCommand oleDbSelectCommand10;
        private OleDbCommand oleDbInsertCommand6;
        private OleDbCommand oleDbUpdateCommand6;
        private OleDbCommand oleDbDeleteCommand6;
        private OleDbDataAdapter difficultyLevelDataAdapter;
        private OleDbCommand oleDbSelectCommand11;
        private OleDbCommand oleDbInsertCommand5;
        private OleDbCommand oleDbUpdateCommand5;
        private OleDbCommand oleDbDeleteCommand5;
        private OleDbDataAdapter questionSubtypesDataAdapter;
        private OleDbCommand oleDbSelectCommand12;
        private OleDbCommand oleDbInsertCommand7;
        private OleDbCommand oleDbUpdateCommand7;
        private OleDbCommand oleDbDeleteCommand7;
        private OleDbDataAdapter questionTypesDataAdapter;
        private OleDbCommand oleDbSelectCommand13;
        private OleDbCommand oleDbInsertCommand8;
        private OleDbCommand oleDbUpdateCommand8;
        private OleDbCommand oleDbDeleteCommand8;
        private OleDbDataAdapter passageToQuestionDataAdapter;
        private OleDbDataAdapter questionsExBySetId;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbSelectCommand14;
        private OleDbCommand oleDbInsertCommand9;
        private OleDbCommand oleDbUpdateCommand9;
        private OleDbCommand oleDbDeleteCommand9;
        private OleDbDataAdapter allQuestionsDataAdapter;
        private OleDbDataAdapter questionSetsExBySetId;
        private OleDbCommand oleDbCommand2;
        private OleDbDataAdapter passagesExBySetId;
        private OleDbCommand oleDbCommand3;
        private OleDbDataAdapter allQuestionsExDataAdapter;
        private OleDbCommand oleDbCommand4;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;
        private OleDbDataAdapter questionEditDataAdapter;
        private OleDbCommand oleDbCommand5;
        private OleDbCommand oleDbCommand6;
        private OleDbCommand oleDbCommand7;
        private OleDbCommand oleDbCommand8;
        private OleDbDataAdapter answersDataAdapter;
        private OleDbCommand oleDbCommand9;
        private OleDbCommand oleDbCommand10;
        private OleDbCommand oleDbCommand11;
        private OleDbCommand oleDbCommand12;
        private OleDbConnection oleDbConnection1;
        private OleDbDataAdapter passageQuestions;
        private OleDbCommand oleDbCommand13;
        private OleDbCommand oleDbCommand14;
        private OleDbCommand oleDbCommand15;
        private OleDbCommand oleDbCommand16;
        private OleDbDataAdapter questionExById;
        private OleDbCommand oleDbCommand17;
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
			allTestContentsAdapter.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
			allQuestionSetsAdapter.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
		}

		private void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs args)
		{
            //if (args.StatementType == StatementType.Insert)
            //    args.Row["Id"] = (int)idCmd.ExecuteScalar();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
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
            this.allTestsAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.allTestContentsAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.testById = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.questionSetsExByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
            this.questionSetById = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.allQuestionSetsExAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.allQuestionSetsAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
            this.questionsExByTestId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand9 = new System.Data.OleDb.OleDbCommand();
            this.passagesEx = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
            this.difficultyLevelDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
            this.questionSubtypesDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand12 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand7 = new System.Data.OleDb.OleDbCommand();
            this.questionTypesDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand8 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand8 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand8 = new System.Data.OleDb.OleDbCommand();
            this.passageToQuestionDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.questionsExBySetId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand9 = new System.Data.OleDb.OleDbCommand();
            this.allQuestionsDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.questionSetsExBySetId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.passagesExBySetId = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.allQuestionsExDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.questionEditDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.answersDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.passageQuestions = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand16 = new System.Data.OleDb.OleDbCommand();
            this.questionExById = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand17 = new System.Data.OleDb.OleDbCommand();
            // 
            // connection
            // 
            this.connection.ConnectionString = "Provider=SQLNCLI.1;Data Source=yuve;Integrated Security=SSPI;Initial Catalog=Gmat" +
                "ClubTest";
            // 
            // allTestsAdapter
            // 
            this.allTestsAdapter.DeleteCommand = this.oleDbDeleteCommand2;
            this.allTestsAdapter.InsertCommand = this.oleDbInsertCommand2;
            this.allTestsAdapter.SelectCommand = this.oleDbSelectCommand1;
            this.allTestsAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Tests", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("IsPractice", "IsPractice"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("GUID", "GUID"),
                        new System.Data.Common.DataColumnMapping("Version", "Version")})});
            this.allTestsAdapter.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.connection;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID1", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsPractice", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 128, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Version", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Version", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO Tests(Name, IsPractice, Description, QuestionTypeId, QuestionSubtypeI" +
                "d, [GUID], Version) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.connection;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 128, "Name"),
            new System.Data.OleDb.OleDbParameter("IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, "IsPractice"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("GUID", System.Data.OleDb.OleDbType.VarWChar, 36, "GUID"),
            new System.Data.OleDb.OleDbParameter("Version", System.Data.OleDb.OleDbType.Integer, 0, "Version")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT Id, Name, IsPractice, Description, QuestionTypeId, QuestionSubtypeId, [GUI" +
                "D], Version FROM Tests";
            this.oleDbSelectCommand1.Connection = this.connection;
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.connection;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 128, "Name"),
            new System.Data.OleDb.OleDbParameter("IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, "IsPractice"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("GUID", System.Data.OleDb.OleDbType.VarWChar, 36, "GUID"),
            new System.Data.OleDb.OleDbParameter("Version", System.Data.OleDb.OleDbType.Integer, 0, "Version"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID1", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsPractice", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 128, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Version", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Version", System.Data.DataRowVersion.Original, null)});
            // 
            // allTestContentsAdapter
            // 
            this.allTestContentsAdapter.DeleteCommand = this.oleDbDeleteCommand3;
            this.allTestContentsAdapter.InsertCommand = this.oleDbInsertCommand3;
            this.allTestContentsAdapter.SelectCommand = this.oleDbSelectCommand3;
            this.allTestContentsAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TestContents", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TestId", "TestId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetId", "QuestionSetId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetOrder", "QuestionSetOrder")})});
            this.allTestContentsAdapter.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM TestContents WHERE (QuestionSetId = ?) AND (TestId = ?) AND (Question" +
                "SetOrder = ?)";
            this.oleDbDeleteCommand3.Connection = this.connection;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TestId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO TestContents(TestId, QuestionSetId, QuestionSetOrder) VALUES (?, ?, ?" +
                ")";
            this.oleDbInsertCommand3.Connection = this.connection;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSetId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionSetOrder")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT TestId, QuestionSetId, QuestionSetOrder FROM TestContents";
            this.oleDbSelectCommand3.Connection = this.connection;
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE TestContents SET TestId = ?, QuestionSetId = ?, QuestionSetOrder = ? WHERE" +
                " (QuestionSetId = ?) AND (TestId = ?) AND (QuestionSetOrder = ?)";
            this.oleDbUpdateCommand3.Connection = this.connection;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSetId"),
            new System.Data.OleDb.OleDbParameter("QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionSetOrder"),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TestId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // testById
            // 
            this.testById.DeleteCommand = this.oleDbDeleteCommand1;
            this.testById.InsertCommand = this.oleDbInsertCommand1;
            this.testById.SelectCommand = this.oleDbSelectCommand4;
            this.testById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Tests", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("GUID", "GUID"),
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("IsPractice", "IsPractice"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("Version", "Version")})});
            this.testById.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.connection;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID1", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsPractice", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 128, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Version", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Version", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO Tests(Description, [GUID], IsPractice, Name, QuestionSubtypeId, Quest" +
                "ionTypeId, Version) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.connection;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("GUID", System.Data.OleDb.OleDbType.VarWChar, 36, "GUID"),
            new System.Data.OleDb.OleDbParameter("IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, "IsPractice"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 128, "Name"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("Version", System.Data.OleDb.OleDbType.Integer, 0, "Version")});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT Description, [GUID], Id, IsPractice, Name, QuestionSubtypeId, QuestionType" +
                "Id, Version FROM Tests WHERE (Id = ?)";
            this.oleDbSelectCommand4.Connection = this.connection;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 0, "Id")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.connection;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("GUID", System.Data.OleDb.OleDbType.VarWChar, 36, "GUID"),
            new System.Data.OleDb.OleDbParameter("IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, "IsPractice"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 128, "Name"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("Version", System.Data.OleDb.OleDbType.Integer, 0, "Version"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GUID1", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GUID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsPractice", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsPractice", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 128, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Version", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Version", System.Data.DataRowVersion.Original, null)});
            // 
            // questionSetsExByTestId
            // 
            this.questionSetsExByTestId.SelectCommand = this.oleDbSelectCommand6;
            this.questionSetsExByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone1", "NumberOfQuestionsInZone1"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone2", "NumberOfQuestionsInZone2"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsToPick", "NumberOfQuestionsToPick"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("TimeLimit", "TimeLimit"),
                        new System.Data.Common.DataColumnMapping("TestId", "TestId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetOrder", "QuestionSetOrder")})});
            // 
            // oleDbSelectCommand6
            // 
            this.oleDbSelectCommand6.CommandText = resources.GetString("oleDbSelectCommand6.CommandText");
            this.oleDbSelectCommand6.Connection = this.connection;
            this.oleDbSelectCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Current, "1")});
            // 
            // questionSetById
            // 
            this.questionSetById.SelectCommand = this.oleDbSelectCommand7;
            this.questionSetById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone1", "NumberOfQuestionsInZone1"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone2", "NumberOfQuestionsInZone2"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsToPick", "NumberOfQuestionsToPick"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("TimeLimit", "TimeLimit")})});
            // 
            // oleDbSelectCommand7
            // 
            this.oleDbSelectCommand7.CommandText = resources.GetString("oleDbSelectCommand7.CommandText");
            this.oleDbSelectCommand7.Connection = this.connection;
            this.oleDbSelectCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 3, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Current, "113")});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = resources.GetString("oleDbSelectCommand5.CommandText");
            this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\GmatClubTestCopy.mdb;Persist Secu" +
                "rity Info=True;Jet OLEDB:Database Password=q&b3pz>#_24";
            // 
            // allQuestionSetsExAdapter
            // 
            this.allQuestionSetsExAdapter.SelectCommand = this.oleDbSelectCommand5;
            this.allQuestionSetsExAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3"),
                        new System.Data.Common.DataColumnMapping("TestId", "TestId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetOrder", "QuestionSetOrder")})});
            // 
            // oleDbDeleteCommand4
            // 
            this.oleDbDeleteCommand4.CommandText = resources.GetString("oleDbDeleteCommand4.CommandText");
            this.oleDbDeleteCommand4.Connection = this.connection;
            this.oleDbDeleteCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            // oleDbUpdateCommand4
            // 
            this.oleDbUpdateCommand4.CommandText = resources.GetString("oleDbUpdateCommand4.CommandText");
            this.oleDbUpdateCommand4.Connection = this.connection;
            this.oleDbUpdateCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            // oleDbInsertCommand4
            // 
            this.oleDbInsertCommand4.CommandText = resources.GetString("oleDbInsertCommand4.CommandText");
            this.oleDbInsertCommand4.Connection = this.connection;
            this.oleDbInsertCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsToPick"),
            new System.Data.OleDb.OleDbParameter("TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, "TimeLimit"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone1"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone2"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone3")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT     QuestionSets.*\r\nFROM         QuestionSets";
            this.oleDbSelectCommand2.Connection = this.connection;
            // 
            // allQuestionSetsAdapter
            // 
            this.allQuestionSetsAdapter.DeleteCommand = this.oleDbDeleteCommand4;
            this.allQuestionSetsAdapter.InsertCommand = this.oleDbInsertCommand4;
            this.allQuestionSetsAdapter.SelectCommand = this.oleDbSelectCommand2;
            this.allQuestionSetsAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
            this.allQuestionSetsAdapter.UpdateCommand = this.oleDbUpdateCommand4;
            // 
            // oleDbSelectCommand8
            // 
            this.oleDbSelectCommand8.CommandText = resources.GetString("oleDbSelectCommand8.CommandText");
            this.oleDbSelectCommand8.Connection = this.connection;
            this.oleDbSelectCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 3, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Current, "104")});
            // 
            // questionsExByTestId
            // 
            this.questionsExByTestId.SelectCommand = this.oleDbSelectCommand8;
            this.questionsExByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture"),
                        new System.Data.Common.DataColumnMapping("SetId", "SetId"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder"),
                        new System.Data.Common.DataColumnMapping("QuestionZone", "QuestionZone"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId")})});
            // 
            // oleDbSelectCommand9
            // 
            this.oleDbSelectCommand9.CommandText = resources.GetString("oleDbSelectCommand9.CommandText");
            this.oleDbSelectCommand9.Connection = this.connection;
            // 
            // passagesEx
            // 
            this.passagesEx.SelectCommand = this.oleDbSelectCommand9;
            this.passagesEx.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PassagesToQuestions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("PassageQuestionId", "PassageQuestionId"),
                        new System.Data.Common.DataColumnMapping("Id", "Id")})});
            // 
            // oleDbSelectCommand10
            // 
            this.oleDbSelectCommand10.CommandText = "SELECT     Id, Name\r\nFROM         DifficultyLevel\r\nORDER BY Id";
            this.oleDbSelectCommand10.Connection = this.connection;
            // 
            // oleDbInsertCommand6
            // 
            this.oleDbInsertCommand6.CommandText = "INSERT INTO [DifficultyLevel] ([Name]) VALUES (?)";
            this.oleDbInsertCommand6.Connection = this.connection;
            this.oleDbInsertCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name")});
            // 
            // oleDbUpdateCommand6
            // 
            this.oleDbUpdateCommand6.CommandText = "UPDATE [DifficultyLevel] SET [Name] = ? WHERE (([Id] = ?) AND ([Name] = ?))";
            this.oleDbUpdateCommand6.Connection = this.connection;
            this.oleDbUpdateCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand6
            // 
            this.oleDbDeleteCommand6.CommandText = "DELETE FROM [DifficultyLevel] WHERE (([Id] = ?) AND ([Name] = ?))";
            this.oleDbDeleteCommand6.Connection = this.connection;
            this.oleDbDeleteCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null)});
            // 
            // difficultyLevelDataAdapter
            // 
            this.difficultyLevelDataAdapter.DeleteCommand = this.oleDbDeleteCommand6;
            this.difficultyLevelDataAdapter.InsertCommand = this.oleDbInsertCommand6;
            this.difficultyLevelDataAdapter.SelectCommand = this.oleDbSelectCommand10;
            this.difficultyLevelDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DifficultyLevel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name")})});
            this.difficultyLevelDataAdapter.UpdateCommand = this.oleDbUpdateCommand6;
            // 
            // oleDbSelectCommand11
            // 
            this.oleDbSelectCommand11.CommandText = "SELECT     QuestionSubtypes.*\r\nFROM         QuestionSubtypes";
            this.oleDbSelectCommand11.Connection = this.connection;
            // 
            // oleDbInsertCommand5
            // 
            this.oleDbInsertCommand5.CommandText = "INSERT INTO [QuestionSubtypes] ([Name]) VALUES (?)";
            this.oleDbInsertCommand5.Connection = this.connection;
            this.oleDbInsertCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name")});
            // 
            // oleDbUpdateCommand5
            // 
            this.oleDbUpdateCommand5.CommandText = "UPDATE [QuestionSubtypes] SET [Name] = ? WHERE (([Id] = ?) AND ([Name] = ?))";
            this.oleDbUpdateCommand5.Connection = this.connection;
            this.oleDbUpdateCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand5
            // 
            this.oleDbDeleteCommand5.CommandText = "DELETE FROM [QuestionSubtypes] WHERE (([Id] = ?) AND ([Name] = ?))";
            this.oleDbDeleteCommand5.Connection = this.connection;
            this.oleDbDeleteCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null)});
            // 
            // questionSubtypesDataAdapter
            // 
            this.questionSubtypesDataAdapter.DeleteCommand = this.oleDbDeleteCommand5;
            this.questionSubtypesDataAdapter.InsertCommand = this.oleDbInsertCommand5;
            this.questionSubtypesDataAdapter.SelectCommand = this.oleDbSelectCommand11;
            this.questionSubtypesDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSubtypes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name")})});
            this.questionSubtypesDataAdapter.UpdateCommand = this.oleDbUpdateCommand5;
            // 
            // oleDbSelectCommand12
            // 
            this.oleDbSelectCommand12.CommandText = "SELECT     QuestionTypes.*\r\nFROM         QuestionTypes";
            this.oleDbSelectCommand12.Connection = this.connection;
            // 
            // oleDbInsertCommand7
            // 
            this.oleDbInsertCommand7.CommandText = "INSERT INTO [QuestionTypes] ([Name]) VALUES (?)";
            this.oleDbInsertCommand7.Connection = this.connection;
            this.oleDbInsertCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name")});
            // 
            // oleDbUpdateCommand7
            // 
            this.oleDbUpdateCommand7.CommandText = "UPDATE [QuestionTypes] SET [Name] = ? WHERE (([Id] = ?) AND ([Name] = ?))";
            this.oleDbUpdateCommand7.Connection = this.connection;
            this.oleDbUpdateCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand7
            // 
            this.oleDbDeleteCommand7.CommandText = "DELETE FROM [QuestionTypes] WHERE (([Id] = ?) AND ([Name] = ?))";
            this.oleDbDeleteCommand7.Connection = this.connection;
            this.oleDbDeleteCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null)});
            // 
            // questionTypesDataAdapter
            // 
            this.questionTypesDataAdapter.DeleteCommand = this.oleDbDeleteCommand7;
            this.questionTypesDataAdapter.InsertCommand = this.oleDbInsertCommand7;
            this.questionTypesDataAdapter.SelectCommand = this.oleDbSelectCommand12;
            this.questionTypesDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionTypes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name")})});
            this.questionTypesDataAdapter.UpdateCommand = this.oleDbUpdateCommand7;
            // 
            // oleDbSelectCommand13
            // 
            this.oleDbSelectCommand13.CommandText = "SELECT     PassagesToQuestions.*\r\nFROM         PassagesToQuestions";
            this.oleDbSelectCommand13.Connection = this.connection;
            // 
            // oleDbInsertCommand8
            // 
            this.oleDbInsertCommand8.CommandText = "INSERT INTO [PassagesToQuestions] ([PassageQuestionId], [QuestionId], [QuestionOr" +
                "der]) VALUES (?, ?, ?)";
            this.oleDbInsertCommand8.Connection = this.connection;
            this.oleDbInsertCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("PassageQuestionId", System.Data.OleDb.OleDbType.Integer, 0, "PassageQuestionId"),
            new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"),
            new System.Data.OleDb.OleDbParameter("QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionOrder")});
            // 
            // oleDbUpdateCommand8
            // 
            this.oleDbUpdateCommand8.CommandText = "UPDATE [PassagesToQuestions] SET [PassageQuestionId] = ?, [QuestionId] = ?, [Ques" +
                "tionOrder] = ? WHERE (([PassageQuestionId] = ?) AND ([QuestionId] = ?) AND ([Que" +
                "stionOrder] = ?))";
            this.oleDbUpdateCommand8.Connection = this.connection;
            this.oleDbUpdateCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("PassageQuestionId", System.Data.OleDb.OleDbType.Integer, 0, "PassageQuestionId"),
            new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"),
            new System.Data.OleDb.OleDbParameter("QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionOrder"),
            new System.Data.OleDb.OleDbParameter("Original_PassageQuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PassageQuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand8
            // 
            this.oleDbDeleteCommand8.CommandText = "DELETE FROM [PassagesToQuestions] WHERE (([PassageQuestionId] = ?) AND ([Question" +
                "Id] = ?) AND ([QuestionOrder] = ?))";
            this.oleDbDeleteCommand8.Connection = this.connection;
            this.oleDbDeleteCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_PassageQuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PassageQuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // passageToQuestionDataAdapter
            // 
            this.passageToQuestionDataAdapter.DeleteCommand = this.oleDbDeleteCommand8;
            this.passageToQuestionDataAdapter.InsertCommand = this.oleDbInsertCommand8;
            this.passageToQuestionDataAdapter.SelectCommand = this.oleDbSelectCommand13;
            this.passageToQuestionDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PassagesToQuestions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("PassageQuestionId", "PassageQuestionId"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder")})});
            this.passageToQuestionDataAdapter.UpdateCommand = this.oleDbUpdateCommand8;
            // 
            // questionsExBySetId
            // 
            this.questionsExBySetId.SelectCommand = this.oleDbCommand1;
            this.questionsExBySetId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture"),
                        new System.Data.Common.DataColumnMapping("SetId", "SetId"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder"),
                        new System.Data.Common.DataColumnMapping("QuestionZone", "QuestionZone"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 0, "Id")});
            // 
            // oleDbSelectCommand14
            // 
            this.oleDbSelectCommand14.CommandText = "SELECT     Questions.*\r\nFROM         Questions";
            this.oleDbSelectCommand14.Connection = this.connection;
            // 
            // oleDbInsertCommand9
            // 
            this.oleDbInsertCommand9.CommandText = "INSERT INTO [Questions] ([TypeId], [SubtypeId], [DifficultyLevelId], [Text], [Pic" +
                "ture]) VALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand9.Connection = this.connection;
            this.oleDbInsertCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"),
            new System.Data.OleDb.OleDbParameter("SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"),
            new System.Data.OleDb.OleDbParameter("DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Picture")});
            // 
            // oleDbUpdateCommand9
            // 
            this.oleDbUpdateCommand9.CommandText = resources.GetString("oleDbUpdateCommand9.CommandText");
            this.oleDbUpdateCommand9.Connection = this.connection;
            this.oleDbUpdateCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            // 
            // oleDbDeleteCommand9
            // 
            this.oleDbDeleteCommand9.CommandText = "DELETE FROM [Questions] WHERE (([Id] = ?) AND ([TypeId] = ?) AND ([SubtypeId] = ?" +
                ") AND ([DifficultyLevelId] = ?) AND ([Text] = ?))";
            this.oleDbDeleteCommand9.Connection = this.connection;
            this.oleDbDeleteCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DifficultyLevelId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});
            // 
            // allQuestionsDataAdapter
            // 
            this.allQuestionsDataAdapter.DeleteCommand = this.oleDbDeleteCommand9;
            this.allQuestionsDataAdapter.InsertCommand = this.oleDbInsertCommand9;
            this.allQuestionsDataAdapter.SelectCommand = this.oleDbSelectCommand14;
            this.allQuestionsDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            this.allQuestionsDataAdapter.UpdateCommand = this.oleDbUpdateCommand9;
            // 
            // questionSetsExBySetId
            // 
            this.questionSetsExBySetId.DeleteCommand = this.oleDbDeleteCommand;
            this.questionSetsExBySetId.InsertCommand = this.oleDbInsertCommand;
            this.questionSetsExBySetId.SelectCommand = this.oleDbCommand2;
            this.questionSetsExBySetId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone1", "NumberOfQuestionsInZone1"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone2", "NumberOfQuestionsInZone2"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsToPick", "NumberOfQuestionsToPick"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("TimeLimit", "TimeLimit")})});
            this.questionSetsExBySetId.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = resources.GetString("oleDbDeleteCommand.CommandText");
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Name", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone3", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone3", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsToPick", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsToPick", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone1"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone2"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone3"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsToPick"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, "TimeLimit")});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 0, "Id")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Description"),
            new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 0, "Name"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone1"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone2"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone3"),
            new System.Data.OleDb.OleDbParameter("NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsToPick"),
            new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"),
            new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"),
            new System.Data.OleDb.OleDbParameter("TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, "TimeLimit"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Name", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone3", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsInZone3", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsToPick", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumberOfQuestionsToPick", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionTypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TimeLimit", System.Data.DataRowVersion.Original, null)});
            // 
            // passagesExBySetId
            // 
            this.passagesExBySetId.SelectCommand = this.oleDbCommand3;
            this.passagesExBySetId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PassagesToQuestions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("PassageQuestionId", "PassageQuestionId"),
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("QuestionSetId", "QuestionSetId")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.connection;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 3, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Current, "104")});
            // 
            // allQuestionsExDataAdapter
            // 
            this.allQuestionsExDataAdapter.SelectCommand = this.oleDbCommand4;
            this.allQuestionsExDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture"),
                        new System.Data.Common.DataColumnMapping("SetId", "SetId"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder"),
                        new System.Data.Common.DataColumnMapping("QuestionZone", "QuestionZone"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            // 
            // questionEditDataAdapter
            // 
            this.questionEditDataAdapter.DeleteCommand = this.oleDbCommand5;
            this.questionEditDataAdapter.InsertCommand = this.oleDbCommand6;
            this.questionEditDataAdapter.SelectCommand = this.oleDbCommand7;
            this.questionEditDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            this.questionEditDataAdapter.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM [Questions] WHERE (([Id] = ?) AND ([TypeId] = ?) AND ([SubtypeId] = ?" +
                ") AND ([DifficultyLevelId] = ?) AND ([Text] = ?))";
            this.oleDbCommand5.Connection = this.connection;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DifficultyLevelId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO Questions\r\n                      (TypeId, SubtypeId, DifficultyLevelI" +
                "d, [Text], Picture)\r\nVALUES     (?,?,?,?,?)";
            this.oleDbCommand6.Connection = this.connection;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TypeId", System.Data.OleDb.OleDbType.Integer, 4, "TypeId"),
            new System.Data.OleDb.OleDbParameter("SubtypeId", System.Data.OleDb.OleDbType.Integer, 4, "SubtypeId"),
            new System.Data.OleDb.OleDbParameter("DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 4, "DifficultyLevelId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.Char, 1024, "Text"),
            new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.Binary, 2147483647, "Picture")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT     Id, TypeId, SubtypeId, DifficultyLevelId, Text, Picture\r\nFROM         " +
                "Questions\r\nWHERE     (Id = ?)";
            this.oleDbCommand7.Connection = this.connection;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 4, "Id")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = "UPDATE    Questions\r\nSET              TypeId = ?, SubtypeId = ?, DifficultyLevelI" +
                "d = ?, [Text] = ?, Picture = ?\r\nWHERE     (Id = ?)";
            this.oleDbCommand8.Connection = this.connection;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TypeId", System.Data.OleDb.OleDbType.Integer, 4, "TypeId"),
            new System.Data.OleDb.OleDbParameter("SubtypeId", System.Data.OleDb.OleDbType.Integer, 4, "SubtypeId"),
            new System.Data.OleDb.OleDbParameter("DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 4, "DifficultyLevelId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.Char, 1024, "Text"),
            new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.Binary, 2147483647, "Picture"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // answersDataAdapter
            // 
            this.answersDataAdapter.DeleteCommand = this.oleDbCommand9;
            this.answersDataAdapter.InsertCommand = this.oleDbCommand10;
            this.answersDataAdapter.SelectCommand = this.oleDbCommand11;
            this.answersDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
                        new System.Data.Common.DataColumnMapping("Order", "Order")})});
            this.answersDataAdapter.UpdateCommand = this.oleDbCommand12;
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = "DELETE FROM [Answers] WHERE (([Id] = ?) AND ([QuestionId] = ?) AND ([Text] = ?) A" +
                "ND ([IsCorrect] = ?) AND ([Order] = ?))";
            this.oleDbCommand9.Connection = this.connection;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsCorrect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsCorrect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Order", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Order", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = "INSERT INTO [Answers] ([QuestionId], [Text], [IsCorrect], [Order]) VALUES (?, ?, " +
                "?, ?)";
            this.oleDbCommand10.Connection = this.connection;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IsCorrect", System.Data.OleDb.OleDbType.Boolean, 0, "IsCorrect"),
            new System.Data.OleDb.OleDbParameter("Order", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "Order")});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = "SELECT     Id, QuestionId, Text, IsCorrect, [Order]\r\nFROM         Answers";
            this.oleDbCommand11.Connection = this.connection;
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = "UPDATE [Answers] SET [QuestionId] = ?, [Text] = ?, [IsCorrect] = ?, [Order] = ? W" +
                "HERE (([Id] = ?) AND ([QuestionId] = ?) AND ([Text] = ?) AND ([IsCorrect] = ?) A" +
                "ND ([Order] = ?))";
            this.oleDbCommand12.Connection = this.connection;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IsCorrect", System.Data.OleDb.OleDbType.Boolean, 0, "IsCorrect"),
            new System.Data.OleDb.OleDbParameter("Order", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "Order"),
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IsCorrect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsCorrect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Order", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Order", System.Data.DataRowVersion.Original, null)});
            // 
            // passageQuestions
            // 
            this.passageQuestions.DeleteCommand = this.oleDbCommand13;
            this.passageQuestions.InsertCommand = this.oleDbCommand14;
            this.passageQuestions.SelectCommand = this.oleDbCommand15;
            this.passageQuestions.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            this.passageQuestions.UpdateCommand = this.oleDbCommand16;
            // 
            // oleDbCommand13
            // 
            this.oleDbCommand13.CommandText = "DELETE FROM [Questions] WHERE (([Id] = ?) AND ([TypeId] = ?) AND ([SubtypeId] = ?" +
                ") AND ([DifficultyLevelId] = ?) AND ([Text] = ?))";
            this.oleDbCommand13.Connection = this.connection;
            this.oleDbCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SubtypeId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DifficultyLevelId", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand14
            // 
            this.oleDbCommand14.CommandText = "INSERT INTO [Questions] ([TypeId], [SubtypeId], [DifficultyLevelId], [Text], [Pic" +
                "ture]) VALUES (?, ?, ?, ?, ?)";
            this.oleDbCommand14.Connection = this.connection;
            this.oleDbCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"),
            new System.Data.OleDb.OleDbParameter("SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"),
            new System.Data.OleDb.OleDbParameter("DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Picture", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Picture")});
            // 
            // oleDbCommand15
            // 
            this.oleDbCommand15.CommandText = "SELECT     Questions.*\r\nFROM         Questions\r\nWHERE     (Id = ?)";
            this.oleDbCommand15.Connection = this.connection;
            this.oleDbCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Current, "1768")});
            // 
            // oleDbCommand16
            // 
            this.oleDbCommand16.CommandText = resources.GetString("oleDbCommand16.CommandText");
            this.oleDbCommand16.Connection = this.connection;
            this.oleDbCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            // 
            // questionExById
            // 
            this.questionExById.SelectCommand = this.oleDbCommand17;
            this.questionExById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            // 
            // oleDbCommand17
            // 
            this.oleDbCommand17.CommandText = "SELECT     Id, TypeId, SubtypeId, DifficultyLevelId, Text, Picture\r\nFROM         " +
                "Questions\r\nWHERE     (Id = ?)";
            this.oleDbCommand17.Connection = this.connection;
            this.oleDbCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 4, "Id")});

		}
		#endregion

		public OleDbDataAdapter AllTestsAdapter
		{
			get { return allTestsAdapter; }
		}

		public OleDbDataAdapter AllQuestionSetsAdapter
		{
			get { return allQuestionSetsAdapter; }
		}

		public OleDbDataAdapter AllTestContentsAdapter
		{
			get { return allTestContentsAdapter; }
		}

	    public void FillTypes_Subtypes(Dataset types)
	    {
            difficultyLevelDataAdapter.Fill(types.DifficultyLevel);
            questionTypesDataAdapter.Fill(types.QuestionTypes);
            questionSubtypesDataAdapter.Fill(types.QuestionSubtypes);
	    }

        public void AddNewTest(Dataset.TestsRow test)
	    {
            allTestsAdapter.Update(new Dataset.TestsRow[] { test });
	    }
	    
        public void FillTest(Dataset test, int testId)
		{
            difficultyLevelDataAdapter.SelectCommand.Connection = connection;
            passagesEx.SelectCommand.Connection = connection;
            questionTypesDataAdapter.SelectCommand.Connection = connection;
            questionSubtypesDataAdapter.SelectCommand.Connection = connection;
            answersDataAdapter.SelectCommand.Connection = connection;
            testById.SelectCommand.Connection = connection;
            questionSetsExByTestId.SelectCommand.Connection = connection;
            questionsExByTestId.SelectCommand.Connection = connection;
                
            difficultyLevelDataAdapter.Fill(test.DifficultyLevel);
            questionTypesDataAdapter.Fill(test.QuestionTypes);
            questionSubtypesDataAdapter.Fill(test.QuestionSubtypes);
            //passageToQuestionDataAdapter.Fill(test.PassagesToQuestions);
            
            //passagesEx.SelectCommand.Parameters[0].Value = testId;
            
            answersDataAdapter.Fill(test.Answers);
            
            testById.SelectCommand.Parameters[0].Value = testId;
            testById.Fill(test);

            questionSetsExByTestId.SelectCommand.Parameters[0].Value = testId;
            questionSetsExByTestId.Fill(test.QuestionSetsEx);

            questionsExByTestId.SelectCommand.Parameters[0].Value = testId;
            questionsExByTestId.Fill(test.QuestionsEx);

            passagesEx.Fill(test.PassagesToQuestionsEx);
            for (int i = 0; i < test.PassagesToQuestionsEx.Count; ++i)
            {   
                for(int j=0; j<test.QuestionsEx.Count; ++j)
                {
                    if(test.PassagesToQuestionsEx[i].Id == test.QuestionsEx[j].Id)
                    {
                        Dataset sd = new Dataset();
                        passageQuestions.SelectCommand.Parameters[0].Value = test.PassagesToQuestionsEx[i].PassageQuestionId;
                        passageQuestions.Fill(sd.PassageQuestions);
                        //test.PassageQuestions.AddPassageQuestionsRow(sd.PassageQuestions[0].Id, sd.PassageQuestions[0].TypeId, sd.PassageQuestions[0].SubtypeId, sd.PassageQuestions[0].DifficultyLevelId, sd.PassageQuestions[0].Text, null);
                       // questionExById.SelectCommand.Parameters[0].Value = sd.PassageQuestions[0].Id;
                        //questionExById.Fill(sd.Questions);
                        if (test.QuestionsEx.FindByIdSetId(test.PassagesToQuestionsEx[i].PassageQuestionId, test.QuestionsEx[j].SetId) == null)
                        {
                            test.QuestionsEx.AddQuestionsExRow(sd.PassageQuestions[0].TypeId, sd.PassageQuestions[0].SubtypeId, sd.PassageQuestions[0].DifficultyLevelId, sd.PassageQuestions[0].Text, null, test.QuestionsEx[j].SetId, 0, 0, 0);
                            test.QuestionsEx[test.QuestionsEx.Count - 1].Id = test.PassagesToQuestionsEx[i].PassageQuestionId;
                        }
                    }
                }
            }
           
            
            //for (int i = 0; i < test.PassagesToQuestionsEx.Count; ++i)
            //{
            //    if (test.Questions.FindById(test.PassagesToQuestionsEx[i].PassageQuestionId) == null)
            //    {
            //        questionEditDataAdapter.SelectCommand.Parameters[0].Value = test.PassagesToQuestionsEx[i].PassageQuestionId;
            //        Dataset sd = new Dataset();
            //        questionEditDataAdapter.Fill(sd.Questions);
            //        test.QuestionsEx.AddQuestionsExRow(sd.Questions[0].TypeId, sd.Questions[0].SubtypeId, sd.Questions[0].DifficultyLevelId, sd.Questions[0].Text, (sd.Questions[0].IsPictureNull() ? (null) : (sd.Questions[0].Picture)), test.QuestionsEx[0].SetId, 254, 0, sd.Questions[0].Id);
            //        //.AddQuestionsRow(sd.Questions[0]);
            //    }
            //    else
            //    {
            //        test.PassagesToQuestionsEx[i].Delete();
            //    }
            //}
			
		}
		public void FillQuestionSet(Dataset questionSet, int questionSetId)
		{

            difficultyLevelDataAdapter.SelectCommand.Connection = connection;
            questionTypesDataAdapter.SelectCommand.Connection = connection;
            questionSubtypesDataAdapter.SelectCommand.Connection = connection;
		    answersDataAdapter.SelectCommand.Connection = connection;
		    passagesExBySetId.SelectCommand.Connection = connection;
		    allQuestionSetsAdapter.SelectCommand.Connection = connection;
            questionsExBySetId.SelectCommand.Connection = connection;
		    
            difficultyLevelDataAdapter.Fill(questionSet.DifficultyLevel);
            questionTypesDataAdapter.Fill(questionSet.QuestionTypes);
            questionSubtypesDataAdapter.Fill(questionSet.QuestionSubtypes);
          
            passagesExBySetId.SelectCommand.Parameters[0].Value = questionSetId;
            passagesExBySetId.Fill(questionSet.PassagesToQuestionsEx);

            answersDataAdapter.Fill(questionSet.Answers);
		    
            allQuestionSetsAdapter.Fill(questionSet.QuestionSets);

            for (int i = 0; i < questionSet.QuestionSets.Count; ++i )
            {
                questionSet.QuestionSetsEx.AddQuestionSetsExRow(questionSet.QuestionSets[i].Id,
                    questionSet.QuestionSets[i].Name,
                    questionSet.QuestionSets[i].Description,
                    questionSet.QuestionSets[i].NumberOfQuestionsToPick,
                    0,
                    0,
                    0,
                    questionSet.QuestionSets[i].NumberOfQuestionsInZone1,
                    questionSet.QuestionSets[i].NumberOfQuestionsInZone2,
                    questionSet.QuestionSets[i].NumberOfQuestionsInZone3,
                    0, 0);
                if(questionSet.QuestionSets[i].IsQuestionTypeIdNull())
                {
                     questionSet.QuestionSetsEx[i].SetQuestionTypeIdNull();
                }else
                {
                    questionSet.QuestionSetsEx[i].QuestionTypeId = questionSet.QuestionSets[i].QuestionTypeId; 
                }

                if (questionSet.QuestionSets[i].IsQuestionSubtypeIdNull())
                {
                    questionSet.QuestionSetsEx[i].SetQuestionSubtypeIdNull();
                }
                else
                {
                    questionSet.QuestionSetsEx[i].QuestionSubtypeId = questionSet.QuestionSets[i].QuestionSubtypeId;
                }

                if (questionSet.QuestionSets[i].IsTimeLimitNull())
                {
                    questionSet.QuestionSetsEx[i].SetTimeLimitNull();
                }
                else
                {
                    questionSet.QuestionSetsEx[i].TimeLimit = questionSet.QuestionSets[i].TimeLimit;
                }
            }

            questionsExBySetId.SelectCommand.Parameters[0].Value = questionSetId;
            questionsExBySetId.Fill(questionSet.QuestionsEx);

            passagesEx.Fill(questionSet.PassagesToQuestionsEx);
            for (int i = 0; i < questionSet.PassagesToQuestionsEx.Count; ++i)
            {
                for (int j = 0; j < questionSet.QuestionsEx.Count; ++j)
                {
                    if (questionSet.PassagesToQuestionsEx[i].Id == questionSet.QuestionsEx[j].Id)
                    {
                        Dataset sd = new Dataset();
                        passageQuestions.SelectCommand.Parameters[0].Value = questionSet.PassagesToQuestionsEx[i].PassageQuestionId;
                        passageQuestions.Fill(sd.PassageQuestions);
                        if (questionSet.QuestionsEx.FindByIdSetId(questionSet.PassagesToQuestionsEx[i].PassageQuestionId, questionSet.QuestionsEx[j].SetId) == null)
                        {
                            questionSet.QuestionsEx.AddQuestionsExRow(sd.PassageQuestions[0].TypeId, sd.PassageQuestions[0].SubtypeId, sd.PassageQuestions[0].DifficultyLevelId, sd.PassageQuestions[0].Text, null, questionSet.QuestionsEx[j].SetId, 0, 0, 0);
                            questionSet.QuestionsEx[questionSet.QuestionsEx.Count - 1].Id = questionSet.PassagesToQuestionsEx[i].PassageQuestionId;
                        }
                    }
                }
            }
		}


        public OleDbDataAdapter AllQuestionSetsExAdapter
        {
            get { return allQuestionSetsExAdapter; }
        }
	    
	    public void FillAllQuestionSetsEx(Dataset dataset)
	    {
            allQuestionSetsExAdapter.Fill(dataset.QuestionSetsEx);
	    }
	
		public void UpdateQuestionSet(Dataset.QuestionSetsExRow questionSet)
		{
			//allQuestionSetsAdapter.Update(new Dataset.QuestionSetsExRow[] {questionSet});
            OleDbCommand c = connection.CreateCommand();

            c.CommandText = @"UPDATE QuestionSets SET Name = '" + questionSet.Name +"'"+
                            ", Description = '" + questionSet.Description + "'" +
                            ", NumberOfQuestionsToPick = " + questionSet.NumberOfQuestionsToPick +
                            ", TimeLimit = " + (questionSet.IsTimeLimitNull()?("null"):(questionSet.TimeLimit.ToString())) +
                            ",QuestionTypeId = " + (questionSet.IsQuestionTypeIdNull()?("null"):(questionSet.QuestionTypeId.ToString()))+
                            ",QuestionSubtypeId = " +(questionSet.IsQuestionSubtypeIdNull()?("null"):(questionSet.QuestionSubtypeId.ToString()))+
                            ",NumberOfQuestionsInZone1 =" + questionSet.NumberOfQuestionsInZone1.ToString() +
                            ",NumberOfQuestionsInZone2 =" + questionSet.NumberOfQuestionsInZone2.ToString() +
                            ",NumberOfQuestionsInZone3 =" + questionSet.NumberOfQuestionsInZone3.ToString() +
                            " Where id = "  + (questionSet.Id.ToString());
		    
             if (c.ExecuteNonQuery() == 0)
             {
                allQuestionSetsAdapter.Update(new Dataset.QuestionSetsExRow[] { questionSet });
             }
		    
			
	    }

	    public OleDbDataAdapter QuestionSetById
	    {
            get { return questionSetById; }
	    }
	    
	    public OleDbDataAdapter QuestionEditor
        {
            get { return questionEditDataAdapter; }    
	    }
	
	    public void GetAllQuestionsEx(Dataset.QuestionsExDataTable questionDataTable)
	    {
            allQuestionsExDataAdapter.SelectCommand.Connection = connection;
            allQuestionsExDataAdapter.Fill(questionDataTable);
	    }
	    
		public void UpdateTest(Dataset fullDs)
		{
		  
            allTestsAdapter.Update(new Dataset.TestsRow[] {fullDs.Tests[0]});
		    Dataset da = new Dataset();
            questionSetsExByTestId.SelectCommand.Parameters[0].Value = fullDs.Tests[0].Id;
		    questionSetsExByTestId.Fill(da);
            for (int i = 0; i < fullDs.QuestionSetsEx.Count; ++i)
            {
                if (fullDs.QuestionSetsEx[i].RowState != DataRowState.Deleted)
                {
                    if (fullDs.QuestionSetsEx[i].TestId == fullDs.Tests[0].Id)
                    {
                        UpdateQuestionSet(fullDs.QuestionSetsEx[i]);
                    }
                }
            }
                    
              
            OleDbTransaction t = connection.BeginTransaction();
            try
            {
                OleDbCommand c = connection.CreateCommand();
                c.Transaction = t;
				
                c.CommandText = "DELETE FROM TestContents WHERE TestId=" + fullDs.Tests[0].Id;
                c.ExecuteNonQuery();

                for (int i = 0; i < fullDs.QuestionSetsEx.Count; ++i)
                {
                    if (fullDs.QuestionSetsEx[i].RowState != DataRowState.Deleted)
                    {
                        c.CommandText = String.Format("INSERT INTO TestContents(TestId, QuestionSetId, QuestionSetOrder) VALUES({0},{1},{2})", fullDs.Tests[0].Id, fullDs.QuestionSetsEx[i].Id, i);
                        c.ExecuteNonQuery();
                    }
                }

                t.Commit();
            } catch (Exception e)
            {
                t.Rollback();
                throw e;
            }
		}

	    public void DeleteSetFromTest(int setId, int testId)
	    {
            OleDbCommand com = connection.CreateCommand();
            string comS ="";

            comS = "DELETE TestContents WHERE (TestId ="+ testId + ") and (QuestionSetId   =" + setId +")";	
	        
	        com.CommandText = comS;
            com.ExecuteNonQuery();
	      
	    }

	    public void AddExistingSetToTest(int setId, int testId, int setOrder)
	    {
            OleDbCommand com = connection.CreateCommand();
            string comS = "";

            comS = @"Insert INTO TestContents (TestId,QuestionSetId,QuestionSetOrder) VALUES (";

            comS += "N'" + (testId) + "'" + ",N'" + (setId) + "'" + ",N'" + (setOrder) + "')";
            com.CommandText = comS;
            com.ExecuteNonQuery();
	    }

        public void UpdateSetsToQuestions(Dataset dataset, int setId)
	    {
            OleDbCommand c = connection.CreateCommand();
            int numberOfQuestionsToPick = -1;
           
            numberOfQuestionsToPick = dataset.QuestionSetsEx.FindById(setId).NumberOfQuestionsToPick;
            c.CommandText = @"UPDATE QuestionSets SET NumberOfQuestionsToPick =" + 0 + " Where id = " + setId;
            c.ExecuteNonQuery();
                      
               
            c.CommandText = @"DELETE FROM SetsToQuestions WHERE (SetId=" + setId +")";
            c.ExecuteNonQuery();

            for (int i = 0; i < dataset.QuestionsEx.Count; ++i)
            {
               
                if(dataset.QuestionsEx[i].RowState != DataRowState.Deleted)
                {
                    if (dataset.QuestionsEx[i].SetId != setId)
                    { continue; }
                    if(dataset.QuestionsEx[i].SubtypeId == 3){continue;}
                    if (dataset.QuestionsEx[i].RowState == DataRowState.Added)
                    {
                        c.CommandText = "SELECT id FROM Questions WHERE ((TypeId = " + dataset.QuestionsEx[i].TypeId + ") AND (SubtypeId = " + dataset.QuestionsEx[i].SubtypeId + ") AND (DifficultyLevelId = " + dataset.QuestionsEx[i].DifficultyLevelId + ") AND (Text = '" + dataset.QuestionsEx[i].Text + "'))";
                        OleDbDataReader reader = c.ExecuteReader();
                        reader.Read();
                        int iDqr = (int)reader[0];
                        reader.Dispose();

                        c.CommandText = String.Format(@"Insert into SetsToQuestions (SetId, QuestionId ,QuestionOrder, QuestionZone) VALUES({0},{1},{2},{3})", setId, iDqr, dataset.QuestionsEx[i].QuestionOrder, dataset.QuestionsEx[i].QuestionZone);
                        c.ExecuteNonQuery();
                        ///numberOfQuestionsToPick++;
                    }
                    else
                    {
                        c.CommandText = String.Format(@"Insert into SetsToQuestions (SetId, QuestionId ,QuestionOrder, QuestionZone) VALUES({0},{1},{2},{3})", setId, dataset.QuestionsEx[i].QuestionId, dataset.QuestionsEx[i].QuestionOrder, dataset.QuestionsEx[i].QuestionZone);
                        c.ExecuteNonQuery();
                      //  numberOfQuestionsToPick++;
                    }
                }
            }
            
            c.CommandText = @"UPDATE QuestionSets SET NumberOfQuestionsToPick =" + (numberOfQuestionsToPick) + " Where id = " + setId;
            c.ExecuteNonQuery();
            
            //for (int i = 0; i < dataset.QuestionsEx.Count; ++i)
            //{
            //    c.CommandText = String.Format(@"Insert into SetsToQuestions (SetId, QuestionId ,QuestionOrder, QuestionZone) VALUES({0},{1},{2},{3})", setId, dataset.QuestionsEx[i].QuestionId, dataset.QuestionsEx[i].QuestionOrder, dataset.QuestionsEx[i].QuestionZone);
            //    c.ExecuteNonQuery();
            //}
            

            //for (int i = 0; i < dataset.PassagesToQuestionsEx.Count; ++i)
            //{
            //    if(dataset.PassagesToQuestionsEx[i] == null)
            //    {
            //        continue;
            //    }
            //    if (dataset.PassagesToQuestionsEx[i].RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if (dataset.QuestionsEx.FindByIdSetId(dataset.PassagesToQuestionsEx[i].Id, setId) == null)
            //    {
            //        c.CommandText = "DELETE FROM PassagesToQuestions WHERE (QuestionId = " + dataset.PassagesToQuestionsEx[i].Id + ")";
            //        c.ExecuteNonQuery();
            //        continue;
            //    }
            //    if (dataset.QuestionsEx.FindByIdSetId(dataset.PassagesToQuestionsEx[i].Id, setId).SetId == setId)
            //    {
            //       //c.CommandText = "DELETE FROM PassagesToQuestions WHERE ((PassageQuestionId=" + dataset.PassagesToQuestionsEx[i].PassageQuestionId + ")AND(QuestionId = " + dataset.PassagesToQuestionsEx[i].Id + "))";
            //        c.CommandText = "DELETE FROM PassagesToQuestions WHERE (QuestionId = " + dataset.PassagesToQuestionsEx[i].Id + ")";
            //        c.ExecuteNonQuery();
                                      
            //    }
            //}

            //for (int i = 0; i < dataset.PassagesToQuestionsEx.Count; ++i)
            //{
            //    if (dataset.PassagesToQuestionsEx[i].RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if (dataset.QuestionsEx.FindByIdSetId(dataset.PassagesToQuestionsEx[i].Id, setId).SetId == setId)
            //    {
            //        int passageQuestionId = -1;
            //        int questionId = -1;
            //        bool flag = false;
            //        for (int j = 0; j < oldQuestionId.Length; ++j)
            //        {
            //            if (oldQuestionId[j] == dataset.PassagesToQuestionsEx[i].PassageQuestionId)
            //            {
            //                passageQuestionId = newQuestionId[j];
            //                flag = true;
            //                break;
            //            }
            //        }
            //        if (flag == false)
            //        {
            //            passageQuestionId = dataset.PassagesToQuestionsEx[i].PassageQuestionId;
            //        }

            //        flag = false;
            //        for (int j = 0; j < oldQuestionId.Length; ++j)
            //        {
            //            if (oldQuestionId[j] == dataset.PassagesToQuestionsEx[i].Id)
            //            {
            //                questionId = newQuestionId[j];
            //                flag = true;
            //                break;
            //            }
            //        }
            //        if (flag == false)
            //        {
            //            questionId = dataset.PassagesToQuestionsEx[i].Id;
            //        }

            //       // c.CommandText = String.Format("Insert into PassagesToQuestions (PassageQuestionId, QuestionId ,QuestionOrder) VALUES({0},{1},{2})", passageQuestionId, questionId, 0);
            //        c.CommandText = String.Format("Insert into PassagesToQuestions (PassageQuestionId, QuestionId ,QuestionOrder) VALUES({0},{1},{2})", passageQuestionId, questionId, 0);
            //        c.ExecuteNonQuery();
            //    }
            //}
	        
            //answersDataAdapter.Update(dataset.Answers);
            
          
        
	    }

	    public void AddQuestionsExToDataSet(Dataset dataset, int setId)
	    {
            questionsExBySetId.SelectCommand.Parameters[0].Value = setId;
            questionsExBySetId.Fill(dataset.QuestionsEx);
	    }

	    public void AddNewQuestionSet(Dataset.QuestionSetsRow qs)
	    {
            allQuestionSetsAdapter.Update(new Dataset.QuestionSetsRow[] { qs });
	    }

        public void AddExistingQuestionToSet(Dataset.QuestionsExRow qsr, int order, int setId)
	    {
            OleDbCommand c = connection.CreateCommand();
            c.CommandText = String.Format(@"Insert into SetsToQuestions (SetId, QuestionId ,QuestionOrder, QuestionZone) VALUES({0},{1},{2},{3})", setId, qsr.Id, order, qsr.QuestionZone);
            c.ExecuteNonQuery();
	    }

	    public void LoadQuestions(Dataset dataset, int setId)
	    {
            difficultyLevelDataAdapter.SelectCommand.Connection = connection;
            questionTypesDataAdapter.SelectCommand.Connection = connection;
            questionSubtypesDataAdapter.SelectCommand.Connection = connection;
            answersDataAdapter.SelectCommand.Connection = connection;
            passagesExBySetId.SelectCommand.Connection = connection;
            allQuestionSetsAdapter.SelectCommand.Connection = connection;
            questionsExBySetId.SelectCommand.Connection = connection;

            difficultyLevelDataAdapter.Fill(dataset.DifficultyLevel);
            questionTypesDataAdapter.Fill(dataset.QuestionTypes);
            questionSubtypesDataAdapter.Fill(dataset.QuestionSubtypes);

            passagesExBySetId.SelectCommand.Parameters[0].Value = setId;
            passagesExBySetId.Fill(dataset.PassagesToQuestionsEx);

            answersDataAdapter.Fill(dataset.Answers);

            allQuestionSetsAdapter.Fill(dataset.QuestionSets);

            for (int i = 0; i < dataset.QuestionSets.Count; ++i)
            {
                dataset.QuestionSetsEx.AddQuestionSetsExRow(dataset.QuestionSets[i].Id,
                    dataset.QuestionSets[i].Name,
                    dataset.QuestionSets[i].Description,
                    dataset.QuestionSets[i].NumberOfQuestionsToPick,
                    0,
                    0,
                    0,
                    dataset.QuestionSets[i].NumberOfQuestionsInZone1,
                    dataset.QuestionSets[i].NumberOfQuestionsInZone2,
                    dataset.QuestionSets[i].NumberOfQuestionsInZone3,
                    0, 0);
                if (dataset.QuestionSets[i].IsQuestionTypeIdNull())
                {
                    dataset.QuestionSetsEx[i].SetQuestionTypeIdNull();
                }
                else
                {
                    dataset.QuestionSetsEx[i].QuestionTypeId = dataset.QuestionSets[i].QuestionTypeId;
                }

                if (dataset.QuestionSets[i].IsQuestionSubtypeIdNull())
                {
                    dataset.QuestionSetsEx[i].SetQuestionSubtypeIdNull();
                }
                else
                {
                    dataset.QuestionSetsEx[i].QuestionSubtypeId = dataset.QuestionSets[i].QuestionSubtypeId;
                }

                if (dataset.QuestionSets[i].IsTimeLimitNull())
                {
                    dataset.QuestionSetsEx[i].SetTimeLimitNull();
                }
                else
                {
                    dataset.QuestionSetsEx[i].TimeLimit = dataset.QuestionSets[i].TimeLimit;
                }
            }

            questionsExBySetId.SelectCommand.Parameters[0].Value = setId;
            questionsExBySetId.Fill(dataset.QuestionsEx);
	       
	    }

	    

	    public void UpdateQuestion(Dataset dataset, Dataset.QuestionsExRow value)
	    {
            OleDbCommand c = connection.CreateCommand();
            value.Text = value.Text.Replace("'", "\"");
            //c.CommandText = @"UPDATE Questions SET TypeId = " +value.TypeId + ", SubtypeId=" +value.SubtypeId + ", DifficultyLevelId=" +value.DifficultyLevelId + ",[Text]='" +value.Text + "'";
            //c.CommandText += ", Picture = null";
            //c.CommandText += " Where id = " +value.Id;
            
            if (value.RowState == DataRowState.Added)
            {
                questionEditDataAdapter.InsertCommand.Connection = connection;
                questionEditDataAdapter.InsertCommand.Parameters["TypeId"].Value = value.TypeId;
                questionEditDataAdapter.InsertCommand.Parameters["SubtypeId"].Value = value.SubtypeId;
                questionEditDataAdapter.InsertCommand.Parameters["DifficultyLevelId"].Value = value.DifficultyLevelId;
                questionEditDataAdapter.InsertCommand.Parameters["Text"].Value = value.Text;

                if (!value.IsPictureNull())
                {
                    questionEditDataAdapter.InsertCommand.Parameters["Picture"].Value = value.Picture;
                }
                else
                {
                    questionEditDataAdapter.InsertCommand.Parameters["Picture"].Value = DBNull.Value;
                }
                int oldId = value.Id;
                questionEditDataAdapter.InsertCommand.ExecuteNonQuery();
                c.CommandText = "SELECT id FROM Questions WHERE ((TypeId = " + value.TypeId + ") AND (SubtypeId = " + value.SubtypeId + ") AND (DifficultyLevelId = " + value.DifficultyLevelId + ") AND (Text = '" + value.Text + "'))";
                OleDbDataReader reader = c.ExecuteReader();
                reader.Read();
                int iDqr = (int)reader[0];
                reader.Dispose();
                dataset.QuestionsEx.FindByIdSetId(oldId, value.SetId).Id = iDqr;
                for(int i=0; i< dataset.Answers.Count; ++i)
                {
                    if (dataset.Answers[i].QuestionId == value.Id)
                        dataset.Answers[i].QuestionId = iDqr;
                }
                if (value.SubtypeId != 3)
                {
                    c.CommandText = String.Format(@"Insert into SetsToQuestions (SetId, QuestionId ,QuestionOrder, QuestionZone) VALUES({0},{1},{2},{3})", value.SetId, iDqr, value.QuestionOrder, value.QuestionZone);
                    c.ExecuteNonQuery();
                }else
                {
                    c.CommandText = @"DELETE FROM SetsToQuestions WHERE (QuestionId=" + iDqr + ")";
                    c.ExecuteNonQuery();
                }

            }
            else
            {
                
                    questionEditDataAdapter.UpdateCommand.Connection = connection;
                    questionEditDataAdapter.UpdateCommand.Parameters[5].Value = value.Id;
                    questionEditDataAdapter.UpdateCommand.Parameters["TypeId"].Value = value.TypeId;
                    questionEditDataAdapter.UpdateCommand.Parameters["SubtypeId"].Value = value.SubtypeId;
                    questionEditDataAdapter.UpdateCommand.Parameters["DifficultyLevelId"].Value = value.DifficultyLevelId;
                    questionEditDataAdapter.UpdateCommand.Parameters["Text"].Value = value.Text;
                    if (!value.IsPictureNull())
                    {
                        questionEditDataAdapter.UpdateCommand.Parameters["Picture"].Value = value.Picture;
                    }
                    else
                    {
                        questionEditDataAdapter.UpdateCommand.Parameters["Picture"].Value = DBNull.Value;
                    }
                    questionEditDataAdapter.UpdateCommand.ExecuteNonQuery();
            }
	        
            answersDataAdapter.Update(dataset.Answers);
	    }


	    public void UpdatePassageQuestion(Dataset dataset, Dataset.QuestionsExRow value)
        {
            OleDbCommand c = connection.CreateCommand();
            value.Text = value.Text.Replace("'", "\"");
            if (value.RowState == DataRowState.Added)
            {
                questionEditDataAdapter.InsertCommand.Connection = connection;
                questionEditDataAdapter.InsertCommand.Parameters["TypeId"].Value = value.TypeId;
                questionEditDataAdapter.InsertCommand.Parameters["SubtypeId"].Value = value.SubtypeId;
                questionEditDataAdapter.InsertCommand.Parameters["DifficultyLevelId"].Value = value.DifficultyLevelId;
                questionEditDataAdapter.InsertCommand.Parameters["Text"].Value = value.Text;

                if (!value.IsPictureNull())
                {
                    questionEditDataAdapter.InsertCommand.Parameters["Picture"].Value = value.Picture;
                }
                else
                {
                    questionEditDataAdapter.InsertCommand.Parameters["Picture"].Value = DBNull.Value;
                }

                //questionEditDataAdapter.InsertCommand.ExecuteNonQuery();
                //c.CommandText = "SELECT id FROM Questions WHERE ((TypeId = " + value.TypeId + ") AND (SubtypeId = " + value.SubtypeId + ") AND (DifficultyLevelId = " + value.DifficultyLevelId + ") AND (Text = '" + value.Text + "'))";
                //OleDbDataReader reader = c.ExecuteReader();
                //reader.Read();
                //int iDqr = (int)reader[reader.Depth];
                //value.Id = iDqr;
                //reader.Dispose();
                
            }
            else
            {

                questionEditDataAdapter.UpdateCommand.Connection = connection;
                questionEditDataAdapter.UpdateCommand.Parameters[5].Value = value.Id;
                questionEditDataAdapter.UpdateCommand.Parameters["TypeId"].Value = value.TypeId;
                questionEditDataAdapter.UpdateCommand.Parameters["SubtypeId"].Value = value.SubtypeId;
                questionEditDataAdapter.UpdateCommand.Parameters["DifficultyLevelId"].Value = value.DifficultyLevelId;
                questionEditDataAdapter.UpdateCommand.Parameters["Text"].Value = value.Text;
                if (!value.IsPictureNull())
                {
                    questionEditDataAdapter.UpdateCommand.Parameters["Picture"].Value = value.Picture;
                }
                else
                {
                    questionEditDataAdapter.UpdateCommand.Parameters["Picture"].Value = DBNull.Value;
                }
                questionEditDataAdapter.UpdateCommand.ExecuteNonQuery();
            }

           
   
            for (int i = 0; i < dataset.QuestionsEx.Count; i++)
            {
                if(dataset.QuestionsEx[i].RowState == DataRowState.Deleted){continue;}
                               
                //if (dataset.QuestionsEx[i].SetId != value.SetId)
                //{
                //    //dataset.QuestionsEx[i].Delete();
                //    continue;
                //}
                int questionId = dataset.QuestionsEx[i].Id;
                
                if (dataset.QuestionsEx[i].RowState == DataRowState.Added)
                {
                    //c.CommandText = "SELECT id FROM Questions WHERE ((TypeId = " + dataset.QuestionsEx[i].TypeId + ") AND (SubtypeId = " + dataset.QuestionsEx[i].SubtypeId + ") AND (DifficultyLevelId = " + dataset.QuestionsEx[i].DifficultyLevelId + ") AND (Text = '" + dataset.QuestionsEx[i].Text + "'))";
                    //OleDbDataReader reader = c.ExecuteReader();
                    //reader.Read();
                    //questionId = (int)reader[reader.Depth];
                    //reader.Dispose();
                }
                if (dataset.QuestionsEx[i].SubtypeId == 3)
                {
                    c.CommandText = @"DELETE FROM SetsToQuestions WHERE (QuestionId=" + questionId + ")";
                    c.ExecuteNonQuery();
                }
                
                if (dataset.QuestionsEx[i].SubtypeId != 4)
                {
                    // dataset.QuestionsEx[i].Delete();
                    continue;
                }

                for(int j =0; j< dataset.PassagesToQuestionsEx.Count; ++j)
                {
                    if(dataset.PassagesToQuestionsEx[j].PassageQuestionId == value.Id)
                    {
                        c.CommandText = "DELETE FROM PassagesToQuestions Where ((PassageQuestionId = " + value.Id + ")AND( QuestionId =" + questionId + "))";
                        c.ExecuteNonQuery();

                        c.CommandText = String.Format("Insert into PassagesToQuestions (PassageQuestionId, QuestionId ,QuestionOrder) VALUES({0},{1},{2})", value.Id, questionId, 0);
                        c.ExecuteNonQuery();
                    }
                }
                
               
            }
	        
	    }
	}
}
