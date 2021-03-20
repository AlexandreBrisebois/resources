using Megaphone.Resources.Core.Models;
using Megaphone.Standard.Services;
using System.Threading.Tasks;

namespace Megaphone.Resources.Core.Services.Storage
{
    public class InMemoryResourceStorageService : IResourceStorageService
    {
        private InMemoryStorageService<StorageEntry<Resource>> backingStore;

        public InMemoryResourceStorageService()
        {
            backingStore = new InMemoryStorageService<StorageEntry<Resource>>();
        }

        public async Task<StorageEntry<Resource>> GetAsync(string partitionKey, string contentKey)
        {
            return await backingStore.GetAsync($"{partitionKey}/{contentKey}");
        }

        public async Task SetAsync(string partitionKey, string contentKey, StorageEntry<Resource> content)
        {
            await backingStore.SetAsync($"{partitionKey}/{contentKey}", content);
        }
    }
}