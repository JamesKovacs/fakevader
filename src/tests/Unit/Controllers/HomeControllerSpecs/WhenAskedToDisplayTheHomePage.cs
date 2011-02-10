using System.Linq;
using System.Web.Mvc;
using FakeVader.Core.Controllers;
using FakeVader.Core.Domain;
using FakeVader.Core.Repositories;
using FakeVader.Core.Services;
using FakeVader.Core.ViewModels;
using NUnit.Framework;
using Rhino.Mocks;
using MvcContrib.TestHelper;

namespace FakeVader.Tests.Controllers.HomeControllerSpecs {
    [TestFixture]
    public class WhenAskedToDisplayTheHomePage : ConcernsFor<HomeController> {
        [Test]
        public void ShouldFetchAListOfBlogPostsFromThePostsRepository() {
            repository.VerifyAllExpectations();
        }

        [Test]
        public void ShouldMapThePostsToTheViewModel() {
            mapper.VerifyAllExpectations();
        }

        [Test]
        public void ShouldRenderTheDefaultView() {
            view.AssertViewRendered().ForView(string.Empty);
        }

        [Test]
        public void ShouldPassTheCorrectViewModelToTheView() {
            view.AssertViewRendered()
                .WithViewData<HomeViewModel>();
        }

        [Test]
        public void ShouldReturnTheCorrectPostViewModels() {
            view.AssertViewRendered()
                .WithViewData<HomeViewModel>()
                .Posts.ShouldBe(postViewModels);
        }

        protected override void Context() {
            repository = Dependency<IRepository<Post>>();
            posts = new Post[] {};
            repository.Expect(x => x.FindAll()).IgnoreArguments().Return(posts.AsQueryable());
            mapper = Dependency<IViewModelMapper>();
            postViewModels = new PostViewModel[] {};
            mapper.Expect(x => x.MapAll<Post,PostViewModel>(posts)).IgnoreArguments().Return(postViewModels);
        }

        protected override HomeController CreateSUT() {
            return new HomeController(repository, mapper);
        }

        protected override void Because() {
            view = Sut.Index();
        }

        private IRepository<Post> repository;
        private ActionResult view;
        private Post[] posts;
        private IViewModelMapper mapper;
        private PostViewModel[] postViewModels;
    }
}