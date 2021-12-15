using Peters.Cookies.Application.Interfaces;
using Peters.Cookies.Application.Models.Order;
using Peters.Cookies.Application.Models.Quote;
using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Domain.Helpers;
using Peters.Cookies.Infrastructure.Interfaces;
using Peters.Cookies.Infrastructure.Queries;

namespace Peters.Cookies.Application.Managers;

public class QuoteManager : IQuoteManager
{
    private readonly IProductsQueryHandler _productsQueryHandler;
    private readonly IQuotesQueryHandler _quotesQueryHandler;

    public QuoteManager(
        IProductsQueryHandler productsQueryHandler,
        IQuotesQueryHandler quotesQueryHandler)
    {
        _productsQueryHandler = productsQueryHandler;
        _quotesQueryHandler = quotesQueryHandler;
    }

    public async Task<IList<Product>> GetProductsAsync()
    {
        var products = await _productsQueryHandler.HandleAsync();
        return products;
    }

    public async Task<PlaceOrder> GenerateQuotesAsync(GenerateQuotes request)
    {
        Assertion.ArgumentNullAssert(request, nameof(request));
        Assertion.ArgumentNullAssert(request.OrderRows, nameof(request.OrderRows));

        var orderLines = GetOrderLines(request.OrderRows);
        var singleQuotes = await _quotesQueryHandler.HandleAsync(new QuotesQuery(orderLines));

        var lowestOrder = GetLowestOrder(singleQuotes);
        var response = MapQuotesToOrder(request.Name, request.WishDate, lowestOrder);

        return response;
    }

    private static IList<KeyValuePair<CookieType, int>> GetOrderLines(IList<Models.Quote.OrderRow> orderRows)
    {
        return orderRows.Select(or => new KeyValuePair<CookieType, int>(or.Type, or.Amount)).ToList();
    }

    private static PlaceOrder MapQuotesToOrder(string name, DateTime wishDate, IEnumerable<Quote> quotes)
    {
        var model = new PlaceOrder(
            name,
            quotes.Select(q => new QuoteRow(q.Supplier.Name, q.Order.Cookie.Type.ToString(), q.TotalPriceInflated)).ToList(),
            quotes.Select(q => new Models.Order.OrderRow(
                q.Order.Amount,
                q.Order.Cookie.Type,
                q.Order.Cookie.Brand,
                q.Supplier.Name,
                wishDate)).ToList()
            );

        return model;
    }

    private static IEnumerable<Quote> GetLowestOrder(IList<Quote> quotes)
    {
        // I know this can be mode more clever with dedicated algorithms
        // that are specifically thought to find the cheapest price or
        // the shortest path between two nodes with given variables

        // Group by Cookie Type
        var groupsByCookieType = quotes
            .GroupBy(a => a.Order.Cookie.Type)
            .Select(group => group.AsEnumerable());
        // Do a Cartesian product amongst the groups and filter out the one with higher shipping delays
        var combinations = CartesianProduct(groupsByCookieType)
                           .Where(b => (b.Max(c => c.ShippingDays) - b.Min(d => d.ShippingDays)) <= 1);
        // Get the lower price with shipping, since without shipping we might have false positives
        var match = combinations.OrderBy(e => e.Sum(f => f.TotalPrice)).First();

        return match;
    }

    private static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
    {
        IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
        return sequences.Aggregate(
            emptyProduct,
            (accumulator, sequence) =>
            from accseq in accumulator
            from item in sequence
            select accseq.Concat(new[] { item }));
    }
}
