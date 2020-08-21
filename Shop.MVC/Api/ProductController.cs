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
        public IHttpActionResult GetAllProducts()
        {
            return Ok(productService.GetAll());
        }
        [Authorize]
        [HttpGet]
        [ApiVersion("1.0")]
        public IHttpActionResult GetProductById(int id)
        {
            return Ok(productService.GetById(id));
        }
        [Authorize]
        [HttpPost]
        [ApiVersion("1.0")]
        public IHttpActionResult InsertProduct(Common.ViewModels.Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Insert(product); 
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpDelete]
        [ApiVersion("1.0")]
        public IHttpActionResult DeleteProduct(int id)
        {
            if(productService.GetById(id) !=null)
            {
                return NotFound();
            }
            else
            {
                productService.Delete(id);
                return Ok();
            }
            
        }

        [Authorize]
        [HttpPut]
        [ApiVersion("1.0")]
        public IHttpActionResult UpdateProduct(Common.ViewModels.Product product)
        {
            if(ModelState.IsValid)
            {
                productService.Update(product);
                return BadRequest();
            }
            else
            {
                return Ok();
            }
            
        }

    }
}
