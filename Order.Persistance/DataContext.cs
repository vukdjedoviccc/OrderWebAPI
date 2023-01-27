global using Microsoft.EntityFrameworkCore;
using Order.Persistance.Configuration;
using Order.Persistance.Model;

namespace Order.Persistance
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

       
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

        
        public DbSet<ProductRecord> Products { get; set; }
        
        public DbSet<OrderRecord> Orders { get; set; }
        
        public DbSet<OrderItemRecord> OrderItems { get; set; }
        
        public DbSet<PromotionRecord> Promotions { get; set; }
        
        public DbSet<PromotionProductRecord> ProductPromotions { get; set; }
        
        public DbSet<CompanyRecord> Companies { get; set; }
        
        public DbSet<PersonRecord> Persons { get; set; }
        
        public DbSet<StockRecord> Stocks { get; set; }
    }
}
