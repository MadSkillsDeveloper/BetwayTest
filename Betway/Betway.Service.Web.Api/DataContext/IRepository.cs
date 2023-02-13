using System.Linq.Expressions;

namespace Betway.Service.Web.Api.DataContext
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<IList<TEntity>> AddListAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}
