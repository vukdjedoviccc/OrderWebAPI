using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Model
{
    
    public class CompanyRecord : CustomerRecord
    {
        
        public string FullName { get; set; }
        
        public string RegistrationNumber { get; set; }
    }
}
