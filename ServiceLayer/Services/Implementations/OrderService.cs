using AutoMapper;
using Common.ViewModels;
using ServiceLayer.Services.Interfaces;
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
        public Common.ViewModels.Order Delete(int id)
        {
            return mapper.Map<Shop.DAL.Entities.Order, Common.ViewModels.Order>(unitOfWork.OrderRepository.Delete(id));
        }

        public IEnumerable<Common.ViewModels.Order> GetAll()
        {
            var orders = unitOfWork.OrderRepository.Get();

            return mapper.Map<IEnumerable<Shop.DAL.Entities.Order>, IEnumerable<Common.ViewModels.Order>>(orders);
        }

        public Common.ViewModels.Order GetById(int id)
        {
            var order = unitOfWork.OrderRepository.GetByID(id);
            return mapper.Map<Shop.DAL.Entities.Order, Common.ViewModels.Order>(order);
        }

        public Order Insert(Common.ViewModels.Order order)
        {
            var retOrder = unitOfWork.OrderRepository.Insert(mapper.Map<Common.ViewModels.Order, Shop.DAL.Entities.Order>(order));

            return mapper.Map<Shop.DAL.Entities.Order, Common.ViewModels.Order>(retOrder);
        }

        public void Update(Order order)
        {
            var dalOrder = mapper.Map<Common.ViewModels.Order, Shop.DAL.Entities.Order>(order);
            unitOfWork.OrderRepository.Update(dalOrder);
        }
    }
}
