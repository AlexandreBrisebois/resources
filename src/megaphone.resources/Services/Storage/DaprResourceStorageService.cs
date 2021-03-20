using Dapr.Client;
using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Services.Storage;
using System.Threading.Tasks;

namespace Megaphone.Resources.Services.Storage
{
    public class DaprResourceStorageService : IResourceStorageService
    {
        const string STATE_STORE = "resource-state";

        private readonly DaprClient client;

        public DaprResourceStorageService(DaprClient client)
        {
            this.client = client;
        }

        public async Task<StorageEntry<Resource>> GetAsync(string partitionKey, string contentKey)
        {
            var (value, etag) = await client.GetStateAndETagAsync<StorageEntry<Resource>>(STATE_STORE, $"{partitionKey}/{contentKey}");

            return value ?? new StorageEntry<Resource>();
        }

        public async Task SetAsync(string partitionKey, string contentKey, StorageEntry<Resource> content)
        {
            await client.SaveStateAsync(STATE_STORE, $"{partitionKey}/{contentKey}", content);
        }
    }
}
