using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Tree;
using GmatClubTest.UnexpectedExceptionDialog;

namespace GmatClubTest.DbEditor
{
	/// <summary>
	/// Summary description for ApplicationController.
	/// </summary>
	public class ApplicationController
	{
		private static ApplicationController theOnlyOneInstance = new ApplicationController();
		private static MainForm mainForm = null;
		public static string APP_CAPTION = "GMAT Club Test - Database Editor";
		public static string APP_DIR = Application.UserAppDataPath + "\\GmatClubTest - DbEditor\\";
		
		//Connection -> EditingDatabase
		private Hashtable editingDatabases = new Hashtable();

		private ApplicationController()
		{
			Entity.Deleted += new GmatClubTest.DbEditor.Tree.Entity.DeleteEventHandler(Entity_Deleted);
		}

		public static ApplicationController Instance
		{
			get {return theOnlyOneInstance;}
		}

		public static MainForm MainForm
		{
			get {return mainForm;}
		}

		#region Exception management

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
            try
            {
                if (e.Exception.Message == "Failed to enable constraints. One or more rows contain values violating non-null, unique, or foreign-key constraints.")
                {
                    MessageBox.Show("Error in databese. Plese check database", APP_CAPTION,
                       MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
//#if DEBUG
			
                ExceptionBox.Show(e.Exception);
//#endif
//#if !DEBUG
//                MessageBox.Show("Unknown error! Please, reconnect connection.", APP_CAPTION,
//                       MessageBoxButtons.OK, MessageBoxIcon.Stop);
//#endif
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal error. Application will be closed.", APP_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
			
		}

		#endregion

		public void Start()
		{
			try
			{
				Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
				Directory.CreateDirectory(APP_DIR);
			    
				mainForm = new MainForm();
				mainForm.Closing += new System.ComponentModel.CancelEventHandler(mainForm_Closing);
				
				Application.Run(mainForm);
			} 
			catch(Exception e)
			{
				ExceptionBox.Show(e);
			} 
		}

		public void AddConnection()
		{
			EditConnectionForm f = new EditConnectionForm(new Connection());

			if (f.ShowDialog() == DialogResult.OK)
			{
				mainForm.Tree.Connections.Add(f.Connection);
				mainForm.Tree.DrawTree();
			}
		}

		public void Refresh()
		{
			foreach (Connection c in mainForm.Tree.Connections)
			{
                if (c.Opened)
                {
                    c.Refresh();
                }
			}
			mainForm.Tree.DrawTree();
		}

		public void Refresh(Connection connection)
		{
            EditingDatabase ed = (EditingDatabase)editingDatabases[connection];
            if (ed != null)
            {
                if (!ed.Closing()) return;
                ed.Close();
                editingDatabases.Remove(connection);
            }
            connection.Refresh();
		}

		public void DeleteEntities()
		{
			Entity[] es = mainForm.Tree.SelectedEntities;
          
			if (DialogResult.Yes == MessageBox.Show("Do you really want to delete the selected objects?", APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
				mainForm.Tree.SuspendLayout();
				try
				{
					foreach (Entity entity in es)
					{
						if (entity is Connection)
							mainForm.Tree.Connections.Remove(entity);
						else
							entity.Parent.RemoveChild(entity);
					}

					mainForm.Tree.DrawTree();	
				} finally
				{
					mainForm.Tree.ResumeLayout();
				}
			}
		}
	    
	 
		private void Entity_Deleted(Entity en)
		{
			if (en is Connection)
				((Connection)en).Close();
		}

		public void RunDefaultAction(Entity entity)
		{
			if (entity is Connection)
			{
				OpenConnection((Connection)entity);
				return;
			}

			if (entity is DbObject)
			{
				Edit((DbObject)entity);
				return;
			}
		}

		private void EditQuestionSet(QuestionSet questionSet)
		{
			EditingDatabase ed = GetEditingDatabase(questionSet);
			ed.EditQuestionSet(questionSet);
		}

        private void EditQuestion(Question question)
        {
            Connection c = question.connection;
            EditingDatabase ed = (EditingDatabase)editingDatabases[c];
            if (ed == null)
            {
                ed = new EditingDatabase(c);
                editingDatabases.Add(c, ed);
            }
           
            ed.EditQuestion(question);
        }

        private void EditPassageQuestion(PassageQuestion question)
        {
            Connection c = question.connection;
            EditingDatabase ed = (EditingDatabase)editingDatabases[c];
            if (ed == null)
            {
                ed = new EditingDatabase(c);
                editingDatabases.Add(c, ed);
            }

            ed.EditPassageQuestion(question);
        }
	    
		private void EditTest(Test test)
		{
			EditingDatabase ed = GetEditingDatabase(test);
			ed.EditTest(test);
		}

		private EditingDatabase GetEditingDatabase(Entity entity)
		{
			Connection c = (Connection)entity.Root;
			EditingDatabase ed = (EditingDatabase)editingDatabases[c];
			if (ed == null)
			{
				ed = new EditingDatabase(c);
				editingDatabases.Add(c, ed);
			}
			return ed;
		}

		public void OpenConnection(Connection connection)
		{
#if !DEBUG
bool resetPasswordOnFail = false;
			try
			{
#endif

#if DEBUG
			connection.Password = connection.DbType == Connection.Type.Access ? "q&b3pz>#_24" : "sys1157";
#endif
			if (connection.Password.Length == 0)
			{
				InputPasswordForm f = new InputPasswordForm();
				if (DialogResult.OK != f.ShowDialog()) return;
				connection.Password = f.Password;
#if !DEBUG
				resetPasswordOnFail = true;
#endif
            }

			connection.Open();
#if !DEBUG
			} catch (Exception e)
			{
				if (resetPasswordOnFail) connection.Password = "";
				MessageBox.Show("Cannot connect to the database: " + e.Message, APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
#endif
		}

		public void CloseConnection(Connection connection)
		{
			EditingDatabase ed = (EditingDatabase)editingDatabases[connection];
			if (ed != null)
			{
				if (!ed.Closing()) return;
				ed.Close();
				editingDatabases.Remove(connection);
			}
			
			connection.Close();
		}

		public void EditConnection(Connection connection)
		{
			Connection clone = (Connection)connection.Clone();
			EditConnectionForm f = new EditConnectionForm(clone);

			if (f.ShowDialog() == DialogResult.OK)
			{
				bool wasOpened = connection.Opened;
				if (wasOpened) CloseConnection(connection);
				connection.Assign(clone);
				if (wasOpened) OpenConnection(connection);
				mainForm.Tree.DrawTree();
			}
		}

		private void mainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			foreach (EditingDatabase edb in editingDatabases.Values)
			{
				if (!edb.Closing())
				{
					e.Cancel = true;
					return;
				}
			}

			EditingDatabase[] ed = new EditingDatabase[editingDatabases.Values.Count];
			editingDatabases.Values.CopyTo(ed, 0);
			foreach (EditingDatabase edb in ed)
				edb.Close();
		}

		public void Edit(DbObject dbObject)
		{
			if (dbObject is Test)
			{
				EditTest((Test)dbObject);
				return;
			}

			if (dbObject is QuestionSet)
			{
				EditQuestionSet((QuestionSet)dbObject);
				return;
			}

            if (dbObject is Question)
            {
                EditQuestion((Question)dbObject);
                return;
            }

            if (dbObject is PassageQuestion)
            {
                EditPassageQuestion((PassageQuestion)dbObject);
                return;
            }
		}

		public static void CopyEntity(Entity[] entities, Entity parent)
		{
			throw new NotImplementedException();
		}

		public static void MoveEntity(Entity[] entities, Entity parent)
		{
			throw new NotImplementedException();
		}
	    
	    public void ExportTest()
        {
            //Connection c = (Connection)(mainForm.Tree.Connections[1]);

            ExportTestForm eTestForm = new ExportTestForm(mainForm);
            eTestForm.ShowDialog();
	       // Refresh();
        }

        public void ImportTest()
        {
            //Connection c = (Connection)(mainForm.Tree.Connections[1]);

            ImportTestForm iTestForm = new ImportTestForm(mainForm);
            iTestForm.ShowDialog();
           // Refresh();
        }

	    public void AddNewTest()
	    {
	        CreateNewTestForm cTest = new CreateNewTestForm(mainForm);
            cTest.ShowDialog();
	    }

	    public void AddNewQuestionSet()
	    {
	        CreateNewQuestionSetForm cSet = new CreateNewQuestionSetForm(mainForm);
            cSet.ShowDialog();
	    }
	}
}
