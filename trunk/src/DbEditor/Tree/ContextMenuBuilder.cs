using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using Crownwood.Magic.Menus;
using GmatClubTest.DbEditor.BusinessObjects;

namespace GmatClubTest.DbEditor.Tree
{
	/// <summary>
	/// Responsible for creation of a pop-up menu of an Entity.
	/// </summary>
	public class ContextMenuBuilder: Component
	{
		private System.ComponentModel.IContainer components;

		private delegate void ConcreteBuilder(Entity e);
		/// <summary>
		/// Table: Type -> ConcreteBuilder
		/// </summary>
		private Hashtable Builders = new Hashtable();
				
		private PopupMenu menu = new PopupMenu();
		private System.Windows.Forms.ImageList imageList;

		private readonly MenuCommand separator;
		internal readonly MenuCommand deleteCmd;
		internal readonly MenuCommand cutCmd;
		internal readonly MenuCommand copyCmd;
		internal readonly MenuCommand pasteCmd;
		internal readonly MenuCommand renameCmd;
		internal readonly MenuCommand refreshCmd;
		internal readonly MenuCommand addConnectionCmd;
		internal readonly MenuCommand openConnectionCmd;
		internal readonly MenuCommand closeConnectionCmd;
		internal readonly MenuCommand editConnectionCmd;
		
		private Tree tree;
	
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="tree">Project tree</param>
		public ContextMenuBuilder(Tree tree)
		{
			InitializeComponent();

			separator = new MenuCommand("-");
			cutCmd = new MenuCommand("Cu&t", imageList, 0, new EventHandler(ContextMenuHandlers.cmdCut_Click));
			copyCmd = new MenuCommand("Cop&y", imageList, 1, new EventHandler(ContextMenuHandlers.cmdCopy_Click));
			pasteCmd = new MenuCommand("&Paste", imageList, 2, new EventHandler(ContextMenuHandlers.cmdPaste_Click));
			deleteCmd = new MenuCommand("&Delete", imageList, 3, new EventHandler(ContextMenuHandlers.cmdDelete_Click));
			renameCmd = new MenuCommand("Rena&me", imageList, 4, new EventHandler(ContextMenuHandlers.cmdRename_Click));
			refreshCmd = new MenuCommand("Re&fresh", imageList, 5, new EventHandler(ContextMenuHandlers.cmdRefresh_Click));
			addConnectionCmd = new MenuCommand("&Add Database", imageList, 6, new EventHandler(ContextMenuHandlers.cmdAddConnection_Click));
			openConnectionCmd = new MenuCommand("&Connect", imageList, 7, new EventHandler(ContextMenuHandlers.cmdOpenConnection_Click));
			closeConnectionCmd = new MenuCommand("Di&sconnect", imageList, 8, new EventHandler(ContextMenuHandlers.cmdCloseConnection_Click));
			editConnectionCmd  = new MenuCommand("&Edit", imageList, 11, new EventHandler(ContextMenuHandlers.cmdEditConnection_Click));

			Builders.Add(typeof(Connection), new ConcreteBuilder(BuildForConnection));
			this.tree = tree;
		}

		/// <summary>
		/// Builds a PopupMenu for the Entity
		/// </summary>
		/// <param name="e">An Entity</param>
		/// <returns>Context menu</returns>
		public PopupMenu Build(Entity e)
		{
			menu.MenuCommands.Clear();
			
			ConcreteBuilder builder = (ConcreteBuilder)Builders[e.GetType()];
			if (builder == null) return menu;
			builder(e);

			if (Clipboard.Entities.Length != 0)
			{
				pasteCmd.Enabled = true;
			    
				if (Clipboard.IsCut)
				{
					foreach (Entity en in Clipboard.Entities)
					{
						if (!e.CanAddMovingChild(en))
						{
							pasteCmd.Enabled = false;
							break;
						}
					}
				}
				else
				{
					foreach (Entity en in Clipboard.Entities)
					{
						if (!e.CanAddClonedChild(en))
						{
							pasteCmd.Enabled = false;
							break;
						}
					}
				}
			}
			else
				pasteCmd.Enabled = false;
			
			foreach(MenuCommand m in menu.MenuCommands) m.Tag = e;
			return menu;
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContextMenuBuilder));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;

		}
		
		/// <summary>
		/// Build menu
		/// </summary>
		/// <returns>PopupMenu</returns>
		public PopupMenu Build()
		{
			menu.MenuCommands.Clear();
			menu.MenuCommands.Add(refreshCmd);
			menu.MenuCommands.Add(addConnectionCmd);
			foreach(MenuCommand m in menu.MenuCommands) m.Tag = null;
			return menu;
		} 

		private void BuildForConnection(Entity e)
		{
			Connection c = (Connection)e;

			if (c.Opened)
				menu.MenuCommands.Add(closeConnectionCmd);
			else
				menu.MenuCommands.Add(openConnectionCmd);

			menu.MenuCommands.Add(refreshCmd);
			menu.MenuCommands.Add(separator);
			menu.MenuCommands.Add(editConnectionCmd);
			menu.MenuCommands.Add(deleteCmd);
		}
	}
}