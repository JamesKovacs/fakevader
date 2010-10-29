using System.Collections.Generic;

namespace FakeVader.Core.Domain {
    public class Blog {
        private readonly IList<Post> posts;

        public Blog() {
            posts = new List<Post>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<Post> Posts {
            get { return posts; }
        }

        public virtual void AddPost(Post post) {
            posts.Add(post);
        }
    }
}