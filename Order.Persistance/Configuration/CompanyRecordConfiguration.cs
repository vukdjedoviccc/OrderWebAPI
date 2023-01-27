using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class CompanyRecordConfiguration : IEntityTypeConfiguration<CompanyRecord>
    {
        
        public void Configure(EntityTypeBuilder<CompanyRecord> builder)
        {
            builder.ToTable("Companies");
        }
    }
}
