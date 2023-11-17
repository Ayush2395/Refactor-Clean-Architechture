using Microsoft.EntityFrameworkCore;

namespace Application.Common.Models
{
    public class PaginatedList<T>
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
        public IReadOnlyCollection<T> Items { get; private set; }

        public PaginatedList(int pageNumber, int pageSize, int totalCount, IReadOnlyCollection<T> items)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(pageNumber / (decimal)pageSize);
            TotalCount = totalCount;
            Items = items;
        }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = items.Count;
            return new PaginatedList<T>(pageNumber, pageSize, count, items);
        }
    }
}
