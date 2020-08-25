using AutoMapper;
using Common.Extensions;
using Common.ViewModels;
using Microsoft.SqlServer.Server;
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
            var product = unitOfWork.ProductRepository.GetFirstOrDefault(filter: q=> q.Id==id, includeProperties: "Category" );
            return mapper.Map<Shop.DAL.Entities.Product, Common.ViewModels.Product>(product);
        }
       
        public int Insert(Common.ViewModels.Product product)
        {
            if (unitOfWork.ProductRepository.GetFirstOrDefault(q => q.Name == product.Name) is null)
            {
                Shop.DAL.Entities.Product dalProduct = mapper.Map<Common.ViewModels.Product, Shop.DAL.Entities.Product>(product);
                var retProduct = unitOfWork.ProductRepository.Insert(dalProduct);
                return retProduct.Id;
            }
            else
            {
                throw new DuplicateProductException();
            }
        }

        public void Delete(int id)
        {
            unitOfWork.ProductRepository.Delete(id);
            unitOfWork.Save();
        }

        public void Update(Common.ViewModels.Product product)
        {
            var dalProduct = mapper.Map<Common.ViewModels.Product, Shop.DAL.Entities.Product>(product);
            unitOfWork.ProductRepository.Update(dalProduct);
            unitOfWork.Save();
        }
    }
}
