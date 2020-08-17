using AutoMapper;
using Common.ViewModels;
using Shop.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IEnumerable<Product> GetAll()
        {
            var products = unitOfWork.ProductRepository.Get();

            return mapper.Map<IEnumerable<Shop.DAL.Entities.Product>, IEnumerable<Common.ViewModels.Product>>(products);
        }

        public Product GetById(int id)
        {
            var product = unitOfWork.ProductRepository.GetByID(id);
            return mapper.Map<Shop.DAL.Entities.Product, Common.ViewModels.Product>(product);
        }

        public Product Insert(Shop.DAL.Entities.Product product)
        {
            return mapper.Map<Shop.DAL.Entities.Product, Common.ViewModels.Product>(unitOfWork.ProductRepository.Insert(product));
        }

        public Product Delete(int id)
        {
            return mapper.Map<Shop.DAL.Entities.Product, Common.ViewModels.Product>(unitOfWork.ProductRepository.Insert(product));
        }

        public Product Update(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
