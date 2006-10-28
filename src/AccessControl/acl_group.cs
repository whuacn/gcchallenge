using System;
using System.Data.SqlClient;
using System.Data;

namespace AccessControl {


   partial class acl_group
   {
      partial class acl_groupDataTable
      {
      }
   
      public static void can_set_name(IDbConnection c, int idx, string new_name)
      {
         Object o_idx = get_group_idx_by_name(c, new_name);
         if (o_idx != null && !o_idx.Equals(idx))
         {
            throw new System.Exception("Such group already exists: " + new_name);
         }
      }

      static Object get_group_idx_by_name(IDbConnection c, string name)
      {
         SqlCommand cmd = (SqlCommand)(c.CreateCommand());
         cmd.CommandText = "select idx from acl_group where name='" + name + "';";
         return cmd.ExecuteScalar();
      }
   }
}
