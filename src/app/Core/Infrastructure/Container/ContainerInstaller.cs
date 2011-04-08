using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Container {
    public class ContainerInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(Component.For<IWindsorContainer>().Instance(container));
        }
    }
}