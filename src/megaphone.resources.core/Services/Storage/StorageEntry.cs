using System;

namespace Megaphone.Resources.Core.Services.Storage
{
    public class StorageEntry<T> where T : new()
    {
        private T value;

        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;

                Updated = DateTimeOffset.UtcNow;
            }
        }

        public bool HasValue => Value != null;
    }
}
