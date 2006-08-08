using System;
using System.Collections;
using System.Windows.Forms;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public class Connection : StaticFolder, IDisposable
    {
        public enum Type
        {
            Access,
            Sql
        } ;

        private string fileName = "";
        private string serverName = "";
        private string dbName = "GmatClubTest";
        private string userName = "gcadmin";
        private Type type = Type.Access;
        private Provider dataProvider = new Provider();
        private String password = "";
        private bool opened;

        private TestQuestionSetSet testsQuestionSets = new TestQuestionSetSet();

        public Connection() : base("?", null)
        {
        }

        public Connection(string fileName) : base(fileName, null)
        {
            FileName = fileName;
        }

        public Connection(string serverName, string dbName, string userName) : base(serverName + "." + dbName, null)
        {
            type = Type.Sql;
            ServerName = serverName;
            DbName = dbName;
            UserName = userName;
        }

        public void Open()
        {
            if (!dataProvider.Opened)
            {
                LoadTestsQuestionSets();
            }
        }

        private void LoadTestsQuestionSets()
        {
            testsQuestionSets = new TestQuestionSetSet();

            ProcessingForm f = new ProcessingForm();
            f.Caption = "Opening Database";
            try
            {
                int nOfOp = 5;
                int op = 1;

                //1
                f.Operation = "Connecting to " + Name + "...";
                f.Show();
                f.Refresh();
                if (!opened)
                {
                    Connect();
                }
                f.Progress = (op++*100)/nOfOp;

                //2
                f.Operation = "Loading Tests...";
                LoadTests();
                f.Progress = (op++*100)/nOfOp;

                //3
                f.Operation = "Loading Question Sets...";
                LoadQuestionSets();
                f.Progress = (op++*100)/nOfOp;

                //4
                f.Operation = "Loading Content of the Tests...";
                LoadTestContents();
                f.Progress = (op++*100)/nOfOp;

                //5
                f.Operation = "Building the Tree...";
                CreateSubElements();
                OnStructureChangedInternally();
                f.Progress = (op++*100)/nOfOp;
            }
            finally
            {
                f.Close();
            }
        }


        private void ReLoadTestsQuestionSets()
        {
            testsQuestionSets = new TestQuestionSetSet();


            ProcessingForm f = new ProcessingForm();
            f.Caption = "Opening Database";
            try

            {
                int nOfOp = 5;
                int op = 1;

                f.Operation = "Connecting to " + Name + "...";
                f.Show();
                f.Refresh();
                if (!opened)
                {
                    Connect();
                }
                f.Progress = (op++*100)/nOfOp;

                //2
                f.Operation = "Loading Tests...";
                LoadTests();
                f.Progress = (op++*100)/nOfOp;

                //3
                f.Operation = "Loading Question Sets...";
                LoadQuestionSets();
                f.Progress = (op++*100)/nOfOp;

                //4
                f.Operation = "Loading Content of the Tests...";
                LoadTestContents();
                f.Progress = (op++*100)/nOfOp;

                //5
                f.Operation = "Building the Tree...";
                CreateSubElements();
                OnStructureChangedInternally();
                f.Progress = (op++*100)/nOfOp;
            }
            finally
            {
                f.Close();
            }
        }

        public void ReloadQuestionSets()
        {
            testsQuestionSets = new TestQuestionSetSet();
            LoadTests();
            LoadQuestionSets();
            LoadTestContents();
        }

        private void LoadTestContents()
        {
            dataProvider.AllTestContentsAdapter.Fill(testsQuestionSets);
        }

        private void LoadQuestionSets()
        {
            dataProvider.AllQuestionSetsAdapter.Fill(testsQuestionSets);
        }

        private void LoadTests()
        {
            dataProvider.AllTestsAdapter.Fill(testsQuestionSets);
        }

        private void CreateSubElements()
        {
            RemoveAllChildren();
            new Tests(this);
            new QuestionSets(this);
        }

        private void Connect()
        {
            if (!Opened)
            {
                if (type == Type.Access)
                    dataProvider.ConnectToAccess(FileName, Password);
                else
                    dataProvider.ConnectToSql(ServerName, DbName, UserName, Password);
                opened = true;
            }
        }

        public void TestConnection()
        {
            Connect();
            Close();
        }

        public void Close()
        {
            if (dataProvider.Opened)
            {
                opened = false;
                dataProvider.Opened = false;
                RemoveAllChildren();
                OnStructureChangedInternally();
            }
        }

        public bool Opened
        {
            get { return dataProvider.Opened; }
        }

        public void Dispose()
        {
            Close();
        }

        public void Save(RegistryKey registryKey, int index)
        {
            RegistryKey dbKey = registryKey.CreateSubKey("Connection" + index.ToString());
            dbKey.SetValue("Type", type.ToString());
            if (type == Type.Access)
            {
                dbKey.SetValue("FileName", FileName);
            }
            else
            {
                dbKey.SetValue("ServerName", ServerName);
                dbKey.SetValue("DbName", DbName);
                dbKey.SetValue("UserName", UserName);
            }
        }

        public static Connection Load(RegistryKey registryKey, int index)
        {
            Connection db;
            RegistryKey dbKey = registryKey.OpenSubKey("Connection" + index.ToString());
            Type type = (Type) Type.Parse(typeof (Type), (String) dbKey.GetValue("Type"), true);
            if (type == Type.Access)
            {
                String fileName = (String) dbKey.GetValue("FileName");
                db = new Connection(fileName);
            }
            else
            {
                String serverName = (String) dbKey.GetValue("ServerName");
                String dbName = (String) dbKey.GetValue("DbName");
                String userName = (String) dbKey.GetValue("UserName");
                db = new Connection(serverName, dbName, userName);
            }
            return db;
        }

        public Type DbType
        {
            get { return type; }
            set
            {
                type = value;
                if (type == Type.Access) Name = fileName;
                else Name = serverName + "." + dbName;
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                DbType = type;
            }
        }

        public string ServerName
        {
            get { return serverName; }
            set
            {
                serverName = value;
                DbType = type;
            }
        }

        public string DbName
        {
            get { return dbName; }
            set
            {
                dbName = value;
                DbType = type;
            }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public void Assign(Connection source)
        {
            DbType = source.DbType;
            UserName = source.UserName;
            Password = source.Password;
            DbName = source.DbName;
            ServerName = source.ServerName;
            FileName = source.FileName;
        }

        internal override bool DoCanAddNewChild(Entity entity)
        {
            return entity is Tests || entity is QuestionSets;
        }

        internal override bool DoCanAddMovingChild(Entity entity)
        {
            return false;
        }

        internal Provider DataProvider
        {
            get { return dataProvider; }
        }

        //TODO: it does not reload data from a DB... Is it OK? - NO!:-)
        public void Refresh()
        {
            ApplicationController.MainForm.Tree.SuspendLayout();

            try
            {
                Hashtable list = new Hashtable();
                foreach (TreeNode node in ApplicationController.MainForm.Tree.Nodes)
                    ApplicationController.MainForm.Tree.ReadExpanded(list, node);

                ReLoadTestsQuestionSets();

                RemoveAllChildren();
                if (Opened) CreateSubElements();

                ApplicationController.MainForm.Tree.DoDraw();

                foreach (TreeNode node in ApplicationController.MainForm.Tree.Nodes)
                    ApplicationController.MainForm.Tree.SetExpanded(list, node);
            }
            finally
            {
                ApplicationController.MainForm.Tree.ResumeLayout();
            }
        }

        public TestQuestionSetSet.TestsDataTable Tests
        {
            get { return testsQuestionSets.Tests; }
        }

        public TestQuestionSetSet.QuestionSetsDataTable QuestionSets
        {
            get { return testsQuestionSets.QuestionSets; }
        }

        public TestQuestionSetSet TestQuestionSetSet
        {
            get { return testsQuestionSets; }
        }
    }
}