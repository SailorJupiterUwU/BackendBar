using BackendBar.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendBar.Data
{
    public class BackendBarDbContext : DbContext
    {
        public BackendBarDbContext(DbContextOptions <BackendBarDbContext> options) : base(options)
        {


        }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(100);
                entity.Property(u => u.Phone).HasMaxLength(15);
                entity.Property(u => u.Email).HasMaxLength(100);
            });
        }

    }
}
