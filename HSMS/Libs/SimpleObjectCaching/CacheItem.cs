using System;

namespace HSMS.Libs.SimpleObjectCaching
{
    internal class CacheItem
    {
        private readonly object key;
        private readonly object value;

        private DateTime lastAccessTime = DateTime.Now;

        public CacheItem(object key, object value)
        {
            this.key = key;
            this.value = value;
        }

        public bool IsExpired
        {
            get
            {
                DateTime temp = lastAccessTime.AddSeconds(CacheManager.CACHE_EXPIRY);
                return temp.CompareTo(DateTime.Now) < 0;
            }
        }

        public object Key
        {
            get { return key; }
        }

        public object Value
        {
            get
            {
                if (IsExpired) return null;
                lastAccessTime = DateTime.Now;
                return value;
            }
        }
    }
}