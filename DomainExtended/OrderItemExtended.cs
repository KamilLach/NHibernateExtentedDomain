using System;
using Domain;

namespace DomainExtended
{
   public class OrderItemExtended : OrderItem
   {
      public virtual DateTime DateOfPurchase { get; set; }
   }
}
