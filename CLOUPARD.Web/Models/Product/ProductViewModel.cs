using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CLOUPARD.Web.Models.Product;

public class ProductViewModel
{
    [HiddenInput(DisplayValue = false)]
    [Required(ErrorMessage = "Id field is required")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name field is required")]
    public string Name { get; set; }
    public string? Description { get; set; }
}
