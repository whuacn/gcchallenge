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
   };
}

