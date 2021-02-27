using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Views;
using System.Threading.Tasks;

namespace megaphone.resources.core
{
    public interface IResourceService
    {
        Task AddAsync(Resource r);
        Task<ResourceView> GetAsync(string id);
        Task<ResourceCacheView> GetCacheAsync(string id);
    }
}