using System;
using System.Collections.Generic;
using System.Linq;

namespace Dexiom.Data
{
    public interface IPaged : IPageable
    {
        int PageCount { get; }
        int PageNumber { get; set; }
    }
}
