namespace Peters.Cookies.Application.Models.Order;

public class QuoteRow
{
    public string SupplierName { get; }

    public string CookieType { get; }

    public decimal TotalAmount { get; }

    public QuoteRow(
        string supplierName, 
        string cookieType, 
        decimal totalAmount)
    {
        SupplierName = supplierName;
        CookieType = cookieType;
        TotalAmount = totalAmount;
    }
}
