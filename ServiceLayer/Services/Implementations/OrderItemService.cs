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
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public Common.ViewModels.OrderItem Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.ViewModels.OrderItem> GetAll()
        {
            var orderItems = unitOfWork.OrderItemRepository.Get();

            return mapper.Map<IEnumerable<Shop.DAL.Entities.OrderItem>, IEnumerable<Common.ViewModels.OrderItem>>(orderItems);
        }

        public Common.ViewModels.OrderItem GetById(int id)
        {
            return mapper.Map<Shop.DAL.Entities.OrderItem, Common.ViewModels.OrderItem>(unitOfWork.OrderItemRepository.GetByID(id));
        }


        public OrderItem Insert(OrderItem orderItem)
        {
            var retOrderItem = unitOfWork.OrderItemRepository.Insert(mapper.Map<Common.ViewModels.OrderItem, Shop.DAL.Entities.OrderItem>(orderItem));

            return mapper.Map<Shop.DAL.Entities.OrderItem, Common.ViewModels.OrderItem>(retOrderItem);
        }

        public void Update(OrderItem orderItem)
        {
            var dalOrderItem = mapper.Map<Common.ViewModels.OrderItem, Shop.DAL.Entities.OrderItem>(orderItem);
            unitOfWork.OrderItemRepository.Update(dalOrderItem);
        }
    }
}
