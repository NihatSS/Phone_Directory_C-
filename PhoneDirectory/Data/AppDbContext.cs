using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Models;
using System.Diagnostics.Metrics;


namespace PhoneDirectory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NIhat\\SQLEXPRESS;Database=PhoneDirectoryDb;Trusted_Connection=True;");
        }
    }
}
