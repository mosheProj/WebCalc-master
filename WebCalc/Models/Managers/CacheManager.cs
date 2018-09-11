using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using WebCalc.Interfaces;

namespace WebCalc.Models
{
    public class CacheManager : ICacheManager
    {

        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;   

        private int _expiredInMinute => int.Parse(_config.GetSection("cache:expiredInMinute").Value);
        public CacheManager(IConfiguration config, 
                            IMemoryCache cache)
        {
            _config = config;
            _cache = cache;
        }
        public bool Exist(string key)
        {
            decimal result;
            return _cache.TryGetValue(key, out result);
        }
        public decimal Get(string key)
        {
            return _cache.Get<decimal>(key);
        }
        public void Insert(string key, decimal value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromMinutes(_expiredInMinute));

            _cache.Set(key, value, cacheEntryOptions);
        }
    }
}
