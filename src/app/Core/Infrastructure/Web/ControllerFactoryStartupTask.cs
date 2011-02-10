using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Web {
    public class ControllerFactoryStartupTask : IContainerStartupTask {
        public void Execute(IWindsorContainer container) {
            container.Register(Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>());
        }
    }
}