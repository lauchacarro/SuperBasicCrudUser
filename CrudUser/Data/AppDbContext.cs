using Microsoft.EntityFrameworkCore;

using CrudUser.Entites;

namespace CrudUser.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
