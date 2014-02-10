using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using DomainExtended;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.NHibernate.DomainExtented;
using NUnit.Framework;
using NHibernate.Tool.hbm2ddl;
using Infrastructure.NHibernate.Domain;

namespace ExtensibleDomainModel
{
   public class CoreTests
   {
      [Test]
      public void create_base_db()
      {
         var factory = Fluently.Configure()
               .Database(MsSqlConfiguration
                            .MsSql2008
                            .ShowSql()
                            .ConnectionString(a_builder => a_builder.FromConnectionStringWithKey("DefaultSimpleConnection"))
                            )
                                    .ExposeConfiguration(a_configuration =>
                                       new SchemaExport(a_configuration).Create(true, true))
               .Mappings(a_configuration => a_configuration
                                               .FluentMappings
                                               .AddFromAssemblyOf<OrderMapping>())
               .BuildSessionFactory();

         factory.OpenSession();
      }

      [Test]
      public void create_extended_db()
      {
         var factory = Fluently.Configure()
            .Database(MsSqlConfiguration
                         .MsSql2008
                         .ShowSql()
                         .ConnectionString(a_builder => a_builder.FromConnectionStringWithKey("DefaultExtendedConnection"))
                         )
                                 .ExposeConfiguration(a_configuration =>
                                    new SchemaExport(a_configuration).Create(true, true))
            .Mappings(a_configuration => a_configuration
                                            .FluentMappings
                                            .AddFromAssemblyOf<OrderMapping>()
                                            .AddFromAssemblyOf<OrderItemExtendedMapping>())
            .BuildSessionFactory();

         var session = factory.OpenSession();
         Order order = new Order();
         order.AddOrderItem(new OrderItemExtended
         {
            DateOfPurchase = DateTime.Now,
            Quantity = 10
         });

         session.Save(order);
         session.Flush();

         // Pobranie
         var recived = session.Get<Order>(order.Id);
      }

      [Test]
      public void order_add_test_shoud_add()
      {
         Order order = new Order();
         order.AddOrderItem(new OrderItemExtended
            {
               DateOfPurchase = DateTime.Now,
               Quantity = 10
            });
      }
   }
}
