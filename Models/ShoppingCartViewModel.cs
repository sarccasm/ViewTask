using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewTask.Models;

public class ShoppingCartViewModel
{
    [Required, StringLength(100), Display(Name = "Input your fullname:")]
    public string FullName { get; set; } = string.Empty;

    [Required, StringLength(250), Display(Name = "Input your address:")]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string Supermarket { get; set; } = string.Empty;

    [Required, DataType(DataType.Date)]
    public DateTime? ShippingDate { get; set; }

    [MinLength(1, ErrorMessage = "Select at least one product.")]
    public string[] Products { get; set; } = [];

    [BindNever]
    public List<SelectListItem> Supermarkets { get; set; } = [];
    [BindNever]
    public List<SelectListItem> AvailableProducts { get; set; } = [];
    [BindNever]
    public List<DateTime> ShippingDates { get; set; } = [];
}
