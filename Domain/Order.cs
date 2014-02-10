using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class Order
   {
      #region Fields

      private IList<OrderItem> orderItems;

      #endregion

      public virtual int Id { get; set; }
      public virtual string Name { get; set; }
      public virtual IEnumerable<OrderItem> OrderItems
      {
         get { return orderItems; }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:System.Object"/> class.
      /// </summary>
      public Order()
      {
         orderItems = new List<OrderItem>();
      }

      public virtual void AddOrderItem(OrderItem a_item)
      {
         orderItems.Add(a_item);
      }
   }
}
