using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Database.Models;

namespace Cefalo.Media.MyBlog.ExtensionServices
{
    public static class DatabaseConfiguration
    {
        public static void DatabaseConfigurationService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
        }
    }
}
