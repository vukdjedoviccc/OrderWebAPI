using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.Domain.Helper
{
    /// <summary>
    /// Klasa koja sadrži metodu za rad sa JSON fajlovima
    /// </summary>
    public class JSONHelper
    {
        /// <summary>
        /// Metoda pomoću koje se upisuju narudžbine u JSON fajl
        /// </summary>
        /// <param name="orders"></param>
        public static void WriteOrdersToJSONFile(List<Model.Order> orders) 
        {
            string fileName = "Orders.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(orders, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
