namespace MvcEssentials.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private const string ModelCacheKey = "ViewModel";

        public HomeController(INewsService newsArticles)
            : base(newsArticles)
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache[ModelCacheKey] == null)
            {
                var allNews = this.NewsArticles.GetAllNew().Take(10);
                var topNews = allNews.To<ArticleCarouselViewModel>().Take(4).ToList();
                var news = allNews.To<NewsArticleIndexViewModel>().Skip(4).ToList();

                var viewModel = new IndexViewModel()
                {
                    Articles = news,
                    TopNews = topNews
                };

                this.HttpContext.Cache.Insert(ModelCacheKey, viewModel, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            }

            var viewModelToDisplay = this.HttpContext.Cache[ModelCacheKey];

            return this.View(viewModelToDisplay);
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