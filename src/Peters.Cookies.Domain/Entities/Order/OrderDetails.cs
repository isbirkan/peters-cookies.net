namespace Peters.Cookies.Domain.Entities;

public class OrderDetails
{
    public CookieType CookieType { get; }

    public Brand Brand { get; }

    public int Amount { get; }

    public string SupplierName { get; }

    public DateTime WishDate { get; }

    public OrderDetails(
        CookieType type, 
        Brand brand, 
        int amount, 
        string supplierName, 
        DateTime wishDate)
    {
        CookieType = type;
        Brand = brand;
        Amount = amount;
        SupplierName = supplierName;
        WishDate = wishDate;
    }
}
