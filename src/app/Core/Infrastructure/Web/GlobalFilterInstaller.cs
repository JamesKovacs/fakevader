using System.Web.Mvc;
using Castle.Core;

namespace FakeVader.Core.Infrastructure.Web {
    public class GlobalFilterInstaller : IStartable {
        public void Start() {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }

        public void Stop() {
        }
    }
}