using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace Shop.MVC.Api
{
    [Authorize]
    [Route("prods")]
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
        public IHttpActionResult GetAllProducts()
        {
            return Ok(productService.GetAll());
        }

 

    }
}
