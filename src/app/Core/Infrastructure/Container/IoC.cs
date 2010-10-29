using System.Collections.Generic;

namespace FakeVader.Core.Infrastructure.Container {
    public static class IoC {
        private static IDependencyResolver resolver;

        public static void Initialize(IDependencyResolver dependencyResolver) {
            resolver = dependencyResolver;
        }

        public static T Resolve<T>() {
            return resolver.Resolve<T>();
        }

        public static T Resolve<T>(string key) {
            return resolver.Resolve<T>(key);
        }

        public static T Resolve<T>(object argumentsAsAnonymousType) {
            return resolver.Resolve<T>(argumentsAsAnonymousType);
        }

        public static T Resolve<T>(string key, object argumentsAsAnonymousType) {
            return resolver.Resolve<T>(key, argumentsAsAnonymousType);
        }

        public static IEnumerable<T> ResolveAll<T>() {
            return resolver.ResolveAll<T>();
        }
    }
}