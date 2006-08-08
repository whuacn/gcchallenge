using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
    public abstract class DbObject : Entity
    {
        public Connection connection;
        protected QuestionType questionType;
        private Dataset fullDataset;
        private Editor editor;

        public DbObject(QuestionType questionType) : base("DbObject", null)
        {
            this.questionType = questionType;
        }

        public DbObject(string name, QuestionType questionType) : base(name, null)
        {
            this.questionType = questionType;
        }

        protected abstract void DoLoadFullDataset();
        public abstract void Save();
        public abstract bool HasChanges { get; }

        public Connection GetConnection()
        {
            return connection;
        }

        public Dataset FullDataset
        {
            get
            {
                if (Parent is DbObject)
                    return ((DbObject) Parent).FullDataset;

                if (fullDataset == null)
                {
                    fullDataset = new Dataset();
                    Load(ref fullDataset);
                }

                return fullDataset;
            }
        }


        public void Load(ref Dataset Dataset)
        {
            if (Parent is DbObject)
            {
                fullDataset = null;
                DbObject parent = (DbObject) Parent;
                Dataset = parent.FullDataset;
                editor.SetBindingPosition();
            }
            else
            {
                if (fullDataset == null)
                {
                    fullDataset = Dataset;
                    DoLoadFullDataset();
                }
                else
                {
                    Dataset = fullDataset;
                }
            }
        }

        public Editor Editor
        {
            get { return editor; }
            set
            {
                editor = value;
                if (editor == null) ClearFullDataset();
            }
        }

        public QuestionType QuestionType
        {
            get { return questionType; }
        }

        private void ClearFullDataset()
        {
            if (fullDataset != null)
            {
                fullDataset.Dispose();
                fullDataset = null;
            }
        }

        //public void UpdateQuestion(int setId)
        //{
        //    connection.DataProvider.UpdateQuestions(fullDataset, setId);
        //}

        public void GetAllQuestionsEx(Dataset ds)
        {
            connection.DataProvider.GetAllQuestionsEx(ds.QuestionsEx);
        }

        public void AddExistingQuestionToSet(Dataset.QuestionsExRow qsr, int order, int setId)
        {
            connection.DataProvider.AddExistingQuestionToSet(qsr, order, setId);
            ApplicationController.Instance.Refresh(connection);
        }

        public void RefreshConnection()
        {
            ApplicationController.Instance.Refresh(connection);
        }
    }
}