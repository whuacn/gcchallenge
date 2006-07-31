using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace GmatClubTest.DbEditor.Tree
{
	/// <summary>
	/// Abstract entity that can exist in the Tree.
	/// </summary>
	[Serializable]
	public abstract class Entity: ICloneable
	{
		#region Attributes

		private Entity parent;
		private ArrayList children = new ArrayList();
		private string name = String.Empty;	
		private bool hidden = false;
		protected bool allowHiding = false;
		[NonSerialized]	private object tag;
		[NonSerialized]	private bool isClonedEntity = false;

		#endregion

		#region Events

		public delegate void CloneEventHandler(Entity en);		
		public delegate void DeleteEventHandler(Entity en);
		public delegate void AddEventHandler(Entity en);
		public delegate void RenameEventHandler(Entity en);
		public delegate void HideEventHandler(Entity en);
		public delegate void AfterMoveEventHandler(Entity en);
		public delegate void StructureInternallyChangedEventHandler();

		/// <summary>
		/// Fires when an entity is cloned.
		/// </summary>
		public static event CloneEventHandler Cloned;

		/// <summary>
		/// Fires when an entity is deleted.
		/// </summary>
		public static event DeleteEventHandler Deleted;

		/// <summary>
		/// Fires when an entity is added.
		/// </summary>
		public static event AddEventHandler AfterAdd;

		/// <summary>
		/// Fires when an entity is renamed.
		/// </summary>
		public static event RenameEventHandler AfterRename;

		/// <summary>
		/// Fires when an entity hidden status is changed.
		/// </summary>
		public static event HideEventHandler AfterHideChanged;

		/// <summary>
		/// Fires when an entity was moved to other folder
		/// </summary>
		public static event AfterMoveEventHandler AfterMove;

		public static event StructureInternallyChangedEventHandler StructureInternallyChanged;

		#endregion

		#region Constructor

		public Entity(string name, Entity parent)
		{
			this.name = name;
			 
			if (parent != null)
				parent.AddNewChild(this);
		}

		#endregion		

		#region Methods

		/// <summary>
		/// Checks if this entity is an ancestor of the specified entity.
		/// </summary>
		/// <param name="entity">An entity.</param>
		/// <returns>true if this entity is an ancestor of the specified entity, false otherwise.</returns>
		public bool IsAncestorOf(Entity entity)
		{			
			for (Entity tmp = entity.parent; tmp != null; tmp = tmp.parent)
				if (tmp == this) 
					return true;
			
			return false;
		}

		/// <summary>
		/// Provides information if this instance can accept a entity which has a parent.
		/// Use doCanAddMovingChild and allowChildToAddMovingChild in order to override standard behavior.
		/// </summary>
		/// <param name="entity">An entity.</param>
		/// <returns>true if this instance can accept entity, false otherwise.</returns>
		public bool CanAddMovingChild(Entity entity)
		{
			//general checks
			if (!entity.CanBeMoved ||
				entity.parent == null ||
				entity == this ||
				entity.parent == this ||
				entity is StaticFolder ||
				entity.isClonedEntity ||
				entity.IsAncestorOf(this)
				) return false;
	
			return DoCanAddMovingChild(entity);
		}

		/// <summary>
		/// Provides information if this instance can accept specified entity which has a parent.
		/// Called from CanAddMovingChild after other checks.
		/// </summary>
		/// <param name="entity">An entity.</param>
		/// <returns>true if this instance can accept entity, false otherwise.</returns>
		internal virtual bool DoCanAddMovingChild(Entity entity)
		{
			return false;
		}

		/// <summary>
		/// Provides information if this instance can add a new entity to its children.
		/// Use doCanAddNewChild and allowChildToAddNewChild in order to override standard behavior.
		/// </summary>
		/// <param name="entity">An entity.</param>
		/// <returns>true if this instance can add the entity, false otherwise.</returns>
		public bool CanAddNewChild(Entity entity)
		{
			//general checks
			if (entity.parent != null ||
				entity == this ||
				entity.isClonedEntity ||
				entity.IsAncestorOf(this)
				) return false;

			return DoCanAddNewChild(entity);
		}

		/// <summary>
		/// Provides information if this instance can add specified new entity.
		/// Called from canAddNewChild after other checks.
		/// </summary>
		/// <param name="entity">An entity.</param>
		/// <returns>true if this instance can add the, false otherwise.</returns>
		internal virtual bool DoCanAddNewChild(Entity entity)
		{
			return false;
		}

		/// <summary>
		/// Adds a new child (the child has to have no parent). 
		/// Applies logic of renaming in case this entity has a child with the same name as the entity which is being added has.
		/// </summary>
		/// <param name="entity">New child</param>
		public void AddNewChild(Entity entity)
		{
			System.Diagnostics.Debug.Assert(entity.parent == null, String.Format("Cannot add {1} to {0}. The entity already has a parent.", this, entity));

			//if (!CanAddNewChild(entity)) throw new Exception(String.Format("Adding of {0} to {1} is forbidden", entity.ToString(), this.ToString()));

            entity.parent = this;
            children.Add(entity);

			//entity will be renamed if it is needed... 
			entity.Name = entity.name;
			OnAfterAdd(entity);
		}

		/// <summary>
		/// Provides information if this instance can add a cloned entity to its children.
		/// </summary>
		/// <param name="entity">An entity.</param>
		/// <returns>true if this instance can add the entity, false otherwise.</returns>
		public bool CanAddClonedChild(Entity entity)
		{
			if (!entity.isClonedEntity) return false;

			entity.isClonedEntity = false;
			
			bool res = false;
			try
			{
				res = CanAddNewChild(entity);
			}
			finally
			{
				entity.isClonedEntity = true;
			}		
			
			return res;
		}

		/// <summary>
		/// Add a new child which was cloned from an existed one.
		/// </summary>
		/// <param name="entity">Cloned entity</param>
		public void AddClonedChild(Entity entity)
		{
			if (!CanAddClonedChild(entity)) throw new Exception(String.Format("Adding of cloned {0} to {1} is forbidden", entity.ToString(), this.ToString()));
			entity.isClonedEntity = false;			
			AddNewChild(entity);
			OnClone(entity);
		}

		/// <summary>
		/// Moves a child from its parent to this entity (the child has to have a parent). 
		/// Applies logic of renaming in case this entity has a child with the same name as the entity which is being added has.
		/// </summary>
		/// <param name="entity">New child</param>
		public void AddMovingChild(Entity entity)
		{
			System.Diagnostics.Debug.Assert(entity.parent != null, String.Format("Cannot move {1} to {0}. The entity has no parent.", this, entity));

			if (!CanAddMovingChild(entity)) throw new Exception(String.Format("Moving of {0} to {1} is forbidden", entity.ToString(), this.ToString()));
				
			entity.parent.children.Remove(entity);
			
			entity.parent = this;
			children.Add(entity);

			//entity will be renamed if it is needed... 
			entity.Name = entity.name;
		
            OnMove(entity);
		}

		/// <summary>
		/// Removes a child.
		/// </summary>
		/// <param name="entity">Child to remove</param>
		internal void RemoveChild(Entity entity)
		{
			if (children.Contains(entity))
			{
				OnDelete(entity);
				entity.parent = null;
				children.Remove(entity);
				entity.Name = "REMOVED! CAN'T BE USED!";
			}
		}

		/// <summary>
		/// Removes all children.
		/// </summary>
		internal void RemoveAllChildren() 
		{
			foreach (Entity child in children) 
			{				
				OnDelete(child);
				child.parent = null;
				child.Name = "REMOVED! CAN'T BE USED!";				
			}

			children.Clear();
		}

		public override string ToString()
		{
			if (parent == null)
				return String.Format("{0} '{1}' (no parent)", GetType().Name, name);
			else
				return String.Format("{0} '{1}' (parent: {2} '{3}')", GetType().Name, name, parent.GetType().Name, parent.Name);
		}

		public Entity Next()
		{
			int thisId = GetIdInParentChildren();
			if( thisId < 0 || !(this.Parent.Children.Count > thisId + 1) ) 
				return null;
			
			return (Entity)this.Parent.Children[thisId + 1];
		}
		
		public Entity Prev()
		{
			int thisId = GetIdInParentChildren();
			if( thisId < 0 || thisId == 0) 
				return null;
			
			return (Entity)this.Parent.Children[thisId - 1];
		}

		private int GetIdInParentChildren()
		{
			if(this.parent == null || this.parent == this) 
				return -1;

			int i = 0;
			foreach (Entity e in parent.Children) 
			{
				if(e == this) 
					return i;
				i++;
			}
			return -1;
		}
		/// <summary>
		/// Sets correct parent in children recursively.
		/// It is needed for DataManager.
		/// </summary>
		internal void FixChildren()
		{
			if(children == null) return;

			foreach(Entity en in children)
			{
				en.parent = this;
				en.FixChildren();
			}
		}

		private bool IsNameUnique()
		{
			if (parent != null)
			{
				foreach(Entity e in parent.children) 
					if (e != this && e.Name == name) return false;
			} 
				                
			return true;
		}

		private void FixName()
		{
			if (!IsNameUnique())
			{
				//renaming entity...

				Regex r = new Regex(@"^(.*?)\s*(\(\d+\))?$");
				Match m = r.Match(name);
				string baseName = m.Groups[1].Value;
				int number = 1;
				do
				{
					name = String.Format("{0} ({1})", baseName, number);
					number++;
				} while(!IsNameUnique());
			}
		}

		/// <summary>
		/// Creates deep clone of the object (but parent == null!!!).
		/// </summary>
		/// <returns>Cloned object (but parent == null!!!)</returns>
		public object Clone()
		{
            Entity n = (Entity)this.MemberwiseClone();
            n.parent = null;
            n.Children = new ArrayList();
            Cloning(n);
            
            System.Diagnostics.Debug.Assert(n.parent == null, "DoClone() should construct entities with parent == null!");

            foreach (Entity e in children)
            {
                Entity nc = (Entity)e.Clone();
                n.children.Add(nc);
                nc.parent = n;
            }

            n.isClonedEntity = true;         

			return n;
		}

		protected virtual void Cloning(Entity clone) {}

		protected static void OnClone(Entity entity)
		{
			if (Cloned != null) 
			{
				Cloned(entity);
			}
		}
		
		protected static void OnDelete(Entity entity)
		{
			if (Deleted != null) 
			{
				Deleted(entity);
			}
		}

		protected static void OnMove(Entity entity)
		{
			if (AfterMove!=null)
			{
				AfterMove(entity);
			}
		}

		protected static void OnAfterHideChanged(Entity entity)
		{
			if( AfterHideChanged != null ) 
			{
				AfterHideChanged(entity);
			}
		}

		protected static void OnAfterAdd(Entity entity)
		{
			if( AfterAdd != null ) 
			{
				AfterAdd(entity);
			}
		}

		protected static void OnAfterRename(Entity entity)
		{
			if (AfterRename != null ) 
			{
				AfterRename(entity);
			}
		}

		protected static void OnStructureChangedInternally()
		{
			if (StructureInternallyChanged != null ) 
				StructureInternallyChanged();
		}

		#endregion

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return name; }
			set	{ name = value; FixName(); if (Parent != null) OnAfterRename(this); } 
		}

		/// <summary>
		/// Shows if Entity hidden or not
		/// </summary>
		public bool Hidden
		{
			get { return hidden; }
			set { hidden = value; OnAfterHideChanged(this); }
		}

		/// <summary>
		/// Shows if Entity can be Hidden or not.
		/// Can be changed from ProjectTree.xml only.
		/// </summary>
		public bool AllowHiding
		{
			get { return allowHiding; }
		}

		/// <summary>
		/// Gets parent of the Entity, or null if it is root.
		/// </summary>
		public Entity Parent
		{
			get { return parent; }
		}

		/// <summary>
		/// The property can be used to logically attach another object or value to this object.
		/// (Practically contains TreeNode).
		/// </summary>
		public object Tag
		{
			get { return tag; }
			set	{ tag = value; }
		}

		/// <summary>
		/// Gets children of the Entity, or null for pure leaves.
		/// </summary>
		public ArrayList Children
		{
			get	{ return children; }
			set { children = value; }
		}

		public Entity Root
		{
			get {if (parent == null) return this; else return parent.Root;}
		}

		public virtual bool CanBeMoved
		{
			get { return true; }
		}

		public virtual object EntityId
		{
			get { return this; }
		}

		#endregion
		
	}
}
