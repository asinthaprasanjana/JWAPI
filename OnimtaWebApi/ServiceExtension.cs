using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnimtaWebApi
{
    public static class ServiceExtension
    {
        public static string a;
        public static void DatabaseConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:OnimtaDB"];
           // services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
          
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
    }
}
