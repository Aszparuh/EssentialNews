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
            var news = this.newsArticles.GetAllNew().To<NewsArticleIndexViewModel>().ToList();
            var categories = this.newsCategories.GetAll().To<NewsCategoryViewModel>().ToList();
            var regions = this.regions.GetAll().To<RegionViewModel>().ToList();
            var topNews = this.newsArticles.GetAllNew().To<ArticleCarouselViewModel>().Take(4).ToList();
            var aside = new AsideViewModel();

            aside.MostVisitedArticles = this.newsArticles.GetAll()
                .OrderByDescending(a => a.Visits.Count)
                .Take(10)
                .To<NewsArticleAsideViewModel>()
                .ToList();

            aside.RecentArticles = this.newsArticles.GetAll()
                .OrderByDescending(a => a.CreatedOn)
                .Take(10)
                .To<NewsArticleAsideViewModel>()
                .ToList();

            var viewModel = new IndexViewModel()
            {
                Articles = news,
                Categories = categories,
                Regions = regions,
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