using Castle.Facilities.FactorySupport;
using Castle.Facilities.Startable;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FakeVader.Core.Infrastructure.Web.TransactionalControllers;

namespace FakeVader.Core.Infrastructure {
    public class ApplicationBootstrapper {
        public WindsorContainer Configure() {
            var container = new WindsorContainer();
            container.AddFacility<FactorySupportFacility>();
            container.AddFacility<TransactionalFacility>();
            container.AddFacility<StartableFacility>(f => f.DeferredStart());
            container.Install(FromAssembly.This());
            return container;
        }
    }
}