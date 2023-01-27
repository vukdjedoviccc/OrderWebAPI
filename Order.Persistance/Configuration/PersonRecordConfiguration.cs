using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Configuration
{
    
    public class PersonRecordConfiguration : IEntityTypeConfiguration<PersonRecord>
    {
       
        public void Configure(EntityTypeBuilder<PersonRecord> builder)
        {
            builder.ToTable("Persons");
        }
    }
}
