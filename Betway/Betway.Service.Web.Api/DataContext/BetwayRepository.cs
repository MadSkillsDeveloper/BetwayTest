using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Betway.Service.Web.Api.DataContext
{
    public class BetwayRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Fields
        private readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<IList<TEntity>> AddListAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return Task.FromResult(entities.ToList()).Result;
        }
        #endregion

        #region Constructors
        public BetwayRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        #endregion
    }
}
