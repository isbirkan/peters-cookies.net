using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Infrastructure.Interfaces;

public interface IProductsQueryHandler
{
    Task<IList<Product>> HandleAsync();
}
