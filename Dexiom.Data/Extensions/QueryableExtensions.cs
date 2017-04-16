using System;
using System.Collections.Generic;
using System.Linq;

namespace Dexiom.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static int GetPageCount<T>(this IQueryable<T> source, int pageSize)
        {
            return (int)Math.Ceiling((double)source.Count() / pageSize);
        }

        public static List<T> GetPage<T>(this IQueryable<T> source, int pageSize, int pageNumber)
        {
            var pageIndex = pageNumber - 1;
            return pageIndex < 0 ? new List<T>() : source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        
        public static PagedCollection<T> GetPagedCollection<T>(this IQueryable<T> source, int pageSize, int pageNumber)
        {
            return new PagedCollection<T>(source, pageSize, pageNumber);
        }
    }
}
