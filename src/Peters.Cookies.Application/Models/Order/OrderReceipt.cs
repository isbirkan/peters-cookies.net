namespace Peters.Cookies.Application.Models.Order;

public class OrderReceipt
{
    public string TotalPricePresentation { get; }

    public OrderReceipt(string totalPricePresentation)
    {
        TotalPricePresentation = totalPricePresentation;
    }
}
