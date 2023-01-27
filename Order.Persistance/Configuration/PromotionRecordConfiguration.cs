using Order.Persistance.Configuration;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class PromotionRecordConfiguration : IEntityTypeConfiguration<PromotionRecord>
    {
       
        public void Configure(EntityTypeBuilder<PromotionRecord> builder)
        {
            builder.ToTable("Promotions");
        }
    }
}
