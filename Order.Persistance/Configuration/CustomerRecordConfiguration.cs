using Order.Persistance.Model;

namespace Order.Persistance.Configuration;

/// <summary>
///     Klasa koja predstavlja konfiguraciju tabele "Customers" u bazi
/// </summary>
public class CustomerRecordConfiguration : IEntityTypeConfiguration<CustomerRecord>
{
    /// <summary>
    ///     Metoda koja konfiguriše tabelu "Customers" u bazi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<CustomerRecord> builder)
    {
        builder.ToTable("Customers");
    }
}