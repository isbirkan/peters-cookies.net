using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Infrastructure.Interfaces;

public interface ICookieSupplierService
{
    ISupplier Supplier { get; }

    bool IsAvailable => true;

    Task<IList<CookieResponse>?> GetCookiesAsync();

    Task<Product?> GetProductAsync();

    Task<IList<Quote>?> GetQuotesAsync(IList<KeyValuePair<CookieType, int>> orderLines);

    Task<OrderResponse?> PostOrderAsync(IList<OrderDetails> orderLines);
}
