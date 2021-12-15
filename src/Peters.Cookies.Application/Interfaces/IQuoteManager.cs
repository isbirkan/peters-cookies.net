using Peters.Cookies.Application.Models.Order;
using Peters.Cookies.Application.Models.Quote;
using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Application.Interfaces;

public interface IQuoteManager
{
    Task<IList<Product>> GetProductsAsync();

    Task<PlaceOrder> GenerateQuotesAsync(GenerateQuotes request);
}
