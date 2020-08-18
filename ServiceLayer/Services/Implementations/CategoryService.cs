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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Common.ViewModels.Category Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.ViewModels.Category> GetAll()
        {
            var categories = unitOfWork.CategoryRepository.Get();

            return mapper.Map<IEnumerable<Shop.DAL.Entities.Category>, IEnumerable<Common.ViewModels.Category>>(categories);
        }

        public Common.ViewModels.Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
