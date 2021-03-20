using Megaphone.Resources.Core.Models;
using Megaphone.Resources.Core.Services.Storage;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Megaphone.Resources.Services
{
    public class FileSystemResourceStorageService : IResourceStorageService
    {
        private string path;

        public FileSystemResourceStorageService()
        {
            path = Environment.GetEnvironmentVariable("DATA_PATH");
        }

        public async Task<StorageEntry<Resource>> GetAsync(string partitionKey, string contentKey)
        {
            string filePath = $"{path}/{partitionKey}/{contentKey}";

            if (File.Exists(filePath))
            {
                using var stream = File.OpenRead(filePath);
                using var reader = new StreamReader(stream);

                var content = await reader.ReadToEndAsync();
                var obj = JsonSerializer.Deserialize<StorageEntry<Resource>>(content);
                return obj;
            }

            return new StorageEntry<Resource>();
        }

        public async Task SetAsync(string partitionKey, string contentKey, StorageEntry<Resource> content)
        {
            string filePath = $"{path}/{partitionKey}/{contentKey}";

            var fileInfo = new FileInfo(filePath);
            fileInfo.Directory.Create();

            using var stream = fileInfo.Create();
            using var writer = new StreamWriter(stream);

            await writer.WriteAsync(JsonSerializer.Serialize(content));
            await writer.FlushAsync();
        }
    }
}
