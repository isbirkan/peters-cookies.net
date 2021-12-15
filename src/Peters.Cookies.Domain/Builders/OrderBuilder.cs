using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Domain.Builders;

public class OrderBuilder : IOrderBuilder
{
    public OrderRequest CreateOrder(IList<OrderDetails> orderLines)
    {
        var order = orderLines.Select(line => new OrderLine(line.Amount, new OrderProduct(line.CookieType, line.Brand), line.WishDate)).ToList();

        return new OrderRequest(order);
    }

    public Receipt CreateReceipt(IList<OrderResponse> orderResponses, int totalAmount)
    {
        return new Receipt(orderResponses.Sum(or => or.TotalPrice), totalAmount);
    }
}
