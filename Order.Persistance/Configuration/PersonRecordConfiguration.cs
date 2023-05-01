using Order.Persistance.Model;

namespace Order.Persistance.Configuration;

/// <summary>
///     Klasa koja predstavlja konfiguraciju tabele "Persons" u bazi
/// </summary>
public class PersonRecordConfiguration : IEntityTypeConfiguration<PersonRecord>
{
    /// <summary>
    ///     Metoda koja konfiguriše tabelu "Persons" u bazi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<PersonRecord> builder)
    {
        builder.ToTable("Persons");
    }
}