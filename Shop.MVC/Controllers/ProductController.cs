using Common.Extensions;
using Common.ViewModels;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            return View(productService.GetAll());
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            productService.Insert(product);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }

        public ActionResult Edit(int id)
        {
            ProductEdit pe = new ProductEdit();
            pe.Product = productService.GetById(id);
            pe.Categories = categoryService.GetAll();
            return View(pe);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    productService.Update(p);
                    return RedirectToAction("List");
                }
                catch(DuplicateProductException duplicateProductException)
                {
                    ModelState.AddModelError("Name", duplicateProductException.Message);
                }
               
            }

            ProductEdit pe = new ProductEdit();
            pe.Product = p;
            pe.Categories = categoryService.GetAll();
            return View("Edit",pe);
        
        }

        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            productService.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult Insert()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }
    }
}