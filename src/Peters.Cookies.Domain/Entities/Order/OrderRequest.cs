namespace Peters.Cookies.Domain.Entities;

public class OrderRequest
{
    public IList<OrderLine> ProductsAndAmounts { get; }

    public OrderRequest(IList<OrderLine> productsAndAmounts)
    {
        ProductsAndAmounts = productsAndAmounts;
    }
}
