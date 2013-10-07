using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SportStore.IoC
{
    public class WindsorControllerFactory: DefaultControllerFactory
    {
        private static IWindsorContainer container { get; set; }

        public WindsorControllerFactory()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .Configure(c => c.LifestyleTransient()));
                 //Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof (IController).IsAssignableFrom(t))
                 //.Configure(c => c.LifestyleTransient()));
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return (IController) container.Resolve(controllerType);
        }
    }
}