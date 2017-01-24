namespace MvcEssentials.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using News;
    using Partials;

    public class IndexViewModel
    {
        public IEnumerable<NewsArticleIndexViewModel> Articles { get; set; }

        public IEnumerable<NewsCategoryViewModel> Categories { get; set; }

        public IEnumerable<RegionViewModel> Regions { get; set; }

        public AsideViewModel Aside { get; set; }

        public IEnumerable<ArticleCarouselViewModel> TopNews { get; set; }
    }
}