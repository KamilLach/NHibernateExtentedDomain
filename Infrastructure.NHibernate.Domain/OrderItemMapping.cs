using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Infrastructure.NHibernate.Domain
{
   public class OrderItemMapping : ClassMap<OrderItem>
   {
      public OrderItemMapping()
      {
         Id(a_x => a_x.Id);
         Map(a_x => a_x.Quantity);
         DiscriminateSubClassesOnColumn("type");
      }
   }
}
