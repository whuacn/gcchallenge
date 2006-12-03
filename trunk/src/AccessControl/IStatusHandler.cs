using System;
using System.Collections.Generic;
using System.Text;

namespace AccessControl
{
   public interface IStatusHandler
   {
      void on_logon();
      bool on_logof();
   }
}
