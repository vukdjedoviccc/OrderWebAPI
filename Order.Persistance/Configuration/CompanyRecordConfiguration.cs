using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    /// <summary>
    /// Klasa koja predstavlja konfiguraciju tabele "Companies" u bazi
    /// </summary>
    public class CompanyRecordConfiguration : IEntityTypeConfiguration<CompanyRecord>
    {
        /// <summary>
        /// Metoda koja konfiguriše tabelu "Companies" u bazi
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CompanyRecord> builder)
        {
            builder.ToTable("Companies");
        }
    }
}
