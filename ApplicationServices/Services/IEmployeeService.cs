using ApplicationServices.Models;

using Domain.Employee;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public interface IEmployeeService
    {
        int AddNew(EmployeeDto entity);
        EmployeeDto Get(int id);
        IEnumerable<EmployeeDto> Get(Expression<Func<EmployeeDto, bool>> predicate);
        IEnumerable<EmployeeDto> GetAll();
        void Update(EmployeeDto entity);
        void Remove(int id);
        void SaveChanges();

    }
}
