using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Model
{
    
    public class PersonRecord : CustomerRecord
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
