using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Domain.Abstractions.Pagination
{
    [ExcludeFromCodeCoverage]
    public class PagedResult<T>
        where T : class
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        private readonly IReadOnlyCollection<T> _items;
        public IReadOnlyCollection<T> Items => _items?.Take(PageSize).ToList() ?? null;
        public bool HasPreviousPage => PageIndex > 1;
        public int? PreviousPage => HasPreviousPage ? PageIndex - 1 : default(int?);

        public readonly bool? _hasNextPage;
        public bool HasNextPage => _hasNextPage ?? PageSize < (_items?.Count ?? default);
        public int? NextPage => HasNextPage ? PageIndex + 1 : default(int?);

        public PagedResult()
        {
        }

        public PagedResult(IReadOnlyCollection<T> items, int pageIndex, int pageSize, bool hasNextPage)
            : this(items, pageIndex, pageSize)
        {
            _hasNextPage = hasNextPage;
        }

        private PagedResult(IReadOnlyCollection<T> items, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            _items = items;
        }

        private PagedResult(IReadOnlyCollection<T> items)
        {
            _items = items;
        }

        public static async Task<PagedResult<T>> CreateAsync(IQueryable<T> source, PageParams pageParams, CancellationToken cancellationToken)
        {
            var items = await source.Skip((pageParams.PageIndex - 1) * pageParams.PageSize).Take(pageParams.PageSize + 1).ToListAsync(cancellationToken);
            return new PagedResult<T>(items, pageParams.PageIndex, pageParams.PageSize);
        }

        public static PagedResult<T> CreateEmpty() => new PagedResult<T>(new List<T>());
    }
}
