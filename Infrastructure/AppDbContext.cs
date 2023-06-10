using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<CommandItem> CommandItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RecyclableMatter> RecyclableMatters { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=stratup;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>().HasOne(s => s.Client).WithMany().HasForeignKey(s => s.ClientId);
            modelBuilder.Entity<Command>().HasOne(s => s.Creator).WithMany().HasForeignKey(s => s.CreatorId);
            modelBuilder.Entity<Command>().HasOne(s => s.Modifier).WithMany().HasForeignKey(s => s.ModifierId);
            modelBuilder.Entity<CommandItem>().HasOne(s => s.Product).WithMany().HasForeignKey(s => s.ProductId);
            modelBuilder.Entity<CommandItem>().HasOne(s => s.Creator).WithMany().HasForeignKey(s => s.CreatorId);
            modelBuilder.Entity<CommandItem>().HasOne(s => s.Modifier).WithMany().HasForeignKey(s => s.ModifierId);
        }
    }
}