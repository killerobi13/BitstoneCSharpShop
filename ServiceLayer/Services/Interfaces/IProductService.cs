using Common.ViewModels;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IProductService
    {
         IEnumerable<Common.ViewModels.Product> GetAll();
         Common.ViewModels.Product GetById(int id);
         int Insert(Common.ViewModels.Product product);
         void Delete(int id);
         void Update(Common.ViewModels.Product product);
    }
}
