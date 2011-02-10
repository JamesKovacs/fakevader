using System.Collections.Generic;
using System.Linq;
using FakeVader.Core.Domain;
using FakeVader.Core.Infrastructure.AutoMapping;
using FakeVader.Core.Services;
using FakeVader.Core.ViewModels;
using NUnit.Framework;

namespace FakeVader.Tests.InfrastructureServices.ViewModelMappingSpecs {
    [TestFixture]
    public class WhenAskedToMapACollectionOfDomainObjectsToViewModels : ConcernsFor<ViewModelMapper> {
        [Test]
        public void ShouldReturnACollectionOfViewModelsWithTheSameNumberOfElements() {
            Assert.That(result.Count(), Is.EqualTo(posts.Count()));
        }

        [Test]
        public void ShouldReturnACollectionOfViewModelsWithMatchingValues() {
            foreach(var post in posts) {
                var localPost = post;
                var viewModel = result.SingleOrDefault(x => x.Title == localPost.Title && x.Text == localPost.Text);
                Assert.That(viewModel, Is.Not.Null);
            }
        }

        protected override void Context() {
            new AutoMapperStartupTask().Execute();
            posts = new [] { 
                new Post("Title1", "Text1"),
                new Post("Title2", "Text2")
            };
        }

        protected override ViewModelMapper CreateSUT() {
            return new ViewModelMapper();
        }

        protected override void Because() {
            result = Sut.MapAll<Post,PostViewModel>(posts);
        }

        private Post[] posts;
        private IEnumerable<PostViewModel> result;
    }
}