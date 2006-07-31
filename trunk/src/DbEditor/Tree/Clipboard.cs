namespace GmatClubTest.DbEditor.Tree
{
	/// <summary>
	/// For processiong Cut, Copy and Paste command.
	/// </summary>
	public class Clipboard
	{
        private static Clipboard theOnlyOneInstance = new Clipboard();
        
        private Entity[] entities = new Entity[0];
        private bool isCut;
        
	    private Clipboard()
	    {
	    }
	    
        public static bool IsCut
        {
            get { return theOnlyOneInstance.isCut; }
        }
   
	    /// <summary>
	    /// Cut command
	    /// </summary>
	    /// <param name="entities">Cut entity</param>
	    public static void CutEntity(Entity[] entities)
	    {
	        theOnlyOneInstance.isCut = true;
	        theOnlyOneInstance.entities = entities;
	    }
	    
	    /// <summary>
	    /// Copy command
	    /// </summary>
	    /// <param name="entities">Copied entity</param>
	    public static void CopyEntity(Entity[] entities)
	    {
	        theOnlyOneInstance.isCut = false;
	        theOnlyOneInstance.entities = entities; 
	    }
	    
	    /// <summary>
	    /// Returns entities for paste command
	    /// </summary>	    
	    public static Entity[] Entities
	    {
			get {return theOnlyOneInstance.entities;}
	    }
	    
	    /// <summary>
	    /// Clear Clipboard
	    /// </summary>
	    public static void ClearClipboard()
	    {
	        theOnlyOneInstance.entities = new Entity[0];
	    }

	}
}
