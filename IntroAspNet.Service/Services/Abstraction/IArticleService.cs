using IntroAspNet.Domain.Entities.Concretes;

namespace IntroAspNet.Service.Services.Abstraction
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticlesAsync();
    }
}
