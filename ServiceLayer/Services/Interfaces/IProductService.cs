﻿using Common.ViewModels;
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
         Common.ViewModels.Product Insert(Common.ViewModels.Product product);
         Common.ViewModels.Product Delete(int id);
         void Update(Common.ViewModels.Product product);
    }
}
