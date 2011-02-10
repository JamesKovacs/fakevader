using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Container {
    public class ControllerStartupTask : IContainerStartupTask {
        public void Execute(IWindsorContainer container) {
            container.Register(
                AllTypes.FromAssembly(Assembly.GetExecutingAssembly())
                        .BasedOn<IController>()
                        .Configure(registration => registration.LifeStyle.Transient)
                );
        }
    }
}