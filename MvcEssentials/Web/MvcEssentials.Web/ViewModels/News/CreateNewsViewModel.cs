namespace MvcEssentials.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateNewsViewModel : IMapTo<NewsArticle>
    {
        public string Title { get; set; }

        [DisplayName("Check if the news is breaking")]
        public bool IsTop { get; set; }

        [DisplayName("Category")]
        public int NewsCategoryId { get; set; }

        public IEnumerable<SelectListItem> NewsCategories { get; set; }

        [DisplayName("Region")]
        public int RegionId { get; set; }

        public IEnumerable<SelectListItem> Regions { get; set; }

        public string ApplicationUserId { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        [DisplayName("Sample Content")]
        public string SampleContent { get; set; }

        public HttpPostedFileBase Upload { get; set; }
    }
}