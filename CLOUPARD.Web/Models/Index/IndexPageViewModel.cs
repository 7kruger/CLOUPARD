using CLOUPARD.Domain.Enum;
using CLOUPARD.Web.Models.Product;
using CLOUPARD.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLOUPARD.Web.Models.Index;

public class IndexPageViewModel
{
    public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    public string? Search { get; set; }
    public IEnumerable<SelectListItem> SortStates { get; set; }
    public SortState? SortState { get; set; }
    public Pagination Pagination { get; set; }
}
