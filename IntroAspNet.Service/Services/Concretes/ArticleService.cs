using IntroAspNet.DataProvider.UnitOfWorks;
using IntroAspNet.Domain.Entities.Concretes;
using IntroAspNet.Service.Services.Abstraction;

namespace IntroAspNet.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<Article>> GetAllArticlesAsync() => await _unitOfWork.GetRepository<Article>().GetAllAsync();
    }
}
