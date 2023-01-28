using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistance.Model
{
    /// <summary>
    /// Klasa koja sadrži postavku za mapiranje tabele "Person" u bazu
    /// </summary>
    public class PersonRecord : CustomerRecord
    {
        // <summary>
        /// Ime osobe
        /// </summary>
        public string FirstName { get; set; }
        // <summary>
        /// Prezime osobe
        /// </summary>
        public string LastName { get; set; }
    }
}
