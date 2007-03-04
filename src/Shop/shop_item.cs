using System;
namespace Shop {


   partial class shop_item
   {

      partial class shop_itemDataTable
      {
      }
   }
}

namespace Shop.shop_itemTableAdapters
{
   public partial class shop_itemTableAdapter
   {
      public System.Data.SqlClient.SqlConnection SqlConnection
      {
         get { return this.Connection; }
         set { this.Connection = value; }
      }
      
      public static string get_item_name(System.Data.SqlClient.SqlConnection SqlConnection,int idx)
      {
         System.Data.SqlClient.SqlCommand cmd=SqlConnection.CreateCommand();
         cmd.CommandText=String.Format("select name from shop_item where idx={0};",idx);
         
         return cmd.ExecuteScalar().ToString();
      }
   };
}

