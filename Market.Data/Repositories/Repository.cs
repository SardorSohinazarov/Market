using Market.Data.DbContexts;
using Market.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Market.Data.Repositories
{
    public class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        protected readonly MarketDbContext _dbContext;
        protected readonly DbSet<TSource> _dbSet;

        public Repository(MarketDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TSource>();
        }

        public async Task<TSource> AddAsync(TSource entity)
        {
            var entry = _dbSet.Add(entity);

            return entry.Entity;
        }

        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string include = null, bool tracking = true)
        {
            IQueryable<TSource> query = expression is null ? _dbSet : _dbSet.Where(expression);

            if(!string.IsNullOrEmpty(include))
                query = query.Include(include);

            if(!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression = null, string include = null)
        {
            return await GetAll(expression,include).FirstOrDefaultAsync();
        }

        public async Task<TSource> UpdateAsync(TSource entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public async Task DeleteAsync(Expression<Func<TSource, bool>> expression)
        {
            var entity = await GetAsync(expression);

            _dbSet.Remove(entity);
        }
    }
}
