namespace Peters.Cookies.Domain.Entities;

public class OrderProduct
{
    public CookieType Type { get; }

    [JsonProperty(PropertyName = "Merk")]
    public Brand Brand { get; }

    public OrderProduct(
        CookieType type, 
        Brand brand)
    {
        Type = type;
        Brand = brand;
    }
}
