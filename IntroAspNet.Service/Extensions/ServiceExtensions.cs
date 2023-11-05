using IntroAspNet.Service.Services.Abstraction;
using IntroAspNet.Service.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace IntroAspNet.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
