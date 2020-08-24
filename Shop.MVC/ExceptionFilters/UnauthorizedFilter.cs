using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Shop.MVC.ExceptionFilters
{
    public class Auth : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response =
            actionContext.ControllerContext.Request.CreateResponse(
                                    HttpStatusCode.Unauthorized,
                                    new GenericResponse<string>("You are not allowed request on this endpoint."));
        }
        
    }
}