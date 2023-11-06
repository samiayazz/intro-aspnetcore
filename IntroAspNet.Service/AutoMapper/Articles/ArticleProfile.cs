using AutoMapper;
using IntroAspNet.Domain.DTOs.Articles;
using IntroAspNet.Domain.Entities.Concretes;

namespace IntroAspNet.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
        }
    }
}
