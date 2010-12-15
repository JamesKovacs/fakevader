using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace FakeVader.Core.Repositories {
    public class Repository<T> : IRepository<T> {
        private readonly ISession session;

        public Repository(ISession session) {
            this.session = session;
        }

        public void Save(T obj) {
            session.Save(obj);
        }

        public IQueryable<T> FindAll() {
            return session.Query<T>();
        }
    }
}