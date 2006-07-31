using System;
using System.Security.Cryptography;
using GmatClubTest.Data;
using GmatClubTest.DataProvider;


namespace GmatClubTest.BusinessLogic
{
	/// <summary>
	/// Manager of the Business Logic.
	/// Singleton.
	/// </summary>
	public class Manager: IDisposable
	{
		private IDataProvider dataProvider;
		private SHA1 sha = new SHA1CryptoServiceProvider();
		private int userId = -1;

		public static Manager CreareManagerUseSql(string dataSource)
		{
            DataProvider.SqlDataProvider p = new DataProvider.SqlDataProvider();
			p.DataSource = dataSource;
			return new Manager(p);
		}

		public static Manager CreareManagerUseAccess(string fileName, string password)
		{
			DataProvider.AccessDataProvider p = new DataProvider.AccessDataProvider();

			p.FileName = fileName;
			p.Password = password;
			return new Manager(p);
		}

		private Manager(DataProvider.IDataProvider dataProvider)
		{
			this.dataProvider = dataProvider;
		}

		~Manager()
		{
			Dispose();
		}

		public void Dispose()
		{
			dataProvider.Close();
		}

		public void GetUsers(UserSet userSet)
		{
			dataProvider.GetUsers(userSet);
		}

		public void GetResults(int userId, DateTime beginTime, DateTime endTime, ResultSet  resultsSet)
		{
			dataProvider.GetResults(userId, beginTime, endTime, resultsSet);
		}

		public void CreateUser(string login, string password, string name, UserSet userSet)
		{
			byte[] hash = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
			
			userSet.Users.AddUsersRow(login, hash, name);
			dataProvider.Update(userSet);
		}

		public void UpdateUsers(Data.UserSet userSet)
		{
			dataProvider.Update(userSet);
		}

		public void GetUser(int id, UserSet userSet)
		{
			dataProvider.GetUser(id, userSet);
			if (userSet.Users.Count == 0) throw new Exception(String.Format("User {0} was not found", id));
		}

		public bool IsPasswordValid(UserSet.UsersRow user, string password)
		{
			byte[] hash = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
			return IsEqual(hash, user.Password);
		}

		private bool IsEqual(byte[] array1, byte[] array2)
		{
			if (array1.Length != array2.Length) return false;
			for (int i = 0; i < array1.Length; i++) if (array1[i] != array2[i]) return false;
			return true;
		}

		public void GetTests(TestSet testSet)
		{
			dataProvider.GetTests(testSet);
		}

		public INavigator RunTest(TestSet.TestsRow test)
		{
			return test.IsPractice ? (INavigator)new PracticeNavigator(test, this) : (INavigator)new TestNavigator(test, this);
		}

		internal IDataProvider DataProvider
		{
			get {return dataProvider;}
		}

		public int UserId
		{
			get {if (userId == -1) throw new Exception("User ID must be set first."); return userId;}
			set {if (userId != -1) throw new Exception("Cannot reset user ID. Recreate manager."); userId = value;}
		}

		public void GetQuestionSetsResultDetailsSet(int resultId, QuestionSetsResultDetailsSet questionSetsResultsDetails)
		{
			dataProvider.GetQuestionSetsResultDetailsSet(resultId, questionSetsResultsDetails);
		}
	}
}
