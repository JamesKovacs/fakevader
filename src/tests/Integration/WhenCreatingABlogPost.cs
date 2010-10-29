using System.Transactions;
using FakeVader.Core.Domain;
using FakeVader.Core.Repositories;
using NUnit.Framework;

namespace FakeVader.Integration {
    [TestFixture]
    public class WhenCreatingABlogPost : InMemoryDatabaseTest {
        [Test]
        public void WillSaveToDb() {
            var blog = new Blog();
            var post = new Post();
            blog.AddPost(post);

            InitDatabase(typeof(Blog).Assembly);

            using(var scope = new TransactionScope()) {
                var repository = new BlogRepository(session);
                repository.Save(blog);
//                repository.Save(post);
                scope.Complete();
            }
        }
    }
}