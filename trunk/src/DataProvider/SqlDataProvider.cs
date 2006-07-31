using System;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;

namespace GmatClubTest.DataProvider
{

	public class SqlDataProvider : BaseDataProvider
	{
		private string dataSource = "localhost";
		private SqlDataAdapter adapterUsers;
		private SqlDataAdapter adapterTests;
		private SqlCommand sqlSelectAll;
		private SqlCommand sqlInsertCommand2;
		private SqlCommand sqlUpdateCommand2;
		private SqlCommand sqlDeleteCommand2;
		private SqlCommand sqlSelectAnswersByQestionId;
		private SqlCommand sqlInsertCommand4;
		private SqlCommand sqlUpdateCommand4;
		private SqlCommand sqlDeleteCommand4;
		private SqlDataAdapter adapterQuestionById;
		private SqlDataAdapter adapterAnswersByQuestionId;
		private SqlDataAdapter adapterUserById;
		private SqlCommand sqlInsertCommand5;
		private SqlCommand sqlUpdateCommand5;
		private SqlCommand sqlDeleteCommand5;
		private SqlCommand sqlSelectUserById;
		private SqlDataAdapter adapterQuestionsByQuestionSetId;
		private SqlDataAdapter adapterAnswersByQuestionSetId;
		private SqlCommand sqlSelectAnswersByQuestionSetId;
		private SqlDataAdapter adapterResultsByUserIdTimeRange;
		
		private SqlCommand sqlSelectCommand2;
		private SqlCommand sqlInsertCommand8;
		private SqlCommand sqlUpdateCommand8;
		private SqlCommand sqlDeleteCommand8;
		private SqlCommand sqlSelectCommand3;
		private SqlCommand sqlInsertCommand3;
		private SqlCommand sqlUpdateCommand3;
		private SqlCommand sqlDeleteCommand3;
		private SqlCommand sqlSelectResultsByUserIdTimeRange;
	
		private System.Data.SqlClient.SqlDataAdapter adapterPassagesToQuestionsByQuestionId;
		private System.Data.SqlClient.SqlCommand sqlSelectPassagesToQuestionsByQuestionId;
		private System.Data.SqlClient.SqlDataAdapter adapterQuestionSetsByTestId;
		
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand9;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand9;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand9;
		private System.Data.SqlClient.SqlDataAdapter adapterQuestionsByQuestionSetIdAndZone;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlDataAdapter adapterAnswersByQuestionSetIdAndZone;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand7;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand7;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand7;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand6;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand6;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand6;

		private SqlDataAdapter adapterResultsByResultId;

		private System.Data.SqlClient.SqlDataAdapter adapterResultDetailsByResultId;
		private SqlDataAdapter adapterResultsDetailsByResultId;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Data.SqlClient.SqlDataAdapter adapterResultsDetailsOfSetsByResultId;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand10;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand10;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand10;
		private System.Data.SqlClient.SqlConnection sqlConnection;
		private System.Data.SqlClient.SqlDataAdapter adapterQuestionSetsExByResultId;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public SqlDataProvider(IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			Init();
		}

		public SqlDataProvider()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			Init();
		}

		private void Init()
		{
			DataSource = dataSource;
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
			sqlConnection.Open();
		}

		public override void Close()
		{
			sqlConnection.Close();
		}

		public string DataSource
		{
			get {return dataSource;}
			set
			{
				dataSource = value;
                sqlConnection.ConnectionString = String.Format("packet size=4096;integrated security=SSPI;data source={0};persist security info=False;initial catalog=GmatClubTest", dataSource);
				//sqlConnection.ConnectionString = String.Format("packet size=4096;integrated security=SSPI;data source={0};persist security info=False;initial catalog=GmatClubChallenge", dataSource);
                //sqlConnection.ConnectionString = String.Format("Data Source=sql2.reinventinc.com;Persist Security Info=True;User ID=re2085;Password=sys1157;initial catalog=GmatClubChallenge", dataSource);
			}
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

		protected override DbDataAdapter AdapterResultsDetailsByResultId
		{
			get {return adapterResultsDetailsByResultId;}
		}

		protected override DbDataAdapter AdapterResultsByResultId
		{
			get {return adapterResultsByResultId;}
		}

		protected override DbDataAdapter AdapterResultDetailsByResultId
		{
			get {return adapterResultDetailsByResultId;}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlDataProvider));
            this.adapterUsers = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.adapterTests = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectAll = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.adapterQuestionById = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
            this.adapterAnswersByQuestionId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectAnswersByQestionId = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
            this.adapterUserById = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectUserById = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand5 = new System.Data.SqlClient.SqlCommand();
            this.adapterQuestionsByQuestionSetId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand8 = new System.Data.SqlClient.SqlCommand();
            this.adapterAnswersByQuestionSetId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectAnswersByQuestionSetId = new System.Data.SqlClient.SqlCommand();
            this.adapterResultsByUserIdTimeRange = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectResultsByUserIdTimeRange = new System.Data.SqlClient.SqlCommand();
            this.adapterResultsDetailsByResultId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand7 = new System.Data.SqlClient.SqlCommand();
            this.adapterQuestionSetsByTestId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand9 = new System.Data.SqlClient.SqlCommand();
            this.adapterResultsByResultId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand6 = new System.Data.SqlClient.SqlCommand();
            this.adapterResultDetailsByResultId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.adapterPassagesToQuestionsByQuestionId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectPassagesToQuestionsByQuestionId = new System.Data.SqlClient.SqlCommand();
            this.adapterQuestionsByQuestionSetIdAndZone = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.adapterAnswersByQuestionSetIdAndZone = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.adapterResultsDetailsOfSetsByResultId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand10 = new System.Data.SqlClient.SqlCommand();
            this.adapterQuestionSetsExByResultId = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
            // 
            // adapterUsers
            // 
            this.adapterUsers.DeleteCommand = this.sqlDeleteCommand1;
            this.adapterUsers.InsertCommand = this.sqlInsertCommand1;
            this.adapterUsers.SelectCommand = this.sqlSelectCommand6;
            this.adapterUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Users", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Login", "Login"),
                        new System.Data.Common.DataColumnMapping("Password", "Password"),
                        new System.Data.Common.DataColumnMapping("Name", "Name")})});
            this.adapterUsers.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM Users WHERE (Id = @Original_Id) AND (Login = @Original_Login) AND (Na" +
                "me = @Original_Name) AND (Password = @Original_Password)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Login", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Login", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.VarBinary, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection
            // 
            this.sqlConnection.ConnectionString = "Data Source=sql2.reinventinc.com;Persist Security Info=True;User ID=re2085;Passwo" +
                "rd=sys1157";
            this.sqlConnection.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO Users(Login, Password, Name) VALUES (@Login, @Password, @Name); SELEC" +
                "T Id, Login, Password, Name FROM Users WHERE (Id = @@IDENTITY)";
            this.sqlInsertCommand1.Connection = this.sqlConnection;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Login", System.Data.SqlDbType.VarChar, 50, "Login"),
            new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarBinary, 20, "Password"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name")});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "SELECT Id, Login, Password, Name FROM Users";
            this.sqlSelectCommand6.Connection = this.sqlConnection;
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Login", System.Data.SqlDbType.VarChar, 50, "Login"),
            new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarBinary, 20, "Password"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Login", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Login", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.VarBinary, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
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
            this.sqlDeleteCommand2.Connection = this.sqlConnection;
            this.sqlDeleteCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = "INSERT INTO Tests(Id, Name, IsPractice, Description) VALUES (@Id, @Name, @IsPract" +
                "ice, @Description); SELECT Id, Name, IsPractice, Description FROM Tests WHERE (I" +
                "d = @Id)";
            this.sqlInsertCommand2.Connection = this.sqlConnection;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 128, "Name"),
            new System.Data.SqlClient.SqlParameter("@IsPractice", System.Data.SqlDbType.Bit, 1, "IsPractice"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 2147483647, "Description")});
            // 
            // sqlSelectAll
            // 
            this.sqlSelectAll.CommandText = "SELECT Id, Name, IsPractice, Description, QuestionTypeId, QuestionSubtypeId FROM " +
                "Tests";
            this.sqlSelectAll.Connection = this.sqlConnection;
            // 
            // sqlUpdateCommand2
            // 
            this.sqlUpdateCommand2.CommandText = "UPDATE Tests SET Id = @Id, Name = @Name, IsPractice = @IsPractice, Description = " +
                "@Description WHERE (Id = @Original_Id); SELECT Id, Name, IsPractice, Description" +
                " FROM Tests WHERE (Id = @Id)";
            this.sqlUpdateCommand2.Connection = this.sqlConnection;
            this.sqlUpdateCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 128, "Name"),
            new System.Data.SqlClient.SqlParameter("@IsPractice", System.Data.SqlDbType.Bit, 1, "IsPractice"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 2147483647, "Description"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
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
            this.sqlDeleteCommand3.Connection = this.sqlConnection;
            this.sqlDeleteCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand3
            // 
            this.sqlInsertCommand3.CommandText = resources.GetString("sqlInsertCommand3.CommandText");
            this.sqlInsertCommand3.Connection = this.sqlConnection;
            this.sqlInsertCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@TypeId", System.Data.SqlDbType.Int, 4, "TypeId"),
            new System.Data.SqlClient.SqlParameter("@SubtypeId", System.Data.SqlDbType.Int, 4, "SubtypeId"),
            new System.Data.SqlClient.SqlParameter("@DifficultyLevelId", System.Data.SqlDbType.Int, 4, "DifficultyLevelId"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 1024, "Text"),
            new System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarBinary, 2147483647, "Picture")});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "SELECT Id, TypeId, SubtypeId, DifficultyLevelId, Text, Picture FROM Questions WHE" +
                "RE (Id = @Id)";
            this.sqlSelectCommand3.Connection = this.sqlConnection;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // sqlUpdateCommand3
            // 
            this.sqlUpdateCommand3.CommandText = resources.GetString("sqlUpdateCommand3.CommandText");
            this.sqlUpdateCommand3.Connection = this.sqlConnection;
            this.sqlUpdateCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@TypeId", System.Data.SqlDbType.Int, 4, "TypeId"),
            new System.Data.SqlClient.SqlParameter("@SubtypeId", System.Data.SqlDbType.Int, 4, "SubtypeId"),
            new System.Data.SqlClient.SqlParameter("@DifficultyLevelId", System.Data.SqlDbType.Int, 4, "DifficultyLevelId"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 1024, "Text"),
            new System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarBinary, 2147483647, "Picture"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
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
            this.sqlDeleteCommand4.Connection = this.sqlConnection;
            this.sqlDeleteCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_QuestionId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 512, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand4
            // 
            this.sqlInsertCommand4.CommandText = resources.GetString("sqlInsertCommand4.CommandText");
            this.sqlInsertCommand4.Connection = this.sqlConnection;
            this.sqlInsertCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionId", System.Data.SqlDbType.Int, 4, "QuestionId"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 512, "Text"),
            new System.Data.SqlClient.SqlParameter("@IsCorrect", System.Data.SqlDbType.Bit, 1, "IsCorrect"),
            new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int, 4, "Order")});
            // 
            // sqlSelectAnswersByQestionId
            // 
            this.sqlSelectAnswersByQestionId.CommandText = "SELECT QuestionId, Text, IsCorrect, [Order] FROM Answers WHERE (QuestionId = @Que" +
                "stionId)";
            this.sqlSelectAnswersByQestionId.Connection = this.sqlConnection;
            this.sqlSelectAnswersByQestionId.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionId", System.Data.SqlDbType.Int, 4, "QuestionId")});
            // 
            // sqlUpdateCommand4
            // 
            this.sqlUpdateCommand4.CommandText = resources.GetString("sqlUpdateCommand4.CommandText");
            this.sqlUpdateCommand4.Connection = this.sqlConnection;
            this.sqlUpdateCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionId", System.Data.SqlDbType.Int, 4, "QuestionId"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 512, "Text"),
            new System.Data.SqlClient.SqlParameter("@IsCorrect", System.Data.SqlDbType.Bit, 1, "IsCorrect"),
            new System.Data.SqlClient.SqlParameter("@Param2", System.Data.SqlDbType.Int, 4, "Order"),
            new System.Data.SqlClient.SqlParameter("@Original_QuestionId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 512, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null)});
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
            this.sqlDeleteCommand5.Connection = this.sqlConnection;
            this.sqlDeleteCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand5
            // 
            this.sqlInsertCommand5.CommandText = "INSERT INTO Users(Login, Password, Name) VALUES (@Login, @Password, @Name); SELEC" +
                "T Id, Login, Password, Name FROM Users WHERE (Id = @@IDENTITY)";
            this.sqlInsertCommand5.Connection = this.sqlConnection;
            this.sqlInsertCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Login", System.Data.SqlDbType.VarChar, 50, "Login"),
            new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarBinary, 20, "Password"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name")});
            // 
            // sqlSelectUserById
            // 
            this.sqlSelectUserById.CommandText = "SELECT Id, Login, Password, Name FROM Users WHERE (Id = @Id)";
            this.sqlSelectUserById.Connection = this.sqlConnection;
            this.sqlSelectUserById.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // sqlUpdateCommand5
            // 
            this.sqlUpdateCommand5.CommandText = "UPDATE Users SET Login = @Login, Password = @Password, Name = @Name WHERE (Id = @" +
                "Original_Id); SELECT Id, Login, Password, Name FROM Users WHERE (Id = @Id)";
            this.sqlUpdateCommand5.Connection = this.sqlConnection;
            this.sqlUpdateCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Login", System.Data.SqlDbType.VarChar, 50, "Login"),
            new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarBinary, 20, "Password"),
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
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
            this.sqlDeleteCommand8.Connection = this.sqlConnection;
            this.sqlDeleteCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Delete2_Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand8
            // 
            this.sqlInsertCommand8.CommandText = "INSERT INTO Questions(TypeId, SubtypeId, DifficultyLevelId, Text, Picture) VALUES" +
                " (@TypeId, @SubtypeId, @DifficultyLevelId, @Text, @Picture)";
            this.sqlInsertCommand8.Connection = this.sqlConnection;
            this.sqlInsertCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@TypeId", System.Data.SqlDbType.Int, 4, "TypeId"),
            new System.Data.SqlClient.SqlParameter("@SubtypeId", System.Data.SqlDbType.Int, 4, "SubtypeId"),
            new System.Data.SqlClient.SqlParameter("@DifficultyLevelId", System.Data.SqlDbType.Int, 4, "DifficultyLevelId"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 1024, "Text"),
            new System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarBinary, 2147483647, "Picture")});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = resources.GetString("sqlSelectCommand2.CommandText");
            this.sqlSelectCommand2.Connection = this.sqlConnection;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionSetId", System.Data.SqlDbType.Int, 4, "SetId")});
            // 
            // sqlUpdateCommand8
            // 
            this.sqlUpdateCommand8.CommandText = "UPDATE Questions SET TypeId = @TypeId, SubtypeId = @SubtypeId, DifficultyLevelId " +
                "= @DifficultyLevelId, Text = @Text, Picture = @Picture WHERE (Id = @Update2_Orig" +
                "inal_Id)";
            this.sqlUpdateCommand8.Connection = this.sqlConnection;
            this.sqlUpdateCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@TypeId", System.Data.SqlDbType.Int, 4, "TypeId"),
            new System.Data.SqlClient.SqlParameter("@SubtypeId", System.Data.SqlDbType.Int, 4, "SubtypeId"),
            new System.Data.SqlClient.SqlParameter("@DifficultyLevelId", System.Data.SqlDbType.Int, 4, "DifficultyLevelId"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 1024, "Text"),
            new System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarBinary, 2147483647, "Picture"),
            new System.Data.SqlClient.SqlParameter("@Update2_Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
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
            this.sqlSelectAnswersByQuestionSetId.CommandText = resources.GetString("sqlSelectAnswersByQuestionSetId.CommandText");
            this.sqlSelectAnswersByQuestionSetId.Connection = this.sqlConnection;
            this.sqlSelectAnswersByQuestionSetId.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionSetId", System.Data.SqlDbType.Int, 4, "QuestionId")});
            // 
            // adapterResultsByUserIdTimeRange
            // 
            this.adapterResultsByUserIdTimeRange.SelectCommand = this.sqlSelectResultsByUserIdTimeRange;
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
            // sqlSelectResultsByUserIdTimeRange
            // 
            this.sqlSelectResultsByUserIdTimeRange.CommandText = resources.GetString("sqlSelectResultsByUserIdTimeRange.CommandText");
            this.sqlSelectResultsByUserIdTimeRange.Connection = this.sqlConnection;
            this.sqlSelectResultsByUserIdTimeRange.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4, "UserId"),
            new System.Data.SqlClient.SqlParameter("@Time1", System.Data.SqlDbType.DateTime, 8, "StartTime"),
            new System.Data.SqlClient.SqlParameter("@Time2", System.Data.SqlDbType.DateTime, 8, "StartTime")});
            // 
            // adapterResultsDetailsByResultId
            // 
            this.adapterResultsDetailsByResultId.DeleteCommand = this.sqlDeleteCommand7;
            this.adapterResultsDetailsByResultId.InsertCommand = this.sqlInsertCommand7;
            this.adapterResultsDetailsByResultId.SelectCommand = this.sqlSelectCommand1;
            this.adapterResultsDetailsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ResultsDetails", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ResultId", "ResultId"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("AnswerId", "AnswerId"),
                        new System.Data.Common.DataColumnMapping("QuestionOrder", "QuestionOrder")})});
            this.adapterResultsDetailsByResultId.UpdateCommand = this.sqlUpdateCommand7;
            // 
            // sqlDeleteCommand7
            // 
            this.sqlDeleteCommand7.CommandText = resources.GetString("sqlDeleteCommand7.CommandText");
            this.sqlDeleteCommand7.Connection = this.sqlConnection;
            this.sqlDeleteCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_QuestionId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ResultId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AnswerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AnswerId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_QuestionOrder", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand7
            // 
            this.sqlInsertCommand7.CommandText = resources.GetString("sqlInsertCommand7.CommandText");
            this.sqlInsertCommand7.Connection = this.sqlConnection;
            this.sqlInsertCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId"),
            new System.Data.SqlClient.SqlParameter("@QuestionId", System.Data.SqlDbType.Int, 4, "QuestionId"),
            new System.Data.SqlClient.SqlParameter("@AnswerId", System.Data.SqlDbType.Int, 4, "AnswerId"),
            new System.Data.SqlClient.SqlParameter("@QuestionOrder", System.Data.SqlDbType.TinyInt, 1, "QuestionOrder")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT ResultId, QuestionId, AnswerId, QuestionOrder FROM ResultsDetails WHERE (R" +
                "esultId = @ResultId)";
            this.sqlSelectCommand1.Connection = this.sqlConnection;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId")});
            // 
            // sqlUpdateCommand7
            // 
            this.sqlUpdateCommand7.CommandText = resources.GetString("sqlUpdateCommand7.CommandText");
            this.sqlUpdateCommand7.Connection = this.sqlConnection;
            this.sqlUpdateCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId"),
            new System.Data.SqlClient.SqlParameter("@QuestionId", System.Data.SqlDbType.Int, 4, "QuestionId"),
            new System.Data.SqlClient.SqlParameter("@AnswerId", System.Data.SqlDbType.Int, 4, "AnswerId"),
            new System.Data.SqlClient.SqlParameter("@QuestionOrder", System.Data.SqlDbType.TinyInt, 1, "QuestionOrder"),
            new System.Data.SqlClient.SqlParameter("@Original_QuestionId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ResultId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AnswerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AnswerId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_QuestionOrder", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionOrder", System.Data.DataRowVersion.Original, null)});
            // 
            // adapterQuestionSetsByTestId
            // 
            this.adapterQuestionSetsByTestId.DeleteCommand = this.sqlDeleteCommand9;
            this.adapterQuestionSetsByTestId.InsertCommand = this.sqlInsertCommand9;
            this.adapterQuestionSetsByTestId.SelectCommand = this.sqlSelectCommand4;
            this.adapterQuestionSetsByTestId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsToPick", "NumberOfQuestionsToPick"),
                        new System.Data.Common.DataColumnMapping("TimeLimit", "TimeLimit"),
                        new System.Data.Common.DataColumnMapping("QuestionTypeId", "QuestionTypeId"),
                        new System.Data.Common.DataColumnMapping("QuestionSubtypeId", "QuestionSubtypeId"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone2", "NumberOfQuestionsInZone2"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone1", "NumberOfQuestionsInZone1"),
                        new System.Data.Common.DataColumnMapping("NumberOfQuestionsInZone3", "NumberOfQuestionsInZone3")})});
            this.adapterQuestionSetsByTestId.UpdateCommand = this.sqlUpdateCommand9;
            // 
            // sqlDeleteCommand9
            // 
            this.sqlDeleteCommand9.CommandText = "DELETE FROM QuestionSets WHERE (Id = @Original_Id)";
            this.sqlDeleteCommand9.Connection = this.sqlConnection;
            this.sqlDeleteCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand9
            // 
            this.sqlInsertCommand9.CommandText = resources.GetString("sqlInsertCommand9.CommandText");
            this.sqlInsertCommand9.Connection = this.sqlConnection;
            this.sqlInsertCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 2147483647, "Description"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsToPick", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsToPick"),
            new System.Data.SqlClient.SqlParameter("@TimeLimit", System.Data.SqlDbType.Int, 4, "TimeLimit"),
            new System.Data.SqlClient.SqlParameter("@QuestionTypeId", System.Data.SqlDbType.Int, 4, "QuestionTypeId"),
            new System.Data.SqlClient.SqlParameter("@QuestionSubtypeId", System.Data.SqlDbType.Int, 4, "QuestionSubtypeId"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsInZone2", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsInZone2"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsInZone1", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsInZone1"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsInZone3", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsInZone3")});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = resources.GetString("sqlSelectCommand4.CommandText");
            this.sqlSelectCommand4.Connection = this.sqlConnection;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@testId", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // sqlUpdateCommand9
            // 
            this.sqlUpdateCommand9.CommandText = resources.GetString("sqlUpdateCommand9.CommandText");
            this.sqlUpdateCommand9.Connection = this.sqlConnection;
            this.sqlUpdateCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 2147483647, "Description"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsToPick", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsToPick"),
            new System.Data.SqlClient.SqlParameter("@TimeLimit", System.Data.SqlDbType.Int, 4, "TimeLimit"),
            new System.Data.SqlClient.SqlParameter("@QuestionTypeId", System.Data.SqlDbType.Int, 4, "QuestionTypeId"),
            new System.Data.SqlClient.SqlParameter("@QuestionSubtypeId", System.Data.SqlDbType.Int, 4, "QuestionSubtypeId"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsInZone2", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsInZone2"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsInZone1", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsInZone1"),
            new System.Data.SqlClient.SqlParameter("@NumberOfQuestionsInZone3", System.Data.SqlDbType.Int, 4, "NumberOfQuestionsInZone3"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null)});
            // 
            // adapterResultsByResultId
            // 
            this.adapterResultsByResultId.DeleteCommand = this.sqlDeleteCommand6;
            this.adapterResultsByResultId.InsertCommand = this.sqlInsertCommand6;
            this.adapterResultsByResultId.SelectCommand = this.sqlSelectCommand8;
            this.adapterResultsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Results", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("UserId", "UserId"),
                        new System.Data.Common.DataColumnMapping("TestId", "TestId"),
                        new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
                        new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
                        new System.Data.Common.DataColumnMapping("Score", "Score")})});
            this.adapterResultsByResultId.UpdateCommand = this.sqlUpdateCommand6;
            // 
            // sqlDeleteCommand6
            // 
            this.sqlDeleteCommand6.CommandText = resources.GetString("sqlDeleteCommand6.CommandText");
            this.sqlDeleteCommand6.Connection = this.sqlConnection;
            this.sqlDeleteCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_EndTime", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EndTime", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Score", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Score", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_StartTime", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "StartTime", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TestId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserId", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand6
            // 
            this.sqlInsertCommand6.CommandText = resources.GetString("sqlInsertCommand6.CommandText");
            this.sqlInsertCommand6.Connection = this.sqlConnection;
            this.sqlInsertCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4, "UserId"),
            new System.Data.SqlClient.SqlParameter("@TestId", System.Data.SqlDbType.Int, 4, "TestId"),
            new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8, "StartTime"),
            new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8, "EndTime"),
            new System.Data.SqlClient.SqlParameter("@Score", System.Data.SqlDbType.Float, 8, "Score")});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "SELECT Id, UserId, TestId, StartTime, EndTime, Score FROM Results WHERE (Id = @Id" +
                ")";
            this.sqlSelectCommand8.Connection = this.sqlConnection;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // sqlUpdateCommand6
            // 
            this.sqlUpdateCommand6.CommandText = resources.GetString("sqlUpdateCommand6.CommandText");
            this.sqlUpdateCommand6.Connection = this.sqlConnection;
            this.sqlUpdateCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 4, "UserId"),
            new System.Data.SqlClient.SqlParameter("@TestId", System.Data.SqlDbType.Int, 4, "TestId"),
            new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8, "StartTime"),
            new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8, "EndTime"),
            new System.Data.SqlClient.SqlParameter("@Score", System.Data.SqlDbType.Float, 8, "Score"),
            new System.Data.SqlClient.SqlParameter("@Original_Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_EndTime", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EndTime", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Score", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Score", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_StartTime", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "StartTime", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TestId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TestId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id")});
            // 
            // adapterResultDetailsByResultId
            // 
            this.adapterResultDetailsByResultId.SelectCommand = this.sqlSelectCommand7;
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
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = resources.GetString("sqlSelectCommand7.CommandText");
            this.sqlSelectCommand7.Connection = this.sqlConnection;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId")});
            // 
            // adapterPassagesToQuestionsByQuestionId
            // 
            this.adapterPassagesToQuestionsByQuestionId.SelectCommand = this.sqlSelectPassagesToQuestionsByQuestionId;
            this.adapterPassagesToQuestionsByQuestionId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PassagesToQuestions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("PassageQuestionId", "PassageQuestionId"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId")})});
            // 
            // sqlSelectPassagesToQuestionsByQuestionId
            // 
            this.sqlSelectPassagesToQuestionsByQuestionId.CommandText = resources.GetString("sqlSelectPassagesToQuestionsByQuestionId.CommandText");
            this.sqlSelectPassagesToQuestionsByQuestionId.Connection = this.sqlConnection;
            this.sqlSelectPassagesToQuestionsByQuestionId.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "QuestionId")});
            // 
            // adapterQuestionsByQuestionSetIdAndZone
            // 
            this.adapterQuestionsByQuestionSetIdAndZone.SelectCommand = this.sqlSelectCommand5;
            this.adapterQuestionsByQuestionSetIdAndZone.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Questions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("TypeId", "TypeId"),
                        new System.Data.Common.DataColumnMapping("SubtypeId", "SubtypeId"),
                        new System.Data.Common.DataColumnMapping("DifficultyLevelId", "DifficultyLevelId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = resources.GetString("sqlSelectCommand5.CommandText");
            this.sqlSelectCommand5.Connection = this.sqlConnection;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionSetId", System.Data.SqlDbType.Int, 4, "SetId"),
            new System.Data.SqlClient.SqlParameter("@QuestionZone", System.Data.SqlDbType.TinyInt, 1, "QuestionZone")});
            // 
            // adapterAnswersByQuestionSetIdAndZone
            // 
            this.adapterAnswersByQuestionSetIdAndZone.SelectCommand = this.sqlCommand1;
            this.adapterAnswersByQuestionSetIdAndZone.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Answers", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Id", "Id"),
                        new System.Data.Common.DataColumnMapping("QuestionId", "QuestionId"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IsCorrect", "IsCorrect"),
                        new System.Data.Common.DataColumnMapping("Order", "Order")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@QuestionSetId", System.Data.SqlDbType.Int, 4, "SetId"),
            new System.Data.SqlClient.SqlParameter("@QuestionZone", System.Data.SqlDbType.TinyInt, 1, "QuestionZone")});
            // 
            // adapterResultsDetailsOfSetsByResultId
            // 
            this.adapterResultsDetailsOfSetsByResultId.DeleteCommand = this.sqlDeleteCommand10;
            this.adapterResultsDetailsOfSetsByResultId.InsertCommand = this.sqlInsertCommand10;
            this.adapterResultsDetailsOfSetsByResultId.SelectCommand = this.sqlSelectCommand9;
            this.adapterResultsDetailsOfSetsByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ResultsDetailsOfSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ResultId", "ResultId"),
                        new System.Data.Common.DataColumnMapping("QuestionSetId", "QuestionSetId"),
                        new System.Data.Common.DataColumnMapping("Score", "Score"),
                        new System.Data.Common.DataColumnMapping("QuestionSetOrder", "QuestionSetOrder")})});
            this.adapterResultsDetailsOfSetsByResultId.UpdateCommand = this.sqlUpdateCommand10;
            // 
            // sqlDeleteCommand10
            // 
            this.sqlDeleteCommand10.CommandText = "DELETE FROM ResultsDetailsOfSets WHERE (QuestionSetId = @Original_QuestionSetId) " +
                "AND (ResultId = @Original_ResultId)";
            this.sqlDeleteCommand10.Connection = this.sqlConnection;
            this.sqlDeleteCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_QuestionSetId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ResultId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand10
            // 
            this.sqlInsertCommand10.CommandText = resources.GetString("sqlInsertCommand10.CommandText");
            this.sqlInsertCommand10.Connection = this.sqlConnection;
            this.sqlInsertCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId"),
            new System.Data.SqlClient.SqlParameter("@QuestionSetId", System.Data.SqlDbType.Int, 4, "QuestionSetId"),
            new System.Data.SqlClient.SqlParameter("@Score", System.Data.SqlDbType.Float, 8, "Score"),
            new System.Data.SqlClient.SqlParameter("@QuestionSetOrder", System.Data.SqlDbType.TinyInt, 1, "QuestionSetOrder")});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = "SELECT ResultId, QuestionSetId, Score, QuestionSetOrder FROM ResultsDetailsOfSets" +
                " WHERE (ResultId = @ResultId) ORDER BY QuestionSetOrder";
            this.sqlSelectCommand9.Connection = this.sqlConnection;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId")});
            // 
            // sqlUpdateCommand10
            // 
            this.sqlUpdateCommand10.CommandText = resources.GetString("sqlUpdateCommand10.CommandText");
            this.sqlUpdateCommand10.Connection = this.sqlConnection;
            this.sqlUpdateCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId"),
            new System.Data.SqlClient.SqlParameter("@QuestionSetId", System.Data.SqlDbType.Int, 4, "QuestionSetId"),
            new System.Data.SqlClient.SqlParameter("@Score", System.Data.SqlDbType.Float, 8, "Score"),
            new System.Data.SqlClient.SqlParameter("@QuestionSetOrder", System.Data.SqlDbType.TinyInt, 1, "QuestionSetOrder"),
            new System.Data.SqlClient.SqlParameter("@Original_QuestionSetId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QuestionSetId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ResultId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ResultId", System.Data.DataRowVersion.Original, null)});
            // 
            // adapterQuestionSetsExByResultId
            // 
            this.adapterQuestionSetsExByResultId.SelectCommand = this.sqlSelectCommand10;
            this.adapterQuestionSetsExByResultId.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "QuestionSets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Score", "Score"),
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
            // 
            // sqlSelectCommand10
            // 
            this.sqlSelectCommand10.CommandText = resources.GetString("sqlSelectCommand10.CommandText");
            this.sqlSelectCommand10.Connection = this.sqlConnection;
            this.sqlSelectCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ResultId", System.Data.SqlDbType.Int, 4, "ResultId")});

		}
		#endregion
	}
}
