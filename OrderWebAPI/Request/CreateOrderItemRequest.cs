namespace OrderWebAPI.Request;

public class CreateOrderItemRequest
{
    /// <summary>
    ///     Količina stavke narudžbine
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    ///     Id proizvoda na koji se stavka narudžbine odnosi
    /// </summary>
    public int ProductId { get; set; }
}