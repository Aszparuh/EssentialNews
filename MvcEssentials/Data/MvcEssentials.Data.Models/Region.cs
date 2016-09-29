namespace MvcEssentials.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Region : BaseModel<int>
    {
        public Region()
        {
            this.Articles = new HashSet<NewsArticle>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<NewsArticle> Articles { get; set; }
    }
}
