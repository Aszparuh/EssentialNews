namespace MvcEssentials.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Data;

    public abstract class BaseController : Controller
    {
        public BaseController(INewsService newsArticles)
        {
            this.NewsArticles = newsArticles;
        }

        protected INewsService NewsArticles
        {
            get;
            private set;
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}