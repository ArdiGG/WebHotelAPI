using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyHotel.BLL.Infracstructure;
using MyHotel.DAL.EF;
using MyHotelCF.APi.Utils;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi.Filter;

namespace MyHotelCF.APi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            NinjectModule dependencyModule = new DependencyModule("MyHotelModel");
            NinjectModule guestModule = new GuestModule();
            NinjectModule roomModule = new RoomModule();
            NinjectModule bookingModule = new BookingModule();
            NinjectModule roomCategoryModule = new RoomCategoryModule();
            var kernel = new StandardKernel(dependencyModule,guestModule,roomModule,bookingModule,roomCategoryModule);

            kernel.Bind<DefaultFilterProviders>().ToSelf()
                .WithConstructorArgument(GlobalConfiguration.Configuration.Services.GetFilterProviders());

            kernel.Bind<DefaultModelValidatorProviders>().ToConstant(
                new DefaultModelValidatorProviders(
                    GlobalConfiguration.Configuration.Services.GetModelValidatorProviders()));
            GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);
        }
    }
}
