using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Services.Interfaces
{
    public interface IResourceService
    {
        Task<AppResource> AddResourceAsync(AppResource resource);
        Task<AppResource?> GetResourceAsync(int id);
        Task<AppResource> UpdateResourceAsync(int id, AppResource resource);
        Task<AppResource> RemoveResourceAsync(int id);
    }
}
