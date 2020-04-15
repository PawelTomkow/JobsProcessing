using AutoMapper;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Infrastructure.DTOs;

namespace ZavenDotNetInterview.Infrastructure.Config
{
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobDto>(); });

        public static IMapper GetMapper() => config.CreateMapper();
    }
}