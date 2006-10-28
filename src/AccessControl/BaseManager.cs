using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace AccessControl
{
   public class BaseManager
   {
      
      public BaseManager(IDbConnection connection)
      {
         connection_ = connection;
      }
      
      public IDbConnection Connection
      {
         get
         {
            return connection_;
         }
      }

      protected IDbConnection connection_;
   }
}
