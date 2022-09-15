
using DataAccess.Common;
using DataAccess.IRepositories;

using DataAccsee.IRepositories;

using Domain.Employee;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

using System.ComponentModel;

namespace DataLayer.SqlServer.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} All method error", typeof(EmployeeRepository));
                return new List<Employee>();
            }
        }

        public override async Task<bool> Upsert(Employee employee)
        {
            try
            {
                var existingEmployee = await dbSet.Where(x => x.Id == employee.Id).FirstOrDefaultAsync();
                if (existingEmployee == null)
                {
                    return await Add(employee);
                }

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.MiddleName = employee.MiddleName;
                existingEmployee.LastName = employee.LastName;

                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Upsert method error", typeof(EmployeeRepository));
                return false;
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var removableEmployee = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (removableEmployee != null)
                {
                    dbSet.Remove(removableEmployee);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(EmployeeRepository));
                return false;
            }
        }
    }
}
