using Dapr.Client;
using Megaphone.Resources.Core.Services.Events;
using Megaphone.Standard.Events;
using System.Threading.Tasks;

namespace Megaphone.Resources.Services.Events
{
    public class DaprEventService : IEventService
    {
        private readonly DaprClient daprClient;

        public DaprEventService(DaprClient daprClient)
        {
            this.daprClient = daprClient;
        }

        public async Task PublishAsync(Event e)
        {
            await daprClient.PublishEventAsync("resource-events", "resource-events", e);
        }
    }
}
