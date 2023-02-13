using Microsoft.EntityFrameworkCore;

namespace Betway.Service.Web.Api.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DbContext _dbContext;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new BetwayRepository<TEntity>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Constructors
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        #endregion
    }
}
