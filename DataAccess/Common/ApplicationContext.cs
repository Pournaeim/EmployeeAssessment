using Domain.Employee;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Common
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
