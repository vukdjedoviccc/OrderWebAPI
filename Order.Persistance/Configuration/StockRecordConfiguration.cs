using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class StockRecordConfiguration : IEntityTypeConfiguration<StockRecord>
    {
       
        public void Configure(EntityTypeBuilder<StockRecord> builder)
        {
            builder.ToTable("Stocks");

            builder.HasOne(s => s.Product).WithOne(p => p.Stock).HasForeignKey<StockRecord>(p => p.ProductId);
            
        }
    }
}
