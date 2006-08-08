using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.DbEditor.Data;

namespace GmatClubTest.DbEditor
{
    public class Editor : UserControl, IDisposable
    {
        private Container components = null;
        protected Dataset data;
        protected DbObject dbObject;
        private Hashtable childEditors = new Hashtable();

        public Editor(DbObject dbObject)
        {
            if (dbObject.Parent is DbObject)
                ApplicationController.Instance.Edit((DbObject) dbObject.Parent);

            this.dbObject = dbObject;
            dbObject.Editor = this;

            InitializeComponent();

            dbObject.Load(ref data);

            if (dbObject.Parent is DbObject)
            {
                DbObject t = (DbObject) dbObject.Parent;
                t.Editor.RegisterChildEditor(this);
            }

            Dock = DockStyle.Fill;
        }

        //Only for the Designer!
        public Editor()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Editor[] a = new Editor[childEditors.Keys.Count];
                childEditors.Keys.CopyTo(a, 0);
                foreach (Editor e in a) e.Dispose();

                if (dbObject.Parent is DbObject)
                {
                    DbObject t = (DbObject) dbObject.Parent;
                    t.Editor.UnregisterChildEditor(this);
                }

                //if(dbObject is Question)
                //{
                //    dbObject.Editor.UnregisterChildEditor(this);
                //}

                dbObject.Editor = null;

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
            this.data = new GmatClubTest.DbEditor.Data.Dataset();
            ((System.ComponentModel.ISupportInitialize) (this.data)).BeginInit();
            this.data = new GmatClubTest.DbEditor.Data.Dataset();
            ((System.ComponentModel.ISupportInitialize) (this.data)).EndInit();
        }

        #endregion

        public bool HasChanges
        {
            get
            {
                EndCurrentEdit();
                bool isNeedSave = dbObject.HasChanges;
                if (isNeedSave)
                {
                    SaveCurrentEdit();
                }
                return isNeedSave;
            }
        }


        public void Save()
        {
            EndCurrentEdit();
            dbObject.Save();
        }

        public virtual String ObjectName
        {
            get { throw new InvalidOperationException(""); }
        }

        public virtual int Id
        {
            get { throw new InvalidOperationException(""); }
        }

        public virtual void SaveCurrentEdit()
        {
            throw new InvalidOperationException("");
        }

        public void RegisterChildEditor(Editor editor)
        {
            childEditors.Add(editor, null);
        }

        public void UnregisterChildEditor(Editor editor)
        {
            childEditors.Remove(editor);
        }

        public bool HasChildEditors
        {
            get { return childEditors.Count > 0; }
        }

        public virtual void SetBindingPosition()
        {
            throw new InvalidOperationException("");
        }

        public virtual void EndCurrentEdit()
        {
            throw new InvalidOperationException("");
        }

        public void Close(bool dontAskToClose)
        {
            if (HasChildEditors)
            {
                if (!dontAskToClose)
                {
                    DialogResult r =
                        MessageBox.Show(
                            String.Format(
                                "This {0} has editing child elements. Do you want to close this {0} and all the children?",
                                ObjectName), ApplicationController.APP_CAPTION, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    if (r == DialogResult.No) return;
                }

                Editor[] a = new Editor[childEditors.Keys.Count];
                childEditors.Keys.CopyTo(a, 0);
                foreach (Editor e in a) e.Close(true);
            }

            if (HasChanges)
            {
                DialogResult r =
                    MessageBox.Show("Do you want to save changes to the " + ObjectName + "?",
                                    ApplicationController.APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes) Save();
            }

            Dispose();
        }
    }
}