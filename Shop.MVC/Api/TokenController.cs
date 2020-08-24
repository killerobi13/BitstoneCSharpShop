using Common.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Http;
using ServiceLayer.Services.Interfaces;
using Shop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Shop.MVC.Api
{
    public class TokenController : ApiController
    {
        private ITokenGenerationService generationService;
        public TokenController(ITokenGenerationService tokenGenerationService)
        {
            generationService = tokenGenerationService;
        }
        [HttpGet]
        [ApiVersion("1.0")]
        public IHttpActionResult GetToken(string Username,string Password)
        {
            var userStore = new UserStore<IdentityUser>(new ShopDbContext());
            var manager = new UserManager<IdentityUser>(userStore);

            var signInManager = new SignInManager<IdentityUser, string>(manager, HttpContext.Current.Request.GetOwinContext().Authentication);

            if (signInManager.PasswordSignIn(Username, Password, false, false) == SignInStatus.Success)
            {
                return Ok(
                    generationService.GenerateToken(Username, 120)
                    );
            }
            else
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
        }


    }
}
