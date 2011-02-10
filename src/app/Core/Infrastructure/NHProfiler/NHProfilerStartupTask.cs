using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace FakeVader.Core.Infrastructure.NHProfiler {
    public class NHProfilerStartupTask : IStartupTask {
        public void Execute() {
            NHibernateProfiler.Initialize();
        }
    }
}