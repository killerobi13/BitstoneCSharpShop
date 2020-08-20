using Common.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shop.DAL;
using Shop.MVC.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Shop.MVC.Controllers
{
    public class UserController : Controller
    {  
        public UserController()
        {

        }

        [HttpPost]
        public ActionResult RegisterUser(Register register)
        {
            var userStore = new UserStore<IdentityUser>(new ShopDbContext());
            var manager = new UserManager<IdentityUser>(userStore);
         
            var user = new IdentityUser() { UserName= register.Username };
            IdentityResult result = manager.Create(user, register.Password);

            if (result.Succeeded)
            {
                return Content("good");
            }
            else
            {
                return Content("bad");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(Register loginModel)
        {
            var userStore = new UserStore<IdentityUser>(new ShopDbContext());
            var manager = new UserManager<IdentityUser>(userStore);

            var signInManager = new SignInManager<IdentityUser,string>(manager, this.Request.GetOwinContext().Authentication);

            if (signInManager.PasswordSignIn(loginModel.Username, loginModel.Password, false, false) == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("invalidCredentials", "The credentials you have entered are invalid");
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var authenticationManager = this.Request.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Product");
        }

    }
}