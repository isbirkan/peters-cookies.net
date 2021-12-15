namespace Peters.Cookies.Api.Models.Order;

    public class OrderReceiptModel
    {
    public string TotalPricePresentation { get; }

    public OrderReceiptModel(string totalPricePresentation)
    {
        TotalPricePresentation = totalPricePresentation;
    }
}
