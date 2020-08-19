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
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public ActionResult Create(IEnumerable<OrderItemAdd> orderItemAdds)
        {
            orderService.Insert(orderItemAdds);
            return Json(new { error=false});
        }

        public ActionResult Display(int id)
        {
            return View();
        }
    }
}