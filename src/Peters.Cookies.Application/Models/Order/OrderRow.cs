using System.ComponentModel.DataAnnotations;
using Peters.Cookies.Domain.Entities;

namespace Peters.Cookies.Application.Models.Order;

public class OrderRow
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

    public OrderRow(
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
