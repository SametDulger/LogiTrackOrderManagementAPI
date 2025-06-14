using LogiTrackAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogiTrackAPI.Data
{
    public class LogiTrackContext : IdentityDbContext<ApplicationUser>
    {
        public LogiTrackContext(DbContextOptions<LogiTrackContext> options) : base(options) { }

        public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithMany(i => i.Orders)
                .UsingEntity(j => j.ToTable("OrderItems"));
        }
    }
}
