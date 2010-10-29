using System.Web.Mvc;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Web {
    public class ControllerFactoryRegistration : IContainerStartupTask {
        public void Execute(IWindsorContainer container) {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}