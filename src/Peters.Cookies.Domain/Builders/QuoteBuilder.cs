using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Domain.Builders;

public class QuoteBuilder : IQuoteBuilder
{
    public IList<Quote> CreateQuotes(IList<KeyValuePair<CookieType, int>> orderDetails, IList<CookieResponse> cookies, ISupplier supplier)
    {
        Assertion.ArgumentNullAssert(orderDetails, nameof(orderDetails));

        var quotes = new List<Quote>();

        foreach (var orderLine in orderDetails)
        {
            var cookie = cookies.First(s => s.Type == orderLine.Key);
            quotes.Add(new Quote(new QuoteLine(orderLine.Value, cookie), supplier));
        }

        return quotes;
    }
}
