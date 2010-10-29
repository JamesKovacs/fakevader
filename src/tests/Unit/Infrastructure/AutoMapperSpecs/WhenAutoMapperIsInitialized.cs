using AutoMapper;
using FakeVader.Core.Infrastructure.AutoMapping;
using NUnit.Framework;

namespace FakeVader.Tests.Infrastructure.AutoMapperSpecs {
    [TestFixture]
    public class WhenAutoMapperIsInitialized : ConcernsFor<AutoMapperRegistration> {
        [Test]
        public void ShouldHaveAValidConfiguration() {
            Mapper.AssertConfigurationIsValid();
        }

        protected override void Context() {
        }

        protected override AutoMapperRegistration CreateSUT() {
            return new AutoMapperRegistration();
        }

        protected override void Because() {
            Sut.Execute();
        }
    }
}