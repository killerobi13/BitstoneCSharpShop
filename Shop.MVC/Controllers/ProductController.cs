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

        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }

        public ActionResult Edit(int id)
        {
            return View(productService.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }

        public ActionResult Insert()
        {
            return View(categoryService.GetAll());
        }


    }
}