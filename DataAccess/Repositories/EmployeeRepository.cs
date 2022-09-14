using DataAccess.Common;

using DataLayer.SqlServer.Common;
using Domain.Employee;

namespace DataLayer.SqlServer.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        ApplicationContext _dbcontext;
        public EmployeeRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _dbcontext = DbContext;
        }

        
    }
}
