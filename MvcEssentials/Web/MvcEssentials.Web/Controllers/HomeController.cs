namespace MvcEssentials.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;
    using ViewModels.News;
    using ViewModels.Partials;

    public class HomeController : BaseController
    {
        private readonly INewsService newsArticles;
        private readonly INewsCategoryService newsCategories;
        private readonly IRegionsService regions;

        public HomeController(INewsService newsArticles, INewsCategoryService newsCategories, IRegionsService regions)
        {
            this.newsArticles = newsArticles;
            this.newsCategories = newsCategories;
            this.regions = regions;
        }

        public ActionResult Index()
        {
            var allNews = this.newsArticles.GetAllNew();
            var topNews = allNews.To<ArticleCarouselViewModel>().Take(4).ToList();
            var news = allNews.To<NewsArticleIndexViewModel>().Skip(4).Take(4).ToList();
            var aside = new AsideViewModel();

            aside.MostVisitedArticles = allNews.OrderByDescending(a => a.Visits.Count)
                .Take(10)
                .To<NewsArticleAsideViewModel>()
                .ToList();

            aside.RecentArticles = allNews.Take(10)
                .To<NewsArticleAsideViewModel>()
                .ToList();

            var viewModel = new IndexViewModel()
            {
                Articles = news,
                Aside = aside,
                TopNews = topNews
            };

            return this.View(viewModel);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}