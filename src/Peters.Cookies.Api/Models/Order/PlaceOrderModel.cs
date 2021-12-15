using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Peters.Cookies.Api.Validation;

namespace Peters.Cookies.Api.Models.Order;

public class PlaceOrderModel
{
    [Required(ErrorMessage = ValidationConstants.NameMissingError)]
    public string Name { get; }

    public string TotalPricePresentation
    {
        get
        {
            return Quotes.Sum(a => a.TotalAmount).ToString("C", new CultureInfo("nl-NL"));
        }
    }

    public IList<QuoteRowModel> Quotes { get; }

    [ListHasElements(ErrorMessage = ValidationConstants.OrderMissingError)]
    public IList<OrderRowModel> OrderRows { get; }

    public PlaceOrderModel(
        string name, 
        IList<QuoteRowModel> quotes, 
        IList<OrderRowModel> orderRows)
    {
        Name = name;
        Quotes = quotes;
        OrderRows = orderRows;
    }
}
