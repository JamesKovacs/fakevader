using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Container {
    public class StartupTaskInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                AllTypes.FromThisAssembly()
                        .BasedOn<IStartable>()
                        .WithService.FirstInterface()
                );
        }
    }
}