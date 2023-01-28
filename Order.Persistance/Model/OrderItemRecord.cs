namespace Order.Persistance.Model
{
    /// <summary>
    /// Klasa koja sadrži postavku za mapiranje tabele "Order" u bazu
    /// </summary>
    public class OrderItemRecord
    {
        // <summary>
        /// Id stavke narudžbine
        /// </summary>
        public int Id { get; set; }
        // <summary>
        /// Količina stavke narudžbine
        /// </summary>
        public int Quantity { get; set; }
        // <summary>
        /// Iznos stavke narudžbine
        /// </summary>
        public decimal Amount { get; set; }
        // <summary>
        /// Navigacioni properti ka proizvodu
        /// </summary>
        public ProductRecord Product { get; set; }
        // <summary>
        /// Id proizvoda
        /// </summary>
        public int ProductId { get; set; }
        // <summary>
        /// Id narudžbine
        /// </summary>
        public int OrderId { get; set; }
        // <summary>
        /// Navigacioni properti ka narudžbini
        /// </summary>
        public OrderRecord Order { get; set; }
    }
}
