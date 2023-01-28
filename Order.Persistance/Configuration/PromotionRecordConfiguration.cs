using Order.Persistance.Configuration;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    /// <summary>
    /// Klasa koja predstavlja konfiguraciju tabele "Promotions" u bazi
    /// </summary>
    public class PromotionRecordConfiguration : IEntityTypeConfiguration<PromotionRecord>
    {
        /// <summary>
        /// Metoda koja konfiguriše tabelu "Promotions" u bazi
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PromotionRecord> builder)
        {
            builder.ToTable("Promotions");
        }
    }
}
