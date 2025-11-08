using System;
using System.Threading.Tasks;
using DesignPatterns;

namespace Programs
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // new AllPrograms().CallPrograms();
            //await new AllPatterns().CallAllPatterns();

            // Caching
            ////var inMemcache = new InMemoryCaching();
            ////inMemcache.ExecuteCaching();
            ////inMemcache.ExecuteCaching();
            ////await Task.Delay(60000);
            ////inMemcache.ExecuteCaching();
            var distCache = new DistributedCaching();
            await distCache.ExecuteCachingAsync();
            await distCache.ExecuteCachingAsync();
            await Task.Delay(60000);
            await distCache.ExecuteCachingAsync();
        }
    }
}
