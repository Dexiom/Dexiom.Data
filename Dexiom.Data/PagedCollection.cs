using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dexiom.Data.Extensions;

namespace Dexiom.Data
{
    public class PagedCollection<TData>
        : IPagedCollection<TData>
    {
        private readonly IEnumerable<TData> _pageData;

        #region Constructors
        public PagedCollection(IQueryable<TData> data, int pageSize, int pageNumber)
        {
            _pageData = data.GetPage(pageSize, pageNumber);
            Count = data.Count();
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        
        public PagedCollection(IEnumerable<TData> pageData, int totalItemCount, int pageSize, int pageNumber)
        {
            _pageData = pageData;
            Count = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        #endregion

        #region IEnumerable<TData>
        public IEnumerator<TData> GetEnumerator()
        {
            return _pageData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region IReadOnlyCollection<TData>

        public int Count { get; set; }

        #endregion

        #region IPaged
        private int? _pageCount;
        public int PageCount
        {
            get
            {
                if (!_pageCount.HasValue)
                    _pageCount = (int)Math.Ceiling((double)Count / PageSize);

                return _pageCount.Value;
            }
        }
        
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        #endregion

    }
}