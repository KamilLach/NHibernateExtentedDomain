using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class OrderItem
   {
      public virtual int Id { get; set; }
      public virtual int Quantity { get; set; }
   }
}
