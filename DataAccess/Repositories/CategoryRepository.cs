using Shop.DAL;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}