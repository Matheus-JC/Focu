using Focu.Core.Enums;

namespace Focu.Core.Models;

public class Order
{
    public Guid Id { get; set; }

    public string Number { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string? ExternalReference { get; set; }
    public PaymentGateway Gateway { get; set; } = PaymentGateway.Stripe;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; } = OrderStatus.WaitingPayment;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid? VoucherId { get; set; }
    public Voucher? Voucher { get; set; }

    public Guid UserId { get; set; }

    public decimal Total => Product.Price - (Voucher?.Amount ?? 0);
}