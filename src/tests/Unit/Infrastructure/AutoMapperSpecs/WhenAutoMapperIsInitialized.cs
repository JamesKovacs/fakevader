using AutoMapper;
using FakeVader.Core.Infrastructure.AutoMapping;
using NUnit.Framework;

namespace FakeVader.Tests.Infrastructure.AutoMapperSpecs {
    [TestFixture]
    public class WhenAutoMapperIsInitialized : ConcernsFor<AutoMapperStartupTask> {
        [Test]
        public void ShouldHaveAValidConfiguration() {
            Mapper.AssertConfigurationIsValid();
        }

        protected override void Context() {
        }

        protected override AutoMapperStartupTask CreateSUT() {
            return new AutoMapperStartupTask();
        }

        protected override void Because() {
            Sut.Execute();
        }
    }
}