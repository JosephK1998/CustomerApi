using Microsoft.EntityFrameworkCore;
using CustomerApi.Models.Entities;

namespace CustomerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option): base(option)
        {
            
        }

        public DbSet<Customers> Customers { get; set; }
    }
}
