namespace MvcEssentials.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Partials;

    public class AsideController : BaseController
    {
        public AsideController(INewsService newsArticles)
            : base(newsArticles)
        {
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var allNews = this.NewsArticles.GetAllNew().Take(10).To<NewsArticleAsideViewModel>().ToList();
            var aside = new AsideViewModel();

            aside.MostVisitedArticles = allNews;
            aside.RecentArticles = allNews;

            return this.PartialView("_AsidePartial", aside);
        }
    }
}