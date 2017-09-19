using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCache
    {
        private static DataCache _instance;

        private static readonly  object InstanceLock = new object();

        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                {

                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCache();
                        }
                    }
                }

                return _instance;
            }

        }

        private readonly ICacheService _cacheService;

        private DataCache()
        {

            _cacheService = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> ProductoList(int id)
        {

            var lista = _cacheService.GetOrAdd(CacheSetting.CategoryCache.Key, () =>
            {
                var cp = new ProcessComponent<Category>();
                return cp.SelectList();

            }, CacheSetting.CategoryCache.SlidingExpiration);

            return lista.ToList();
        }


    }
}