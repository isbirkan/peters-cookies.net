using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Infrastructure.Services;

public class CookieSupplierCService : CookieSupplierServiceBase
{
    public CookieSupplierCService(
        HttpClient httpClient,
        IQuoteBuilder quoteBuilder,
        IOrderBuilder orderBuilder)
        : base(httpClient,
               quoteBuilder,
               orderBuilder,
               new SupplierC())
    {
        Assertion.ArgumentNullAssert(httpClient, nameof(httpClient));

        httpClient.BaseAddress = new Uri("http://stroopwafelc.azurewebsites.net/api/");
    }
}
