using MapsterMapper;
using Rule4.Controllers;
using Rule4.Services;

namespace Rule4.ServicesExtension
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddControllers();

            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            
            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<BaseService>();
            services.AddScoped<PostService>();
            services.AddScoped<TagService>();

            services.AddTransient<PostController>();
            services.AddTransient<TagController>();
            services.AddSwaggerGen();
        }
    }
}
