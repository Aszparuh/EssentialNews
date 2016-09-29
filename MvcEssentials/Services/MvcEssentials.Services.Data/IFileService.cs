namespace MvcEssentials.Services.Data
{
    using MvcEssentials.Data.Models;

    public interface IFileService
    {
        Image GetById(int id);
    }
}
