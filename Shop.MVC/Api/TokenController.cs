using Common.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Http;
using ServiceLayer.Services.Interfaces;
using Shop.DAL;
using Shop.MVC.App_Start;
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

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.Request.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public IHttpActionResult GetToken(string Username,string Password)
        { 
            if (SignInManager.PasswordSignIn(Username, Password, false, false) == SignInStatus.Success)
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
