using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Infrastructure.Queries;

public class QuotesQuery
{
    public IList<KeyValuePair<CookieType, int>> OrderLines { get; }

    public QuotesQuery(IList<KeyValuePair<CookieType, int>> orderLines)
    {
        OrderLines = orderLines;
    }
}
