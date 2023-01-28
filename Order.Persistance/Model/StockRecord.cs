using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Model
{
    /// <summary>
    /// Klasa koja sadrži postavku za mapiranje tabele "Stock" u bazu
    /// </summary>
    public class StockRecord
    {
        // <summary>
        /// Id proizvoda u skladištu
        /// </summary>
        public int Id { get; set; }

        
        // <summary>
        /// Količina proizvoda u skladištu
        /// </summary>
        public int Quantity { get; set; }

        // <summary>
        /// Navigacioni properti ka listi proizvoda
        /// </summary>
        public ProductRecord Product { get; set; }
        public int ProductId { get; set; }
    }
}
