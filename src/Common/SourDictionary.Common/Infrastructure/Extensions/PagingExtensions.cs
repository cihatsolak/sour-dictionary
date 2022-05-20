namespace SourDictionary.Common.Infrastructure.Extensions
{
    public static class PagingExtensions
    {
        public static async Task<PagedViewModel<T>> GetPagedAsync<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
        {
            int count = await query.CountAsync();
            Page paging = new(pageSize, count, currentPage);

            var data = await query.Skip(paging.Skip).Take(paging.PageSize).AsNoTracking().ToListAsync();

            var result = new PagedViewModel<T>(data, paging);

            return result;
        }
    }
}
