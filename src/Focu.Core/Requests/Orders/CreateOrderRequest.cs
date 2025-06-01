namespace Focu.Core.Requests.Orders;

public class CreateOrderRequest : Request
{
    public Guid ProductId { get; set; }
    public Guid? VoucherId { get; set; }
}