using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Common.ViewModels.Order> GetAll();
        Common.ViewModels.Order GetById(int id);
        Common.ViewModels.Order Insert(Shop.DAL.Entities.Order order);
        Common.ViewModels.Order Delete(int id);
        Common.ViewModels.Order Update(int id);
    }
}
