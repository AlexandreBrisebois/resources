using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Representations;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Megaphone.Resources.Tests
{
    public class ResourceFunctionsTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async Task PostResourceTest()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/") };

            var response = await ResourceFunctions.PostResource(TestFactory.CreatePostHttpRequest(input), logger);

            var resource = JsonSerializer.Deserialize<ResourceRepresentation>(response.Content);

            Assert.Equal(input.Self.ToString(), resource.Url);

        }

        [Fact]
        public async Task GetResourceRepresentationTest()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached value" };

            var response = await ResourceFunctions.PostResource(TestFactory.CreatePostHttpRequest(input), logger);

            var representation = await ResourceFunctions.GetResource(TestFactory.CreateGetHttpRequest(), id,logger);

            var resource = JsonSerializer.Deserialize<ResourceRepresentation>(representation.Content);

            Assert.Equal(input.Self.ToString(), resource.Url);
        } 
        
        [Fact]
        public async Task GetResourceCacheRepresentationTest()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached value" };

            var response = await ResourceFunctions.PostResource(TestFactory.CreatePostHttpRequest(input), logger);

            var representation = await ResourceFunctions.GetResourceCache(TestFactory.CreateGetHttpRequest(), id,logger);

            var resource = JsonSerializer.Deserialize<ResourceCacheRepresentation>(representation.Content);

            Assert.Equal("cached value", resource.Cache);
        }
    }
}
