using System.Globalization;

namespace Peters.Cookies.Application.Models.Order;

public class PlaceOrder
{
    public string Name { get; }

    public string TotalPricePresentation
    {
        get
        {
            return Quotes.Sum(a => a.TotalAmount).ToString("C", new CultureInfo("nl-NL"));
        }
    }

    public IList<QuoteRow> Quotes { get; }

    public IList<OrderRow> OrderRows { get; }

    public PlaceOrder(string name, IList<QuoteRow> quotes, IList<OrderRow> orderRows)
    {
        Name = name;
        Quotes = quotes;
        OrderRows = orderRows;
    }
}
