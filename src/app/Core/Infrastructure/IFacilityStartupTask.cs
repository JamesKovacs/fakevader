using Castle.Windsor;

namespace FakeVader.Core.Infrastructure {
    public interface IFacilityStartupTask {
        void Execute(IWindsorContainer container);
    }
}