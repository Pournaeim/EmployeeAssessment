using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IRepository<Entity> where Entity : BaseEntity, new()
    {
        void Create(Entity entity);
        Entity Get(int id);
        IEnumerable<Entity> GetAll();
        IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate);
        void Update(Entity entity);
        void Delete(Entity entity);
        void SaveChanges();

    }
}
