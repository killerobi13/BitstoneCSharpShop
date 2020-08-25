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

        public IEnumerable<Common.ViewModels.Order> GetAllOrdersOfUser(string userId)
        {            
            return mapper.Map<IEnumerable<Shop.DAL.Entities.Order>, IEnumerable<Common.ViewModels.Order>>
                (unitOfWork.OrderRepository.Get(t => t.UserId == userId, includeProperties: "OrderItems"));
        }

        Common.ViewModels.Order IOrderService.Insert(IEnumerable<OrderItemAdd> orderItemAdds, string userId)
        {
            Shop.DAL.Entities.Order dalOrder = new Shop.DAL.Entities.Order();
            dalOrder.OrderItems = new List<Shop.DAL.Entities.OrderItem>();

            dalOrder.PurchaseDate = DateTime.Now;
            dalOrder.UserId = userId;

            foreach (var orderItem in orderItemAdds)
            {
                if(!dalOrder.OrderItems.Any(t=>t.ProductId==orderItem.ProductId))
                {
                    var product = unitOfWork.ProductRepository.GetByID(orderItem.ProductId);

                    dalOrder.Total += product.Price * orderItem.Quantity; 

                    var orderItemDal = new Shop.DAL.Entities.OrderItem();
                    orderItemDal.Quantity = orderItem.Quantity;
                    orderItemDal.ProductId = orderItem.ProductId;
                    orderItemDal.Price = product.Price;
                    dalOrder.OrderItems.Add(orderItemDal);

                }
            }

            unitOfWork.OrderRepository.Insert(dalOrder);
            unitOfWork.Save();
            return mapper.Map<Shop.DAL.Entities.Order, Common.ViewModels.Order>(dalOrder);
        }
    }
}
