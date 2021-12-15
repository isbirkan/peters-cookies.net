using Peters.Cookies.Application.Models.Order;

namespace Peters.Cookies.Application.Interfaces;

public interface IOrderManager
{
    Task<OrderReceipt> PlaceOrderAsync(PlaceOrder request);
}
