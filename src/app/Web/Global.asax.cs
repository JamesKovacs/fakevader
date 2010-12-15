using System.Web;
using FakeVader.Core.Infrastructure;

namespace FakeVader.Web {
    public class MvcApplication : HttpApplication {
        private static bool initialized;
        private static readonly object initializationLock = new object();

        public override void Init() {
            base.Init();
            if(initialized) {
                return;
            }
            lock(initializationLock) {
                if(initialized) {
                    return;
                }
                new ApplicationBootstrapper().Configure();
                initialized = true;
            }
        }
    }
}