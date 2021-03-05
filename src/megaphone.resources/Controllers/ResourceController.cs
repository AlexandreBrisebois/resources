using Dapr.Client;
using megaphone.resources.core;
using Megaphone.Resources.Commands;
using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Views;
using Megaphone.Resources.Events;
using Megaphone.Resources.Representations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Megaphone.Resources.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;
        private readonly DaprClient daprClient;

        public ResourceController(IResourceService resourceService,
                                  [FromServices] DaprClient daprClient)
        {
            this.resourceService = resourceService;
            this.daprClient = daprClient;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> PostAsync(Resource resource)
        {
            await resourceService.AddAsync(resource);

            var e = EventFactory.MakeResourceUpdateEvent(resource);

            var c = new PublishResourceUpdateEvent(e);
            await c.ApplyAsync(daprClient);

            if (Debugger.IsAttached)
                Console.WriteLine($"updated resource: \"{resource.Display}\" ({resource.Published.ToString("s")})");

            return Accepted();
        }

        [HttpGet()]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResourceRepresentation),(int)HttpStatusCode.OK)]
        public async Task<ResourceRepresentation> GetResource(string id)
        {
            var view = await resourceService.GetAsync(id);

            var representation = RepresentationFactory.MakeRepresentation(view);
            return representation;
        }

        [HttpHead()]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResourceLastUpdateRepresentation), (int)HttpStatusCode.OK)]
        public async Task<ResourceLastUpdateRepresentation> HeadResource(string id)
        {
            var view = await resourceService.GetAsync(id);

            return RepresentationFactory.MakeLastUpdateRepresentation(view);
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
