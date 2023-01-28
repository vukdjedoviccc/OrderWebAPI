using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    /// <summary>
    /// Klasa koja predstavlja konfiguraciju tabele "Products" u bazi
    /// </summary>
    public class ProductRecordConfiguration : IEntityTypeConfiguration<ProductRecord>
    {
        /// <summary>
        /// Metoda koja konfiguriše tabelu "Products" u bazi
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ProductRecord> builder)
        {
            builder.ToTable("Products");
            
        }

    }
}
