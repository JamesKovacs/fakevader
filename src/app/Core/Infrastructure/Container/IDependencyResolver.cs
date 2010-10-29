using System.Collections.Generic;

namespace FakeVader.Core.Infrastructure.Container {
    public interface IDependencyResolver {
        T Resolve<T>();
        T Resolve<T>(string key);
        T Resolve<T>(object argumentsAsAnonymousType);
        T Resolve<T>(string key, object argumentsAsAnonymousType);
        IEnumerable<T> ResolveAll<T>();
    }
}