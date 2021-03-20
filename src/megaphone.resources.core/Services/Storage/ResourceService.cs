using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Views;
using System.Threading.Tasks;

namespace Megaphone.Resources.Core.Services.Storage
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceStorageService storageService;

        public ResourceService(IResourceStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async Task AddAsync(Resource r)
        {
            await storageService.SetAsync(r.Self.Host, r.Id, new StorageEntry<Resource> { Value = r });
        }

        public async Task<ResourceView> GetAsync(string host, string id)
        {
            var entry = await storageService.GetAsync(host, id);

            if (!entry.HasValue)
                return ResourceView.Empty;

            var r = entry.Value;

            return new ResourceView
            {
                Display = r.Display,
                Id = r.Id,
                Url = r.Self.ToString(),
                Created = r.Created,
                Description = r.Description,
                IsActive = r.IsActive,
                Published = r.Published,
                StatusCode = r.StatusCode,
                Type = r.Type
            };
        }

        public async Task<ResourceCacheView> GetCacheAsync(string host, string id)
        {
            var entry = await storageService.GetAsync(host, id);

            if (entry.HasValue)
            {
                var r = entry.Value;

                return new ResourceCacheView
                {
                    Cache = r.Cache,
                    Id = r.Id,
                    Url = r.Self.ToString()
                };
            }

            return ResourceCacheView.Empty;
        }
    }
}
