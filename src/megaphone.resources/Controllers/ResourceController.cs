using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Services.Events;
using Megaphone.Resources.Core.Services.Storage;
using Megaphone.Resources.Events;
using Megaphone.Resources.Representations;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Megaphone.Resources.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;
        private readonly IEventService eventService;

        public ResourceController([FromServices] IResourceService resourceService,
                                  [FromServices] IEventService eventService)
        {
            this.resourceService = resourceService;
            this.eventService = eventService;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> PostAsync(Resource resource)
        {
            await resourceService.AddAsync(resource);

            var e = EventFactory.MakeResourceUpdateEvent(resource);
            await eventService.PublishAsync(e);

            return Accepted();
        }

        [HttpGet()]
        [Route("{host}/{id}")]
        [ProducesResponseType(typeof(ResourceRepresentation),(int)HttpStatusCode.OK)]
        public async Task<ResourceRepresentation> GetResource(string host, string id)
        {
            var view = await resourceService.GetAsync(host, id);

            var representation = RepresentationFactory.MakeRepresentation(view);
            return representation;
        }

        [HttpGet()]
        [Route("{host}/{id}/last-updated")]
        [ProducesResponseType(typeof(ResourceLastUpdateRepresentation), (int)HttpStatusCode.OK)]
        public async Task<ResourceLastUpdateRepresentation> HeadResource(string host, string id)
        {
            var view = await resourceService.GetAsync(host, id);

            return RepresentationFactory.MakeLastUpdateRepresentation(view);
        }

        [HttpGet()]
        [Route("{host}/{id}/cache")]
        [ProducesResponseType(typeof(ResourceCacheRepresentation), (int)HttpStatusCode.OK)]
        public async Task<ResourceCacheRepresentation> GetResourceCache(string host, string id)
        {
            var view = await resourceService.GetCacheAsync(host,id);
            var representation = RepresentationFactory.MakeRepresentation(view);
            return representation;
        }
    }
}
