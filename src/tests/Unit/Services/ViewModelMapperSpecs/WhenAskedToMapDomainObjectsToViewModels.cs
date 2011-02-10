using System.Collections.Generic;
using System.Linq;
using FakeVader.Core.Domain;
using FakeVader.Core.Services;
using FakeVader.Core.ViewModels;
using NUnit.Framework;

namespace FakeVader.Tests.Services.ViewModelMapperSpecs {
    [TestFixture]
    public class WhenAskedToMapAnEmptyCollectionOfDomainObjectsToViewModels : ConcernsFor<ViewModelMapper> {
        [Test]
        public void ShouldReturnAnEmptyEnumerable() {
            Assert.That(result, Is.SameAs(Enumerable.Empty<PostViewModel>()));
        }

        protected override void Context() {
            noPosts = new Post[]{};
        }

        protected override ViewModelMapper CreateSUT() {
            return new ViewModelMapper();
        }

        protected override void Because() {
            result = Sut.MapAll<Post,PostViewModel>(noPosts);
        }

        private Post[] noPosts;
        private IEnumerable<PostViewModel> result;
    }
}