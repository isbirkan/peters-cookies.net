namespace Peters.Cookies.Domain.Entities;

public class OrderLine
{
    public int Amount { get; }

    public OrderProduct Product { get; }

    public DateTime WishDate { get; }

    public OrderLine(
        int amount, 
        OrderProduct product, 
        DateTime wishDate)
    {
        Amount = amount;
        Product = product;
        WishDate = wishDate;
    }
}
