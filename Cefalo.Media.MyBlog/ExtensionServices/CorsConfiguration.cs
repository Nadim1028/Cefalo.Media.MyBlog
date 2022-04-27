using Microsoft.Extensions.DependencyInjection;

namespace Cefalo.Media.MyBlog.ExtensionServices
{
    public static class CorsConfiguration
    {
        public static string MyAllowSpecificOrigins { get; private set; }

        public static void CORSConfigurationServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader() .WithOrigins("http://localhost:3000"));
            });

            //services.AddCors(options =>
            // {
            //     options.AddPolicy(name: MyAllowSpecificOrigins,
            //                       policy =>
            //                       {
            //                           policy.WithOrigins("http://localhost:3000");
            //                       });
            // });

        }
    }
}
