using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Core.Application.Contracts.Persistence.Base;
using PruebaTecnica.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Infraestructure.Persistence;

namespace PruebaTecnica.Infraestructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PruebaDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            return services;
        }
    }
}
