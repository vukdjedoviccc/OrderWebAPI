using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class OrderItemRecordConfiguration : IEntityTypeConfiguration<OrderRecord>
    {
        
        public void Configure(EntityTypeBuilder<OrderRecord> builder)
        {
            builder.ToTable("Orders");
        }
    }
}
