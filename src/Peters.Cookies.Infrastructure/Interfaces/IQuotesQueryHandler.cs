using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Infrastructure.Queries;

namespace Peters.Cookies.Infrastructure.Interfaces;

public interface IQuotesQueryHandler
{
    Task<IList<Quote>> HandleAsync(QuotesQuery query);
}
