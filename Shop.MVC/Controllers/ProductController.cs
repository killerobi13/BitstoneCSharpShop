﻿using Common.Extensions;
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

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    productService.Insert(product);
                }
                catch (DuplicateProductException duplicateProductException)
                {
                    ModelState.AddModelError("Name", duplicateProductException.Message);
                }
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Insert");
            }

        }
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id)
        {
            ProductEdit pe = new ProductEdit();
            pe.Product = productService.GetById(id);
            pe.Categories = categoryService.GetAll();
            return View(pe);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public ActionResult EditProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                productService.Update(newProduct);
                return RedirectToAction("List");
            }
            else
            {
                ProductEdit editedProduct = new ProductEdit();
                editedProduct.Product = newProduct;
                editedProduct.Categories = categoryService.GetAll();
                return View("Edit", editedProduct);

            }

        
        }
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            productService.Delete(id);
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Insert()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }
    }
}