using System;
using System.Data;
using System.Data.SqlClient;

namespace AccessControl {


   partial class acl_function
   {

      public static void can_set_name(IDbConnection c, int idx, string new_name)
      {
         if ("new_one" == new_name) throw new System.Exception("Please rename function 'new_function'");
         Object dx = get_function_idx_by_name(c, new_name);

         if (dx != null && !dx.Equals(idx))
         {
            throw new System.Exception("Other function has such name: " + new_name);
         }
      }

      protected static Object get_function_idx_by_name(IDbConnection c, string new_name)
      {
         SqlCommand cmd = (SqlCommand)(c.CreateCommand());
         cmd.CommandText = "select idx from acl_function where name='" + new_name + "';";
         return cmd.ExecuteScalar();
      }
      
      public static int create(IDbConnection c,string name)
      {
         throw new System.Exception("Not impl");
      }


   }
}

namespace AccessControl.acl_functionTableAdapters
{
   public partial class acl_functionTableAdapter
   {
      public System.Data.SqlClient.SqlConnection SqlConnection
      {
         get { return this.Connection; }
         set { this.Connection = value; }

      }
   };
}


