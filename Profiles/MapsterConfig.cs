using Mapster;
using Rule4.Dto.Tags;
using Rule4.Models;
using System.Reflection;

namespace Rule4.Profiles
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Tag, GetTagByNameDto>.NewConfig()
                .Map(dest => dest.PostCount, src => src.Posts.Count, src => src.Posts != null);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}