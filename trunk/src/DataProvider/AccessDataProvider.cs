using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;

namespace GmatClubTest.DataProvider
{
	public class AccessDataProvider : BaseDataProvider
	{
		private string password;
		private string fileName = "GmatClubTest.mdb";
		private OleDbDataAdapter adapterUsers;
		private OleDbCommand sqlInsertCommand1;
		private OleDbCommand sqlUpdateCommand1;
		private OleDbCommand sqlDeleteCommand1;
		private OleDbCommand sqlSelectAllUsers;
		private OleDbDataAdapter adapterTests;
		private OleDbCommand sqlSelectAll;
		private OleDbCommand sqlInsertCommand2;
		private OleDbCommand sqlUpdateCommand2;
		private OleDbCommand sqlDeleteCommand2;
		private OleDbCommand sqlSelectAnswersByQestionId;
		private OleDbCommand sqlInsertCommand4;
		private OleDbCommand sqlUpdateCommand4;
		private OleDbCommand sqlDeleteCommand4;
		private OleDbDataAdapter adapterQuestionById;
		private OleDbDataAdapter adapterAnswersByQuestionId;
		private OleDbDataAdapter adapterUserById;
		private OleDbCommand sqlInsertCommand5;
		private OleDbCommand sqlUpdateCommand5;
		private OleDbCommand sqlDeleteCommand5;
		private OleDbCommand sqlSelectUserById;
		private OleDbDataAdapter adapterQuestionsByQuestionSetId;
		private OleDbDataAdapter adapterAnswersByQuestionSetId;
		private OleDbCommand sqlSelectAnswersByQuestionSetId;
		private OleDbDataAdapter adapterResultsByUserIdTimeRange;
		
		private OleDbCommand sqlSelectQuestionSetsByTestId;
		private OleDbCommand sqlSelectCommand5a;
		private OleDbCommand sqlSelectCommand1;
		private OleDbCommand sqlInsertCommand7;
		private OleDbCommand sqlUpdateCommand7;
		private OleDbCommand sqlDeleteCommand7;
		private OleDbCommand sqlSelectCommand2;
		private OleDbCommand sqlInsertCommand8;
		private OleDbCommand sqlUpdateCommand8;
		private OleDbCommand sqlDeleteCommand8;
		private OleDbCommand sqlSelectCommand3;
		private OleDbCommand sqlInsertCommand3;
		private OleDbCommand sqlUpdateCommand3;
		private OleDbCommand sqlDeleteCommand3;
		private OleDbCommand sqlSelectResultsByUserIdTimeRange;

		private OleDbCommand sqlSelectResultsByResultId;
		private OleDbCommand sqlInsertCommand6;
		private OleDbCommand sqlUpdateCommand6;
		private OleDbCommand sqlDeleteCommand6;
		private OleDbCommand sqlSelectCommand4;
		private OleDbConnection oleDbConnection;
		private OleDbCommand idCmd;
		private System.Data.OleDb.OleDbDataAdapter adapterPassagesToQuestionsByQuestionId;
		private System.Data.OleDb.OleDbCommand oleDbSelectPassagesToQuestionsByQuestionId;
		private System.Data.OleDb.OleDbDataAdapter adapterQuestionSetsByTestId;
		
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbDataAdapter adapterQuestionsByQuestionSetIdAndZone;
		private System.Data.OleDb.OleDbCommand oleDbSelectQuestionsByQuestionSetIdAndZone;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter adapterAnswersByQuestionSetIdAndZone;


		private OleDbDataAdapter adapterResultsByResultId;
		private OleDbDataAdapter adapterResultsDetailsByResultId;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand selectAnswersByQuestionSetIdAndZone;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbDataAdapter adapterResultsDetailsOfSetsByResultId;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private System.Data.OleDb.OleDbDataAdapter adapterQuestionSetsExByResultId;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		private System.Data.OleDb.OleDbDataAdapter adapterResultDetailsByResultId;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand8;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public AccessDataProvider(IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			Init();
		}

		private void Init()
		{
			idCmd = new OleDbCommand("SELECT @@IDENTITY", oleDbConnection);
			adapterResultsByResultId.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
			adapterUsers.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
		}

		public AccessDataProvider()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
			
			Init();
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

		public override void Open()
		{
			oleDbConnection.Open();
		}

		public override void Close()
		{
			oleDbConnection.Close();
		}

		public string FileName
		{
			get {return fileName;}
			set
			{
				if (!File.Exists(value)) throw new Exception(String.Format("File {0} is not found.", value));
				fileName = value;
				RebuildConnectionString();
			}
		}

		private void RebuildConnectionString()
		{
			oleDbConnection.ConnectionString = String.Format("Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Database Password=\"{1}\";Data Source=\"{0}\";Password=;Mode=Share Deny None;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=\"Microsoft.Jet.OLEDB.4.0\";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=True;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=True;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1", fileName, Password);
		}

		protected override DbDataAdapter AdapterUsers
		{
			get {return adapterUsers;}
		}

		protected override DbDataAdapter AdapterUserById
		{
			get {return adapterUserById;}
		}

		protected override DbDataAdapter AdapterTests
		{
			get {return adapterTests;}
		}
		
		protected override DbDataAdapter AdapterQuestionSetsByTestId
		{
			get {return adapterQuestionSetsByTestId;}
		}

		protected override DbDataAdapter AdapterQuestionById
		{
			get {return adapterQuestionById;}
		}

		protected override DbDataAdapter AdapterQuestionsByQuestionSetId
		{
			get {return adapterQuestionsByQuestionSetId;}
		}

		protected override DbDataAdapter AdapterAnswersByQuestionSetId
		{
			get {return adapterAnswersByQuestionSetId;}
		}

		protected override DbDataAdapter AdapterResultsByUserIdTimeRange
		{
			get {return adapterResultsByUserIdTimeRange;}
		}

		protected override DbDataAdapter AdapterResultDetailsByResultId
		{
			get {return adapterResultDetailsByResultId;}
		}

		protected override DbDataAdapter AdapterResultsByResultId
		{
			get {return adapterResultsByResultId;}
		}


		protected override DbDataAdapter AdapterResultsDetailsByResultId
		{
			get {return adapterResultsDetailsByResultId;}
		}

		public string Password
		{
			get { return password; }
			set { password = value; FileName = fileName; }
		}

		private void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs args)
		{
			if (args.StatementType == StatementType.Insert)
				args.Row["Id"] = (int)idCmd.ExecuteScalar();
		}

		protected override DbDataAdapter AdapterPassagesToQuestionsByQuestionId
		{
			get {return adapterPassagesToQuestionsByQuestionId;}
		}

		protected override DbDataAdapter AdapterAnswersByQuestionSetIdAndZone 
		{
			get {return adapterAnswersByQuestionSetIdAndZone;}
		}

		protected override DbDataAdapter AdapterQuestionsByQuestionSetIdAndZone 
		{
			get {return adapterQuestionsByQuestionSetIdAndZone;}
		}

		protected override DbDataAdapter AdapterQuestionSetsExByResultId 
		{
			get {return adapterQuestionSetsExByResultId;}
		}

		protected override DbDataAdapter AdapterResultsDetailsOfSetsByResultId 
		{
			get {return adapterResultsDetailsOfSetsByResultId;}
		}
		

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlSelectCommand5a = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection = new System.Data.OleDb.OleDbConnection();
			this.adapterUsers = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectAllUsers = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.adapterTests = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectAll = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.adapterQuestionById = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.adapterAnswersByQuestionId = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectAnswersByQestionId = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.adapterUserById = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectUserById = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.adapterQuestionsByQuestionSetId = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlDeleteCommand8 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand8 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand8 = new System.Data.OleDb.OleDbCommand();
			this.adapterAnswersByQuestionSetId = new System.Data.OleDb.OleDbDataAdapter();
			this.sqlSelectAnswersByQuestionSetId = new System.Data.OleDb.OleDbCommand();
			this.adapterResultsByUserIdTimeRange = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectResultsByUserIdTimeRange = new System.Data.OleDb.OleDbCommand();
			this.adapterResultsDetailsByResultId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.sqlDeleteCommand7 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand7 = new System.Data.OleDb.OleDbCommand();
			this.adapterQuestionSetsByTestId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectQuestionSetsByTestId = new System.Data.OleDb.OleDbCommand();
			this.adapterResultsByResultId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.sqlDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
			this.sqlInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectResultsByResultId = new System.Data.OleDb.OleDbCommand();
			this.sqlUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
			this.adapterResultDetailsByResultId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.sqlSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.adapterPassagesToQuestionsByQuestionId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectPassagesToQuestionsByQuestionId = new System.Data.OleDb.OleDbCommand();
			this.adapterQuestionsByQuestionSetIdAndZone = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectQuestionsByQuestionSetIdAndZone = new System.Data.OleDb.OleDbCommand();
			this.adapterAnswersByQuestionSetIdAndZone = new System.Data.OleDb.OleDbDataAdapter();
			this.selectAnswersByQuestionSetIdAndZone = new System.Data.OleDb.OleDbCommand();
			this.adapterResultsDetailsOfSetsByResultId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.adapterQuestionSetsExByResultId = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			// 
			// sqlSelectCommand5a
			// 
			this.sqlSelectCommand5a.CommandText = @"SELECT QuestionSets.Id, QuestionSets.Name, QuestionSets.Description, QuestionSets.NumberOfQuestionsToPick, QuestionSets.TimeLimit, QuestionSets.QuestionTypeId, QuestionSets.QuestionSubtypeId, TestContents.ShowQuestionSetDescription, TestContents.TestId, TestContents.QuestionSetId FROM ((QuestionSets INNER JOIN TestContents ON QuestionSets.Id = TestContents.QuestionSetId) INNER JOIN Tests ON TestContents.TestId = Tests.Id) WHERE (Tests.Id = @testId) ORDER BY TestContents.QuestionSetOrder";
			this.sqlSelectCommand5a.Connection = this.oleDbConnection;
			this.sqlSelectCommand5a.Parameters.Add(new System.Data.OleDb.OleDbParameter("@testId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Current, "@testId"));
			// 
			// oleDbConnection
			// 
			this.oleDbConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Projects\GmatClubTest\src\db\GmatClubTest.mdb"";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=True;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			// 
			// adapterUsers
			// 
			this.adapterUsers.DeleteCommand = this.sqlDeleteCommand1;
			this.adapterUsers.InsertCommand = this.sqlInsertCommand1;
			this.adapterUsers.SelectCommand = this.sqlSelectAllUsers;
			this.adapterUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "users", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("id", "id"),
																																																			new System.Data.Common.DataColumnMapping("login", "login"),
																																																			new System.Data.Common.DataColumnMapping("password", "password"),
																																																			new System.Data.Common.DataColumnMapping("name", "name")})});
			this.adapterUsers.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM users WHERE (id = @Original_id)";
			this.sqlDeleteCommand1.Connection = this.oleDbConnection;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO Users(Login, [Password], Name) VALUES (@Login, @Password, @Name)";
			this.sqlInsertCommand1.Connection = this.oleDbConnection;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Login", System.Data.OleDb.OleDbType.VarChar, 50, "Login"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Password", System.Data.OleDb.OleDbType.VarBinary, 20, "Password"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Name", System.Data.OleDb.OleDbType.VarChar, 50, "Name"));
			// 
			// sqlSelectAllUsers
			// 
			this.sqlSelectAllUsers.CommandText = "SELECT id, login, [password], name FROM users";
			this.sqlSelectAllUsers.Connection = this.oleDbConnection;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE users SET login = @login, [password] = @password, name = @name WHERE (id =" +
				" @Original_id)";
			this.sqlUpdateCommand1.Connection = this.oleDbConnection;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@login", System.Data.OleDb.OleDbType.VarChar, 50, "login"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@password", System.Data.OleDb.OleDbType.VarBinary, 20, "password"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@name", System.Data.OleDb.OleDbType.VarChar, 50, "name"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id", System.Data.OleDb.OleDbType.Integer, 0, "id"));
			// 
			// adapterTests
			// 
			this.adapterTests.DeleteCommand = this.sqlDeleteCommand2;
			this.adapterTests.InsertCommand = this.sqlInsertCommand2;
			this.adapterTests.SelectCommand = this.sqlSelectAll;
			this.adapterTests.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "Tests", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																			new System.Data.Common.DataColumnMapping("Name", "Name"),
																																																			new System.Data.Common.DataColumnMapping("IsPractice", "IsPractice"),
																																																			new System.Data.Common.DataColumnMapping("Description", "Description")})});
			this.adapterTests.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM Tests WHERE (Id = @Original_Id)";
			this.sqlDeleteCommand2.Connection = this.oleDbConnection;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO Tests(Id, Name, IsPractice, Description) VALUES (@Id, @Name, @IsPract" +
				"ice, @Description)";
			this.sqlInsertCommand2.Connection = this.oleDbConnection;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Name", System.Data.OleDb.OleDbType.VarChar, 128, "Name"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IsPractice", System.Data.OleDb.OleDbType.Boolean, 0, "IsPractice"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Description", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Description"));
			// 
			// sqlSelectAll
			// 
			this.sqlSelectAll.CommandText = "SELECT Id, Name, IsPractice, Description, QuestionTypeId, QuestionSubtypeId FROM " +
				"Tests";
			this.sqlSelectAll.Connection = this.oleDbConnection;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE Tests SET Id = @Id, Name = @Name, IsPractice = @IsPractice, Description = " +
				"@Description WHERE (Id = @Original_Id)";
			this.sqlUpdateCommand2.Connection = this.oleDbConnection;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Name", System.Data.OleDb.OleDbType.VarChar, 128, "Name"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IsPractice", System.Data.OleDb.OleDbType.Boolean, 0, "IsPractice"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Description", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Description"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// adapterQuestionById
			// 
			this.adapterQuestionById.DeleteCommand = this.sqlDeleteCommand3;
			this.adapterQuestionById.InsertCommand = this.sqlInsertCommand3;
			this.adapterQuestionById.SelectCommand = this.sqlSelectCommand3;
			this.adapterQuestionById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																					   new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
																																																					   new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
																																																					   new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
																																																					   new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																					   new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
			this.adapterQuestionById.UpdateCommand = this.sqlUpdateCommand3;
			// 
			// sqlDeleteCommand3
			// 
			this.sqlDeleteCommand3.CommandText = "DELETE FROM Questions WHERE (Id = @Original_Id)";
			this.sqlDeleteCommand3.Connection = this.oleDbConnection;
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "INSERT INTO Questions(TypeId, SubtypeId, DifficultyLevelId, Text, Picture) VALUES" +
				" (@TypeId, @SubtypeId, @DifficultyLevelId, @Text, @Picture)";
			this.sqlInsertCommand3.Connection = this.oleDbConnection;
			this.sqlInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Text", System.Data.OleDb.OleDbType.VarChar, 1024, "Text"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "Picture"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT Id, TypeId, SubtypeId, DifficultyLevelId, Text, Picture FROM Questions WHE" +
				"RE (Id = @Id)";
			this.sqlSelectCommand3.Connection = this.oleDbConnection;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// sqlUpdateCommand3
			// 
			this.sqlUpdateCommand3.CommandText = "UPDATE Questions SET TypeId = @TypeId, SubtypeId = @SubtypeId, DifficultyLevelId " +
				"= @DifficultyLevelId, Text = @Text, Picture = @Picture WHERE (Id = @Original_Id)" +
				"";
			this.sqlUpdateCommand3.Connection = this.oleDbConnection;
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Text", System.Data.OleDb.OleDbType.VarChar, 1024, "Text"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "Picture"));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// adapterAnswersByQuestionId
			// 
			this.adapterAnswersByQuestionId.DeleteCommand = this.sqlDeleteCommand4;
			this.adapterAnswersByQuestionId.InsertCommand = this.sqlInsertCommand4;
			this.adapterAnswersByQuestionId.SelectCommand = this.sqlSelectAnswersByQestionId;
			this.adapterAnswersByQuestionId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
																																																							new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																							new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
																																																							new System.Data.Common.DataColumnMapping("Order", "Order")})});
			this.adapterAnswersByQuestionId.UpdateCommand = this.sqlUpdateCommand4;
			// 
			// sqlDeleteCommand4
			// 
			this.sqlDeleteCommand4.CommandText = "DELETE FROM Answers WHERE (QuestionId = @Original_QuestionId) AND (Text = @Origin" +
				"al_Text)";
			this.sqlDeleteCommand4.Connection = this.oleDbConnection;
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Text", System.Data.OleDb.OleDbType.VarChar, 512, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand4
			// 
			this.sqlInsertCommand4.CommandText = "INSERT INTO Answers(QuestionId, Text, IsCorrect, [Order]) VALUES (@QuestionId, @T" +
				"ext, @IsCorrect, @Param1)";
			this.sqlInsertCommand4.Connection = this.oleDbConnection;
			this.sqlInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Text", System.Data.OleDb.OleDbType.VarChar, 512, "Text"));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IsCorrect", System.Data.OleDb.OleDbType.Boolean, 0, "IsCorrect"));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Param1", System.Data.OleDb.OleDbType.Integer, 0, "Order"));
			// 
			// sqlSelectAnswersByQestionId
			// 
			this.sqlSelectAnswersByQestionId.CommandText = "SELECT QuestionId, Text, IsCorrect, [Order] FROM Answers WHERE (QuestionId = @Que" +
				"stionId)";
			this.sqlSelectAnswersByQestionId.Connection = this.oleDbConnection;
			this.sqlSelectAnswersByQestionId.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			// 
			// sqlUpdateCommand4
			// 
			this.sqlUpdateCommand4.CommandText = "UPDATE Answers SET QuestionId = @QuestionId, Text = @Text, IsCorrect = @IsCorrect" +
				", [Order] = @Param2 WHERE (QuestionId = @Original_QuestionId) AND (Text = @Origi" +
				"nal_Text)";
			this.sqlUpdateCommand4.Connection = this.oleDbConnection;
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Text", System.Data.OleDb.OleDbType.VarChar, 512, "Text"));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@IsCorrect", System.Data.OleDb.OleDbType.Boolean, 0, "IsCorrect"));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Param2", System.Data.OleDb.OleDbType.Integer, 0, "Order"));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Text", System.Data.OleDb.OleDbType.VarChar, 512, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			// 
			// adapterUserById
			// 
			this.adapterUserById.DeleteCommand = this.sqlDeleteCommand5;
			this.adapterUserById.InsertCommand = this.sqlInsertCommand5;
			this.adapterUserById.SelectCommand = this.sqlSelectUserById;
			this.adapterUserById.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Users", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																			   new System.Data.Common.DataColumnMapping("Login", "Login"),
																																																			   new System.Data.Common.DataColumnMapping("Password", "Password"),
																																																			   new System.Data.Common.DataColumnMapping("Name", "Name")})});
			this.adapterUserById.UpdateCommand = this.sqlUpdateCommand5;
			// 
			// sqlDeleteCommand5
			// 
			this.sqlDeleteCommand5.CommandText = "DELETE FROM Users WHERE (Id = @Original_Id)";
			this.sqlDeleteCommand5.Connection = this.oleDbConnection;
			this.sqlDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand5
			// 
			this.sqlInsertCommand5.CommandText = "INSERT INTO Users(Login, Name, [Password]) VALUES (?, ?, ?)";
			this.sqlInsertCommand5.Connection = this.oleDbConnection;
			this.sqlInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Login", System.Data.OleDb.OleDbType.VarWChar, 50, "Login"));
			this.sqlInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
			this.sqlInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Password", System.Data.OleDb.OleDbType.VarBinary, 20, "Password"));
			// 
			// sqlSelectUserById
			// 
			this.sqlSelectUserById.CommandText = "SELECT Id, Login, [Password], Name FROM Users WHERE (Id = @Id)";
			this.sqlSelectUserById.Connection = this.oleDbConnection;
			this.sqlSelectUserById.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// sqlUpdateCommand5
			// 
			this.sqlUpdateCommand5.CommandText = "UPDATE Users SET Login = @Login, [Password] = @Password, Name = @Name WHERE (Id =" +
				" @Original_Id)";
			this.sqlUpdateCommand5.Connection = this.oleDbConnection;
			this.sqlUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Login", System.Data.OleDb.OleDbType.VarChar, 50, "Login"));
			this.sqlUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Password", System.Data.OleDb.OleDbType.VarBinary, 20, "Password"));
			this.sqlUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Name", System.Data.OleDb.OleDbType.VarChar, 50, "Name"));
			this.sqlUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// adapterQuestionsByQuestionSetId
			// 
			this.adapterQuestionsByQuestionSetId.DeleteCommand = this.sqlDeleteCommand8;
			this.adapterQuestionsByQuestionSetId.InsertCommand = this.sqlInsertCommand8;
			this.adapterQuestionsByQuestionSetId.SelectCommand = this.sqlSelectCommand2;
			this.adapterQuestionsByQuestionSetId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																								   new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
																																																								   new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
																																																								   new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
																																																								   new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																								   new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
			this.adapterQuestionsByQuestionSetId.UpdateCommand = this.sqlUpdateCommand8;
			// 
			// sqlDeleteCommand8
			// 
			this.sqlDeleteCommand8.CommandText = "DELETE FROM Questions WHERE (Id = @Delete2_Original_Id)";
			this.sqlDeleteCommand8.Connection = this.oleDbConnection;
			this.sqlDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Delete2_Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand8
			// 
			this.sqlInsertCommand8.CommandText = "INSERT INTO Questions(TypeId, SubtypeId, DifficultyLevelId, Text, Picture) VALUES" +
				" (@TypeId, @SubtypeId, @DifficultyLevelId, @Text, @Picture)";
			this.sqlInsertCommand8.Connection = this.oleDbConnection;
			this.sqlInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"));
			this.sqlInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"));
			this.sqlInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"));
			this.sqlInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Text", System.Data.OleDb.OleDbType.VarChar, 1024, "Text"));
			this.sqlInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "Picture"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT Questions.Id, Questions.TypeId, Questions.SubtypeId, Questions.DifficultyLevelId, Questions.Text, Questions.Picture FROM (SetsToQuestions INNER JOIN Questions ON SetsToQuestions.QuestionId = Questions.Id) WHERE (SetsToQuestions.SetId = @QuestionSetId)";
			this.sqlSelectCommand2.Connection = this.oleDbConnection;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "SetId"));
			// 
			// sqlUpdateCommand8
			// 
			this.sqlUpdateCommand8.CommandText = "UPDATE Questions SET TypeId = @TypeId, SubtypeId = @SubtypeId, DifficultyLevelId " +
				"= @DifficultyLevelId, Text = @Text, Picture = @Picture WHERE (Id = @Update2_Orig" +
				"inal_Id)";
			this.sqlUpdateCommand8.Connection = this.oleDbConnection;
			this.sqlUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TypeId", System.Data.OleDb.OleDbType.Integer, 0, "TypeId"));
			this.sqlUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@SubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "SubtypeId"));
			this.sqlUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@DifficultyLevelId", System.Data.OleDb.OleDbType.Integer, 0, "DifficultyLevelId"));
			this.sqlUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Text", System.Data.OleDb.OleDbType.VarChar, 1024, "Text"));
			this.sqlUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "Picture"));
			this.sqlUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Update2_Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// adapterAnswersByQuestionSetId
			// 
			this.adapterAnswersByQuestionSetId.SelectCommand = this.sqlSelectAnswersByQuestionSetId;
			this.adapterAnswersByQuestionSetId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																							   new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
																																																							   new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																							   new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
																																																							   new System.Data.Common.DataColumnMapping("Order", "Order")})});
			// 
			// sqlSelectAnswersByQuestionSetId
			// 
			this.sqlSelectAnswersByQuestionSetId.CommandText = "SELECT Answers.* FROM ((Answers INNER JOIN Questions ON Answers.QuestionId = Ques" +
				"tions.Id) INNER JOIN SetsToQuestions ON Questions.Id = SetsToQuestions.QuestionI" +
				"d) WHERE (SetsToQuestions.SetId = @QuestionSetId)";
			this.sqlSelectAnswersByQuestionSetId.Connection = this.oleDbConnection;
			this.sqlSelectAnswersByQuestionSetId.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			// 
			// adapterResultsByUserIdTimeRange
			// 
			this.adapterResultsByUserIdTimeRange.SelectCommand = this.oleDbSelectCommand8;
			this.adapterResultsByUserIdTimeRange.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "Results", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																								 new System.Data.Common.DataColumnMapping("UserId", "UserId"),
																																																								 new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
																																																								 new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
																																																								 new System.Data.Common.DataColumnMapping("Score", "Score"),
																																																								 new System.Data.Common.DataColumnMapping("TestName", "TestName"),
																																																								 new System.Data.Common.DataColumnMapping("TestIsPractice", "TestIsPractice"),
																																																								 new System.Data.Common.DataColumnMapping("TestId", "TestId")})});
			// 
			// oleDbSelectCommand8
			// 
			this.oleDbSelectCommand8.CommandText = @"SELECT Results.Id, Results.UserId, Results.StartTime, Results.EndTime, Results.Score, Tests.Name AS TestName, Tests.IsPractice AS TestIsPractice, Tests.Id AS TestId FROM (Results INNER JOIN Tests ON Results.TestId = Tests.Id) WHERE (Results.UserId = ?) AND (Results.StartTime BETWEEN ? AND ?)";
			this.oleDbSelectCommand8.Connection = this.oleDbConnection;
			this.oleDbSelectCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserId", System.Data.OleDb.OleDbType.Integer, 0, "UserId"));
			this.oleDbSelectCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			this.oleDbSelectCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartTime1", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			// 
			// sqlSelectResultsByUserIdTimeRange
			// 
			this.sqlSelectResultsByUserIdTimeRange.CommandText = @"SELECT Results.Id, Results.UserId, Results.StartTime, Results.EndTime, Results.Score, Tests.Name AS TestName, Tests.IsPractice AS TestIsPractice, Tests.Id AS TestId FROM (Results INNER JOIN Tests ON Results.TestId = Tests.Id) WHERE (Results.UserId = @UserId) AND (Results.StartTime BETWEEN @Time1 AND @Time2)";
			this.sqlSelectResultsByUserIdTimeRange.Connection = this.oleDbConnection;
			this.sqlSelectResultsByUserIdTimeRange.Parameters.Add(new System.Data.OleDb.OleDbParameter("@UserId", System.Data.OleDb.OleDbType.Integer, 0, "UserId"));
			this.sqlSelectResultsByUserIdTimeRange.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Time1", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			this.sqlSelectResultsByUserIdTimeRange.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Time2", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			// 
			// adapterResultsDetailsByResultId
			// 
			this.adapterResultsDetailsByResultId.DeleteCommand = this.oleDbDeleteCommand3;
			this.adapterResultsDetailsByResultId.InsertCommand = this.oleDbInsertCommand3;
			this.adapterResultsDetailsByResultId.SelectCommand = this.oleDbSelectCommand4;
			this.adapterResultsDetailsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "ResultsDetails", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("ResultId", "ResultId"),
																																																										new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
																																																										new System.Data.Common.DataColumnMapping("AnswerId", "AnswerId"),
																																																										new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder")})});
			this.adapterResultsDetailsByResultId.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM ResultsDetails WHERE (QuestionId = ?) AND (ResultId = ?) AND (AnswerI" +
				"d = ? OR ? IS NULL AND AnswerId IS NULL) AND (QuestionOrder = ?)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResultId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AnswerId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AnswerId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AnswerId1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AnswerId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionOrder", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO ResultsDetails (ResultId, QuestionId, AnswerId, QuestionOrder) VALUES" +
				" (?, ?, ?, ?);";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AnswerId", System.Data.OleDb.OleDbType.Integer, 0, "AnswerId"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionOrder"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT ResultId, QuestionId, AnswerId, QuestionOrder FROM ResultsDetails WHERE (R" +
				"esultId = ?)";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 4, "ResultId"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE ResultsDetails SET ResultId = ?, QuestionId = ?, AnswerId = ?, QuestionOrd" +
				"er = ? WHERE (QuestionId = ?) AND (ResultId = ?) AND (AnswerId = ? OR ? IS NULL " +
				"AND AnswerId IS NULL) AND (QuestionOrder = ?);";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AnswerId", System.Data.OleDb.OleDbType.Integer, 0, "AnswerId"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionOrder"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResultId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AnswerId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AnswerId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param44", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_QuestionOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionOrder", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand7
			// 
			this.sqlDeleteCommand7.CommandText = "DELETE FROM ResultsDetails WHERE (QuestionId = @Original_QuestionId) AND (ResultI" +
				"d = @Original_ResultId)";
			this.sqlDeleteCommand7.Connection = this.oleDbConnection;
			this.sqlDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_ResultId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand7
			// 
			this.sqlInsertCommand7.CommandText = "INSERT INTO ResultsDetails(ResultId, QuestionId, AnswerId, QuestionOrder) VALUES " +
				"(@ResultId, @QuestionId, @AnswerId, @QuestionOrder)";
			this.sqlInsertCommand7.Connection = this.oleDbConnection;
			this.sqlInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			this.sqlInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			this.sqlInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@AnswerId", System.Data.OleDb.OleDbType.Integer, 0, "AnswerId"));
			this.sqlInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionOrder", System.Data.OleDb.OleDbType.TinyInt, 0, "QuestionOrder"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ResultId, QuestionId, AnswerId, QuestionOrder FROM ResultsDetails WHERE (R" +
				"esultId = ?)";
			this.sqlSelectCommand1.Connection = this.oleDbConnection;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			// 
			// sqlUpdateCommand7
			// 
			this.sqlUpdateCommand7.CommandText = "UPDATE ResultsDetails SET ResultId = @ResultId, QuestionId = @QuestionId, AnswerI" +
				"d = @AnswerId, QuestionOrder = @QuestionOrder WHERE (QuestionId = @Original_Ques" +
				"tionId) AND (ResultId = @Original_ResultId)";
			this.sqlUpdateCommand7.Connection = this.oleDbConnection;
			this.sqlUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			this.sqlUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			this.sqlUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@AnswerId", System.Data.OleDb.OleDbType.Integer, 0, "AnswerId"));
			this.sqlUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionOrder", System.Data.OleDb.OleDbType.TinyInt, 0, "QuestionOrder"));
			this.sqlUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_QuestionId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_ResultId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null));
			// 
			// adapterQuestionSetsByTestId
			// 
			this.adapterQuestionSetsByTestId.DeleteCommand = this.oleDbDeleteCommand1;
			this.adapterQuestionSetsByTestId.InsertCommand = this.oleDbInsertCommand1;
			this.adapterQuestionSetsByTestId.SelectCommand = this.oleDbSelectCommand1;
			this.adapterQuestionSetsByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																								  new System.Data.Common.DataColumnMapping("Name", "Name"),
																																																								  new System.Data.Common.DataColumnMapping("Description", "Description"),
																																																								  new System.Data.Common.DataColumnMapping("NumberOfQuestionsToPick", "NumberOfQuestionsToPick"),
																																																								  new System.Data.Common.DataColumnMapping("TimeLimit", "TimeLimit"),
																																																								  new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
																																																								  new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
																																																								  new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone1", "NumberOfQuestionsInZone1"),
																																																								  new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3"),
																																																								  new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone2", "NumberOfQuestionsInZone2")})});
			this.adapterQuestionSetsByTestId.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM QuestionSets WHERE (Id = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO QuestionSets(Name, Description, NumberOfQuestionsToPick, TimeLimit, Q" +
				"uestionTypeId, QuestionSubtypeId, NumberOfQuestionsInZone1, NumberOfQuestionsInZ" +
				"one3, NumberOfQuestionsInZone2) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsToPick"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, "TimeLimit"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone1"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone3"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone2"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT QuestionSets.Id, QuestionSets.Name, QuestionSets.Description, QuestionSets.NumberOfQuestionsToPick, QuestionSets.TimeLimit, QuestionSets.QuestionTypeId, QuestionSets.QuestionSubtypeId, QuestionSets.NumberOfQuestionsInZone1, QuestionSets.NumberOfQuestionsInZone3, QuestionSets.NumberOfQuestionsInZone2 FROM ((QuestionSets INNER JOIN TestContents ON QuestionSets.Id = TestContents.QuestionSetId) INNER JOIN Tests ON TestContents.TestId = Tests.Id) WHERE (Tests.Id = ?) ORDER BY TestContents.QuestionSetOrder";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE QuestionSets SET Name = ?, Description = ?, NumberOfQuestionsToPick = ?, T" +
				"imeLimit = ?, QuestionTypeId = ?, QuestionSubtypeId = ?, NumberOfQuestionsInZone" +
				"1 = ?, NumberOfQuestionsInZone3 = ?, NumberOfQuestionsInZone2 = ? WHERE (Id = ?)" +
				"";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 0, "Description"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsToPick", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsToPick"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeLimit", System.Data.OleDb.OleDbType.Integer, 0, "TimeLimit"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionTypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionTypeId"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionSubtypeId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSubtypeId"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone1", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone1"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone3", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone3"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfQuestionsInZone2", System.Data.OleDb.OleDbType.Integer, 0, "NumberOfQuestionsInZone2"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlSelectQuestionSetsByTestId
			// 
			this.sqlSelectQuestionSetsByTestId.CommandText = @"SELECT QuestionSets.Id, QuestionSets.Name, QuestionSets.Description, QuestionSets.NumberOfQuestionsToPick, QuestionSets.TimeLimit, QuestionSets.QuestionTypeId, QuestionSets.QuestionSubtypeId FROM ((QuestionSets INNER JOIN TestContents ON QuestionSets.Id = TestContents.QuestionSetId) INNER JOIN Tests ON TestContents.TestId = Tests.Id) WHERE (Tests.Id = @testId) ORDER BY TestContents.QuestionSetOrder";
			this.sqlSelectQuestionSetsByTestId.Connection = this.oleDbConnection;
			this.sqlSelectQuestionSetsByTestId.Parameters.Add(new System.Data.OleDb.OleDbParameter("@testId", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// adapterResultsByResultId
			// 
			this.adapterResultsByResultId.DeleteCommand = this.oleDbDeleteCommand2;
			this.adapterResultsByResultId.InsertCommand = this.oleDbInsertCommand2;
			this.adapterResultsByResultId.SelectCommand = this.oleDbSelectCommand3;
			this.adapterResultsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "Results", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																						  new System.Data.Common.DataColumnMapping("UserId", "UserId"),
																																																						  new System.Data.Common.DataColumnMapping("TestId", "TestId"),
																																																						  new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
																																																						  new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
																																																						  new System.Data.Common.DataColumnMapping("Score", "Score")})});
			this.adapterResultsByResultId.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM Results WHERE (Id = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO Results(UserId, TestId, StartTime, EndTime, Score) VALUES (?, ?, ?, ?" +
				", ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserId", System.Data.OleDb.OleDbType.Integer, 0, "UserId"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.Date, 0, "EndTime"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Score", System.Data.OleDb.OleDbType.Double, 0, "Score"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT Id, UserId, TestId, StartTime, EndTime, Score FROM Results WHERE (Id = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE Results SET UserId = ?, TestId = ?, StartTime = ?, EndTime = ?, Score = ? " +
				"WHERE (Id = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserId", System.Data.OleDb.OleDbType.Integer, 0, "UserId"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.Date, 0, "EndTime"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Score", System.Data.OleDb.OleDbType.Double, 0, "Score"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand6
			// 
			this.sqlDeleteCommand6.CommandText = "DELETE FROM Results WHERE (Id = @Original_Id)";
			this.sqlDeleteCommand6.Connection = this.oleDbConnection;
			this.sqlDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand6
			// 
			this.sqlInsertCommand6.CommandText = "INSERT INTO Results(UserId, TestId, StartTime, EndTime, Score) VALUES (@UserId, @" +
				"TestId, @StartTime, @EndTime, @Score)";
			this.sqlInsertCommand6.Connection = this.oleDbConnection;
			this.sqlInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@UserId", System.Data.OleDb.OleDbType.Integer, 0, "UserId"));
			this.sqlInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"));
			this.sqlInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@StartTime", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			this.sqlInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@EndTime", System.Data.OleDb.OleDbType.Date, 0, "EndTime"));
			this.sqlInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Score", System.Data.OleDb.OleDbType.Integer, 0, "Score"));
			// 
			// sqlSelectResultsByResultId
			// 
			this.sqlSelectResultsByResultId.CommandText = "SELECT Id, UserId, TestId, StartTime, EndTime, Score FROM Results WHERE (Id = @Id" +
				")";
			this.sqlSelectResultsByResultId.Connection = this.oleDbConnection;
			this.sqlSelectResultsByResultId.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// sqlUpdateCommand6
			// 
			this.sqlUpdateCommand6.CommandText = "UPDATE Results SET UserId = @UserId, TestId = @TestId, StartTime = @StartTime, En" +
				"dTime = @EndTime, Score = @Score WHERE (Id = @Original_Id)";
			this.sqlUpdateCommand6.Connection = this.oleDbConnection;
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@UserId", System.Data.OleDb.OleDbType.Integer, 0, "UserId"));
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@TestId", System.Data.OleDb.OleDbType.Integer, 0, "TestId"));
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@StartTime", System.Data.OleDb.OleDbType.Date, 0, "StartTime"));
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@EndTime", System.Data.OleDb.OleDbType.Date, 0, "EndTime"));
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Score", System.Data.OleDb.OleDbType.Integer, 0, "Score"));
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Original_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", System.Data.OleDb.OleDbType.Integer, 0, "Id"));
			// 
			// adapterResultDetailsByResultId
			// 
			this.adapterResultDetailsByResultId.SelectCommand = this.oleDbSelectCommand5;
			this.adapterResultDetailsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
																																																								new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
																																																								new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder"),
																																																								new System.Data.Common.DataColumnMapping("QuestionText", "QuestionText"),
																																																								new System.Data.Common.DataColumnMapping("QuestionDifficultyLevel", "QuestionDifficultyLevel"),
																																																								new System.Data.Common.DataColumnMapping("SetId", "SetId"),
																																																								new System.Data.Common.DataColumnMapping("Id", "Id")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT Answers.IsCorrect, ResultsDetails.QuestionId, ResultsDetails.QuestionOrder, Questions.[Text] AS QuestionText, DifficultyLevel.Name AS QuestionDifficultyLevel, SetsToQuestions.SetId, Answers.Id FROM (((((Answers INNER JOIN Questions ON Answers.QuestionId = Questions.Id) INNER JOIN ResultsDetails ON Answers.Id = ResultsDetails.AnswerId AND Questions.Id = ResultsDetails.QuestionId) INNER JOIN DifficultyLevel ON Questions.DifficultyLevelId = DifficultyLevel.Id) INNER JOIN SetsToQuestions ON Questions.Id = SetsToQuestions.QuestionId) INNER JOIN ResultsDetailsOfSets ON ResultsDetails.ResultId = ResultsDetailsOfSets.ResultId AND SetsToQuestions.SetId = ResultsDetailsOfSets.QuestionSetId) WHERE (ResultsDetails.ResultId = ?) ORDER BY ResultsDetails.QuestionOrder";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT DISTINCT Answers.IsCorrect, ResultsDetails.QuestionId, ResultsDetails.QuestionOrder, Questions.[Text] AS QuestionText, DifficultyLevel.Name AS QuestionDifficultyLevel, SetsToQuestions.SetId, Answers.Id FROM ((Results INNER JOIN ((((Answers INNER JOIN Questions ON Answers.QuestionId = Questions.Id) INNER JOIN ResultsDetails ON Answers.Id = ResultsDetails.AnswerId AND Questions.Id = ResultsDetails.QuestionId) INNER JOIN DifficultyLevel ON Questions.DifficultyLevelId = DifficultyLevel.Id) INNER JOIN SetsToQuestions ON Questions.Id = SetsToQuestions.QuestionId) ON Results.Id = ResultsDetails.ResultId) INNER JOIN TestContents ON Results.TestId = TestContents.TestId) WHERE (ResultsDetails.ResultId = @ResultId) ORDER BY ResultsDetails.QuestionOrder";
			this.sqlSelectCommand4.Connection = this.oleDbConnection;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("@ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			// 
			// adapterPassagesToQuestionsByQuestionId
			// 
			this.adapterPassagesToQuestionsByQuestionId.SelectCommand = this.oleDbSelectPassagesToQuestionsByQuestionId;
			this.adapterPassagesToQuestionsByQuestionId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															 new System.Data.Common.DataTableMapping("Table", "PassageToQuestions", new System.Data.Common.DataColumnMapping[] {
																																																												   new System.Data.Common.DataColumnMapping("PassageQuestionId", "PassageQuestionId"),
																																																												   new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId")})});
			// 
			// oleDbSelectPassagesToQuestionsByQuestionId
			// 
			this.oleDbSelectPassagesToQuestionsByQuestionId.CommandText = "SELECT PassagesToQuestions.* FROM (PassagesToQuestions INNER JOIN PassagesToQuest" +
				"ions PassagesToQuestions_1 ON PassagesToQuestions.PassageQuestionId = PassagesTo" +
				"Questions_1.PassageQuestionId) WHERE (PassagesToQuestions_1.QuestionId = ?)";
			this.oleDbSelectPassagesToQuestionsByQuestionId.Connection = this.oleDbConnection;
			this.oleDbSelectPassagesToQuestionsByQuestionId.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionId"));
			// 
			// adapterQuestionsByQuestionSetIdAndZone
			// 
			this.adapterQuestionsByQuestionSetIdAndZone.SelectCommand = this.oleDbSelectCommand2;
			this.adapterQuestionsByQuestionSetIdAndZone.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															 new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																										  new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
																																																										  new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
																																																										  new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
																																																										  new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																										  new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT Questions.Id, Questions.TypeId, Questions.SubtypeId, Questions.DifficultyLevelId, Questions.[Text], Questions.Picture FROM (SetsToQuestions INNER JOIN Questions ON SetsToQuestions.QuestionId = Questions.Id) WHERE (SetsToQuestions.SetId = ?) AND (SetsToQuestions.QuestionZone = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SetId", System.Data.OleDb.OleDbType.Integer, 0, "SetId"));
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionZone", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionZone"));
			// 
			// oleDbSelectQuestionsByQuestionSetIdAndZone
			// 
			this.oleDbSelectQuestionsByQuestionSetIdAndZone.CommandText = @"SELECT Questions.Id, Questions.TypeId, Questions.SubtypeId, Questions.DifficultyLevelId, Questions.Text, Questions.Picture FROM (SetsToQuestions INNER JOIN Questions ON SetsToQuestions.QuestionId = Questions.Id) WHERE (SetsToQuestions.SetId = @QuestionSetId)";
			this.oleDbSelectQuestionsByQuestionSetIdAndZone.Connection = this.oleDbConnection;
			this.oleDbSelectQuestionsByQuestionSetIdAndZone.Parameters.Add(new System.Data.OleDb.OleDbParameter("@QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "SetId"));
			// 
			// adapterAnswersByQuestionSetIdAndZone
			// 
			this.adapterAnswersByQuestionSetIdAndZone.SelectCommand = this.selectAnswersByQuestionSetIdAndZone;
			this.adapterAnswersByQuestionSetIdAndZone.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														   new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("Id", "Id"),
																																																									  new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
																																																									  new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																									  new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
																																																									  new System.Data.Common.DataColumnMapping("Order", "Order")})});
			// 
			// selectAnswersByQuestionSetIdAndZone
			// 
			this.selectAnswersByQuestionSetIdAndZone.CommandText = "SELECT Answers.* FROM ((Answers INNER JOIN Questions ON Answers.QuestionId = Ques" +
				"tions.Id) INNER JOIN SetsToQuestions ON Questions.Id = SetsToQuestions.QuestionI" +
				"d) WHERE (SetsToQuestions.SetId = ?) AND (SetsToQuestions.QuestionZone = ?)";
			this.selectAnswersByQuestionSetIdAndZone.Connection = this.oleDbConnection;
			this.selectAnswersByQuestionSetIdAndZone.Parameters.Add(new System.Data.OleDb.OleDbParameter("SetId", System.Data.OleDb.OleDbType.Integer, 0, "SetId"));
			this.selectAnswersByQuestionSetIdAndZone.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionZone", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionZone"));
			// 
			// adapterResultsDetailsOfSetsByResultId
			// 
			this.adapterResultsDetailsOfSetsByResultId.DeleteCommand = this.oleDbDeleteCommand4;
			this.adapterResultsDetailsOfSetsByResultId.InsertCommand = this.oleDbInsertCommand4;
			this.adapterResultsDetailsOfSetsByResultId.SelectCommand = this.oleDbSelectCommand6;
			this.adapterResultsDetailsOfSetsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															new System.Data.Common.DataTableMapping("Table", "ResultsDetailsOfSets", new System.Data.Common.DataColumnMapping[] {
																																																													new System.Data.Common.DataColumnMapping("QuestionSetId", "QuestionSetId"),
																																																													new System.Data.Common.DataColumnMapping("QuestionSetOrder", "QuestionSetOrder"),
																																																													new System.Data.Common.DataColumnMapping("ResultId", "ResultId"),
																																																													new System.Data.Common.DataColumnMapping("Score", "Score")})});
			this.adapterResultsDetailsOfSetsByResultId.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM ResultsDetailsOfSets WHERE (QuestionSetId = ?) AND (ResultId = ?)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResultId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO ResultsDetailsOfSets(QuestionSetId, QuestionSetOrder, ResultId, Score" +
				") VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSetId"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionSetOrder"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Score", System.Data.OleDb.OleDbType.Double, 0, "Score"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT QuestionSetId, QuestionSetOrder, ResultId, Score FROM ResultsDetailsOfSets" +
				" WHERE (ResultId = ?) ORDER BY QuestionSetOrder";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection;
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE ResultsDetailsOfSets SET QuestionSetId = ?, QuestionSetOrder = ?, ResultId" +
				" = ?, Score = ? WHERE (QuestionSetId = ?) AND (ResultId = ?)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, "QuestionSetId"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("QuestionSetOrder", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "QuestionSetOrder"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Score", System.Data.OleDb.OleDbType.Double, 0, "Score"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_QuestionSetId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResultId", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null));
			// 
			// adapterQuestionSetsExByResultId
			// 
			this.adapterQuestionSetsExByResultId.SelectCommand = this.oleDbSelectCommand7;
			this.adapterQuestionSetsExByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("Score", "Score"),
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
			this.oleDbSelectCommand7.CommandText = @"SELECT ResultsDetailsOfSets.Score, QuestionSets.Description, QuestionSets.Id, QuestionSets.Name, QuestionSets.NumberOfQuestionsInZone1, QuestionSets.NumberOfQuestionsInZone2, QuestionSets.NumberOfQuestionsInZone3, QuestionSets.NumberOfQuestionsToPick, QuestionSets.QuestionSubtypeId, QuestionSets.QuestionTypeId, QuestionSets.TimeLimit FROM (QuestionSets INNER JOIN ResultsDetailsOfSets ON QuestionSets.Id = ResultsDetailsOfSets.QuestionSetId) WHERE (ResultsDetailsOfSets.ResultId = ?)";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection;
			this.oleDbSelectCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResultId", System.Data.OleDb.OleDbType.Integer, 0, "ResultId"));

		}
		#endregion
	}
}
