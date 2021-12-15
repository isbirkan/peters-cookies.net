namespace Peters.Cookies.Domain.Entities;

[JsonConverter(typeof(StringEnumConverter))]
public enum Brand
{
    Stroopie,
    Cuddlies
}
