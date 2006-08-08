using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using GmatClubTest.Data;

namespace GmatClubTest.DataProvider
{
    public class BaseDataProvider : Component, IDataProvider
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public BaseDataProvider(IContainer container)
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            container.Add(this);
            InitializeComponent();
        }

        public BaseDataProvider()
        {
            ///
            /// Required for Windows.Forms Class Composition Designer support
            ///
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        public virtual void Open()
        {
            throw new InvalidOperationException("The method must be overriden.");
        }

        public virtual void Close()
        {
            throw new InvalidOperationException("The method must be overriden.");
        }

        protected virtual DbDataAdapter AdapterUsers
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterUserById
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterTests
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterQuestionById
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterAnswersByQuestionId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterQuestionSetsByTestId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterQuestionsByQuestionSetId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterQuestionsByQuestionSetIdAndZone
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterAnswersByQuestionSetId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterAnswersByQuestionSetIdAndZone
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterResultsByUserIdTimeRange
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterResultsDetailsByResultId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterResultsByResultId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterResultDetailsByResultId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterPassagesToQuestionsByQuestionId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterQuestionSetsExByResultId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        protected virtual DbDataAdapter AdapterResultsDetailsOfSetsByResultId
        {
            get
            {
                {
                    throw new InvalidOperationException("The method must be overriden.");
                }
            }
        }

        public void Update(ResultResultDetailSet results)
        {
            AdapterResultsByResultId.Update(results.Results);
            AdapterResultsDetailsByResultId.Update(results.ResultsDetails);
            AdapterResultsDetailsOfSetsByResultId.Update(results.ResultsDetailsOfSets);
        }

        public void Update(UserSet users)
        {
            AdapterUsers.Update(users);
        }

        public void GetUsers(UserSet users)
        {
            AdapterUsers.Fill(users);
        }

        public void GetUser(int userId, UserSet user)
        {
            IDataParameter[] p = AdapterUserById.GetFillParameters();
            p[0].Value = userId;
            AdapterUserById.Fill(user);
        }

        public void GetResults(int userId, DateTime beginTime, DateTime endTime, ResultSet results)
        {
            IDataParameter[] p = AdapterResultsByUserIdTimeRange.GetFillParameters();
            p[0].Value = userId;
            p[1].Value = beginTime;
            p[2].Value = endTime;
            AdapterResultsByUserIdTimeRange.Fill(results);
        }

        public void GetQuestionSetsResultDetailsSet(int resultId, QuestionSetsResultDetailsSet questionSetsResultDetails)
        {
            IDataParameter[] p = AdapterQuestionSetsExByResultId.GetFillParameters();
            p[0].Value = resultId;
            AdapterQuestionSetsExByResultId.Fill(questionSetsResultDetails.QuestionSets);

            p = AdapterResultDetailsByResultId.GetFillParameters();
            p[0].Value = resultId;
            AdapterResultDetailsByResultId.Fill(questionSetsResultDetails.Answers);
        }

        public void GetPassageToQuestions(int questionId, PassageToQuestionSet passageToQuestions)
        {
            IDataParameter[] p = AdapterPassagesToQuestionsByQuestionId.GetFillParameters();
            p[0].Value = questionId;
            AdapterPassagesToQuestionsByQuestionId.Fill(passageToQuestions.PassageToQuestions);
        }

        public void GetTests(TestSet tests)
        {
            AdapterTests.Fill(tests);
        }

        public void GetQuestionSetsByTestId(int testId, QuestionSetSet questionSets)
        {
            IDataParameter[] p = AdapterQuestionSetsByTestId.GetFillParameters();
            p[0].Value = testId;
            AdapterQuestionSetsByTestId.Fill(questionSets);
        }

        public void GetQuestion(int questionId, QuestionSet questionSet)
        {
            IDataParameter[] p = AdapterQuestionById.GetFillParameters();
            p[0].Value = questionId;
            AdapterQuestionById.Fill(questionSet);
        }

        public void GetAnswers(int questionId, AnswerSet answerSet)
        {
            IDataParameter[] p = AdapterAnswersByQuestionId.GetFillParameters();
            p[0].Value = questionId;
            AdapterAnswersByQuestionId.Fill(answerSet);
        }

        public void GetQuestionsAnswersByQuestionSetId(int questionSetId, QuestionAnswerSet questionsAnswers)
        {
            IDataParameter[] p = AdapterQuestionsByQuestionSetId.GetFillParameters();
            p[0].Value = questionSetId;
            AdapterQuestionsByQuestionSetId.Fill(questionsAnswers.Questions);

            p = AdapterAnswersByQuestionSetId.GetFillParameters();
            p[0].Value = questionSetId;
            AdapterAnswersByQuestionSetId.Fill(questionsAnswers.Answers);
        }

        public void GetQuestionsAnswersByQuestionSetIdAndZone(int questionSetId, byte questionZone,
                                                              QuestionAnswerSet questionsAnswers)
        {
            IDataParameter[] p = AdapterQuestionsByQuestionSetIdAndZone.GetFillParameters();
            p[0].Value = questionSetId;
            p[1].Value = questionZone;
            AdapterQuestionsByQuestionSetIdAndZone.Fill(questionsAnswers.Questions);

            p = AdapterAnswersByQuestionSetIdAndZone.GetFillParameters();
            p[0].Value = questionSetId;
            p[1].Value = questionZone;
            AdapterAnswersByQuestionSetIdAndZone.Fill(questionsAnswers.Answers);
        }
    }
}