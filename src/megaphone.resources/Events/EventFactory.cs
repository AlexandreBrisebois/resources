using Megaphone.Resources.Core.Models;
using Megaphone.Standard.Events;
using System;

namespace Megaphone.Resources.Events
{
    internal class EventFactory
    {
        internal static Event MakeResourceUpdateEvent(Resource r)
        {
            return EventBuilder
                  .NewEvent(Events.Resource.Update)
                  .WithMetadata("updated", DateTimeOffset.UtcNow.ToString())
                  .WithMetadata("published", r.Published.ToString())
                  .WithMetadata("status", r.StatusCode.ToString())
                  .WithData("resource", "id", r.Id)
                  .WithData("resource", "display", r.Display)
                  .WithData("resource", "url", r.Self.ToString())
                  .WithData("resource", "type", r.Type)
                  .Make();
        }
    }
}