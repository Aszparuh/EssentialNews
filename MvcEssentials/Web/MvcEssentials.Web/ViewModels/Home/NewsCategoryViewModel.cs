namespace MvcEssentials.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using MvcEssentials.Data.Models;
    using MvcEssentials.Web.Infrastructure.Mapping;

    public class NewsCategoryViewModel : IMapFrom<NewsCategory>
    {
        public string Name { get; set; }

        public virtual ICollection<NewsArticle> Articles { get; set; }
    }
}