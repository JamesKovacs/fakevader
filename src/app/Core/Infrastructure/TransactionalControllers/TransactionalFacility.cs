using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace FakeVader.Core.Infrastructure.TransactionalControllers {
    public class TransactionalFacility : AbstractFacility {
        protected override void Init() {
            Kernel.Register(Component.For<TransactionalInterceptor>());
            Kernel.ComponentModelBuilder.AddContributor(new TransactionalInterceptorContributor());
        }
    }
}