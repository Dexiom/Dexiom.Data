using System;
using System.Collections.Generic;
using System.Linq;

namespace Dexiom.Data
{
    public interface IPageable
    {
        int Count { get; }
        int PageSize { get; }
    }
}
