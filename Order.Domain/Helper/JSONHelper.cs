using System.Text.Json;

namespace Order.Domain.Helper;

/// <summary>
///     Klasa koja sadrži metodu za rad sa JSON fajlovima
/// </summary>
public class JsonHelper
{
    /// <summary>
    ///     Metoda pomoću koje se upisuju narudžbine u JSON fajl
    /// </summary>
    /// <param name="orders"></param>
    public static void WriteOrdersToJSONFile(List<Model.Order> orders)
    {
        var fileName = "Orders.json";
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(orders, options);
        File.WriteAllText(fileName, jsonString);
    }
}