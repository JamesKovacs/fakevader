using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace FakeVader.Core.Infrastructure.NHProfiler {
    public class NHProfilerRegistration : IStartupTask {
        public void Execute() {
            NHibernateProfiler.Initialize();
        }
    }
}