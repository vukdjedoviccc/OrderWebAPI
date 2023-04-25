namespace OrderWebAPI.Request;

public class CreateProductRequest
{
    /// <summary>
    ///     Ime proizvoda
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Cena proizvoda
    /// </summary>
    public decimal Price { get; set; }
}