using IntroAspNet.Domain.DTOs.Articles;

namespace IntroAspNet.Service.Services.Abstraction
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesAsync();
    }
}
