using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;
using System.Text.Json;
using System.Threading.Tasks;
namespace Programs
{
    /*
     * Caching means temporarily storing frequently used data (like API responses, database results, static content, etc.) in faster memory so that the next request for the same data can be served more quickly.
     * Typically, caching is implemented using in-memory data stores like Redis or Memcached, or even local memory within an application.
     * Types of Caching:
     * . In-Memory Caching: Storing data in the application's memory for quick access.(This is ideally used in one application)
     * . Distributed Caching: Using external systems like Redis or Memcached(Redis, NCache, Azure Cache for Redis) to store cached data, allowing multiple application instances to share the same cache.(This is best for sharing between multiple applicaitons)
     * . Output Caching: Storing the output of expensive operations (like rendering a web page) to serve it faster on subsequent requests.
     * . Database cache: Inside the database system itself to speed up query performance(SQL Server buffer pool, EF second-level cache).
     * . Client-side cache: The browser caches static resources (like images, CSS, JavaScript) to reduce load times on subsequent visits(Angular HTTP cache, browser storage).
     * Eviction Policies: 
     *  . Least Recently Used (LRU): Removes the least recently accessed items first.
     *  . LFU (Least Frequently Used): Removes the least frequently accessed items first.
     *  . First In First Out (FIFO): Removes the oldest items first.
     *  . Time-to-Live (TTL): Items are removed after a specified time period.
     *  . 
     */
    public class InMemoryCaching
    {
        private readonly IMemoryCache caching;
        private readonly string cacheKey = "cahce_123";

        public InMemoryCaching()
        {
            // use Microsoft.Extensions.Caching.Memory; nuget package.
            // use this as dependency injection in real world application
            caching = new MemoryCache(new MemoryCacheOptions());
        }

        public string ExecuteCaching()
        {
            if (this.caching.TryGetValue(cacheKey, out string? cacheValue))
            {
                Console.WriteLine("Cache hit. Retrieved from cache: " + cacheValue);

                return cacheValue;
            }
            // Simulate data retrieval (e.g., from a database or API)
            Console.WriteLine("Cache miss. Fetching data...");
            cacheValue = "Data fetched at " + DateTime.Now.ToString();

            // Set cache options with 1 mins expiration
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            // Store data in cache
            this.caching.Set(cacheKey, cacheValue, cacheOptions);
            Console.WriteLine("Cache value is set");

            return cacheValue;
        }
    }

    /*
     * Unlike IMemoryCache (which lives in one app instance’s RAM), distributed caching stores data in a shared external cache that all app instances can access — typically a Redis server.This ensures:
       - All APIs share the same cached data
       - Cache survives app restarts
       - Scales better in cloud setups
     */
    public class DistributedCaching
    {
        private readonly IDistributedCache caching;
        private readonly string cacheKey = "cahce_123";

        public DistributedCaching()
        {
            /*
                 use using Microsoft.Extensions.Caching.StackExchangeRedis;; nuget package.
                // use this as dependency injection in real world application
                builder.Services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = "localhost:6379"; // or your Azure Redis endpoint
                    options.InstanceName = "DemoApp_";        // prefix for all keys
                });
                Post that you can inject IDistributedCache in constructor.
            */
            this.caching = new RedisCache(new RedisCacheOptions()
            {
                Configuration = "localhost:6379", // Redis server configuration
                InstanceName = "SampleInstance"
            });
        }

        public async Task<string> ExecuteCachingAsync()
        {
            var cached = await this.caching.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cached))
            {
                Console.WriteLine("Cache hit. Retrieved from cache: " + cached);
                return JsonSerializer.Deserialize<string>(cached)!;
            }

            // Simulate data retrieval (e.g., from a database or API)
            Console.WriteLine("Cache miss. Fetching data...");
            var cacheValue = "Data fetched at " + DateTime.Now.ToString();

            // Set cache options with 1 mins expiration
            var cacheOptions = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            // Store data in cache
            await this.caching.SetStringAsync(cacheKey, JsonSerializer.Serialize(cacheValue), cacheOptions);
            Console.WriteLine("Cache value is set");

            return cacheValue;
        }
    }
}
