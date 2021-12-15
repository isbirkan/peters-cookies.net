namespace Peters.Cookies.Domain.Entities;

public class CookieResponse
{
    [JsonProperty("Type")]
    public CookieType Type { get; set; }

    [JsonProperty("Merk")]
    public Brand Brand { get; set; }

    [JsonProperty("Prijs")]
    public decimal Price { get; set; }
}