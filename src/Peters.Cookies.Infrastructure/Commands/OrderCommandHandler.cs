using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Infrastructure.Interfaces;

namespace Peters.Cookies.Infrastructure.Commands;

public class OrderCommandHandler : IOrderCommandHandler
{
    private readonly IEnumerable<ICookieSupplierService> _cookieSupplierServices;

    public OrderCommandHandler(IEnumerable<ICookieSupplierService> cookieSupplierServices)
    {
        _cookieSupplierServices = cookieSupplierServices;
    }

    public async Task<OrderResponse?> HandleAsync(OrderCommand command)
    {
        Assertion.ArgumentNullAssert(command, nameof(command));

        var cookieSupplierService = _cookieSupplierServices.Single(
            service =>
            service.Supplier.Name.Equals(command.Supplier, StringComparison.OrdinalIgnoreCase));

        var response = await cookieSupplierService.PostOrderAsync(command.OrderLines);
        if (response != null) 
        {
            return response;
        }

        return null;
    }
}
