namespace GmatClubTest.Data.BindedTestsTableAdapters 
{
   public partial class binded_testsTableAdapter
   {
      public System.Data.SqlClient.SqlConnection SqlConnection
      {
         get { return this.Connection; }
         set { this.Connection = value; }
      }
   };
}

