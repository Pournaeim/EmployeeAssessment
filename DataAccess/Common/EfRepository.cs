using DataAccess.Common;
using Domain.Common;
using System.Linq.Expressions;

namespace DataLayer.SqlServer.Common
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly ApplicationContext dbContext;
        public EfRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {

            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToArray();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
