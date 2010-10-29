using System.Web;
using FakeVader.Core.Infrastructure;

namespace FakeVader.Web {
    public class MvcApplication : HttpApplication {
        public override void Init() {
            base.Init();
            new ApplicationBootstrapper().Configure();
        }
    }
}