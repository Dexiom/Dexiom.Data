using System.Collections.Generic;

namespace Dexiom.Data
{
    public interface IPagedCollection<out TData> : IReadOnlyCollection<TData>, IPaged
    {
    }
}