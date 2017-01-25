namespace MvcEssentials.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;
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
            var allNews = this.newsArticles.GetAllNew().Take(10).ToList();
            var topNews = allNews.Take(4).Select(x => this.Mapper.Map<ArticleCarouselViewModel>(x)).Take(4);
            var news = allNews.Skip(4).Take(6).Select(x => this.Mapper.Map<NewsArticleIndexViewModel>(x));
            var aside = new AsideViewModel();

            aside.MostVisitedArticles = allNews.Take(10).Select(x => this.Mapper.Map<NewsArticleAsideViewModel>(x));
            aside.RecentArticles = allNews.Take(10).Select(x => this.Mapper.Map<NewsArticleAsideViewModel>(x));

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