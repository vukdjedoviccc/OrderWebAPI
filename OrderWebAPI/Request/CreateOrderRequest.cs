using Order.Domain.Model;

namespace OrderWebAPI.Request;

public class CreateOrderRequest
{
    /// <summary>
    ///     Vreme narudžbine
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    ///     Lista stavki narudžbine
    /// </summary>
    public List<OrderItem>? Items { get; set; }

    /// <summary>
    ///     Id kupca
    /// </summary>
    public int CustomerId { get; set; }
}