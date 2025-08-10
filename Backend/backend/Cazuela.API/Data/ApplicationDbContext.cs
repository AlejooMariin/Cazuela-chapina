using Microsoft.EntityFrameworkCore;
using CazuelaChapina.Models;

namespace CazuelaChapina.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tamal> Tamales { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<InventarioMovimiento> InventarioMovimientos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaItem> VentaItems { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones específicas (relaciones, constraints)

            modelBuilder.Entity<Combo>()
                .HasMany(c => c.Tamales)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Combo>()
                .HasMany(c => c.Bebidas)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venta>()
                .HasMany(v => v.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar propiedades opcionales para VentaItem (por ejemplo TamalId o BebidaId)
            modelBuilder.Entity<VentaItem>()
                .HasOne(vi => vi.Tamal)
                .WithMany()
                .HasForeignKey(vi => vi.TamalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VentaItem>()
                .HasOne(vi => vi.Bebida)
                .WithMany()
                .HasForeignKey(vi => vi.BebidaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
