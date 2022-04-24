namespace SourDictionary.Api.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);

        int Add(IEnumerable<TEntity> entities);
        Task<int> AddAsync(IEnumerable<TEntity> entities);

        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);

        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);

        int Delete(Guid id);
        Task<int> DeleteAsync(Guid id);

        bool DeleteRange(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);

        int AddOrUpdate(TEntity entity);
        Task<int> AddOrUpdateAsync(TEntity entity);

        IQueryable<TEntity> AsQueryable();
        Task<List<TEntity>> GetAll(bool noTracking = true);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

        Task BulkDeleteByIdAsync(IEnumerable<Guid> ids);
        Task BulkDeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task BulkDeleteAsync(IEnumerable<TEntity> entities);
        Task BulkUpdateAsync(IEnumerable<TEntity> entities);
        Task BulkAddAsync(IEnumerable<TEntity> entities);
    }
}
