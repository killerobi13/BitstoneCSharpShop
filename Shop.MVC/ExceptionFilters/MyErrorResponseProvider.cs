using Common.ViewModels;
using Microsoft.Web.Http.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Shop.MVC.ExceptionFilters
{
    public class MyErrorResponseProvider : DefaultErrorResponseProvider
    {
        // note: in Web API the response type is HttpResponseMessage
        public override HttpResponseMessage CreateResponse(ErrorResponseContext context)
        {
            switch (context.ErrorCode)
            {
                case "UnsupportedApiVersion":
                    {
                        return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }

            }

            return base.CreateResponse(context);
        }
    }
}