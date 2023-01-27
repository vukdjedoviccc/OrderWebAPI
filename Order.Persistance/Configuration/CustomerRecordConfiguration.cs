using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class CustomerRecordConfiguration : IEntityTypeConfiguration<CustomerRecord>
    {
        
        public void Configure(EntityTypeBuilder<CustomerRecord> builder)
        {
            builder.ToTable("Customers");
            //builder.HasDiscriminator<string>("CustomerType")
            //    .HasValue<PersonRecord>("Person")
            //    .HasValue<CompanyRecord>("Company");
        }
    }
}
