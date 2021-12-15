using System.Text;
using Newtonsoft.Json;
using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Interfaces;
using Peters.Cookies.Infrastructure.Interfaces;

namespace Peters.Cookies.Infrastructure.Services;

public class CookieSupplierServiceBase : ServiceBase, ICookieSupplierService
{
    private readonly IQuoteBuilder _quoteBuilder;
    private readonly IOrderBuilder _orderBuilder;

    public ISupplier Supplier { get; set; }

    public CookieSupplierServiceBase(
        HttpClient httpClient,
        IQuoteBuilder quoteBuilder,
        IOrderBuilder orderBuilder,
        ISupplier supplier)
        : base(httpClient)
    {
        _quoteBuilder = quoteBuilder;
        _orderBuilder = orderBuilder;
        Supplier = supplier;
    }


    public async Task<IList<CookieResponse>?> GetCookiesAsync()
    {
        var response = await GetAsync<IList<CookieResponse>>("products");
        if (response != null)
        {
            return response;
        }

        return null;
    }

    public async Task<Product?> GetProductAsync()
    {
        var cookies = await GetCookiesAsync();
        if (cookies != null && cookies.Any())
        {
            return new Product(cookies, Supplier.Name);
        }

        return null;
    }

    public async Task<IList<Quote>?> GetQuotesAsync(IList<KeyValuePair<CookieType, int>> orderLines)
    {
        var cookies = await GetCookiesAsync();
        if (cookies != null && cookies.Any())
        {
            return _quoteBuilder.CreateQuotes(orderLines, cookies, Supplier);
        }

        return null;
    }

    public async Task<OrderResponse?> PostOrderAsync(IList<OrderDetails> orderLines)
    {
        var order = _orderBuilder.CreateOrder(orderLines);
        using var requestContent = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
        return await PostAsync<OrderResponse>("order", requestContent);
    }
}
