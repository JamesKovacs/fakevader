using System.Collections.Generic;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Container {
    public class WindsorDependencyResolver : IDependencyResolver {
        private readonly IWindsorContainer innerContainer;

        public WindsorDependencyResolver(IWindsorContainer windsorContainer) {
            innerContainer = windsorContainer;
        }

        #region IDependencyResolver Members

        public T Resolve<T>() {
            return innerContainer.Resolve<T>();
        }

        public T Resolve<T>(string key) {
            return innerContainer.Resolve<T>(key);
        }

        public T Resolve<T>(object argumentsAsAnonymousType) {
            return innerContainer.Resolve<T>(argumentsAsAnonymousType);
        }

        public T Resolve<T>(string key, object argumentsAsAnonymousType) {
            return innerContainer.Resolve<T>(key, argumentsAsAnonymousType);
        }

        public IEnumerable<T> ResolveAll<T>() {
            foreach(T obj in innerContainer.ResolveAll<T>()) {
                yield return obj;
            }
        }

        #endregion
    }
}