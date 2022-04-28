namespace SourDictionary.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Insert Methods
        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual int Add(TEntity entity)
        {
            Entities.Add(entity);
            return _context.SaveChanges();
        }

        public virtual async Task<int> AddAsync(IEnumerable<TEntity> entities)
        {
            if (entities != null && !entities.Any())
                return 0;

            await Entities.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public virtual int Add(IEnumerable<TEntity> entities)
        {
            if (entities is null && !entities.Any())
                return 0;

            Entities.AddRange(entities);
            return _context.SaveChanges();
        }
        #endregion

        #region Update Methods
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public virtual int Update(TEntity entity)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges();
        }
        #endregion

        #region Delete Methods
        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }

            Entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var entity = await Entities.FindAsync(id);
            if (entity is null)
                return 0;

            return await DeleteAsync(entity);
        }

        public virtual int Delete(Guid id)
        {
            var entity = Entities.Find(id);
            if (entity is null)
                return 0;

            return Delete(entity);
        }

        public virtual int Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }

            Entities.Remove(entity);
            return _context.SaveChanges();
        }

        public virtual bool DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            _context.RemoveRange(Entities.Where(predicate));
            return _context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            _context.RemoveRange(Entities.Where(predicate));
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion

        #region AddOrUpdate Methods

        public virtual Task<int> AddOrUpdateAsync(TEntity entity)
        {
            // check the entity with the id already tracked
            if (!Entities.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                _context.Update(entity);

            return _context.SaveChangesAsync();
        }

        public virtual int AddOrUpdate(TEntity entity)
        {
            if (!Entities.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                _context.Update(entity);

            return _context.SaveChanges();
        }

        #endregion

        #region Get Methods

        public virtual IQueryable<TEntity> AsQueryable() => Entities.AsQueryable();
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Entities.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query;
        }


        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            return Get(predicate, noTracking, includes).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll(bool noTracking = true)
        {
            if (noTracking)
                return await Entities.AsNoTracking().ToListAsync();

            return await Entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            TEntity found = await Entities.FindAsync(id);

            if (found == null)
                return null;

            if (noTracking)
                _context.Entry(found).State = EntityState.Detached;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                _context.Entry(found).Reference(include).Load();
            }

            return found;
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();

        }

        #endregion

        #region Bulk Methods

        public virtual async Task BulkDeleteByIdAsync(IEnumerable<Guid> ids)
        {
            if (ids is null && !ids.Any())
            {
                await Task.CompletedTask;
                return;
            }

            _context.RemoveRange(Entities.Where(i => ids.Contains(i.Id)));
            await _context.SaveChangesAsync();
        }

        public virtual async Task BulkDeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            _context.RemoveRange(Entities.Where(predicate));
            await _context.SaveChangesAsync();
        }

        public virtual async Task BulkDeleteAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null && !entities.Any())
            {
                await Task.CompletedTask;
                return;
            }

            Entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task BulkUpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null && !entities.Any())
            {
                await Task.CompletedTask;
                return;
            }

            Entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task BulkAddAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null && !entities.Any())
            {
                await Task.CompletedTask;
                return;
            }

            await Entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region SaveChanges Methods

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        #endregion


        private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes is null)
                return query;

            foreach (var includeItem in includes)
            {
                query = query.Include(includeItem);
            }

            return query;
        }
    }
}
