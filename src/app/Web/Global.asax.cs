using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;
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
                var bootstrapper = new ApplicationBootstrapper();
                var container = bootstrapper.Configure();
                DependencyResolver.SetResolver(new WindsorDependencyResolver(container));
                initialized = true;
            }
        }
    }

    public class WindsorDependencyResolver : IDependencyResolver {
        private readonly WindsorContainer container;

        public WindsorDependencyResolver(WindsorContainer container) {
            this.container = container;
        }

        public object GetService(Type serviceType) {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return container.Kernel.HasComponent(serviceType) ? container.ResolveAll(serviceType).ToEnumerable<object>() : Enumerable.Empty<object>();
        }
    }

    public static class ArrayExtensions {
        public static IEnumerable<T> ToEnumerable<T>(this Array array) {
            return from object item in array select (T)item;
        }
    }
}