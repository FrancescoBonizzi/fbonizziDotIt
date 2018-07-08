using fbonizziDotIt.Data.Infrastructure;
using fbonizziDotIt.Domain;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace fbonizziDotIt.Data
{
    public class CachedDataProvider : ICachedDataProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IDataProvider _dataProvider;

        public CachedDataProvider(
           IMemoryCache memoryCache,
           IDataProvider dataProvider)
        {
            _cache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public Task<WhatIWantToShowTheWorld> GetData(CancellationToken cancellationToken)
        {
            return _cache.GetOrCreateAsync(
                "WhatIWantToShowTheWorld-GetData",
                cacheEntry =>
                {
                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return _dataProvider.GetData(cancellationToken);
                });
        }
    }
}
