using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Domain.Interfaces;

public interface IOrderBuilder
{
    OrderRequest CreateOrder(IList<OrderDetails> orderLines);

    Receipt CreateReceipt(IList<OrderResponse> orderResponses, int totalAmount);
}
