using Peters.Cookies.Domain.Entities;
using Peters.Cookies.Infrastructure.Interfaces;

namespace Peters.Cookies.Infrastructure.Queries;

public class ProductsQueryHandler : IProductsQueryHandler
{
    private readonly IEnumerable<ICookieSupplierService> _cookieSupplierServices;

    public ProductsQueryHandler(IEnumerable<ICookieSupplierService> cookieSupplierServices)
    {
        _cookieSupplierServices = cookieSupplierServices;
    }

    public async Task<IList<Product>> HandleAsync()
    {
        var products = new List<Product>();
        var tasks = _cookieSupplierServices.Select(async service =>
        {
            var product = await service.GetProductAsync();
            if (product != null)
            {
                products.Add(product);
            }
        });

        await Task.WhenAll(tasks);

        return products;
    }
}
