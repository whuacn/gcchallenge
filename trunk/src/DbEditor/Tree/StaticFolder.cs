using System;

namespace GmatClubTest.DbEditor.Tree
{
    /// <summary>
    /// Abstract class for system folders in the Tree.
    /// </summary>
    [Serializable]
    public abstract class StaticFolder : Entity
    {
        public StaticFolder(string name, Entity parent) : base(name, parent)
        {
        }

        public override bool CanBeMoved
        {
            get { return false; }
        }
    }
}