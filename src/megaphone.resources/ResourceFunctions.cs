using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using megaphone.resources.core;
using Megaphone.Standard.Services;
using Megaphone.Resources.Core.Models;
using System.IO;
using Megaphone.Resources.Representations;
using System.Linq;
using Megaphone.Resources.Core.Views;
using System.Text.Json;
using System;
using System.Net.Http;

namespace Megaphone.Resources
{

    public static class ResourceFunctions
    {
        private static ResourceService resourceService = new ResourceService(new InMemoryPartitionedStorageService<Resource>());

        [FunctionName("post-resource")]
        public static async Task<SystemTextJsonResult> PostResource(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "")] HttpRequest req,
            ILogger log)
        {
            var resource = await JsonSerializer.DeserializeAsync<Resource>(req.Body);

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

            return new SystemTextJsonResult(representation, options: null, 201);
        }

        [FunctionName("get-resource")]
        public static async Task<SystemTextJsonResult> GetResource([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{id}")] HttpRequest req, string id, ILogger logger)
        {
            var view = await resourceService.GetAsync(id);

            var representation = RepresentationFactory.MakeRepresentation(view);

            return new SystemTextJsonResult(representation, options: null);
        } 
        
        [FunctionName("get-resource-cache")]
        public static async Task<SystemTextJsonResult> GetResourceCache([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{id}/cache")] HttpRequest req, string id, ILogger logger)
        {
            var view = await resourceService.GetCacheAsync(id);

            var representation = RepresentationFactory.MakeRepresentation(view);

            return new SystemTextJsonResult(representation, options: null);
        }

        public class SystemTextJsonResult : ContentResult
        {
            private const string ContentTypeApplicationJson = "application/json";

            public SystemTextJsonResult(object value, JsonSerializerOptions options = null, int statusCode = 200)
            {
                StatusCode = statusCode;
                ContentType = ContentTypeApplicationJson;
                Content = options == null ? JsonSerializer.Serialize(value) : JsonSerializer.Serialize(value, options);
            }
        }
    }
}
