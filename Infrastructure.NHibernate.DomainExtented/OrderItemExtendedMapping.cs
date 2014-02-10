using DomainExtended;
using FluentNHibernate.Mapping;
using Infrastructure.NHibernate.Domain;

namespace Infrastructure.NHibernate.DomainExtented
{
   public class OrderItemExtendedMapping : SubclassMap<OrderItemExtended>
   {
      public OrderItemExtendedMapping()
      {
         Map(a_x => a_x.DateOfPurchase);
         DiscriminatorValue("Extended");
      }
   }
}
