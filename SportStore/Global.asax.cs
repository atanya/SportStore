using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using SportStore.IoC;

namespace SportStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ConfigureIoC();
        }

        public static IWindsorContainer Container;
        private static void ConfigureIoC()
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }
    }
}