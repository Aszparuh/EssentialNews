namespace MvcEssentials.Services.Data
{
    using System.Linq;
    using MvcEssentials.Data.Models;

    public interface INewsService
    {
        IQueryable<NewsArticle> GetAllNew();

        IQueryable<NewsArticle> GetAll();

        NewsArticle GetById(int id);

        void Add(NewsArticle article);
    }
}
