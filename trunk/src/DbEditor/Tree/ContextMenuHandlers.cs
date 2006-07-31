using System;
using Crownwood.Magic.Menus;
using GmatClubTest.DbEditor.BusinessObjects;

namespace GmatClubTest.DbEditor.Tree
{
	/// <summary>
	/// Contains handlers of the context menu.
	/// </summary>
	public class ContextMenuHandlers
	{
		/// <summary>
		/// There is no need to create the class.
		/// </summary>
		private ContextMenuHandlers()
		{
		}
        
		internal static void cmd_Click(object sender, EventArgs e)
		{
			throw new Exception("Handler is not implemented");
		}

		internal static void cmdDelete_Click(object sender, EventArgs e) 
		{
			ApplicationController.Instance.DeleteEntities();
		}

		internal static void cmdRename_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//MenuCommand cmd = (MenuCommand)sender;
			//MainFrm.ApplicationController.RenameEntity((Entity)cmd.Tag);
		}
		
		internal static void cmdCut_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//MainFrm.ApplicationController.CutToClipboard();
        }
        
        internal static void cmdCopy_Click(object sender, EventArgs e)
        {
			throw new NotImplementedException();
			//MainFrm.ApplicationController.CopyToClipboard();
        }	

        internal static void cmdPaste_Click(object sender, EventArgs e)
        {
			throw new NotImplementedException();
            //MenuCommand cmd = (MenuCommand)sender;
            //MainFrm.ApplicationController.PasteFromClipboard((Entity)cmd.Tag);
        }

		public static void cmdRefresh_Click(object sender, EventArgs e)
		{
			MenuCommand cmd = (MenuCommand)sender;
			if (cmd.Tag == null)
				ApplicationController.Instance.Refresh();
			else
				ApplicationController.Instance.Refresh((Connection)cmd.Tag);
		}

		public static void cmdAddConnection_Click(object sender, EventArgs e)
		{
			ApplicationController.Instance.AddConnection();
		}

		public static void cmdOpenConnection_Click(object sender, EventArgs e)
		{
			MenuCommand cmd = (MenuCommand)sender;
			ApplicationController.Instance.OpenConnection((Connection)cmd.Tag);
		}

		public static void cmdCloseConnection_Click(object sender, EventArgs e)
		{
			MenuCommand cmd = (MenuCommand)sender;
			ApplicationController.Instance.CloseConnection((Connection)cmd.Tag);
		}

		public static void cmdEditConnection_Click(object sender, EventArgs e)
		{
			MenuCommand cmd = (MenuCommand)sender;
			ApplicationController.Instance.EditConnection((Connection)cmd.Tag);
		}
	}
}
