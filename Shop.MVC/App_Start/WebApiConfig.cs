using AutoMapper;
using Common.ViewModels;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Web.Http.Routing;
using Microsoft.Web.Http.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServiceLayer.Services;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using Shop.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using Unity.AspNet.Mvc;

namespace Shop.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            //configure unity for web api
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ITokenGenerationService, TokenGenerationService>();
            container.RegisterType<ICategoryService, CategoryService>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Shop.DAL.Entities.Product, Common.ViewModels.Product>()
                .ForMember(d => d.Category, d => d.MapFrom(x => x.Category.Name));
                cfg.CreateMap<Category, Common.ViewModels.Category>();
                cfg.CreateMap<Common.ViewModels.Product, Product>().ForMember(d => d.Category, opt => opt.Ignore());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            //configure json
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            config.AddApiVersioning(t => t.ReportApiVersions = true);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{apiVersion}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { apiVersion = new ApiVersionRouteConstraint() }

            );
        }
    }
}
