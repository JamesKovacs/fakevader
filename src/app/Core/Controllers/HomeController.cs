using System.Linq;
using System.Web.Mvc;
using FakeVader.Core.Domain;
using FakeVader.Core.Repositories;
using FakeVader.Core.Services;
using FakeVader.Core.ViewModels;

namespace FakeVader.Core.Controllers {
    [HandleError]
    public class HomeController : Controller {
        private readonly IRepository<Post> repository;
        private readonly IViewModelMapper mapper;

        public HomeController(IRepository<Post> repository, IViewModelMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual ActionResult Index() {
            var posts = from post in repository.FindAll()
                        orderby post.PublishDate descending
                        select post;
            var recentPosts = posts.Skip(0).Take(10).ToList();
            var postViewModels = mapper.MapAll<Post,PostViewModel>(recentPosts);
            var viewModel = new HomeViewModel {Posts = postViewModels};
            return View(viewModel);
        }

        public virtual ActionResult About() {
            return View();
        }
    }
}