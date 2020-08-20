using System;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Shop.DAL;
using Shop.MVC.Identity;

[assembly: OwinStartup(typeof(Shop.MVC.App_Start.Startup))]

namespace Shop.MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
               new JwtBearerAuthenticationOptions
               {
                   TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidIssuer = "bitshop2021",
                       ValidateLifetime = true,
                   }
               });
        
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/User/Login"),

            });
        }
    }
}
