using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;
using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor
{
    public partial class SelectSet : Form
    {
        public int setId;
        private Connection connection;
        int setOrder;
        public int testId;
        public Dataset.QuestionSetsRow qsRow;
        private Test test;
        public SelectSet(Connection con, int testId, int setId, int setOrder, Test t)
        {
            test = t;
            InitializeComponent();
            this.setOrder = setOrder;
            this.setId = setId;
            this.testId = testId;
            connection = con;
            setsDataset.Clear();
            //connection.DataProvider.AllQuestionSetsAdapter.Fill(this.setsDataset.QuestionSetsEx);
            Provider provider;
            provider = connection.DataProvider;
            provider.AllQuestionSetsAdapter.Fill(setsDataset.QuestionSets);
            provider.AllQuestionSetsExAdapter.Fill(setsDataset.QuestionSetsEx);
            provider.AllTestsAdapter.Fill(setsDataset.Tests);
            //dataGridView1.Update();
        }

        private void SelectSet_Load(object sender, EventArgs e)
        {
            
            for (int i=0; i<setsDataset.QuestionSetsEx.Count; ++i)
            {
                    if (setsDataset.QuestionSetsEx[i].TestId == testId)
                    {
                        try
                        {
                            setsDataset.QuestionSets.FindById(setsDataset.QuestionSetsEx[i].Id).Delete();
                        }catch
                        {
                            
                        }
                        continue;
                    }
                if(!setsDataset.Tests.FindById(testId).IsQuestionTypeIdNull())
                {
                    if(setsDataset.Tests.FindById(testId).QuestionTypeId != setsDataset.QuestionSetsEx[i].QuestionTypeId)
                    {
                        setsDataset.QuestionSetsEx[i].Delete();
                        continue;
                    }
                }
            }
            setsDataGrid.Update();
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (setsDataGrid.SelectedRows.Count > 0)
            {
                setId = (int)setsDataGrid.SelectedRows[0].Cells[0].Value;
                qsRow = setsDataset.QuestionSets.FindById(setId);
                test.setId = setId;
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                
            }else
            {
                MessageBox.Show("Set not selected.", "Select set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;        
            }
        }
        //public QuestionSet questionSet
        //{
        //    get
        //    {
        //        connection.DataProvider.QuestionSetById.SelectCommand.Parameters[0].Value = setId;
        //        connection.DataProvider.QuestionSetById.Fill(setsDataset.QuestionSets);
        //        QuestionSet qs =new QuestionSet(setsDataset.QuestionSets.Rows[0] ,Entity p);
        //        return setsDataset.QuestionSets.FindById(setId);
        //    }
        //}
    }
}