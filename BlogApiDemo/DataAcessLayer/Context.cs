using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAcessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=.;database=CoreBlogApiDb;trusted_connection=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
