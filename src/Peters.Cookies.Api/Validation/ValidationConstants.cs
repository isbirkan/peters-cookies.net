namespace Peters.Cookies.Api.Validation;

public static class ValidationConstants
{
    public const string NameMissingError = "You must provide a name!";
    public const string DateMissingError = "You must provide a date for your pickup!";
    public const string DateNotDeliverableError = "The pickup day must not be a Sunday, a Public Holiday and in the future!";
    public const string OrderMissingError = "You must provide at least one order!";
    public const string OrderAmountMissingError = "You must provide the amount of the order!";
    public const string OrderTypeMissingError = "You must provide the type of the order!";
}
