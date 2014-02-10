using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Infrastructure.NHibernate.Domain
{
   public class OrderMapping : ClassMap<Order>
   {
      public OrderMapping()
      {
         Id(a_x => a_x.Id);
         Map(a_x => a_x.Name);
         HasMany(a_x => a_x.OrderItems)
            .Cascade.All();
      }
   }
}
