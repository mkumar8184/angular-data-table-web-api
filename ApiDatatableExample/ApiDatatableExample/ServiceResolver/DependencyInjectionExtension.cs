
using DbLayer.Entity;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace ApiDatatableExample.ServiceResolver
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection ServiceResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddCors();
            services.AddDbContext<EmployeesContext>(options =>
             options.UseSqlServer(configuration["AppConfig:DbContext"]));
          
            return services;
          
        }
    }
}
