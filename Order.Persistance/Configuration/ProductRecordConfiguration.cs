using Order.Persistance.Model;

namespace Order.Persistance.Configuration;

/// <summary>
///     Klasa koja predstavlja konfiguraciju tabele "Products" u bazi
/// </summary>
public class ProductRecordConfiguration : IEntityTypeConfiguration<ProductRecord>
{
    /// <summary>
    ///     Metoda koja konfiguriše tabelu "Products" u bazi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<ProductRecord> builder)
    {
        builder.ToTable("Products");
    }
}