using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Views;
using System.Threading.Tasks;

namespace Megaphone.Resources.Core.Services.Storage
{
    public interface IResourceService
    {
        Task AddAsync(Resource r);
        Task<ResourceView> GetAsync(string host, string id);
        Task<ResourceCacheView> GetCacheAsync(string host, string id);
    }
}