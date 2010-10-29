using Castle.MicroKernel.Facilities;

namespace FakeVader.Core.Infrastructure.NHibernateSupport {
    public class TransactionalFacility : AbstractFacility {
        protected override void Init() {
            Kernel.AddComponent<TransactionalInterceptor>();
            Kernel.ComponentModelBuilder.AddContributor(new TransactionalInterceptorContributor());
        }
    }
}