using System.ComponentModel.DataAnnotations;
using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Api.Models.Order;

public class OrderRowModel
{
    [Required]
    public int Amount { get; }

    [Required]
    public CookieType Type { get; }

    [Required]
    public Brand Brand { get; }

    [Required]
    public string SupplierName { get; }

    [Required]
    public DateTime WishDate { get; }

    public OrderRowModel(
        int amount, 
        CookieType type, 
        Brand brand, 
        string supplierName, 
        DateTime wishDate)
    {
        Amount = amount;
        Type = type;
        Brand = brand;
        SupplierName = supplierName;
        WishDate = wishDate;
    }
}
