using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Repository.Interfaces
{


    public interface IResourceRepository
    {
        Task<AppResource> AddResourceAsync(AppResource resource);
        Task<AppResource?> GetResourceAsync(int id);
        Task<IEnumerable<AppResource>> GetAllResourceAsync();
        Task<AppResource> UpdateResourceAsync(int id, AppResource resource);
        Task<AppResource> RemoveResourceAsync(int id);
    }
}
