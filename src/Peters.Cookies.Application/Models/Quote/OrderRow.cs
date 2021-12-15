using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Application.Models.Quote;

public class OrderRow
{
    public int Amount { get; set; }

    public CookieType Type { get; set; }
}
