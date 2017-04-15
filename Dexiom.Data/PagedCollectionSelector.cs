using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dexiom.Data
{
    public class PagedCollectionSelector<TData>
        : IPagedCollection<TData>
    {
        private readonly IEnumerable<TData> _data;
        
        public PagedCollectionSelector(IEnumerable<TData> data, int pageNumber, int pageSize)
        {
            _data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        
        #region IEnumerable<TData>
        public IEnumerator<TData> GetEnumerator()
        {
            var pageIndex = PageNumber - 1;

            if (pageIndex < 0)
                yield break;

            foreach (var row in _data.Skip(pageIndex * PageSize).Take(PageSize))
            {
                yield return row;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
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

        private int? _itemCount;
        public int Count
        {
            get
            {
                if (!_itemCount.HasValue)
                    _itemCount = _data.Count();

                return _itemCount.Value;
            }
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        #endregion
    }
}