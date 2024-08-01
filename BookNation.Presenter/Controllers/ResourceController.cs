using BookNation.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookNation.Presenter.Controllers
{
    public class ResourceController : BaseApiController
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _resourceService.GetAllResourceAsync());
        }
    }
}
