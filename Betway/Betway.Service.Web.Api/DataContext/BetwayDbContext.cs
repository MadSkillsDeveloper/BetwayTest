using Microsoft.EntityFrameworkCore;

namespace Betway.Service.Web.Api.DataContext
{
    public class BetwayDbContext : DbContext
    {
        #region Fields
        #endregion

        #region Properties
        public DbSet<User> Users;
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User(1, "lulamile.gaji@gmail.com",
                "$2a$11$yjw06UBulYLya4MrTo/.2eqq6BWYli0elKZdER4NU5.c8ZZ0iZ2VO"));
        }
        #endregion

        #region Constructors
        public BetwayDbContext(DbContextOptions<BetwayDbContext> options)
            : base(options)
        {

        }
        #endregion
    }
}
