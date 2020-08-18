using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderItemService
    {
        IEnumerable<Common.ViewModels.OrderItem> GetAll();
        Common.ViewModels.OrderItem GetById(int id);
        Common.ViewModels.OrderItem Insert(Common.ViewModels.OrderItem orderItem);
        Common.ViewModels.OrderItem Delete(int id);
        void Update(Common.ViewModels.OrderItem orderItem);
    }
}
