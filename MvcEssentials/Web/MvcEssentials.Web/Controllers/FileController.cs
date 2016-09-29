namespace MvcEssentials.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data;

    public class FileController : Controller
    {
        private readonly IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = this.fileService.GetById(id);
            return this.File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}