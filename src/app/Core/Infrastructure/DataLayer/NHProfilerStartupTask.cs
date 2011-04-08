using Castle.Core;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace FakeVader.Core.Infrastructure.DataLayer {
    public class NHProfilerStartupTask : IStartable {
        public void Start() {
            NHibernateProfiler.Initialize();
        }

        public void Stop() {
        }
    }
}