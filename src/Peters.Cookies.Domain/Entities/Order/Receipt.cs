namespace Peters.Cookies.Domain.Entities;

public class Receipt
{
    public decimal TotalPrice { get; }

    public decimal TotalPriceInflated => TotalPrice + decimal.Multiply(TotalAmount, 1);

    public string TotalPricePresentation => TotalPriceInflated.ToString("C", new CultureInfo("nl-NL"));

    public int TotalAmount { get; }

    public Receipt(
        decimal totalPrice, 
        int totalAmount)
    {
        TotalPrice = totalPrice;
        TotalAmount = totalAmount;
    }
}
