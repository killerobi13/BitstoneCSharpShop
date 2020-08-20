using AutoMapper;
using ServiceLayer.Services;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using Shop.DAL.Entities;
using Shop.UnitsOfWork;
using System;

using Unity;

namespace Shop.MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
           
            container.RegisterType<ICategoryService, CategoryService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, Common.ViewModels.Product>()
                .ForMember(d => d.Category, d => d.MapFrom(x =>x.Category.Name));
                cfg.CreateMap<Category, Common.ViewModels.Category>();
                cfg.CreateMap<Common.ViewModels.Product,Product>().ForMember(d => d.Category, opt => opt.Ignore());
            });

            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);
        }
    }
}