namespace MvcEssentials.Web.ViewModels.Partials
{
    using System.Collections.Generic;

    public class AsideViewModel
    {
        public IEnumerable<NewsArticleAsideViewModel> RecentArticles { get; set; }

        public IEnumerable<NewsArticleAsideViewModel> MostVisitedArticles { get; set; }
    }
}