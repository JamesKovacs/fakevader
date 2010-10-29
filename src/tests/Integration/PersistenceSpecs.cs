using FakeVader.Core.Domain;
using NUnit.Framework;

namespace FakeVader.Integration {
    public class PersistenceSpecs : InMemoryDatabaseTest {

        [SetUp]
        public void SetUp() {
            InitDatabase(typeof(Blog).Assembly);
        }
    }
}