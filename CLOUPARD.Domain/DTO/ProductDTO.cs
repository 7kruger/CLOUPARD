using System.ComponentModel.DataAnnotations;

namespace CLOUPARD.Domain.DTO;

public class ProductDTO : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
}
