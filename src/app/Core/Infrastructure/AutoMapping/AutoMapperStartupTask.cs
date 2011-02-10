using AutoMapper;
using FakeVader.Core.Domain;
using FakeVader.Core.ViewModels;

namespace FakeVader.Core.Infrastructure.AutoMapping {
    public class AutoMapperStartupTask : IStartupTask {
        public void Execute() {
            Mapper.CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.PublishDate, x => x.AddFormatter<DateFormatter>());
        }
    }
}