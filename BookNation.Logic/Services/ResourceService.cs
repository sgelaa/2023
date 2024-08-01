
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using BookNation.Logic.Services.Interfaces;

namespace BookNation.Logic.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        public async Task<AppResource> AddResourceAsync(AppResource resource)
        {
            return await _resourceRepository.AddResourceAsync(resource);
        }

        public async Task<IEnumerable<AppResource>> GetAllResourceAsync()
        {
            return await _resourceRepository.GetAllResourceAsync();
        }

        public async Task<AppResource?> GetResourceAsync(int id)
        {
            return await _resourceRepository.GetResourceAsync(id);
        }

        public async Task<AppResource> RemoveResourceAsync(int id)
        {
            return await _resourceRepository.RemoveResourceAsync(id);
        }

        public async Task<AppResource> UpdateResourceAsync(int id, AppResource resource)
        {
            return await _resourceRepository.UpdateResourceAsync(id, resource);
        }
    }
}
