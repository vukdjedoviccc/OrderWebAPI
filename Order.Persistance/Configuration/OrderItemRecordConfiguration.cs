global using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    /// <summary>
    /// Klasa koja predstavlja konfiguraciju tabele "OrderItems" u bazi
    /// </summary>
    public class OrderRecordConfiguration : IEntityTypeConfiguration<OrderItemRecord>
    {
        /// <summary>
        /// Metoda koja konfiguriše tabelu "OrderItems" u bazi
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<OrderItemRecord> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
