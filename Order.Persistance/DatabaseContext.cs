global using Microsoft.EntityFrameworkCore;
using Order.Persistance.Configuration;
using Order.Persistance.Model;

namespace Order.Persistance;

/// <summary>
///     Klasa koja služi za pristup podacima iz tabela unutar baze
/// </summary>
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    /// <summary>
    ///     "Products" tabela u bazi
    /// </summary>
    public DbSet<ProductRecord> Products { get; set; }

    /// <summary>
    ///     "Orders" tabela u bazi
    /// </summary>
    public DbSet<OrderRecord> Orders { get; set; }

    /// <summary>
    ///     "OrderItems" tabela u bazi
    /// </summary>
    public DbSet<OrderItemRecord> OrderItems { get; set; }

    /// <summary>
    ///     "Promotions" tabela u bazi
    /// </summary>
    public DbSet<PromotionRecord> Promotions { get; set; }

    /// <summary>
    ///     "ProductPromotions" tabela u bazi
    /// </summary>
    public DbSet<PromotionProductRecord> ProductPromotions { get; set; }

    /// <summary>
    ///     "Companies" tabela u bazi
    /// </summary>
    public DbSet<CompanyRecord> Companies { get; set; }

    /// <summary>
    ///     "Persons" tabela u bazi
    /// </summary>
    public DbSet<PersonRecord> Persons { get; set; }

    /// <summary>
    ///     "Stocks" tabela u bazi
    /// </summary>
    public DbSet<StockRecord> Stocks { get; set; }

    /// <summary>
    ///     Metoda koja konfiguriše tabele u bazi
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderRecordConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemRecordConfiguration());
        modelBuilder.ApplyConfiguration(new ProductRecordConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionRecordConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionProductRecordConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerRecordConfiguration());
        modelBuilder.ApplyConfiguration(new PersonRecordConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyRecordConfiguration());
        modelBuilder.ApplyConfiguration(new StockRecordConfiguration());
    }
}