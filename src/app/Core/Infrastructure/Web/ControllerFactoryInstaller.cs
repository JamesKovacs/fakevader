using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Web {
    public class ControllerFactoryInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>());
        }
    }
}