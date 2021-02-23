using megaphone.resources.core;
using Megaphone.Resources.Core.Models;
using Megaphone.Standard.Services;
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
            var service = new ResourceService(new InMemoryPartitionedStorageService<Resource>());
        }

        [Fact]
        public async Task AddResource()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var service = new ResourceService(new InMemoryPartitionedStorageService<Resource>());
            await service.AddAsync(new Resource() { Id = id });
        }

        [Fact]
        public async Task GetResourceById()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var service = new ResourceService(new InMemoryPartitionedStorageService<Resource>());
            await service.AddAsync(new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/") });
            var resource = await service.GetAsync(id);

            Assert.Equal(id, resource.Id);
        } 
        
        [Fact]
        public async Task GetResourceCacheById()
        {
            var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
            var service = new ResourceService(new InMemoryPartitionedStorageService<Resource>());
            await service.AddAsync(new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached content"});
            var resource = await service.GetCacheAsync(id);

            Assert.Equal(id, resource.Id);
            Assert.Equal("cached content", resource.Cache);
        }
    }
}
