namespace Peters.Cookies.Domain.Entities;

public class OrderResponse
{
    [JsonProperty("TotaalPrijs")]
    public decimal TotalPrice { get; }
}
