using Peters.Cookies.Api.Models.Quote;
using Peters.Cookies.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace Peters.Cookies.Api.Models.Examples;

public class GenerateQuotesModelExample : IExamplesProvider<GenerateQuotesModel>
{
    public GenerateQuotesModel GetExamples()
    {
        var orderRows = new List<OrderRowModel>
            {
                new OrderRowModel(8, CookieType.Regular),
                new OrderRowModel(3, CookieType.SugarFree),
                new OrderRowModel(14, CookieType.Super)
            };

        return new GenerateQuotesModel("Birkan", new DateTime(2022, 01, 05), orderRows);
    }
}
