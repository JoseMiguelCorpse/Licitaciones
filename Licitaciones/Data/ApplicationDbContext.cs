using Microsoft.EntityFrameworkCore;
using SupabaseApi.Models;

namespace SupabaseApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Licitacion> Licitaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Licitacion>()
                .HasKey(l => l.Nombre);  // Definir Nombre como la clave primaria

            // Configuración adicional si es necesario
            modelBuilder.Entity<Licitacion>()
                .Property(l => l.Nombre)
                .IsRequired();
        }
    }
}
