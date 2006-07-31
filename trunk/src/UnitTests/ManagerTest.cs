using System;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using NUnit.Framework;
using System.Windows.Forms;

namespace GmatClubTest.UnitTests
{
	/// <summary>
	/// Tests for BusinessLogic.Manager
	/// </summary>
	//[TestFixture]
	public class ManagerTest
	{
		private Random random = new Random();
		private Manager manager;

		private void CheckNavigator(INavigator navigator)
		{
			QuestionSetSet.QuestionSetsRow qs;
			QuestionAnswerSet qd = new QuestionAnswerSet(); 

			while (navigator.HasNextSet)
			{
				if (navigator.HasPreviousSet && random.Next(3) == 1)
					qs = navigator.GetPreviousSet();
				else
					qs = navigator.GetNextSet();

				while (navigator.HasNextQuestion)
				{
					
					if (navigator.HasPreviousQuestion && random.Next(3) == 1)
						navigator.GetPreviousQuestion(qd);
					else
						navigator.GetNextQuestion(qd);

					QuestionAnswerSet.QuestionsRow q = qd.Questions[0];

					if (q.SubtypeId == (byte)Data.Question.Subtype.ReadingComprehensionPassage)
						Assert.Fail("Set cannot directly contain question of type ReadingComprehensionPassage");

					if (q.SubtypeId == (byte)Data.Question.Subtype.ReadingComprehensionQuestionToPassage)
						navigator.GetPasssageToQuestion(q.Id);
				
					QuestionAnswerSet.AnswersRow[] a = q.GetAnswersRows();

					navigator.SetUserAnswer(a[random.Next(a.Length)].Id);
				}	 
			}

			navigator.CommitResult();
		}

		[TestFixtureSetUp] 
		public void Init()
		{
			manager = Manager.CreareManagerUseAccess(@"c:\Projects\GmatClubTest\src\Practice\bin\Debug\GmatClubTest.mdb", "q&b3pz>#_24");
			//manager = Manager.CreareManagerUseSql(SystemInformation.ComputerName);
			UserSet u = new UserSet();  
			manager.CreateUser("UnitTestUser" + random.Next().ToString(), random.Next().ToString(), "UnitTestUserName", u);
			manager.UserId = u.Users[0].Id;
		} 

		[TestFixtureTearDown] 
		public void Dispose()
		{
			UserSet u = new UserSet();
			manager.GetUsers(u);

			foreach (UserSet.UsersRow row in u.Users.Rows)
                if (row.Login.StartsWith("UnitTestUser")) row.Delete();
			
			manager.UpdateUsers(u);

			manager.Dispose();
		}

		[Test] 
		public void CreateUser()
		{
			UserSet u = new UserSet();
			manager.CreateUser("UnitTestUser" + random.Next().ToString(), random.Next().ToString(), "UnitTestUserName", u);
			Assert.IsTrue(u.Users.Count > 0);
		}

		[Test] 
		public void GetUser()
		{
			UserSet u1 = new UserSet();
			UserSet u2 = new UserSet();
			manager.CreateUser("UnitTestUser" + random.Next().ToString(), random.Next().ToString(), "UnitTestUserName", u1);
			manager.GetUser(u1.Users[0].Id, u2);
			Assert.IsTrue(u1.Users[0].Id == u2.Users[0].Id);
		}

		[Test] 
		public void RemoveUser()
		{
			UserSet u = new UserSet();
			manager.CreateUser("UnitTestUser" + random.Next().ToString(), random.Next().ToString(), "UnitTestUserName", u);
			int id = u.Users[0].Id;

			u.Users[0].Delete(); //marks the record for deletion
			manager.UpdateUsers(u); //executes the deletion

			try
			{
				manager.GetUser(id, u);
			} catch
			{ 
				/*it's ok*/
				return;
			}

			Assert.Fail(String.Format("User {0} was not removed successfully.", id));
		}

		[Test] 
		public void UpdateUser()
		{
			Data.UserSet u = new UserSet();
			manager.CreateUser("UnitTestUser" + random.Next().ToString(), random.Next().ToString(), "UnitTestUserName", u);
			int id = u.Users[0].Id;

			u.Users[0].Name = "1";
			manager.UpdateUsers(u);

			UserSet u2 = new UserSet();
			manager.GetUser(id, u2);
			Assert.AreEqual(u2.Users[0].Name, "1");
		}

		[Test] 
		public void GetUsers()
		{
			UserSet u = new UserSet();
			manager.GetUsers(u);
		}

		[Test] 
		public void CheckPassword()
		{
			string passw = random.Next().ToString();
			UserSet u = new UserSet();
			manager.CreateUser("UnitTestUser" + random.Next().ToString(), passw, "UnitTestUserName", u);

			Assert.IsTrue(manager.IsPasswordValid(u.Users[0], passw));
			Assert.IsFalse(manager.IsPasswordValid(u.Users[0], "AAA!"));
		}

		[Test] 
		public void GetTests()
		{
			TestSet t = new TestSet();
			manager.GetTests(t);
		}

		[Test]
		public void RunPractice()
		{
			TestSet ts = new TestSet();
			manager.GetTests(ts);

			foreach (TestSet.TestsRow t in ts.Tests)
				if (t.IsPractice)
				{
					INavigator navigator = manager.RunTest(t);
					CheckNavigator(navigator);
				}
		}

		[Test]
		public void RunTest()
		{
			TestSet ts = new TestSet();
			manager.GetTests(ts);

			foreach (TestSet.TestsRow t in ts.Tests)
				if (!t.IsPractice)
				{
					INavigator navigator = manager.RunTest(t);
					CheckNavigator(navigator);
				}
		}

	}
}
