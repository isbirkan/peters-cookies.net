using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Domain.Entities;

public class SupplierA : ISupplier
{
    public string Name => "Supplier A";

    public decimal GetShippingCost(Quote order)
    {
        return 5m;
    }

    public int GetDeliveryDays(Quote order)
    {
        return 4;
    }
}
