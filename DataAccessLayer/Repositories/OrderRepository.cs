using Shop.DAL;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}