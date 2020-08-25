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
        private const string CART_KEY = "CART_PRODUCTS";
        private IProductService productService;


        public CartController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetCart()
        {
            if (Session[CART_KEY] == null)
            {
                Session[CART_KEY] = new List<OrderItemAdd>();
            }

            var cart = (List<OrderItemAdd>)Session[CART_KEY];
            List<CartItem> cartItems = new List<CartItem>();

            foreach(var existingCartItem in cart)
            {

                var product = productService.GetById(existingCartItem.ProductId);

                if (product != null)
                {
                    CartItem cartItem = new CartItem();
                    cartItem.Name = product.Name;
                    cartItem.SingleUnitPrice = product.Price;
                    cartItem.Quantity = existingCartItem.Quantity;
                    cartItem.ProductId = product.Id;
                    cartItems.Add(cartItem);
                }

            }
            return View(cartItems);
        }

        [HttpPost]
        public ActionResult AddProduct(int id)
        {
            if (Session[CART_KEY] == null)
            {
                Session[CART_KEY] = new List<OrderItemAdd>();
            }

            var cart = (List<OrderItemAdd>)Session[CART_KEY];

            if (cart.Any(t=>t.ProductId==id))
            {
                var orderItemAdd = cart.FirstOrDefault(t => t.ProductId == id);
                orderItemAdd.Quantity++;
            }
            else
            {
                cart.Add(new OrderItemAdd() { ProductId = id, Quantity = 1 });
            }

            return Json(new { prod_id = id, quantity = cart.First(t=>t.ProductId==id).Quantity });
        }
        [HttpPost]
        public ActionResult SubProduct(int id)
        {
            var cart = (List<OrderItemAdd>)Session[CART_KEY];

            if (cart.FirstOrDefault(t => t.ProductId == id) is null)
            {
                return Json(new {error=true });
            }
            else
            {
                var orderItemAdd = cart.FirstOrDefault(t => t.ProductId == id);


                if (orderItemAdd.Quantity > 1)
                    orderItemAdd.Quantity--;
            }
            return Json(new { error = false, prod_id = id, quantity = cart.First(t => t.ProductId == id).Quantity });
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var cart = (List<OrderItemAdd>)Session[CART_KEY];

            if (cart[id] == null)
            {
                return Json(new { error = true });
            }
            else
            {
                cart.RemoveAt(id);
                return Json(new { error = false });
            }
        }
    }
}