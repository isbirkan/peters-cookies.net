using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Domain.Interfaces;

public interface IQuoteBuilder
{
    IList<Quote> CreateQuotes(IList<KeyValuePair<CookieType, int>> orderDetails, IList<CookieResponse> cookies, ISupplier supplier);
}