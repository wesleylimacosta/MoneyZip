using Microsoft.EntityFrameworkCore;
using MoneyZip.Domain;

namespace MoneyZip.Infrastructure.Data;

public class MoneyZipDbContext : DbContext
{
    public DbSet<User> Users { get; set; } 
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<MoneyTransaction> Transactions { get; set; }

    public MoneyZipDbContext(DbContextOptions<MoneyZipDbContext> options)
        : base(options)
    {
        Console.WriteLine($"Database path: {Database.GetDbConnection().DataSource}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar a herança TPH para User
        
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<CommonUser>("CommonUser")
            .HasValue<MerchantUser>("MerchantUser");

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        // Configurar a relação um-para-um entre User e Wallet
        modelBuilder.Entity<User>()
            .HasOne(u => u.Wallet)
            .WithOne()
            .HasForeignKey<Wallet>(w => w.UserId);

        modelBuilder.Entity<Wallet>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<MoneyTransaction>()
            .HasKey(t => t.Id);
    }
}