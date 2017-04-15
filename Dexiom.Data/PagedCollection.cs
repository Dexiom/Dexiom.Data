using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dexiom.Data
{
    public class PagedCollection<TData>
        : IPagedCollection<TData>
    {
        private readonly IEnumerable<TData> _pageData;
        
        public PagedCollection(IEnumerable<TData> pageData, int pageNumber, int pageSize, int totalItemCount)
        {
            _pageData = pageData;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Count = totalItemCount;
        }
        
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
        
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        #endregion

    }
}