using System.Data.Entity;

namespace Sanofi.Sap.DataAccess.Requests
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected SapDbContext Context { get; }

        protected DbSet<TEntity> DbSet { get; }

        public Repository(SapDbContext dbContext)
        {
            Context = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public void Save(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Add(entity);
            }
        }
    }
}