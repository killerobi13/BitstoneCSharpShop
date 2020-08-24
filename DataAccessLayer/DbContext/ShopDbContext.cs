using Microsoft.AspNet.Identity.EntityFramework;
using Shop.DAL.Entities;
using Shop.MVC.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.DAL
{
    public class ShopDbContext : IdentityDbContext<AppUser>
    {
        public ShopDbContext() : base("ShopContext")
        {

        }
        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}