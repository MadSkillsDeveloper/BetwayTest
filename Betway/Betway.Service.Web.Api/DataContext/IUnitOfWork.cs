namespace Betway.Service.Web.Api.DataContext
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
