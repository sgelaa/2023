using BookNation.DataAccess.Data;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;

namespace BookNation.Logic.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly DataContext _context;

        public ResourceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppResource> AddResourceAsync(AppResource resource)
        {
            var res = new AppResource
            {
                LinkId = resource.LinkId,
                ResourceHost = resource.ResourceHost,
                ResourceHostId = resource.ResourceHostId,
                ResourceType = resource.ResourceType
            };

            _context.Resources.Add(res);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<AppResource?> GetResourceAsync(int id)
        {
            return await _context.Resources.FindAsync(id);
        }

        public async Task<AppResource> RemoveResourceAsync(int id)
        {
            var del = await GetResourceAsync(id);
            if (del != null)
            {
                _context.Resources.Remove(del);
                await _context.SaveChangesAsync();
            }
            return del;
        }

        public async Task<AppResource> UpdateResourceAsync(int id, AppResource resource)
        {
            var update = await GetResourceAsync(id);
            if (update != null)
            {
                _context.Resources.Update(update);
                await _context.SaveChangesAsync();
            }
            return update;
        }
    }
}
