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
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(100);
                entity.Property(u => u.Phone).HasMaxLength(15);
                entity.Property(u => u.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(p => p.Nombre).HasMaxLength(100);
                entity.Property(p => p.Telefono).HasMaxLength(20);
            });
        }

    }
}
