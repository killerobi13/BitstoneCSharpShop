using Common.ViewModels;
using Microsoft.AspNet.Identity;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.MVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        public ActionResult Create(IEnumerable<OrderItemAdd> orderItemAdds)
        {
            var order = orderService.Insert(orderItemAdds,User.Identity.GetUserId());
            return PartialView(order);
        }

        public ActionResult Display(int id)
        {
            return View();
        }
    }
}