using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Infrastructure.Commands;

namespace Peters.Cookies.Infrastructure.Interfaces;

public interface IOrderCommandHandler
{
    Task<OrderResponse?> HandleAsync(OrderCommand command);
}
