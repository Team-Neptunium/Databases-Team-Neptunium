namespace BoardgameSimulator.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IBoardgameSimulatorDbContext context;
        private IDbSet<T> set;

        public GenericRepository(IBoardgameSimulatorDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            //var entry = AttachIfDetached(entity);
            //entry.State = EntityState.Added;

            this.set.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            //var entry = AttachIfDetached(entity);
            //entry.State = EntityState.Deleted;

            this.set.Remove(entity);
        }

        public void Detach(T entity)
        {
            DbEntityEntry<T> entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            DbEntityEntry<T> entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
