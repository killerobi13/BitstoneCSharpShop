using Shop.DAL;
using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.UnitsOfWork
{
    public class UnitOfWork : IDisposable, Shop.UnitsOfWork.IUnitOfWork
    {
        private ShopDbContext context = new ShopDbContext();
        private CategoryRepository categoryRepository;
        private OrderRepository orderRepository;
        private OrderItemRepository orderItemRepository;
        private ProductRepository productRepository;
        private bool disposed = false;


        public CategoryRepository CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {

                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(context);
                }
                return orderRepository;
            }
        }

        public OrderItemRepository OrderItemRepository
        {
            get
            {
                if (this.orderItemRepository == null)
                {
                    this.orderItemRepository = new OrderItemRepository(context);
                }
                return orderItemRepository;
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}