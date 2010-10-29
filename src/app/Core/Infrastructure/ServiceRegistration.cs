using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure {
    public class ServiceRegistration : IContainerStartupTask {
        public void Execute(IWindsorContainer container) {
            container.Register(
                AllTypes.FromAssembly(Assembly.GetExecutingAssembly())
                        .Where(x => x.Namespace.StartsWith("FakeVader.Core.Services"))
                        .WithService.FirstInterface()
                );
        }
    }
}