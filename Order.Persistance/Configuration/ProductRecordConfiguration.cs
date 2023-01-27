using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class ProductRecordConfiguration : IEntityTypeConfiguration<ProductRecord>
    {
        
        public void Configure(EntityTypeBuilder<ProductRecord> builder)
        {
            builder.ToTable("Products");
            
        }

    }
}
