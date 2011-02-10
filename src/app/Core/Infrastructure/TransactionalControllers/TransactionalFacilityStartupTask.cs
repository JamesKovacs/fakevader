using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.TransactionalControllers {
    public class TransactionalFacilityStartupTask : IFacilityStartupTask {
        public void Execute(IWindsorContainer container) {
            container.AddFacility("transactional", new TransactionalFacility());
        }
    }
}