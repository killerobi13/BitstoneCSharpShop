using AutoMapper;
using Common.ViewModels;
using ServiceLayer.Services.Interfaces;
using Shop.DAL.Entities;
using Shop.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        Common.ViewModels.Order IOrderService.Insert(IEnumerable<OrderItemAdd> orderItemAdds)
        {
            Shop.DAL.Entities.Order dalOrder = new Shop.DAL.Entities.Order();
            int total = 0;
            dalOrder.OrderItems = new List<Shop.DAL.Entities.OrderItem>();
            Dictionary<int, Shop.DAL.Entities.Product> products = new Dictionary<int, Shop.DAL.Entities.Product>();

            foreach (var orderItem in orderItemAdds)
            {
                try
                {
                    products.Add(orderItem.ProductId, unitOfWork.ProductRepository.GetByID(orderItem.ProductId));
                }catch
                {
                    orderItemAdds = orderItemAdds.Where(t => t.ProductId != orderItem.ProductId);
                }
            }

            foreach (var orderItem in orderItemAdds)
            {
                var product = products[orderItem.ProductId];
                total += product.Price * orderItem.Quantity;
            }

            dalOrder.Total = total;
            dalOrder.PurchaseDate = DateTime.Now;
            unitOfWork.OrderRepository.Insert(dalOrder);


            var orderId = dalOrder.Id;

            foreach (var orderItem in orderItemAdds)
            {
                Shop.DAL.Entities.OrderItem oi = new Shop.DAL.Entities.OrderItem();
                oi.Quantity = orderItem.Quantity;
                oi.ProductId = orderItem.ProductId;
                oi.OrderId = orderId;
                oi.Price = products[orderItem.ProductId].Price;
                
                unitOfWork.OrderItemRepository.Insert(oi);
            }
            unitOfWork.Save();
            return null ;
        }
    }
}
