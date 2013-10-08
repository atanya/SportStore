using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DomainModel.Interfaces;
using DomainModel.Repositories;

namespace SportStore.IoC
{
    public class WindsorControllerFactory: DefaultControllerFactory
    {
        private const string ConnectionString = "ConnectionString";

        private static IWindsorContainer container { get; set; }

        public WindsorControllerFactory()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .Configure(c => c.LifestylePerWebRequest()));

            var cs = ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
            container.Register(
                Component.For<IProductRepository>()
                         .ImplementedBy<ProductRepository>()
                         .DependsOn(new {connectionString = cs}).LifestylePerWebRequest());
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return (IController) container.Resolve(controllerType);
        }
    }
}