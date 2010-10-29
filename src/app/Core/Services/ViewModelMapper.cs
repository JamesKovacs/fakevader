using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace FakeVader.Core.Services {
    public class ViewModelMapper : IViewModelMapper {
        public IEnumerable<TResult> MapAll<T, TResult>(IEnumerable<T> objs) {
            if(objs == null || objs.Count() == 0) {
                return Enumerable.Empty<TResult>();
            }
            return InnerMap<T,TResult>(objs);
        }

        private IEnumerable<TResult> InnerMap<T, TResult>(IEnumerable<T> objs) {
            foreach(var obj in objs) {
                yield return Mapper.Map<T, TResult>(obj);
            }
        }
    }
}