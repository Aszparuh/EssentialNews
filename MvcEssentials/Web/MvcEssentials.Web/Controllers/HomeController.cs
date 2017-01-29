namespace MvcEssentials.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
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
                var allNews = this.NewsArticles.GetAllNew().Take(10).ToList();
                var topNews = allNews.Take(4).Select(x => this.Mapper.Map<ArticleCarouselViewModel>(x)).Take(4);
                var news = allNews.Skip(4).Take(6).Select(x => this.Mapper.Map<NewsArticleIndexViewModel>(x));

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