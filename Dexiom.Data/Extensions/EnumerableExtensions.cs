using System;
using System.Collections.Generic;
using System.Linq;

namespace Dexiom.Data.Extensions
{
    public static class EnumerableExtensions
    {
        public static int GetPageCount<T>(this IEnumerable<T> source, int pageSize)
        {
            return (int)Math.Ceiling((double)source.Count() / pageSize);
        }

        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> source, int pageSize, int pageNumber)
        {
            var pageIndex = pageNumber - 1;
            return pageIndex < 0 ? Enumerable.Empty<T>() : source.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public static IEnumerable<IEnumerable<T>> GetPages<T>(this IEnumerable<T> source, int pageSize)
        {
            var list = source as IList<T> ?? source.ToList();
            for (var i = 1; i <= GetPageCount(list, pageSize); i++)
            {
                yield return GetPage(list, pageSize, i);
            }
        }

        public static IPagedCollection<T> GetPagedCollection<T>(this IEnumerable<T> source, int pageSize, int pageNumber)
        {
            return new PagedCollectionSelector<T>(source, pageNumber, pageSize);
        }
    }
}
