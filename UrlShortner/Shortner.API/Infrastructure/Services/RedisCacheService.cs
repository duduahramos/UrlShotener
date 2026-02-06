using StackExchange.Redis;
using Shortner.API.Application.Interfaces;

namespace Shortner.API.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _cacheDB;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _cacheDB = redis.GetDatabase();
        }
        
        public Task<bool> SaveAsync(string key, string value, int _urlExpirationInSeconds)
        {
            return _cacheDB.StringSetAsync(key, value, TimeSpan.FromSeconds(_urlExpirationInSeconds));
        }
    
        public async Task<string> GetAsync(string key)
        {
            return await _cacheDB.StringGetAsync(key);
        }
    }
}