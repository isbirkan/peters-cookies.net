using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Domain.Interfaces;

namespace Peters.Cookies.Infrastructure.Services;

public class CookieSupplierBService : CookieSupplierServiceBase
{
    public static bool IsAvailable => GetAvailability();

    public CookieSupplierBService(
        HttpClient httpClient,
        IQuoteBuilder quoteBuilder,
        IOrderBuilder orderBuilder)
        : base(httpClient,
               quoteBuilder,
               orderBuilder,
               new SupplierB())
    {
        Assertion.ArgumentNullAssert(httpClient, nameof(httpClient));

        httpClient.BaseAddress = new Uri("http://stroopwafelb.azurewebsites.net/api/");
    }

    private static bool GetAvailability()
    {
        var today = DateTime.Now;

        return !today.IsSunday() && !today.IsPublicHolidayInNetherlands();
    }
}
