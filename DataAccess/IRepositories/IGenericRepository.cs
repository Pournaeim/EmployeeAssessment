using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace DataAccess.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<bool> Add(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Upsert(T entity);
        Task<bool> Delete(int id);

    }
}
