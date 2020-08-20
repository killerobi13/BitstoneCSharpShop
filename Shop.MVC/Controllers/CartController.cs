using Common.ViewModels;
using Newtonsoft.Json;
using ServiceLayer.Services;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Shop.MVC.Controllers
{
    public class CartController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public CartController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetCart()
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach(var t in Session.Keys)
            {
                int i = Int32.Parse(t.ToString());
                var product = productService.GetById(i);

                if (product != null)
                {
                    CartItem cartItem = new CartItem();
                    cartItem.Name = product.Name;
                    cartItem.SingleUnitPrice = product.Price;
                    cartItem.Quantity = (int)Session[t.ToString()];
                    cartItem.ProductId = product.Id;
                    cartItems.Add(cartItem);
                }

            }
            return View(cartItems);
        }

        [HttpPost]
        public ActionResult AddProduct(int id)
        {
            string index = id.ToString();
            //add the product id and product default quantity
            if (Session[index] == null)
            {
                Session.Add(index, 1);
            }
            else
            {
                if((int)Session[index] <=99)
                Session[index] = ((int)Session[index]) + 1;
            }
            return Json(new { prod_id = id, quantity = Session[index] },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SubProduct(int id)
        {
            string index = id.ToString();

            if (Session[index] == null)
            {
                return Json(new {error=true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if ((int)Session[index] > 1)
                    Session[index] = ((int)Session[index]) -1;
            }
            return Json(new { error = false, prod_id = id, quantity = Session[index] }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            string index = id.ToString();

            if (Session[index] == null)
            {
                return Json(new { error = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session.Remove(id.ToString());
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}