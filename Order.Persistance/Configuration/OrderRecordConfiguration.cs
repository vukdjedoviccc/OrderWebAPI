using Order.Persistance.Model;

namespace Order.Persistance.Configuration;

/// <summary>
///     Klasa koja predstavlja konfiguraciju tabele "Orders" u bazi
/// </summary>
public class OrderItemRecordConfiguration : IEntityTypeConfiguration<OrderRecord>
{
    /// <summary>
    ///     Metoda koja konfiguriše tabelu "Orders" u bazi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<OrderRecord> builder)
    {
        builder.ToTable("Orders");
    }
}