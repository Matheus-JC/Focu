namespace Focu.Core.Requests.Orders;

public class GetVoucherByNumberRequest : Request
{
    public string Number { get; set; } = string.Empty;
}