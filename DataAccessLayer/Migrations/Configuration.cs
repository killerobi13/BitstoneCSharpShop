namespace DataAccessLayer.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shop.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.DAL.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop.DAL.ShopDbContext context)
        {
            var categories = new List<Category>
            {
            new Category(){ Id=0,Name="IT&C"},
            new Category(){ Id=1,Name="Books"},
            new Category(){ Id=2,Name="Toys"}
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(s));
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product(){ Id=2,
                    //Description="A great product"
                    Name="Lenovo zen3",Category=categories[0],Price = 10 },
                new Product(){ Id=1,//Description="A beautiful product",
                Name="Spartan Toy",Category=categories[2], Price = 20 },
                new Product(){ Id=2,//Description="A wonderful product",
                 Name="The book of books",Category=categories[1], Price = 40 }
            };
            products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();

            var orderItems = new List<OrderItem>()
            {
                new OrderItem() { Id=1, Price=20, Product=products[1], Quantity=2},
                new OrderItem() { Id=2, Price=30, Product=products[2], Quantity=6},
                new OrderItem() { Id=3, Price=15, Product=products[0], Quantity=5}
            };
            orderItems.ForEach(s => context.OrderItems.AddOrUpdate(s));
            context.SaveChanges();

            var orders = new List<Order>()
            {
                new Order() { Id=1,Total=200, OrderItems = orderItems.Take(2).ToList() },
                new Order() { Id=2,Total=150, OrderItems = orderItems.Skip(2).Take(1).ToList() },
                new Order() { Id=3,Total=240, OrderItems = null },
            };
            orders.ForEach(s => context.Orders.AddOrUpdate(s));

            context.SaveChanges();

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(
                  new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("User"));
            roleManager.Create(new IdentityRole("Admin"));

            base.Seed(context);
        }
    }
}
