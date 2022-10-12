using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Domain.Abstractions.Pagination
{
    [ExcludeFromCodeCoverage]
    public class PageParams
    {
        private const int DefaultSize = 20;
        private const int DefaultIndex = 1;

        public int PageSize { get; private set; }
        public int PageIndex { get; private set; }

        public PageParams(int pageIndex, int pageSize)
        {
            PageSize = pageSize <= 0 ? DefaultSize : pageSize;
            PageIndex = pageIndex <= 0 ? DefaultIndex : pageIndex;
        }

        public PageParams()
        {
            PageSize = DefaultSize;
            PageIndex = DefaultIndex;
        }
    }
}
