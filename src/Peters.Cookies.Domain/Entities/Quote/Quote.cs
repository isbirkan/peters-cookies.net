using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Domain.Entities;

public class Quote
{
    public decimal TotalPrice => TotalWithoutShippingCost + Supplier.GetShippingCost(this);

    public decimal TotalPriceInflated => TotalInflatedWithoutShippingCost + Supplier.GetShippingCost(this);

    public string TotalPricePresentation => TotalPriceInflated.ToString("C", new CultureInfo("nl-NL"));

    public decimal TotalWithoutShippingCost
    {
        get { return Order.Price; }
    }

    public decimal TotalInflatedWithoutShippingCost
    {
        get { return decimal.Add(Order.Price, 1); }
    }

    public int ShippingDays => Supplier.GetDeliveryDays(this);

    public QuoteLine Order { get; }

    public ISupplier Supplier { get; }

    public Quote(QuoteLine order, ISupplier supplier)
    {
        Order = order;
        Supplier = supplier;
    }
}
