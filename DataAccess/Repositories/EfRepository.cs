using DataAccess.Common;
using Domain.IRepositories;
using Domain.Common;

namespace DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly ApplicationDbContext dbContext;

        public EfRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Add(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
            return true;
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public bool Upsert(T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return true;
        }

    }

}
