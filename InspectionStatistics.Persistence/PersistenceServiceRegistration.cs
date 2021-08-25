using InspectionStatistics.Application.Contracts.Persistence;
using InspectionStatistics.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InspectionStatistics.Domain.Contracts.Persistence;

namespace InspectionStatistics.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InspectionStatisticsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InspectionStatisticsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IInspectionRepository, InspectionRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
