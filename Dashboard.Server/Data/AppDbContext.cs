using Dashboard.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeesData> EmployeesDatas { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
