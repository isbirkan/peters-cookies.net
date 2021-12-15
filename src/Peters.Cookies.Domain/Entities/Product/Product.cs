namespace Peters.Cookies.Domain.Entities;

public class Product
{
    public IList<CookieResponse> Cookies { get; }

    public string SupplierName { get; }

    public Product(
        IList<CookieResponse> cookies, 
        string supplierName)
    {
        Cookies = cookies;
        SupplierName = supplierName;
    }
}
