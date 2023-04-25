namespace OrderWebAPI.Request;

public class CreateStockRequest
{
    /// <summary>
    ///     Id proizvoda na skladištu
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    ///     Količina određenog proizvoda na skladištu
    /// </summary>
    public int Quantity { get; set; }
}