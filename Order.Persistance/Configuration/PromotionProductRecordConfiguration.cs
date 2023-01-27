using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class PromotionProductRecordConfiguration : IEntityTypeConfiguration<PromotionProductRecord>
    {
        
        public void Configure(EntityTypeBuilder<PromotionProductRecord> builder)
        {
            builder.HasKey(p => new { p.ProductId, p.PromotionId });
            builder.HasOne(p => p.Product).WithMany(p => p.PromotionProducts).HasForeignKey(p => p.ProductId); // ovo ti znači da jednom Product-u odgovara više PromotionProduct-a
            builder.HasOne(p => p.Promotion).WithMany(p => p.PromotionProducts).HasForeignKey(p => p.PromotionId);
            builder.ToTable("ProductPromotion");

        }

    }
}
