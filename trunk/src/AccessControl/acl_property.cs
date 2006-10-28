using System;
using System.Data.SqlClient;
using System.Data;

namespace AccessControl {


   partial class acl_property
   {
      public static void can_set_name(IDbConnection c,int idx,string new_name)
      {
         Object o_idx=get_property_idx_by_name(c,new_name);
         if(o_idx!=null && !o_idx.Equals(idx))
         {
            throw new System.Exception("Such property already exists: "+new_name);
         }
      }
      
      static Object get_property_idx_by_name(IDbConnection c,string name)
      {
         SqlCommand cmd=(SqlCommand )(c.CreateCommand());
         cmd.CommandText="select idx from acl_property where name='"+name+"';";
         return cmd.ExecuteScalar();
      }
      
      partial class acl_propertyDataTable
      {
         
      }
   }
}
