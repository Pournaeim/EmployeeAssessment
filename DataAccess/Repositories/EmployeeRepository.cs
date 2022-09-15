using DataAccess.Common;
using Domain.IRepositories;
using DataAccess.Repositories;
using Domain.Employee;

using Microsoft.Extensions.Logging;

namespace DataLayer.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        ApplicationDbContext _dbcontext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

    }
}
