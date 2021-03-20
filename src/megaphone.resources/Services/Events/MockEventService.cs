using Megaphone.Resources.Core.Services.Events;
using Megaphone.Standard.Events;
using Megaphone.Standard.Services;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Megaphone.Resources.Services.Events
{
    public class MockEventService : IEventService
    {
        public ConcurrentQueue<Event> PublishedEvents { get; init; } = new ConcurrentQueue<Event>();

        public Task PublishAsync(Event e)
        {
            PublishedEvents.Enqueue(e);
            return Task.CompletedTask;
        }
    }
}
