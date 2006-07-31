using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GmatClubTest.DbEditor.BusinessObjects;

namespace GmatClubTest.DbEditor.Tree
{
	/// <summary>
	/// Responsible for visual presentation an Entity.
	/// Singleton.
	/// </summary>
	public class EntityRenderer
	{
		public static TreeNode Render(Entity e) 
		{
            if (e is Question || e is PassageQuestion)
            {
                return null;
            }
			Presentation p = (Presentation)instance.presentation[e.GetType()];
			Debug.Assert(p != null, String.Format("Cannot render Entity {0} of type {1}. A visual presentation of such type is unknown.", e.Name, e.GetType().Name));
           
			TreeNode node = new TreeNode();			
			node.Text = e.Name;
			node.ImageIndex = p.imageIndex;

			if (p.isNameBold)
				node.ForeColor = Color.Blue;
            
			if (e.Hidden == true)
				node.ForeColor = Color.LightGray;

			if (p.specificRenderer != null) 
				node = p.specificRenderer(e, node);
				
			if (Clipboard.Entities.Length != 0)
			{
			    foreach (Entity entity in Clipboard.Entities)
			    {
			        if (e == entity)
			            node.ForeColor = Color.DimGray;
			    }
			}

			node.Tag = e;
			e.Tag = node;
			node.SelectedImageIndex = node.ImageIndex;
			return node;
		}

		private TreeNode ConnectionRenderer(Entity e, TreeNode node)
		{
			Connection db = (Connection)e;
			if (db.DbType == Connection.Type.Access)
			{
				node.ImageIndex = db.Opened ? DATABASE_ACCESS_ICON : DATABASE_ACCESS_DISABLED_ICON;
			} else
			{
				node.ImageIndex = db.Opened ? DATABASE_SQL_ICON : DATABASE_SQL_DISABLED_ICON;
			}

			return node;
		}
		
		/// <summary>
		/// Private constructor
		/// </summary>
		private EntityRenderer()
		{
			presentation = new Hashtable();

			presentation.Add(typeof(Connection), new Presentation(DATABASE_SQL_ICON, true, new Presentation.SpecificRenderer(ConnectionRenderer)));
			presentation.Add(typeof(Tests), new Presentation(TESTS_ICON, false));
			presentation.Add(typeof(QuestionSets), new Presentation(QUESTION_SETS_ICON, false));
			presentation.Add(typeof(QuantitativeAdaptiveTests), new Presentation(QUNTITATIVE_ICON, false));
			presentation.Add(typeof(QuantitativeSets), new Presentation(QUNTITATIVE_ICON, false));
			presentation.Add(typeof(VerbalAdaptiveTests), new Presentation(VERBAL_ICON, false));
			presentation.Add(typeof(VerbalSets), new Presentation(VERBAL_ICON, false));
			presentation.Add(typeof(MixedAdaptiveTests), new Presentation(MIXED_ICON, false));
			presentation.Add(typeof(MixedSets), new Presentation(MIXED_ICON, false));
			presentation.Add(typeof(Test), new Presentation(TEST_ICON, false));
			presentation.Add(typeof(QuestionSet), new Presentation(QUESTION_SET_ICON, false));
			presentation.Add(typeof(AdaptiveTests), new Presentation(ADAPTIVE_TESTS_ICON, false));
			presentation.Add(typeof(Practices), new Presentation(PRACTICES_ICON, false));
			presentation.Add(typeof(QuantitativePractices), new Presentation(QUNTITATIVE_ICON, false));
			presentation.Add(typeof(VerbalPractices), new Presentation(VERBAL_ICON, false));
			presentation.Add(typeof(MixedPractices), new Presentation(MIXED_ICON, false));
		}

		/// <summary>
		/// The only one instance.
		/// </summary>
		private static EntityRenderer instance = new EntityRenderer();

		/// <summary>
		/// Table: Type -> Presentation
		/// </summary>
		private Hashtable presentation;

		private class Presentation
		{
			public delegate TreeNode SpecificRenderer(Entity entity, TreeNode node);

			public Presentation(int imageIndex, bool isNameBold)
			{
				this.imageIndex = imageIndex;
				this.isNameBold = isNameBold;
				specificRenderer = null;
			}

			public Presentation(int imageIndex, bool isNameBold, SpecificRenderer specificRenderer)
			{
				this.imageIndex = imageIndex;
				this.isNameBold = isNameBold;
				this.specificRenderer = specificRenderer;
			}

			public int imageIndex;
			public bool isNameBold;
			public SpecificRenderer specificRenderer;
		}

		private const int DATABASE_SQL_ICON = 0;
		private const int DATABASE_SQL_DISABLED_ICON = 1;
		private const int DATABASE_ACCESS_ICON = 2;
		private const int DATABASE_ACCESS_DISABLED_ICON = 3;
		private const int TESTS_ICON = 4;
		private const int QUESTION_SETS_ICON = 5;
		private const int QUNTITATIVE_ICON = 6;
		private const int VERBAL_ICON = 7;
		private const int MIXED_ICON = 8;
		private const int TEST_ICON = 9;
		private const int QUESTION_SET_ICON = 10;
		private const int ADAPTIVE_TESTS_ICON = 11;
		private const int PRACTICES_ICON = 12;
	}
}