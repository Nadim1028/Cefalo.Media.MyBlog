using Microsoft.Extensions.DependencyInjection;

namespace Cefalo.Media.MyBlog.ExtensionServices
{
    public static class CorsConfiguration
    {
        public static void CORSConfigurationServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
