namespace Order.Persistance.Model
{
    /// <summary>
    /// Klasa koja sadrži postavku za mapiranje tabele "Promotion" u bazu
    /// </summary>
    public class PromotionRecord
    {
        // <summary>
        /// Id promocije
        /// </summary>
        public int Id { get; set; }
        // <summary>
        /// Naziv promocije
        /// </summary>
        public string Name { get; set; }
        // <summary>
        /// Popust promocije
        /// </summary>
        public decimal Discount { get; set; }
        // <summary>
        /// Datum i vreme od kada je promocija aktivna
        /// </summary>
        public DateTime FromDate { get; set; }
        // <summary>
        /// Datum i vreme do kada je promocija aktivna
        /// </summary>
        public DateTime ToDate { get; set; }
        // <summary>
        /// Navigacioni properti ka listi promocija i njoj odgovarajućih proizvoda
        /// </summary>
        public List<PromotionProductRecord> PromotionProducts { get; set; }
    }
}
