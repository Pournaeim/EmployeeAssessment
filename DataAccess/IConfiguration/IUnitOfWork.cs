
using DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IConfiguration
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }

        Task CompleteAsync();
    }
}
