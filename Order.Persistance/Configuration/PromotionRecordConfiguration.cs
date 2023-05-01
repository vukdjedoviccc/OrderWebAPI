using Order.Persistance.Model;

namespace Order.Persistance.Configuration;

/// <summary>
///     Klasa koja predstavlja konfiguraciju tabele "Promotions" u bazi
/// </summary>
public class PromotionRecordConfiguration : IEntityTypeConfiguration<PromotionRecord>
{
    /// <summary>
    ///     Metoda koja konfiguriše tabelu "Promotions" u bazi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<PromotionRecord> builder)
    {
        builder.ToTable("Promotions");
    }
}