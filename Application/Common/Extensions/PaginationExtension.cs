using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Extensions
{
    public static class PaginationExtension
    {
        public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(this IQueryable<TDestination> query, int pageNumber, int pageSize) where TDestination : class => PaginatedList<TDestination>.CreateAsync(query.AsNoTracking(), pageNumber, pageSize);
    }
}
