namespace MvcEssentials.Data.Models
{
    using MvcEssentials.Data.Common.Models;

    public class Visit : BaseModel<int>
    {
        public int NewsArticleId { get; set; }

        public virtual NewsArticle NewsArticle { get; set; }
    }
}
