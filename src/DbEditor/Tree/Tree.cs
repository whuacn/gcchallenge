using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Crownwood.Magic.Menus;
using GmatClubTest.DbEditor.BusinessObjects;
using GmatClubTest.UnexpectedExceptionDialog;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor.Tree
{
    /// <summary>
    /// Summary description for Tree.
    /// </summary>
    public class Tree : TreeView
    {
        private RegistryKey registryKey;
        private ContextMenuBuilder contextMenuBuilder;
        private ArrayList connections = new ArrayList();

        private bool isEditingNow = false;

        public ArrayList Connections
        {
            get { return connections; }
        }

        public Tree()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            contextMenuBuilder = new ContextMenuBuilder(this);

            Entity.StructureInternallyChanged +=
                new Entity.StructureInternallyChangedEventHandler(Entity_StructureInternallyChanged);

            registryKey = Registry.CurrentUser.CreateSubKey("Software\\GmatClubTest\\DbEditor\\");
        }

        /// <summary>
        /// Saves the project tree using DataManager.
        /// </summary>
        public void SaveTree()
        {
            try
            {
                registryKey.DeleteSubKeyTree("Connections");
                RegistryKey dbKey = registryKey.CreateSubKey("Connections");
                dbKey.SetValue("Count", connections.Count);
                for (int i = 0; i < connections.Count; ++i)
                    ((Connection) connections[i]).Save(dbKey, i);
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Error while saving the list of connections: {0}", e.Message),
                                ApplicationController.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the project tree using DataManager.
        /// </summary>
        public void LoadTree()
        {
            try
            {
                RegistryKey dbKey = registryKey.CreateSubKey("Connections");
                int c = (int) dbKey.GetValue("Count", 0);
                for (int i = 0; i < c; ++i)
                    connections.Add(Connection.Load(dbKey, i));
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Error while loading the list of connections: {0}", e.Message),
                                ApplicationController.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DrawTree();
        }

        /// <summary>
        /// Draw the project tree || 
        /// </summary>
        internal void DrawTree()
        {
            SuspendLayout();

            try
            {
                Hashtable list = new Hashtable();
                foreach (TreeNode node in Nodes)
                    ReadExpanded(list, node);

                DoDraw();

                foreach (TreeNode node in Nodes)
                    SetExpanded(list, node);
            }
            finally
            {
                ResumeLayout();
            }
        } // DrawTree()

        internal void DoDraw()
        {
            Nodes.Clear();

            foreach (Entity en in Connections)
            {
                TreeNode node = EntityRenderer.Render(en);
                if (node == null)
                {
                    continue;
                }
                Nodes.Add(node);
                DrawSubTree(node, en.Children);
            }
        }

        private void DrawSubTree(TreeNode parent_node, ArrayList list)
        {
            if (list == null)
                return;
            foreach (Entity en in list)
            {
                TreeNode node = EntityRenderer.Render(en);
                if (node == null)
                {
                    continue;
                }
                parent_node.Nodes.Add(node);
                DrawSubTree(node, en.Children);
            }
        } // DrawSubTree()

        /// <summary>
        /// Get selected items in tree
        /// </summary>
        /// <returns>Selected Entities Array</returns>
        public Entity[] SelectedEntities
        {
            get
            {
                Entity[] entities = new Entity[1];

                int i = 0;
                foreach (TreeNode selectedNode in SelectedNodes)
                {
                    entities[i] = (Entity) selectedNode.Tag;
                    i++;
                }
                return entities;
            }
        }

        public TreeNode[] SelectedNodes
        {
            get
            {
                TreeNode[] a = new TreeNode[1];
                a[0] = SelectedNode;
                return a;
            }
        }

        internal void ReadExpanded(Hashtable list, TreeNode node)
        {
            //list.Clear();
            if (!list.ContainsKey(((Entity)node.Tag).EntityId))
            {
                list.Add(((Entity)node.Tag).EntityId, new NodeProperties(node.IsExpanded, node.IsSelected));
            }else
            {
                list[((Entity) node.Tag).EntityId] = new NodeProperties(node.IsExpanded, node.IsSelected);
            }
            foreach (TreeNode n in node.Nodes)
                ReadExpanded(list, n);
        }

        internal void SetExpanded(Hashtable list, TreeNode node)
        {
            object eid = ((Entity) node.Tag).EntityId;
            if (list.ContainsKey(eid))
            {
                if (((NodeProperties) list[eid]).IsSelected) SelectedNode = node; //else  DeselectNode(node, true);
                if (node.IsSelected || ((NodeProperties) list[eid]).IsExpanded) node.Expand();
                else node.Collapse();
                if (node.IsSelected)
                {
                    if (node.Parent != null)
                        ExpandUp(node.Parent);
                }
            }

            foreach (TreeNode n in node.Nodes)
                SetExpanded(list, n);
        }

        private void ExpandUp(TreeNode node)
        {
            node.Expand();
            if (node.Parent != null)
                ExpandUp(node.Parent);
        }

        /*private void Tree_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            TreeNode clickedNode = GetNodeAt(new Point(e.X, e.Y));

            if (clickedNode != null)
            {
               ActiveNode = clickedNode;

               if (!clickedNode.Selected)
               {
                  SelectedNodes.Clear();
                  this.SelectedNode = clickedNode;
               }
            }
         }
      }*/

        private void Tree_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = GetNodeAt(new Point(e.X, e.Y));

                PopupMenu menu;

                if (clickedNode != null)
                {
                    SelectedNode = clickedNode;
                    menu = contextMenuBuilder.Build((Entity) clickedNode.Tag);
                }
                else
                {
                    menu = contextMenuBuilder.Build();
                }
                menu.TrackPopup(Cursor.Position);
            }
        }

        private void Tree_DragOver(object sender, DragEventArgs e)
        {
            TreeNode node = GetNodeAt(PointToClient(new Point(e.X, e.Y)));
            if (node != null)
            {
                node.Expand();

                TreeNode target = GetSuitableDropTarget(e);
                if (target == null)
                    e.Effect = DragDropEffects.None;
                else
                    e.Effect = ((e.KeyState & 8) == 8) ? DragDropEffects.Copy : DragDropEffects.Move; //check CTRL   
            }
        }

        private void Tree_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                TreeNode target = GetSuitableDropTarget(e);
                if (target == null)
                    e.Effect = DragDropEffects.None;
                else
                {
                    Entity newParent = (Entity) target.Tag;

                    TreeNode[] nodeList = SelectedNodes;

                    int i = 0;

                    Entity[] entities = new Entity[nodeList.Length];

                    foreach (TreeNode node in nodeList)
                    {
                        entities[i] = (Entity) node.Tag;
                        i++;
                    }

                    if ((e.KeyState & 8) == 8) //check CTRL
                    {
                        ApplicationController.CopyEntity(entities, newParent);
                    }
                    else
                    {
                        ApplicationController.MoveEntity(entities, newParent);
                    }

                    ((TreeNode) newParent.Tag).Expand();
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        /// <summary>
        /// Used from Tree_DragOver & Tree_DragDrop.
        /// </summary>
        /// <param name="e">DragEventArgs</param>
        /// <returns>null if mouse is not over suitable target, the target - otherwise</returns>
        private TreeNode GetSuitableDropTarget(DragEventArgs e)
        {
            TreeNode target = GetNodeAt(PointToClient(new Point(e.X, e.Y)));
            if (target == null)
            {
                e.Effect = DragDropEffects.None;
                return null;
            }

            Entity targetEntity = (Entity) target.Tag;

            foreach (TreeNode node in SelectedNodes)
            {
                if (!targetEntity.CanAddMovingChild((Entity) node.Tag) || target == node)
                {
                    return null;
                }
            }

            return target;
        }

        private void Tree_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!isEditingNow)
                {
                    Entity[] entities = SelectedEntities;
                    if (entities == null || entities.Length == 0) return;
                    PopupMenu menu = contextMenuBuilder.Build(entities[0]);
                    foreach (MenuCommand m in menu.MenuCommands)
                    {
                        if (m == contextMenuBuilder.deleteCmd)
                        {
                            ApplicationController.Instance.DeleteEntities();
                            break;
                        }
                    }
                }
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (!isEditingNow)
                {
                    Entity[] entities = SelectedEntities;
                    if (entities == null || entities.Length != 1) return;
                    ApplicationController.Instance.RunDefaultAction(entities[0]);
                }
            }
        }


        private void Tree_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            isEditingNow = true;
        }

        private void Tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            isEditingNow = false;
            SelectedNode = e.Node;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // Tree
            // 
            this.AllowDrop = true;
            this.ShowRootLines = false;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tree_MouseUp);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Tree_DragOver);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tree_KeyUp);
            this.DoubleClick += new System.EventHandler(this.Tree_DoubleClick);
            this.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.Tree_AfterLabelEdit);
            this.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Tree_ItemDrag);
            this.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.Tree_BeforeLabelEdit);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Tree_DragDrop);
        }

        #endregion

        [Serializable]
        public class NodeProperties
        {
            public bool IsExpanded, IsSelected;

            public NodeProperties(bool IsExpanded, bool IsSelected)
            {
                this.IsExpanded = IsExpanded;
                this.IsSelected = IsSelected;
            }
        }

        private void Entity_StructureInternallyChanged()
        {
            DrawTree();
        }

        private void Tree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            SelectedNode = (TreeNode) e.Item;
            if (((Entity) (((TreeNode) e.Item).Tag)).CanBeMoved)
                DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void Tree_DoubleClick(object sender, EventArgs e)
        {
            TreeNode clickedNode = GetNodeAt(PointToClient(Cursor.Position));

            if (clickedNode != null)
                ApplicationController.Instance.RunDefaultAction((Entity) clickedNode.Tag);
        }
    }
}