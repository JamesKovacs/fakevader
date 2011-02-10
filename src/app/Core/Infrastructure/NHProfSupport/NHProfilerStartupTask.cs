using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace FakeVader.Core.Infrastructure.NHProfSupport {
    public class NHProfilerStartupTask : IStartupTask {
        public void Execute() {
            NHibernateProfiler.Initialize();
        }
    }
}