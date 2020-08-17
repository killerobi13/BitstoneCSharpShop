using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public Common.ViewModels.Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.ViewModels.Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.Order Insert(Shop.DAL.Entities.Order order)
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.Order Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
