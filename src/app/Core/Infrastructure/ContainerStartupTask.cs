using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure {
    public class ContainerStartupTask : IContainerStartupTask {
        public void Execute(IWindsorContainer container) {
            container.Register(Component.For<IWindsorContainer>().Instance(container));
        }
    }
}