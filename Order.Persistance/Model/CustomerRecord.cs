using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Model
{
    
    public class CustomerRecord
    {
        
        public int Id { get; set; }
        
        public string Adress { get; set; }
        
        public string PhoneNumber { get; set; }
       
        public string Email { get; set; }
        
        public List<OrderRecord> Orders { get; set; }
    }
}
