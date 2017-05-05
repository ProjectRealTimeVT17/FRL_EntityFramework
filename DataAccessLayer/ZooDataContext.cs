using System.Data.Entity;
using Models;

namespace DataAccessLayer
{
    public class ZooDataContext : DbContext
    {
        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
