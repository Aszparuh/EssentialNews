namespace MvcEssentials.Web.ViewModels.Home
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using MvcEssentials.Web.Infrastructure.Mapping;

    public class ArticleCarouselViewModel : IMapFrom<NewsArticle>, IMapTo<NewsArticle>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ImageId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<NewsArticle, ArticleCarouselViewModel>()
                .ForMember(x => x.ImageId, opt => opt.MapFrom(x => x.Images.Where(img => img.Type == ImageType.Normal).FirstOrDefault().Id));
        }
    }
}