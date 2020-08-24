using Common.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Shop.DAL;
using Shop.MVC.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shop.MVC.Controllers
{
    //public class ApplicationSignInManager : SignInManager<AppUser, string>
    //{
    //    public ApplicationSignInManager(UserManager<AppUser> userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }

    //    public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
    //    {
    //        return user.GenerateUserIdentityAsync((UserManager<AppUser>)UserManager);
    //    }

    //    public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
    //    {
    //        return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
    //    }
    //}

    public class UserController : Controller
    {  
        public UserController()
        {

        }

        [HttpPost]
        public ActionResult RegisterUser(Login register)
        {
            if(ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new ShopDbContext());
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = register.Username };
                IdentityResult result = manager.Create(user, register.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return View("Register");
                }

            }
            return View("Register");

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

        [HttpGet]
        public ActionResult Logout()
        {
            var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            AuthenticationManager.SignOut();
            return RedirectToAction("Index","Product");
        }

        [HttpPost]
        public ActionResult LoginUser(Login loginModel)
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



    }
}