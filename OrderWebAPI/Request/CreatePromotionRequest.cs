namespace Order.Domain.Request
{
    
    public class CreatePromotionRequest
    {
        /// <summary>
        /// Naziv promocije
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Popust promocije
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Datum početka promocije
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Datum završetka promocije
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Lista proizvoda
        /// </summary>
        public List<int> ProductIds { get; set; } 
    }
}
