using System;
using System.Linq;

namespace FakeVader.Core.Extensions {
    public static class TypeExtensions {
        public static bool Implements<T>(this Type service) {
            return service.GetInterfaces().Contains(typeof(T));
        }
    }
}