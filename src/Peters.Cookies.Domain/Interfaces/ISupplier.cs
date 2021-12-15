using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Domain.Interfaces;

public interface ISupplier
{
    string Name { get; }

    decimal GetShippingCost(Quote order);

    int GetDeliveryDays(Quote order);
}
