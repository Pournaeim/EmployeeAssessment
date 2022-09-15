using Domain.Common;
using Domain.Employee;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
