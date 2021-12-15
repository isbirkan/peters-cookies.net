using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Infrastructure.Commands;

public class OrderCommand
{
    public IList<OrderDetails> OrderLines { get; }

    public string Supplier { get; }

    public OrderCommand(
        IList<OrderDetails> orderLines, 
        string supplier)
    {
        OrderLines = orderLines;
        Supplier = supplier;
    }
}
