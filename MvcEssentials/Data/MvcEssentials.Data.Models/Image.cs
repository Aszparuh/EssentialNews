namespace MvcEssentials.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MvcEssentials.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public ImageType Type { get; set; }

        public byte[] Content { get; set; }

        public int NewsArticleId { get; set; }

        public virtual NewsArticle NewsArticle { get; set; }
    }
}
