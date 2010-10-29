using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Rhino.Mocks;

namespace FakeVader.Tests {
    [TestFixture]
    public abstract class ConcernsFor<T> {
        protected T Sut;

        [TestFixtureSetUp]
        public void FixtureSetup() {
            Context();
            Sut = CreateSUT();
            Because();
        }

        protected abstract void Context();
        protected abstract T CreateSUT();
        protected abstract void Because();

        protected TMock Dependency<TMock>() where TMock : class {
            var type = typeof(TMock);
            if(type.IsClass) {
                var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if(ctors.Any(x => x.GetParameters().Length == 0)) {
                    return MockRepository.GenerateMock<TMock>();
                }
                return MockRepository.GenerateMock<TMock>(MockParametersFor(GreediestConstructor(ctors)));
            }
            return MockRepository.GenerateMock<TMock>();
        }

        private static object[] MockParametersFor(ConstructorInfo ctor) {
            return ctor.GetParameters().Select(x => x.ParameterType.IsValueType ? Activator.CreateInstance(x.ParameterType) : MockRepository.GenerateStub(x.ParameterType)).ToArray();
        }

        private static ConstructorInfo GreediestConstructor(IEnumerable<ConstructorInfo> constructorInfos) {
            return constructorInfos.OrderBy(x => x.GetParameters().Count()).Last();
        }
    }
}