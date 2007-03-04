namespace Shop {


   partial class shop_sold_item
   {

      partial class shop_sold_itemDataTable
      {
      }
      public partial class shop_sold_itemRow
      {
         public bool is_expired()
         {
            if (this.expires_at == this.sold_at)
            {
               return false;
            }

            if (this.expires_at < System.DateTime.Now)
            {
               if (this.sold_count!=0)
               {
                  return false;
               }
               return true;
            }
            return false;
         }

         public bool is_depleted()
         {
            if (this.sold_count == this.use_count && this.sold_count!=0)
            {
               return true;
            }
            return false;

         }
      }
   }
}
namespace Shop.shop_sold_itemTableAdapters
{
   public partial class shop_sold_itemTableAdapter
   {
      public System.Data.SqlClient.SqlConnection SqlConnection
      {
         get { return this.Connection; }
         set { this.Connection = value; }
      }
   };
}

