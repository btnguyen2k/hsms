using System.Collections.Generic;
using System.Threading;

namespace HSMS.Libs.SimpleObjectCaching
{
    public class CacheManager
    {
        public const int CACHE_EXPIRY = 3600;

        public const string DEFAULT_CACHE_NAME = "DEFAULT";

        private const int THREAD_SLEEP_MILLIS = 5*60*1000;

        private static readonly IDictionary<string, Cache> caches = new Dictionary<string, Cache>();

        static CacheManager()
        {
            Thread testThread = new Thread(Invalidate);
            testThread.IsBackground = true;
            testThread.Start();
        }

        private static void Invalidate()
        {
            while (true)
            {
                lock (caches)
                {
                    foreach (KeyValuePair<string, Cache> cache in caches)
                    {
                        cache.Value.Invalidate();
                    }
                }
                Thread.Sleep(THREAD_SLEEP_MILLIS);
            }
        }

        public static Cache GetCache()
        {
            return GetDefaultCache();
        }

        public static Cache GetCache(string name)
        {
            lock (caches)
            {
                Cache c;
                try
                {
                    c = caches[name];
                }
                catch (KeyNotFoundException)
                {
                    c = null;
                }
                if (c == null)
                {
                    c = new Cache(name);
                    caches[name] = c;
                }
                return c;
            }
        }

        public static Cache GetDefaultCache()
        {
            return GetCache(DEFAULT_CACHE_NAME);
        }
    }
}