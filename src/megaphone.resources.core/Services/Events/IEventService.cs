using Megaphone.Standard.Events;
using System.Threading.Tasks;

namespace Megaphone.Resources.Core.Services.Events
{
    public interface IEventService
    {
        Task PublishAsync(Event e);
    }
}
