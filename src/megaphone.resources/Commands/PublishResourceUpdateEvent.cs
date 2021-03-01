using Dapr.Client;
using Megaphone.Standard.Commands;
using Megaphone.Standard.Events;
using System.Threading.Tasks;

namespace Megaphone.Resources.Commands
{
    public class PublishResourceUpdateEvent : ICommand<DaprClient>
    {
        private readonly Event e;

        public PublishResourceUpdateEvent(Event e)
        {
            this.e = e;
        }
        public async Task ApplyAsync(DaprClient model)
        {
            await model.PublishEventAsync("resource-events", "resource-events", e);
        }
    }
}
