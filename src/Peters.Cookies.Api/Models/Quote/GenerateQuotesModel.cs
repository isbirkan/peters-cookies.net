using System.ComponentModel.DataAnnotations;
using Peters.Cookies.Api.Validation;

namespace Peters.Cookies.Api.Models.Quote;

public class GenerateQuotesModel
{
    [Required(ErrorMessage = ValidationConstants.NameMissingError)]
    public string Name { get; private set; }

    [Required(ErrorMessage = ValidationConstants.DateMissingError)]
    [DateIsDeliverable(ErrorMessage = ValidationConstants.DateNotDeliverableError)]
    public DateTime WishDate { get; private set; }

    [ListHasElements(ErrorMessage = ValidationConstants.OrderMissingError)]
    public IReadOnlyCollection<OrderRowModel> OrderRows { get; private set; }

    public GenerateQuotesModel(
        string name, 
        DateTime wishDate, 
        IReadOnlyCollection<OrderRowModel> orderRows)
    {
        Name = name;
        WishDate = wishDate;
        OrderRows = orderRows;
    }
}
