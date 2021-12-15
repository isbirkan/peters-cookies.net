using System.ComponentModel.DataAnnotations;
using Peters.Cookies.Api.Validation;
using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Api.Models.Quote;

public class OrderRowModel
{
    [Required(ErrorMessage = ValidationConstants.OrderAmountMissingError)]
    public int Amount { get; private set; }

    [Required(ErrorMessage = ValidationConstants.OrderTypeMissingError)]
    public CookieType Type { get; private set; }

    public OrderRowModel(
        int amount, 
        CookieType type)
    {
        Amount = amount;
        Type = type;
    }
}
