using Peters.Cookies.Application.Models.Order;

namespace Peters.Cookies.Application.Models.Quote;

public class GenerateQuotes
{
    public string? Name { get; private set; }

    public DateTime WishDate { get; private set; }

    public IList<OrderRow>? OrderRows { get; private set; }
}
