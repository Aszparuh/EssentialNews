namespace MvcEssentials.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using MvcEssentials.Data.Models;
    using Services.Data;
    using Services.Logic;
    using ViewModels.Home;
    using ViewModels.News;

    public class NewsController : BaseController
    {
        private readonly INewsService newsArticles;
        private readonly INewsCategoryService newsCategories;
        private readonly IRegionsService newsRegions;
        private readonly IImageProcessService imageProcessService;

        public NewsController(INewsService newsArticles, INewsCategoryService newsCategories, IRegionsService newsRegions, IImageProcessService imageProcessService)
        {
            this.newsArticles = newsArticles;
            this.newsCategories = newsCategories;
            this.newsRegions = newsRegions;
            this.imageProcessService = imageProcessService;
        }

        // GET: News
        public ActionResult Details(int id, string name)
        {
            var article = this.newsArticles.GetById(id);

            if (article != null && article.Title == name)
            {
                var viewModel = this.Mapper.Map<DetailsViewModel>(article);
                return this.View(viewModel);
            }
            else
            {
                return new HttpNotFoundResult("Article not found");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Journalist")]
        public ActionResult Create()
        {
            var model = new CreateNewsViewModel();
            var categoriesList = this.newsCategories.GetAll().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();
            var regionsList = this.newsRegions.GetAll().Select(r => new SelectListItem() { Text = r.Name, Value = r.Id.ToString() }).ToList();

            model.NewsCategories = categoriesList;
            model.Regions = regionsList;
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Journalist")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateNewsViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                var modelToSave = this.Mapper.Map<NewsArticle>(input);
                modelToSave.ApplicationUserId = this.User.Identity.GetUserId();

                var originalImageContent = this.imageProcessService.ToByteArray(input.Upload);
                var thumbnailImageContent = this.imageProcessService.Resize(originalImageContent, 260, 180);
                var qualityImageContent = this.imageProcessService.Resize(originalImageContent, 640, 360);
                var asideThumbnailImageContent = this.imageProcessService.Resize(originalImageContent, 141, 106);
                var name = input.Upload.FileName;
                var contentType = input.Upload.ContentType;

                modelToSave.Images.Add(
                    new Image()
                    {
                        FileName = name,
                        ContentType = contentType,
                        Content = originalImageContent,
                        Type = ImageType.Original
                    });

                modelToSave.Images.Add(
                    new Image()
                    {
                        FileName = name,
                        ContentType = "image/jpeg",
                        Content = thumbnailImageContent,
                        Type = ImageType.Thumbnail
                    });

                modelToSave.Images.Add(
                    new Image()
                    {
                        FileName = name,
                        ContentType = "image/jpeg",
                        Content = qualityImageContent,
                        Type = ImageType.Normal
                    });

                modelToSave.Images.Add(
                    new Image()
                    {
                        FileName = name,
                        ContentType = "image/jpeg",
                        Content = asideThumbnailImageContent,
                        Type = ImageType.AsideThumbnail
                    });

                this.newsArticles.Add(modelToSave);

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(input);
        }
    }
}