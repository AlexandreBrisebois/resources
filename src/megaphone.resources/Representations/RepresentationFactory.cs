using Megaphone.Resources.Core.Views;
using Megaphone.Standard.Representations.Links;
using System;

namespace Megaphone.Resources.Representations
{
    public partial class RepresentationFactory
    {
        public static ResourceLastUpdateRepresentation MakeLastUpdateRepresentation(ResourceView view)
        {
            var r = new ResourceLastUpdateRepresentation
            {
                IsActive = view.IsActive,
                Type = view.Type,
                LastUpdated = view.Created
            };

            if (view != ResourceView.Empty)
                r.AddLink(Relations.Self, $"/api/resources/{new Uri(view.Url).Host}/{view.Id}");

            return r;
        }
        public static ResourceRepresentation MakeRepresentation(ResourceView view)
        {
            var r = new ResourceRepresentation
            {
                Display = view.Display,
                Url = view.Url,
                Created = view.Created,
                Description = view.Description,
                IsActive = view.IsActive,
                Published = view.Published,
                StatusCode = view.StatusCode,
                Type = view.Type
            };

            r.AddLink(Relations.Self, $"/api/resources/{new Uri(view.Url).Host}/{view.Id}");

            return r;
        }

        public static ResourceCacheRepresentation MakeRepresentation(ResourceCacheView view)
        {
            var r = new ResourceCacheRepresentation
            {
                Url = view.Url,
                Cache = view.Cache
            };

            r.AddLink(Relations.Self, $"/api/resources/{new Uri(view.Url).Host}/{view.Id}");

            return r;
        }
    }
}