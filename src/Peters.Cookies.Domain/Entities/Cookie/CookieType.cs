namespace Peters.Cookies.Domain.Entities;

[JsonConverter(typeof(StringEnumConverter))]
public enum CookieType
{
    Gewoon,     // This means Regular in Dutch
    Suikervrij, // This means Sugar Free in Dutch
    Super,
    Regular,
    SugarFree
}
