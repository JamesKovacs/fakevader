using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Services {
    public class ServicesInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                AllTypes.FromThisAssembly()
                        .Where(x => x.Namespace.StartsWith("FakeVader.Core.Services"))
                        .WithService.DefaultInterface()
                );
        }
    }
}