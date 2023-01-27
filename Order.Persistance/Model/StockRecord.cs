using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Model
{
    
    public class StockRecord
    {
      
        public int Id { get; set; }

        
        public int Quantity { get; set; }

        public ProductRecord Product { get; set; }
        public int ProductId { get; set; }
    }
}
