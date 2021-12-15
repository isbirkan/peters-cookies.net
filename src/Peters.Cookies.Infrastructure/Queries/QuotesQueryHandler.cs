using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Infrastructure.Interfaces;

namespace Peters.Cookies.Infrastructure.Queries;

public class QuotesQueryHandler : IQuotesQueryHandler
{
    private readonly IEnumerable<ICookieSupplierService> _cookieSupplierServices;

    public QuotesQueryHandler(IEnumerable<ICookieSupplierService> cookieSupplierServices)
    {
        _cookieSupplierServices = cookieSupplierServices;
    }

    public async Task<IList<Quote>> HandleAsync(QuotesQuery query)
    {
        // Initial implementation which was not thread safe

        //var singleQuotes = new List<Quote>();
        //var tasks = _cookieSupplierServices
        //    .Where(service => service.IsAvailable)
        //    .Select(async service =>
        //{
        //    var quotes = await service.GetQuotesAsync(query.OrderLines);
        //    singleQuotes.AddRange(quotes);
        //});

        //await Task.WhenAll(tasks).ConfigureAwait(false);
        //return singleQuotes;

        var tasks = _cookieSupplierServices
            .Where(service => service.IsAvailable)
            .Select(async service =>
            {
                return await service.GetQuotesAsync(query.OrderLines);
            });

        await Task.WhenAll(tasks).ConfigureAwait(false);


        var singleQuotes = new List<Quote>();
        foreach (var task in tasks)
        {
            var result = task.Result;
            if (result != null && result.Any())
            {
                singleQuotes.AddRange(result);
            }
        }

        return singleQuotes;
    }
}
