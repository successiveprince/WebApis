using ASPNET_MVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVCCRUD.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MyEmployee> Employee { get; set; }
    }
}
