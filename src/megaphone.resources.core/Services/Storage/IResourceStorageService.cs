using Megaphone.Resources.Core.Models;
using Megaphone.Standard.Services;

namespace Megaphone.Resources.Core.Services.Storage
{
    public interface IResourceStorageService : IPartionedStorageService<StorageEntry<Resource>>
    {

    }
}