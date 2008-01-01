using System.Collections.Generic;

namespace HSMS.Libs.SimpleObjectCaching
{
    public class Cache
    {
        private readonly string name;
        private readonly IDictionary<object, CacheItem> cacheItems = new Dictionary<object, CacheItem>();

        internal Cache(string name)
        {
            this.name = name;
        }

        public object this[object key]
        {
            get
            {
                if (key == null) return null;
                CacheItem ci;
                try
                {
                    ci = cacheItems[key];
                }
                catch (KeyNotFoundException)
                {
                    ci = null;
                }
                if (ci == null) return null;
                if (ci.IsExpired)
                {
                    cacheItems.Remove(key);
                    return null;
                }
                return ci.Value;
            }
            set
            {
                if (key == null) return;
                if (value != null)
                {
                    CacheItem ci = new CacheItem(key, value);
                    cacheItems[key] = ci;
                }
                else
                {
                    cacheItems.Remove(key);
                }
            }
        }

        public string Name
        {
            get { return name; }
        }

        public int Size
        {
            get { return cacheItems.Count; }
        }

        internal void Invalidate()
        {
            lock (cacheItems)
            {
                foreach (KeyValuePair<object, CacheItem> item in cacheItems)
                {
                    if (item.Value.IsExpired)
                    {
                        cacheItems.Remove(item);
                    }
                }
            }
        }

        public void Add(object key, object value)
        {
            this[key] = value;
        }

        public object Get(object key)
        {
            return this[key];
        }

        public void Remove(object key)
        {
            this[key] = null;
        }
    }
}