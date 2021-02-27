using megaphone.resources.core;
using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Views;
using Megaphone.Resources.Representations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Megaphone.Resources.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;
        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> PostAsync(Resource resource)
        {
            await resourceService.AddAsync(resource);

            var resourceView = new ResourceView
            {
                Display = resource.Display,
                Id = resource.Id,
                Url = resource.Self.ToString(),
                Created = resource.Created,
                Description = resource.Description,
                IsActive = resource.IsActive,
                Published = resource.Published,
                StatusCode = resource.StatusCode,
                Type = resource.Type
            };

            var representation = RepresentationFactory.MakeRepresentation(resourceView);

            return Accepted();
        }

        [HttpGet()]
        [Route("{id}")]
        public async Task<ResourceRepresentation> GetResource(string id)
        {
            var view = await resourceService.GetAsync(id);
            var representation = RepresentationFactory.MakeRepresentation(view);
            return representation;
        }

        [HttpGet()]
        [Route("{id}/cache")]
        public async Task<ResourceCacheRepresentation> GetResourceCache(string id)
        {
            var view = await resourceService.GetCacheAsync(id);
            var representation = RepresentationFactory.MakeRepresentation(view);
            return representation;
        }
    }
}
