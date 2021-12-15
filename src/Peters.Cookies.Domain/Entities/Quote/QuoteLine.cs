namespace Peters.Cookies.Domain.Entities;

public class QuoteLine
{
    public int Amount { get; }

    [JsonProperty(PropertyName = "Product")]
    public CookieResponse Cookie { get; }

    public decimal Price => Amount * Cookie.Price;

    public QuoteLine(
        int amount, 
        CookieResponse cookie)
    {
        Amount = amount;
        Cookie = cookie;
    }
}
