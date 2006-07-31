using System;
using System.Collections;
using System.Windows.Forms;
using Crownwood.Magic.Controls;
using GmatClubTest.DbEditor.BusinessObjects;
using TabPage = Crownwood.Magic.Controls.TabPage;

namespace GmatClubTest.DbEditor
{
	internal class EditingDatabase
	{
		private TabPage tabPage = new Crownwood.Magic.Controls.TabPage();
		private TabbedGroups tabbedGroups = new Crownwood.Magic.Controls.TabbedGroups();
		
		//test ID -> TabPage
		private Hashtable editingTests = new Hashtable();

		//questionSet ID -> TabPage
		private Hashtable editingQuestionSets = new Hashtable();

		public EditingDatabase(Connection connection)
		{
			ApplicationController.MainForm.TabControl.SuspendLayout();
			try
			{
				tabbedGroups.ImageList = ApplicationController.MainForm.TabControl.ImageList;
				tabbedGroups.AtLeastOneLeaf = false;
				tabbedGroups.PageCloseWhenEmpty = true;
				tabbedGroups.PageCloseRequest+=new Crownwood.Magic.Controls.TabbedGroups.PageCloseRequestHandler(tabbedGroups_PageCloseRequest);

				tabbedGroups.Dock = System.Windows.Forms.DockStyle.Fill;

				tabPage.ImageIndex = connection.DbType == Connection.Type.Sql ? 0 : 2;
				tabPage.Title = connection.Name;

				tabPage.Controls.Add(tabbedGroups);

				ApplicationController.MainForm.TabControl.TabPages.Add(tabPage);
				ApplicationController.MainForm.TabControl.SelectedTab = tabPage;
			} 
			finally
			{
				ApplicationController.MainForm.TabControl.ResumeLayout();
			}
		}

		public void EditTest(Test test)
		{
			tabPage.Selected = true;
			TabPage tp = (TabPage)editingTests[test.Value.Id];

			if (tp == null)
			{
				TestEditor e = new TestEditor(test);
				tp = CreatePage(e, test.Value.Name);
				editingTests[test.Value.Id] = tp;
			}

			tp.Selected = true;
			tp.Focus();
		}

		public void EditQuestionSet(QuestionSet quetionSet)
		{
			tabPage.Selected = true;
			TabPage tp = (TabPage)editingQuestionSets[quetionSet.Value.Id];

			if (tp == null)
			{
				QuestionSetEditor e = new QuestionSetEditor(quetionSet);
				tp = CreatePage(e, quetionSet.Value.Name);
				editingQuestionSets[quetionSet.Value.Id] = tp;
			}

			tp.Selected = true;
			tp.Focus();
		}
	    
        public void EditQuestion(Question quetion)
        {
            tabPage.Selected = true;
            TabPage tp = (TabPage)editingQuestionSets[quetion.Value.Id];

            if (tp == null)
            {
                
                QuestionEditor e = new QuestionEditor(quetion);
                tp = CreatePage(e, QuestionType.TypeNames[quetion.Value.TypeId]);
                
                editingQuestionSets[quetion.Value.Id] = tp;
            }

            tp.Selected = true;
            tp.Focus();
        }


        public void EditPassageQuestion(PassageQuestion quetion)
        {
            tabPage.Selected = true;
            TabPage tp = (TabPage)editingQuestionSets[quetion.Value.Id];

            if (tp == null)
            {

                PassageQuestionEditor e = new PassageQuestionEditor(quetion);
                tp = CreatePage(e, QuestionType.TypeNames[quetion.Value.TypeId]);
                
                editingQuestionSets[quetion.Value.Id] = tp;
            }

            tp.Selected = true;
            tp.Focus();
        }
	    
		private TabPage CreatePage(Editor c, string name)
		{
			c.Disposed += new EventHandler(EditorDisposed);
			TabPage tp = new Crownwood.Magic.Controls.TabPage();
				
			tp.Dock = System.Windows.Forms.DockStyle.Fill;
			tp.Title = name;
			tp.ImageIndex = c is TestEditor ? 9 : 10;

			c.Tag = tp;
			tp.Controls.Add(c);

			TabGroupLeaf tgl = GetFirstLeaf();
			tgl.TabPages.Add(tp);
			return tp;
		}

		private void tabbedGroups_PageCloseRequest(TabbedGroups tg, TGCloseRequestEventArgs e)
		{
			e.Cancel = true;
			Editor editor = (Editor)e.TabPage.Controls[0];
			editor.Close(false);
		}

		private TabGroupLeaf GetFirstLeaf()
		{
			if (tabbedGroups.RootSequence.Count == 0)
				tabbedGroups.RootSequence.AddNewLeaf();

			return (TabGroupLeaf)tabbedGroups.RootSequence[0];
		}

		public bool Closing()
		{
			foreach(TabPage t in editingQuestionSets.Values)
			{
                try
                {
                    Editor editor = (Editor)t.Controls[0];
                    if (editor.HasChanges)
                    {
                        DialogResult r = MessageBox.Show("Save changes to the " + editor.ObjectName + "?", ApplicationController.APP_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (r == DialogResult.Cancel) return false;
                        if (r == DialogResult.Yes)
                        {
                            editor.Save();
                        }
                    }
                }catch{}
			}

			foreach(TabPage t in editingTests.Values)
			{
				Editor editor = (Editor)t.Controls[0];
				if (editor.HasChanges)
				{
					DialogResult r = MessageBox.Show("Save changes to the " + editor.ObjectName + "?", ApplicationController.APP_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (r == DialogResult.Cancel) return false;
					if (r == DialogResult.Yes) editor.Save();
				}	
			}

			return true;
		}

		public void Close()
		{
			TabPage[] tps = new TabPage[editingQuestionSets.Values.Count];
			editingQuestionSets.Values.CopyTo(tps, 0);
			foreach(TabPage t in tps)
			{
			    try
                {
				Editor editor = (Editor)t.Controls[0];
				editor.Dispose();
            }
            catch { }
			}

			tps = new TabPage[editingTests.Values.Count];
			editingTests.Values.CopyTo(tps, 0);
			foreach(TabPage t in tps)
			{
				Editor editor = (Editor)t.Controls[0];
				editor.Dispose();
			}

			ApplicationController.MainForm.TabControl.TabPages.Remove(tabPage);
		}

		private void EditorDisposed(object sender, EventArgs e)
		{
			Editor editor = (Editor)sender;

			if (editor is TestEditor)
			{
				editingTests.Remove(editor.Id);
			}
			else
			{
				editingQuestionSets.Remove(editor.Id);
			}
			
			TabPage tp = (TabPage)editor.Tag;

			//locate and remove the tab page 
			for (int i = 0; i < tabbedGroups.RootSequence.Count; ++i)
			{
				TabGroupLeaf tgl = (TabGroupLeaf)tabbedGroups.RootSequence[i];
				foreach (TabPage tabPage in tgl.TabPages)
				{
					if (tabPage == tp)
					{
						tgl.TabPages.Remove(tp);
						return;
					}
				}
			}
		}
	}
}
