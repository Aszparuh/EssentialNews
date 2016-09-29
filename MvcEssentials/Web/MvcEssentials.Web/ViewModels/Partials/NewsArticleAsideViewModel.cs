namespace MvcEssentials.Web.ViewModels.Partials
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class NewsArticleAsideViewModel : IMapFrom<NewsArticle>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? SmallThumbnailId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<NewsArticle, NewsArticleAsideViewModel>()
                .ForMember(x => x.SmallThumbnailId, opt => opt.MapFrom(
                    x => x.Images.Where(img => img.Type == ImageType.AsideThumbnail)
                    .FirstOrDefault().Id));
        }
    }
}