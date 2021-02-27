﻿using System;

namespace Megaphone.Resources.Services
{
    public class StorageEntry<T> where T : new()
    {
        public DateTimeOffset Updated { get; set; } = DateTimeOffset.UtcNow;

        public T Value { get; set; }

        public bool HasValue => Value != null;
    }
}
