using Dapr.Client;
using Megaphone.Resources.Core.Models;
using Megaphone.Standard.Services;
using System.Threading.Tasks;

namespace Megaphone.Resources.Services
{

    public class ResourceStorageService : IStorageService<Resource>
    {
        const string STATE_STORE = "resource-state";

        private readonly DaprClient client;

        public ResourceStorageService(DaprClient client)
        {
            this.client = client;
        }

        public async Task<Resource> GetAsync(string key)
        {

            var (value, etag) = await this.client.GetStateAndETagAsync<Resource>(STATE_STORE, key);

            return value ?? Resource.Empty;
        }

        public async Task SetAsync(string key, Resource content)
        {
            await this.client.SaveStateAsync(STATE_STORE, key, content);
        }
    }
}
