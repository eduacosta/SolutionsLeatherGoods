﻿namespace ASF.UI.WbSite.Constants
{
    using System;

    public static class CacheSetting
    {
        public static class SitemapNodes
        {
            public const string Key = "SitemapNodes";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }

        public static class CategoryCache
        {
            public const string Key = "CategoryCache";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }


        public static class IdiomaCache
        {
            public const string Key = "IdiomaCache";
            public static readonly TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }



    }
}