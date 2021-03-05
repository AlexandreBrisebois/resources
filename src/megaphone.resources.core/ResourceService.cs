using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Views;
using Megaphone.Standard.Services;
using System.Threading.Tasks;

namespace megaphone.resources.core
{
    public class ResourceService : IResourceService
    {
        private readonly IStorageService<Resource> storageService;

        public ResourceService(IStorageService<Resource> storageService)
        {
            this.storageService = storageService;
        }

        public async Task AddAsync(Resource r)
        {
            await storageService.SetAsync(r.Id, r);
        }

        public async Task<ResourceView> GetAsync(string id)
        {
            var r = await storageService.GetAsync(id);

            if (r == Resource.Empty)
                return ResourceView.Empty;

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

        public async Task<ResourceCacheView> GetCacheAsync(string id)
        {
            var r = await storageService.GetAsync(id);

            return new ResourceCacheView
            {
                Cache = r.Cache,
                Id = r.Id,
                Url = r.Self.ToString()
            };
        }
    }
}
