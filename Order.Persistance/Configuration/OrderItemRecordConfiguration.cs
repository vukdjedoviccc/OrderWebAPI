global using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class OrderRecordConfiguration : IEntityTypeConfiguration<OrderItemRecord>
    {
        
        public void Configure(EntityTypeBuilder<OrderItemRecord> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
