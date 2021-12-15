namespace Peters.Cookies.Api.Models.Order;

public class QuoteRowModel
{
    public string SupplierName { get; }

    public string CookieType { get; }

    public decimal TotalAmount { get; }

    public QuoteRowModel(
        string supplierName, 
        string cookieType, 
        decimal totalAmount)
    {
        SupplierName = supplierName;
        CookieType = cookieType;
        TotalAmount = totalAmount;
    }
}
