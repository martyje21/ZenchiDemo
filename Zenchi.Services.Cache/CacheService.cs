using Zenchi.Domain.ServiceInterfaces;
using System;


namespace Zenchi.Services.Cache
{
    // This service implementation resides in the web application project rather than a separate class library
    // because it leverages the System.Web.Caching which is already available in the project. 
    public class CacheService : ICacheService
    {
        public object Get(string key)
        {
            return System.Web.HttpContext.Current.Cache.Get(key);
        }

        public void Insert(string key, object value, DateTime expiration)
        {
            System.Web.HttpContext.Current.Cache.Insert(key, value, null, expiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }
    }
}