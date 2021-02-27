using Megaphone.Resources.Controllers;
using Megaphone.Resources.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Megaphone.Resources.Tests
{
    public class ResourceApiTests
    {

        [Fact]
        public async Task PostResourceTest()
        {
            ILogger<ResourceController> logger = new ListLogger<ResourceController>();

            ResourceController controller = new(logger);

            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/") };

            var response = await controller.PostAsync(input);

            Assert.IsType<AcceptedResult>(response);
        }

        [Fact]
        public async Task GetResourceRepresentationTest()
        {
            ILogger<ResourceController> logger = new ListLogger<ResourceController>();

            ResourceController controller = new(logger);

            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached value" };

            await controller.PostAsync(input);

            var representation = await controller.GetResource(id);

            Assert.Equal(input.Self.ToString(), representation.Url);
        }

        [Fact]
        public async Task GetResourceCacheRepresentationTest()
        {
            ILogger<ResourceController> logger = new ListLogger<ResourceController>();

            ResourceController controller = new(logger);

            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached value" };

            await controller.PostAsync(input);

            var representation = await controller.GetResourceCache(id);

            Assert.Equal("cached value", representation.Cache);
        }
    }
}
