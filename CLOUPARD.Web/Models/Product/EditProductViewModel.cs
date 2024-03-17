using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CLOUPARD.Web.Models.Product;

public class EditProductViewModel
{
    [HiddenInput(DisplayValue = false)]
    [Required(ErrorMessage = "Id field is required")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name field is required")]
    public string Name { get; set; }
    public string? Description { get; set; }
}
