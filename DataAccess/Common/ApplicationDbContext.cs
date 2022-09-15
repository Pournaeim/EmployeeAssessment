using Domain.Employee;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Common
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {   

        }
    }
}
