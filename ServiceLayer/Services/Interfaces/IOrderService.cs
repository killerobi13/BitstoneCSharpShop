using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Common.ViewModels.Order Insert(IEnumerable<OrderItemAdd> orderItemAdds, string userId);
        IEnumerable<Common.ViewModels.Order> GetAllOrdersOfUser(string userId);
    }
}
