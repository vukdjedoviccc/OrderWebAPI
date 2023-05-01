using Order.Persistance.Model;

namespace Order.Persistance.Configuration;

/// <summary>
///     Klasa koja predstavlja konfiguraciju tabele "ProductPromotion" u bazi
/// </summary>
public class PromotionProductRecordConfiguration : IEntityTypeConfiguration<PromotionProductRecord>
{
    /// <summary>
    ///     Metoda koja konfiguriše tabelu "ProductPromotion" u bazi
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<PromotionProductRecord> builder)
    {
        builder.HasKey(p => new { p.ProductId, p.PromotionId });
        builder.HasOne(p => p.Product).WithMany(p => p.PromotionProducts).HasForeignKey(p => p.ProductId);
        builder.HasOne(p => p.Promotion).WithMany(p => p.PromotionProducts).HasForeignKey(p => p.PromotionId);
        builder.ToTable("ProductPromotion");
    }
}