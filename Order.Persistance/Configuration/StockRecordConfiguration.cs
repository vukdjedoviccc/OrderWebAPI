using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    /// <summary>
    /// Klasa koja predstavlja konfiguraciju tabele "Stocks" u bazi
    /// </summary>
    public class StockRecordConfiguration : IEntityTypeConfiguration<StockRecord>
    {
        /// <summary>
        /// Metoda koja konfiguriše tabelu "Stocks" u bazi
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<StockRecord> builder)
        {
            builder.ToTable("Stocks");

            builder.HasOne(s => s.Product).WithOne(p => p.Stock).HasForeignKey<StockRecord>(p => p.ProductId);
            
        }
    }
}
