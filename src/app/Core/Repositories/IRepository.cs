using System.Linq;

namespace FakeVader.Core.Repositories {
    public interface IRepository<T> {
        void Save(T obj);
        IQueryable<T> FindAll();
    }
}