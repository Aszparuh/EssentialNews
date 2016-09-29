namespace MvcEssentials.Services.Data
{
    using MvcEssentials.Data.Common;
    using MvcEssentials.Data.Models;

    public class FileService : IFileService
    {
        private readonly IDbRepository<Image> images;

        public FileService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public Image GetById(int id)
        {
            return this.images.GetById(id);
        }
    }
}
