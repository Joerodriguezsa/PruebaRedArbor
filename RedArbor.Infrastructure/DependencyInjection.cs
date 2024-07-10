using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedArbor.Application.Interface.IRepository;
using RedArbor.Application.Interface.IService;
using RedArbor.Application.Service;
using RedArbor.Infrastructure.Repository;

namespace RedArbor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RedArborDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("StringConnectionSqlServer")));

            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPortalService, PortalService>();
            services.AddTransient<ICompanyService, CompanyService>();

            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPortalRepository, PortalRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            return services;

        }
    }
}
