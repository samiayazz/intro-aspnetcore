using IntroAspNet.DataProvider.Repositories.Abstraction;
using IntroAspNet.DataProvider.Repositories.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntroAspNet.DataProvider.Extensions
{
    public static class DataProviderExtensions
    {
        public static IServiceCollection LoadDataProviderExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
