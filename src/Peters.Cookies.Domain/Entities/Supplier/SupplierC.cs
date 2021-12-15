using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Domain.Entities;

public class SupplierC : ISupplier
{
    private const int ShippingCostPercentage = 5;

    public string Name => "Supplier C";

    public decimal GetShippingCost(Quote order)
    {
        Assertion.ArgumentNullAssert(order, nameof(order));

        return order.TotalWithoutShippingCost / 100 * ShippingCostPercentage;
    }

    public int GetDeliveryDays(Quote order)
    {
        return 5;
    }
}
