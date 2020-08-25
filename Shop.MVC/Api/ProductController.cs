using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Security.Claims;
using Microsoft.Web.Http;
using Shop.MVC.Extensions;
using Common.ViewModels;
using Common.Extensions;
using Shop.MVC.ExceptionFilters;

namespace Shop.MVC.Api
{
    public class ProductController : ApiController
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [Authorize]
        [HttpGet]
        [ApiVersion("1.0")]
        public object GetAllProducts()
        {
            return new GenericResponse<IEnumerable<Product>>(productService.GetAll());
        }

        [Authorize]
        [HttpGet]
        [ApiVersion("1.0")]
        public object GetProductById(int id)
        {
            var product = productService.GetById(id);
            if (product != null)
            {
                return new GenericResponse<Product>(product);
            }
            else
            {
                return new GenericResponse<Product>("Product not found");
            }
        }

        [Authorize]
        [HttpPost]
        [ApiVersion("1.0")]
        public object InsertProduct(Common.ViewModels.Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var insertedProductId = productService.Insert(product);
                    return new GenericResponse<int>(insertedProductId);
                }
                catch (DuplicateProductException dup)
                {
                    return new GenericResponse<Product>(dup.Message);
                }
            }
            else
            {
                return new GenericResponse<Product>(ModelState.GenerateValidations());
            }
        }
        [Authorize]
        [HttpDelete]
        [ApiVersion("1.0")]
        public object DeleteProduct(int id)
        {
            if(productService.GetById(id) !=null)
            {
                productService.Delete(id);
                return new GenericResponse<Product>();
            }
            else
            {
                return new GenericResponse<Product>("Product not found");
            }

        }

        [Authorize]
        [HttpPut]
        [ApiVersion("1.0")]
        public object UpdateProduct(Common.ViewModels.Product product)
        {
            if(ModelState.IsValid)
            {   
                productService.Update(product);
                return new GenericResponse<Product>(product);
            }
            else
            {
                return new GenericResponse<string>(ModelState.GenerateValidations());
            }
            
        }

    }
}
