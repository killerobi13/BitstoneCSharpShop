using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        public Common.ViewModels.OrderItem Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.ViewModels.OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.OrderItem Insert(Shop.DAL.Entities.OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.OrderItem Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
