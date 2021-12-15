using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Domain.Entities;

public class SupplierB : ISupplier
{
    private const decimal ShippingCostLimit = 50m;
    private const decimal ShippingCostAboveLimit = 0m;
    private const decimal ShippingCostUnderLimit = 5m;
    private const int StandardDeliveryDays = 3;

    public string Name => "Supplier B";

    public decimal GetShippingCost(Quote order)
    {
        Assertion.ArgumentNullAssert(order, nameof(order));

        return order.TotalWithoutShippingCost > ShippingCostLimit ? ShippingCostAboveLimit : ShippingCostUnderLimit;
    }

    public int GetDeliveryDays(Quote order)
    {
        return GetCalculatedDeliveryDate(StandardDeliveryDays);
    }

    public int GetCalculatedDeliveryDate(int numberOfDays)
    {
        var deliveryDay = DateTime.Now.AddDays(numberOfDays);
        if (deliveryDay.IsSunday() || deliveryDay.IsPublicHolidayInNetherlands())
        {
            return GetCalculatedDeliveryDate(numberOfDays++);
        }

        return numberOfDays;
    }
}
