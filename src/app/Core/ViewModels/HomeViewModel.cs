using System.Collections.Generic;

namespace FakeVader.Core.ViewModels {
    public class HomeViewModel {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}