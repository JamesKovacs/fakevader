using System.Transactions;
using FakeVader.Core.Domain;
using FakeVader.Core.Repositories;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace FakeVader.Tests.Integration.Core.Repositories {
    [TestFixture]
    public class WhenCreatingABlogPost : InMemoryDatabaseTest {
        [Test]
        public void WillSaveToDb() {
            var blog = new Blog();
            var post = new Post("Title", "Text");
            blog.AddPost(post);

            using(var scope = new TransactionScope()) {
                var repository = new Repository<Blog>(Session);
                repository.Save(blog);
                scope.Complete();
            }
        }

        [Test]
        public void ShouldSavePostToDatabase() {
            new PersistenceSpecification<Post>(Session)
            .CheckProperty(x => x.Permalink, "PermalinkTextGoesHere")
            .CheckProperty(x => x.Text, "Text of blog post...")
            .CheckProperty(x => x.Title, "Funky Title")
            .VerifyTheMappings();
        }

    }
}