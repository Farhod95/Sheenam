using Microsoft.EntityFrameworkCore;
using Sheenam.Models;

namespace Sheenam.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server = (localdb)\\MSSQLLocalDB; Database = Sheenam; Trusted_Connection = True;";
            optionsBuilder.UseSqlServer(path);
        }
    }
}