using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Common.ViewModels.Category> GetAll();
        Common.ViewModels.Category GetById(int id);
        Common.ViewModels.Category Insert(Shop.DAL.Entities.Category category);
        Common.ViewModels.Category Delete(int id);
        Common.ViewModels.Category Update(int id);
    }
}
