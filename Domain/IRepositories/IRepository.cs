using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Domain.Common;

namespace Domain.IRepositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        bool Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Upsert(T entity);
        bool Delete(T entity);

    }
}
