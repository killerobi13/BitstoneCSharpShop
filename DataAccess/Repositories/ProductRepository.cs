using Shop.DAL;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}