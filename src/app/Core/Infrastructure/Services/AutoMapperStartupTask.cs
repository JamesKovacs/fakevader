using AutoMapper;
using Castle.Core;
using FakeVader.Core.Domain;
using FakeVader.Core.ViewModels;

namespace FakeVader.Core.Infrastructure.Services {
    public class AutoMapperStartupTask : IStartable {
        public void Start() {
            Mapper.CreateMap<Post, PostViewModel>()
                  .ForMember(dest => dest.PublishDate, x => x.AddFormatter<DateFormatter>());
        }

        public void Stop() {
        }
    }
}