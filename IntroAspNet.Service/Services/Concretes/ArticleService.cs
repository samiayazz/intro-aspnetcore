using AutoMapper;
using IntroAspNet.DataProvider.UnitOfWorks;
using IntroAspNet.Domain.DTOs.Articles;
using IntroAspNet.Domain.Entities.Concretes;
using IntroAspNet.Service.Services.Abstraction;

namespace IntroAspNet.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<List<ArticleDto>> GetAllArticlesAsync() => _mapper.Map<List<ArticleDto>>(await _unitOfWork.GetRepository<Article>().GetAllAsync());
    }
}
