using AutoMapper;
using CLOUPARD.BLL.Interfaces;
using CLOUPARD.Domain.Constants;
using CLOUPARD.Domain.Enum;
using CLOUPARD.Web.Models.Index;
using CLOUPARD.Web.Models.Product;
using CLOUPARD.Web.Models.Shared;
using CLOUPARD.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLOUPARD.Web.Services.Implementations;

public class IndexPageService : IIndexPageService
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public IndexPageService(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<IndexPageViewModel> GetIndexPageViewModel(int? pageNumber, string? search, SortState? sortBy)
    {
        int pageSize = Constants.PRODUCTS_PER_PAGE;
        int page = pageNumber ?? 1;

        var indexPageViewModel = new IndexPageViewModel();
        var products = await _productService.GetAllAsync(search, sortBy);

        if(products != null)
        {
            var list = products.Skip((page - 1) * pageSize).Take(pageSize);
            indexPageViewModel.Products = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            indexPageViewModel.Pagination = new Pagination(products.Count(), page, pageSize);
        }

        indexPageViewModel.Search = search;
        indexPageViewModel.SortState = sortBy;
        indexPageViewModel.SortStates = GetSortStates();

        return indexPageViewModel;
    }

    private IEnumerable<SelectListItem> GetSortStates()
    {
        var sortStates = new List<SelectListItem>()
        {
            new SelectListItem() { Value = null, Text = "Default", Selected = true },
            new SelectListItem() { Value = SortState.NameAsc.ToString(), Text = SortState.NameAsc.ToString(), Selected = false },
            new SelectListItem() { Value = SortState.NameDesc.ToString(), Text = SortState.NameDesc.ToString(), Selected = false },
            new SelectListItem() { Value = SortState.IdAsc.ToString(), Text = SortState.IdAsc.ToString(), Selected = false },
            new SelectListItem() { Value = SortState.IdDesc.ToString(), Text = SortState.IdDesc.ToString(), Selected = false },
        };

        return sortStates;
    }
}
