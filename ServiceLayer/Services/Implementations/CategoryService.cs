using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        public Common.ViewModels.Category Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.ViewModels.Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.Category Insert(Shop.DAL.Entities.Category category)
        {
            throw new NotImplementedException();
        }

        public Common.ViewModels.Category Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
