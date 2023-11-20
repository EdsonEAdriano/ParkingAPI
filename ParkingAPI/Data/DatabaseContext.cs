using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;

namespace ParkingAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Control> Controls { get; set; }
        public DbSet<Prices> Prices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Control>()
                .HasOne(p => p.price)
                .WithMany()
                .HasForeignKey(p => p.priceID) 
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
