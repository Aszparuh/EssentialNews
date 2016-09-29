namespace MvcEssentials.Services.Data
{
    using System.Linq;
    using MvcEssentials.Data.Models;

    public interface IRegionsService
    {
        IQueryable<Region> GetAll();
    }
}
