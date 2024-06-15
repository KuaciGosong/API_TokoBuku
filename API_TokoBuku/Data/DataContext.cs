using API_TokoBuku.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TokoBuku.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Buku> Bukus { get; set; }
        public DbSet<Pelanggan> Pelanggans { get; set; }
        public DbSet<Pembelian> Pembelians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pembelian>()
                .HasOne(p => p.Buku)
                .WithMany(b => b.pembelians)
                .HasForeignKey(p => p.BukuID);

            modelBuilder.Entity<Pembelian>()
                .HasOne(p => p.Pelanggan)
                .WithMany(pl => pl.pembelians)
                .HasForeignKey(p => p.PelangganID);
        }
    }
}
