using System.Collections.Generic;

namespace FakeVader.Core.Services {
    public interface IViewModelMapper {
        IEnumerable<TResult> MapAll<T, TResult>(IEnumerable<T> objs);
    }
}