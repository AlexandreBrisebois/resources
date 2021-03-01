using megaphone.resources.core;
using Megaphone.Resources.Controllers;
using Megaphone.Resources.Core.Models;
using Megaphone.Standard.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Megaphone.Resources.Tests
{
    public class ResourceApiTests
    {

        //[Fact]
        //public async Task PostResourceTest()
        //{
        //    ResourceController controller = new(new ResourceService(new InMemoryStorageService<Resource>()));

        //    var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
        //    var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/") };

        //    var response = await controller.PostAsync(input);

        //    Assert.IsType<AcceptedResult>(response);
        //}

        //[Fact]
        //public async Task GetResourceRepresentationTest()
        //{
        //    ResourceController controller = new(new ResourceService(new InMemoryStorageService<Resource>()));

        //    var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
        //    var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached value" };

        //    await controller.PostAsync(input);

        //    var representation = await controller.GetResource(id);

        //    Assert.Equal(input.Self.ToString(), representation.Url);
        //}

        //[Fact]
        //public async Task GetResourceCacheRepresentationTest()
        //{
        //    ResourceController controller = new(new ResourceService(new InMemoryStorageService<Resource>()));

        //    var id = "d64bc5a5-f2d2-572c-bfbf-b99e5340c0d9";
        //    var input = new Resource { Id = id, Self = new Uri("https://devblogs.microsoft.com/dotnet/staying-safe-with-dotnet-containers/"), Cache = "cached value" };

        //    await controller.PostAsync(input);

        //    var representation = await controller.GetResourceCache(id);

        //    Assert.Equal("cached value", representation.Cache);
        //}
    }
}
