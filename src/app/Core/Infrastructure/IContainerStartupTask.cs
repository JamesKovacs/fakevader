using Castle.Windsor;

namespace FakeVader.Core.Infrastructure {
    public interface IContainerStartupTask {
        void Execute(IWindsorContainer container);
    }
}