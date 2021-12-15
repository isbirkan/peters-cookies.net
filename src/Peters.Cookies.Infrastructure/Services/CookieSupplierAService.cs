using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Infrastructure.Services;

public class CookieSupplierAService : CookieSupplierServiceBase
{
    public CookieSupplierAService(
         HttpClient httpClient,
         IQuoteBuilder quoteBuilder,
         IOrderBuilder orderBuilder)
        : base(httpClient,
               quoteBuilder,
               orderBuilder,
               new SupplierA())
    {
        Assertion.ArgumentNullAssert(httpClient, nameof(httpClient));

        httpClient.BaseAddress = new Uri("http://stroopwafela.azurewebsites.net/api/");
    }
}
