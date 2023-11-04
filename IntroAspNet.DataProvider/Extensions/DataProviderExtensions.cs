using IntroAspNet.DataProvider.Context;
using IntroAspNet.DataProvider.Repositories.Abstraction;
using IntroAspNet.DataProvider.Repositories.Concretes;
using IntroAspNet.DataProvider.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntroAspNet.DataProvider.Extensions
{
    public static class DataProviderExtensions
    {
        public static IServiceCollection LoadDataProviderExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
