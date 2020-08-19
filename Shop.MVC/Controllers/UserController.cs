using Common.ViewModels;
using DataAccessLayer.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shop.DAL;
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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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
            var result = SignInManager.PasswordSignIn(loginModel.Username, loginModel.Password, true, false);

            if (result == SignInStatus.Success)
                return Content("good");
            else
                return Content("false");
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