using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Services.Storage;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Megaphone.Resources.Core.Tests
{
    public class ResourceServiceTests
    {
        [Fact]
        public void CreateResourceServiceInstance()
        {
            var service = new ResourceService(new InMemoryResourceStorageService());
        }

        [Fact]
        public async Task AddResource()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var service = new ResourceService(new InMemoryResourceStorageService());
            Uri uri = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/");
        }

        [Fact]
        public async Task GetResourceById()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var service = new ResourceService(new InMemoryResourceStorageService());
            Uri uri = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/");
            await service.AddAsync(new Resource { Id = id, Self = uri });
            var resource = await service.GetAsync(uri.Host, id);

            Assert.Equal(id, resource.Id);
        } 
        
        [Fact]
        public async Task GetResourceCacheById()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var service = new ResourceService(new InMemoryResourceStorageService());
            Uri uri = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/");
            await service.AddAsync(new Resource { Id = id, Self = uri, Cache = "cached content"});
            var resource = await service.GetCacheAsync(uri.Host, id);

            Assert.Equal(id, resource.Id);
            Assert.Equal("cached content", resource.Cache);
        }
    }
}
