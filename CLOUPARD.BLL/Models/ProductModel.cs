using CLOUPARD.Domain;

namespace CLOUPARD.BLL.Models;

public class ProductModel : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}
