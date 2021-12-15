using Peters.Cookies.Api.Models.Order;
using Peters.Cookies.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace Peters.Cookies.Api.Models.Examples;

public class PlaceOrderModelExample : IExamplesProvider<PlaceOrderModel>
{
    public PlaceOrderModel GetExamples()
    {
        var quoteRows = new List<QuoteRowModel>
        {
            new QuoteRowModel("Supplier C", "Regular", (decimal)8.14),
            new QuoteRowModel("Supplier C", "SugarFree", (decimal)4.78),
            new QuoteRowModel("Supplier C", "Super", (decimal)14.23)
        };
        var orderRows = new List<OrderRowModel>
        {
            new OrderRowModel(8, CookieType.Regular, Brand.Cuddlies, "Supplier C", new DateTime(2022, 01, 05)),
            new OrderRowModel(3, CookieType.SugarFree, Brand.Cuddlies, "Supplier C", new DateTime(2022, 01, 05)),
            new OrderRowModel(14, CookieType.Super, Brand.Cuddlies, "Supplier C", new DateTime(2022, 01, 05))
        };

        return new PlaceOrderModel("Birkan", quoteRows, orderRows);
    }
}
