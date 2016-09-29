namespace MvcEssentials.Services.Data
{
    using System.Linq;
    using MvcEssentials.Data.Common;
    using MvcEssentials.Data.Models;

    public class NewsCategoryService : INewsCategoryService
    {
        private readonly IDbRepository<NewsCategory> categories;

        public NewsCategoryService(IDbRepository<NewsCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<NewsCategory> GetAll()
        {
            return this.categories.All().OrderBy(c => c.Name);
        }
    }
}
